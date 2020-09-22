using org.rosenbohm.csharp.CADdy;
using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kbg.NppPluginNET;

namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    public partial class frmTransformCoord : Form
    {
        /// <summary>Sprachdatei</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        private INotepadPPGateway notepad;
        /// <summary>der Binding-Source zum anzeigen</summary>
        private BindingSource displayTransformPoints;
        /// <summary>die Transformation</summary>
        private ClassTransformation transformation;
        /// <summary>Textboxenwerte Setzen</summary>
        /// <param name="fromthis"></param>
        public void setFromSetting(ref Settings fromthis, ref INotepadPPGateway notepad)
        {
            settings = fromthis;
            this.notepad = notepad;
        }

        /// <summary>Konstruktor</summary>
        /// <param name="language"></param>
        /// <param name="points"></param>
        public frmTransformCoord(ref ClassLanguage language)
        {
            this.language = language;
            this.displayTransformPoints = new BindingSource();
            InitializeComponent();
            setLanguage();
            dgvTransformation.DataSource = displayTransformPoints;
            dgvTransformation.AutoGenerateColumns = false;
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmTransformCoord_Title");
            btnCalcTransform.Text = language.getLanguageText("frmTransformCoord_btnCalcTransform");
            btnClose.Text = language.getLanguageText("frmTransformCoord_btnClose");
            btnMakeTransform.Text = language.getLanguageText("frmTransformCoord_btnMakeTransform");
            btnChangeSrcDest.Text = language.getLanguageText("frmTransformCoord_btnChangeSrcDest");
            lblSrc.Text = language.getLanguageText("frmTransformCoord_lblSrc");
            lblDest.Text = language.getLanguageText("frmTransformCoord_lblDest");
            lblSigmaXY.Text = language.getLanguageText("frmTransformCoord_lblSigmaXY");
            lblSigmaZ.Text = language.getLanguageText("frmTransformCoord_lblSigmaZ");
            pointName.HeaderText = language.getLanguageText("frmTransformCoord_ColPNR");
            SrcRW.HeaderText = language.getLanguageText("frmTransformCoord_ColSrcRW");
            SrcHW.HeaderText = language.getLanguageText("frmTransformCoord_ColSrcHW");
            SrcZ.HeaderText = language.getLanguageText("frmTransformCoord_ColSrcZ");
            DstRW.HeaderText = language.getLanguageText("frmTransformCoord_ColDstRW");
            DstHW.HeaderText = language.getLanguageText("frmTransformCoord_ColDstHW");
            DstZ.HeaderText = language.getLanguageText("frmTransformCoord_ColDstZ");
            deltaRW.HeaderText = language.getLanguageText("frmTransformCoord_ColdeltaRW");
            deltaHW.HeaderText = language.getLanguageText("frmTransformCoord_ColdeltaHW");
            deltaZ.HeaderText = language.getLanguageText("frmTransformCoord_ColdeltaZ");
            usePoint.HeaderText = language.getLanguageText("frmTransformCoord_ColusePoint");
            useZ.HeaderText = language.getLanguageText("frmTransformCoord_ColuseZ");
            cbNewPointsNewTab.Text = language.getLanguageText("frmTransformCoord_cbNewPointsNewTab");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            cbListSrc.Items.Clear();
            cbListDest.Items.Clear();
            List<String> fileNames = ClassNPPTools.getOpenFileNames();

            if ((fileNames != null) && (fileNames.Count > 0))
            {
                if (fileNames.Count > 1)
                {
                    if (fileNames[fileNames.Count - 1].ToLower().Equals("new 1"))
                        fileNames.RemoveAt(fileNames.Count - 1);
                }
                cbListSrc.Items.AddRange(fileNames.ToArray());
                cbListDest.Items.AddRange(fileNames.ToArray());
            }
            if ((fileNames.Count == 2) && (ClassStringTools.IsNullOrWhiteSpace(cbListSrc.Text)) && ClassStringTools.IsNullOrWhiteSpace(cbListDest.Text))
            {
                cbListSrc.SelectedIndex = 0;
                cbListDest.SelectedIndex = 1;
            }
            else
            {
                if ((!ClassStringTools.IsNullOrWhiteSpace(cbListSrc.Text)) && (!fileNames.Contains(cbListSrc.Text)))
                {
                    cbListSrc.Text = "";
                    resetTransform();
                }
                if ((!ClassStringTools.IsNullOrWhiteSpace(cbListDest.Text)) && (!fileNames.Contains(cbListDest.Text)))
                {
                    cbListDest.Text = "";
                    resetTransform();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            displayTransformPoints.Clear();
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, this.Handle);
        }
        /// <summary>Mach mich zu</summary>
        public void closeMe()
        {
            displayTransformPoints.Clear();
            Win32.SendMessage(PluginBase.nppData._nppHandle, 2055u, 0, base.Handle);
        }

        /// <summary>Setzte die Mindestbreite</summary>
        public void setMinWidth()
        {
            int mw = 870 / FontHeight;

        }

        private void btnCalcTransform_Click(object sender, EventArgs e)
        {
            if ((displayTransformPoints.Count > 0) && (transformation != null))
            {
                //foreach (ClassTransformdisplayPoint transp in displayTransformPoints)
                //  transformation.setUsing(transp);
            }
            if (transformation == null)
            {
                String cuFile = ClassNPPTools.getCurrentFile();
                ClassCADdyPunkte file1 = new ClassCADdyPunkte(ref language);
                ClassNPPTools.switchToFile(cbListSrc.Text);
                file1.getPointsFromCurrentCADdy(settings);
                ClassCADdyPunkte file2 = new ClassCADdyPunkte(ref language);
                ClassNPPTools.switchToFile(cbListDest.Text);
                file2.getPointsFromCurrentCADdy(settings);
                ClassNPPTools.switchToFile(cuFile);
                transformation = new ClassTransformation(file1, file2, ref language, 3, 4);
            }
            else
            {
                transformation.calcResiduen();
            }
            if (transformation != null)
            {
                displayTransformPoints.Clear();
                foreach (ClassTransformPointPair matchPoint in transformation.MatchPoints)
                    displayTransformPoints.Add(new ClassTransformdisplayPoint(matchPoint, 3, 4));
                tbSigmaXY.Text = ClassConverters.ToString(transformation.SigmaXY, ",", "", 3, true);
                tbSigmaZ.Text = ClassConverters.ToString(transformation.SigmaZ, ",", "", 3, true);
                if (transformation.SigmaXY < 0.1)
                    tbSigmaXY.BackColor = Color.LightGreen;
                else if (Double.IsNaN(transformation.SigmaXY))
                    tbSigmaXY.BackColor = Color.LightGray;
                else
                    tbSigmaXY.BackColor = Color.Orange;
                if (transformation.SigmaZ < 0.1)
                    tbSigmaZ.BackColor = Color.LightGreen;
                else if (Double.IsNaN(transformation.SigmaZ))
                    tbSigmaZ.BackColor = Color.LightGray;
                else
                    tbSigmaZ.BackColor = Color.Orange;
                btnMakeTransform.Enabled = true;
            }
        }

        private void btnMakeTransform_Click(object sender, EventArgs e)
        {
            if (transformation != null)
            {
                transformation.calcTransformation();
                if (cbNewPointsNewTab.Checked)
                {
                    String myNewFile = System.IO.Path.GetDirectoryName(cbListSrc.Text) + @"\" + System.IO.Path.GetFileNameWithoutExtension(cbListSrc.Text) + "_WORLD" + System.IO.Path.GetExtension(cbListSrc.Text);
                    if (ClassNPPTools.getOpenFileNames().Contains(myNewFile))
                        ClassNPPTools.closefile(myNewFile, true);                        
                    if (System.IO.File.Exists(myNewFile)) System.IO.File.Delete(myNewFile);
                    /*System.IO.File.CreateText(myNewFile);
                    Win32.SendMessage(PluginBase.nppData._nppHandle, (int)NppMsg.NPPM_DOOPEN, 0, myNewFile);
                    */
                    ClassNPPTools.newfile(myNewFile);
                    ClassCADdyPunkte file2 = new ClassCADdyPunkte(ref language);
                    ClassNPPTools.switchToFile(myNewFile);
                    foreach (ClassCADdyPunkt newPoint in transformation.newPoints)
                        file2.Punkte.Add(newPoint);
                    file2.formatCurrentToCADdy(settings);
                    file2.clear();
                    file2 = null;
                }
                else
                {
                    ClassCADdyPunkte file2 = new ClassCADdyPunkte(ref language);
                    ClassNPPTools.switchToFile(cbListDest.Text);
                    file2.getPointsFromCurrentCADdy(settings);
                    foreach (ClassCADdyPunkt newPoint in transformation.newPoints)
                        file2.Punkte.Add(newPoint);
                    file2.formatCurrentToCADdy(settings);
                    file2.clear();
                    file2 = null;
                }
            }
        }

        private void cbListSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetTransform();
        }

        public void resetTransform()
        {
            if (transformation != null)
            {
                transformation.clearForDestroy();
                transformation = null;
            }
            displayTransformPoints.Clear();
            tbSigmaXY.BackColor = Color.LightGray;
            tbSigmaXY.Text = "";
            tbSigmaZ.BackColor = Color.LightGray;
            tbSigmaZ.Text = "";
            btnMakeTransform.Enabled = false;
        }
        /// <summary>Schnelles Quelle Ziel tauschen</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeSrcDest_Click(object sender, EventArgs e)
        {
            displayTransformPoints.Clear();
            String temp = cbListSrc.Text;
            cbListSrc.Text = cbListDest.Text;
            cbListDest.Text = temp;
            transformation = null;
            //btnCalcTransform_Click(sender, e);
        }
    }
}
