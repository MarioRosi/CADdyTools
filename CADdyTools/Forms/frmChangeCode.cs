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
    public partial class frmChangeCode : Form
    {
        /// <summary>Sprachdatei</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        private INotepadPPGateway notepad;

        /// <summary>Zugriff auf die Punkte</summary>
        private ClassCADdyPunkte points;
        /// <summary>Zugriff auf die Messdaten</summary>
        private ClassCADdyMessdaten stpks;

        /// <summary>Textboxenwerte Setzen</summary>
        /// <param name="fromthis"></param>
        /// <param name="notepad"></param>
        public void setFromSetting(ref Settings fromthis, ref INotepadPPGateway notepad)
        {
            settings = fromthis;
            this.notepad = notepad;
        }

        /// <summary>Konstruktor</summary>
        /// <param name="language"></param>
        /// <param name="points"></param>
        /// <param name="stpks"></param>
        public frmChangeCode(ref ClassLanguage language, ref ClassCADdyPunkte points, ref ClassCADdyMessdaten stpks)
        {
            this.language = language;
            this.points = points;
            this.stpks = stpks;
            InitializeComponent();
            setLanguage();
        }

        private void setLanguage()
        {
            this.Text = language.getLanguageText("frmChangeCode_Title");

            tabPChangePKTCode.Text = language.getLanguageText("frmChangeCode_TAB_Pointnumber");
            lblPunktnummer.Text = language.getLanguageText("frmChangeCode_PNR_Pointnmber");
            lblPKTCodeNeu.Text = language.getLanguageText("frmChangeCode_PNR_CodeNew");
            toolTip1.SetToolTip(cbPunktnummer, language.getLanguageText("frmChangeCode_PNR_Tooltip_Pointnumber"));
            btnPktChangeCode.Text = language.getLanguageText("frmChangeCode_BTN_SetCode");

            tabPCode.Text = language.getLanguageText("frmChangeCode_TAB_Code");
            lblCodeOld.Text = language.getLanguageText("frmChangeCode_COD_CodeOld");
            lblCodeNew.Text = language.getLanguageText("frmChangeCode_COD_CodeNew");
            toolTip1.SetToolTip(cbCodePKTNeu, language.getLanguageText("frmChangeCode_COD_Tooltip_CodeOld"));
            btnChangeCode.Text = language.getLanguageText("frmChangeCode_BTN_SetCode");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            List<String> pointnumbers = new List<String>();
            List<String> codes = new List<String>();
            if (points.HasPunkte)
            {
                pointnumbers = points.getDestinctPointnumbers();
                codes = points.getDestinctCodes();
                btnChangeCode.Enabled = true;
                btnPktChangeCode.Enabled = true;
            }
            else if (stpks.HasMessdaten)
            {
                pointnumbers = stpks.getDestinctPointnumbers();
                codes = stpks.getDestinctCodes();
                btnChangeCode.Enabled = true;
                btnPktChangeCode.Enabled = true;
            }
            else
            {
                btnChangeCode.Enabled = false;
                btnPktChangeCode.Enabled = false;
            }
            cbPunktnummer.Items.Clear();
            cbPunktnummer.Items.AddRange(pointnumbers.ToArray());
            cbCodeNew.Items.Clear();
            cbCodeNew.Items.AddRange(codes.ToArray());
            cbCodeOld.Items.Clear();
            cbCodeOld.Items.AddRange(codes.ToArray());
            cbCodePKTNeu.Items.Clear();
            cbCodePKTNeu.Items.AddRange(codes.ToArray());
        }

        private void btnPktChangeCode_Click(object sender, EventArgs e)
        {
            if (points.HasPunkte)
            {

                if (points.setPointNumberToCode(cbPunktnummer.Text, cbCodePKTNeu.Text))
                    points.formatCurrentToCADdy(settings);

            }
            else if (stpks.HasMessdaten)
            {

                stpks.getMeasuresFromCurrentCADdy(settings);
                if (stpks.setPointNumberToCode(cbPunktnummer.Text, cbCodePKTNeu.Text))
                    stpks.formatCurrentToCADdy(settings);

            }
        }

        private void btnChangeCode_Click(object sender, EventArgs e)
        {
            if (points.HasPunkte)
            {
                if (points.setOldCodeToNewCode(cbCodeOld.Text, cbCodeOld.Text))
                    points.formatCurrentToCADdy(settings);

            }
            else if (stpks.HasMessdaten)
            {
                if (stpks.setOldCodeToNewCode(cbCodeOld.Text, cbCodeOld.Text))
                    stpks.formatCurrentToCADdy(settings);
            }
        }
    }
}
