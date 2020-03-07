using org.rosenbohm.csharp.CADdy;
using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    public partial class frmRotateCoord : Form
    {
        /// <summary>Sprachdatei</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        private INotepadPPGateway notepad;
        /// <summary>die aktuellen Messdaten</summary>
        private ClassCADdyPunkte points;
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
        public frmRotateCoord(ref ClassLanguage language, ref ClassCADdyPunkte points)
        {
            this.language = language;
            this.points = points;
            InitializeComponent();
            setLanguage();
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmRotateCoord_Title");
            tabControl1.Text = language.getLanguageText("frmRotateCoord_TAB");
            lblRotPoint.Text = language.getLanguageText("frmRotateCoord_RotPoint");
            lblrPointZTo0.Text = language.getLanguageText("frmRotateCoord_RotPointZTo0");
            chbZTo0.Text = language.getLanguageText("frmRotateCoord_CBRotPointZTo0");
            lblDirPoint.Text = language.getLanguageText("frmRotateCoord_DirPoint");
            lblDirection.Text = language.getLanguageText("frmRotateCoord_Direction");
            toolTip1.SetToolTip(tbDirection, language.getLanguageText("frmRotateCoord_DirPointTolTip"));
            //toolTip1.SetToolTip(cbRotPoint, language.getLanguageText("frmChangeID_Tooltip_Pointnumber"));
            btnPktCalcRotation.Text = language.getLanguageText("frmRotateCoord_BTN_MakeIt");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            if ((points != null) && (points.HasPunkte))
            {
                List<String> pointnumbers = new List<String>();
                cbRotPoint.Enabled = true;
                cbDirPoint.Enabled = true;
                tbDirection.Enabled = true;
                chbZTo0.Enabled = true;
                pointnumbers = this.points.getDestinctPointnumbers();
                btnPktCalcRotation.Enabled = true;
                cbRotPoint.Items.Clear();
                cbRotPoint.Items.AddRange(pointnumbers.ToArray());
                cbDirPoint.Items.Clear();
                cbDirPoint.Items.AddRange(pointnumbers.ToArray());
                tbDirection.Text = "0.0";
            }
            else
            {
                cbRotPoint.Enabled = false;
                cbDirPoint.Enabled = false;
                tbDirection.Enabled = false;
                chbZTo0.Enabled = false;
                btnPktCalcRotation.Enabled = false;
            }
        }

        private void btnPktRotation_Click(object sender, EventArgs e)
        {
            if ((points != null) && (points.HasPunkte))
            {
                String rPnr = cbRotPoint.Text;
                String dPnr = cbDirPoint.Text;
                Double direction;
                if (ClassConverters.StringToDouble(tbDirection.Text, out direction))
                {
                    if (rPnr.CompareTo(dPnr) != 0)
                    {
                        if (points.rotateCoords(rPnr, dPnr, direction, chbZTo0.Checked))
                            points.formatCurrentToCADdy(settings);
                        else
                            points.getPointsFromCurrentCADdy(settings);
                    }
                    else
                        MessageBox.Show(language.getLanguageText("MSG_BOX_frmRotateCoord_identPoint"));
                }
                else
                    MessageBox.Show(language.getLanguageText("MSG_BOX_frmRotateCoord_notdirection"));
            }
        }
    }
}
