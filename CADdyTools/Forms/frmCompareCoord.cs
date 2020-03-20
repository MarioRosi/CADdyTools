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
    public partial class frmCompareCoord : Form
    {
        /// <summary>Sprachdatei</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        private INotepadPPGateway notepad;
        /// <summary>der Binding-Source zum anzeigen</summary>
        private BindingSource displayComparePoints;
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
        public frmCompareCoord(ref ClassLanguage language)
        {
            this.language = language;
            this.displayComparePoints = new BindingSource();
            InitializeComponent();
            setLanguage();
            dgvCompare.DataSource = displayComparePoints;
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmCompareCoord_Title");
            btnMakeCompare.Text = language.getLanguageText("frmCompareCoord_btnMakeCompare");
            btnClose.Text = language.getLanguageText("frmCompareCoord_btnClose");
            btnChangeEpochen.Text = language.getLanguageText("frmCompareCoord_btnSwapEpoch");
            lblEpoche1.Text = language.getLanguageText("frmCompareCoord_lblEpoche1");
            lblEpoche2.Text = language.getLanguageText("frmCompareCoord_lblEpoche2");
            pointName.HeaderText = language.getLanguageText("frmCompareCoord_ColPNR");
            ep1RW.HeaderText = language.getLanguageText("frmCompareCoord_Colep1RW");
            ep1HW.HeaderText = language.getLanguageText("frmCompareCoord_Colep1HW");
            ep1Z.HeaderText = language.getLanguageText("frmCompareCoord_Colep1Z");
            ep2RW.HeaderText = language.getLanguageText("frmCompareCoord_Colep2RW");
            ep2HW.HeaderText = language.getLanguageText("frmCompareCoord_Colep2HW");
            ep2Z.HeaderText = language.getLanguageText("frmCompareCoord_Colep2Z");
            deltaRW.HeaderText = language.getLanguageText("frmCompareCoord_ColdeltaRW");
            deltaHW.HeaderText = language.getLanguageText("frmCompareCoord_ColdeltaHW");
            deltaZ.HeaderText = language.getLanguageText("frmCompareCoord_ColdeltaZ");
            delta2D.HeaderText = language.getLanguageText("frmCompareCoord_Coldelta2D");
            delta3D.HeaderText = language.getLanguageText("frmCompareCoord_Coldelta3D");
            deltaRiwi.HeaderText = language.getLanguageText("frmCompareCoord_ColdeltaRiwi");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            cbList1.Items.Clear();
            cbList2.Items.Clear();
            List<String> fileNames = ClassNPPTools.getOpenFileNames();

            if ((fileNames != null) && (fileNames.Count > 0))
            {
                if (fileNames.Count > 1)
                {
                    if (fileNames[fileNames.Count - 1].ToLower().Equals("new 1"))
                        fileNames.RemoveAt(fileNames.Count - 1);
                }
                cbList1.Items.AddRange(fileNames.ToArray());
                cbList2.Items.AddRange(fileNames.ToArray());
            }
            if (fileNames.Count == 2)
            {
                cbList1.SelectedIndex = 0;
                cbList2.SelectedIndex = 1;
                btnMakeCompare_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            displayComparePoints.Clear();
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, this.Handle);
        }

        private void btnMakeCompare_Click(object sender, EventArgs e)
        {
            String cuFile = ClassNPPTools.getCurrentFile();
            ClassCADdyPunkte file1 = new ClassCADdyPunkte(ref language);
            ClassNPPTools.switchToFile(cbList1.Text);
            file1.getPointsFromCurrentCADdy(settings);
            displayComparePoints.Clear();
            ClassCADdyPunkte file2 = new ClassCADdyPunkte(ref language);
            ClassNPPTools.switchToFile(cbList2.Text);
            file2.getPointsFromCurrentCADdy(settings);
            ClassNPPTools.switchToFile(cuFile);
            file1.sortBy(enPointColumn.colPointnumber);
            file2.sortBy(enPointColumn.colPointnumber);

            foreach (ClassCADdyPunkt point1 in file1.Punkte)
            {
                ClassCADdyPunkt point2 = file2.getPointByName(point1.Punktnummer);
                if (point2 != null)
                {
                    displayComparePoints.Add(new ClassCADdyPointCompare(point1, point2, 3, 4));
                }
            }
            file1.clear();
            file1 = null;
            file2.clear();
            file2 = null;
            this.dgvCompare.Refresh();
        }

        private void btnChangeEpochen_Click(object sender, EventArgs e)
        {
            String fn1 = cbList1.Text;
            cbList1.Text = cbList2.Text;
            cbList2.Text = fn1;
            btnMakeCompare_Click(null, null);
        }
    }
}
