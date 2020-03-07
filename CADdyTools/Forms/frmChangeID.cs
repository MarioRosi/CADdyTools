using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.CADdy;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    public partial class frmChangeID : Form
    {
        /// <summary>Sprachdatei</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        private INotepadPPGateway notepad;
        /// <summary>die aktuellen Messdaten</summary>
        private ClassCADdyMessdaten cuMeasures;
        /// <summary>Textboxenwerte Setzen</summary>
        /// <param name="fromthis"></param>
        public void setFromSetting(ref Settings fromthis, ref INotepadPPGateway notepad)
        {
            settings = fromthis;
            this.notepad = notepad;            
        }

        /// <summary>Konstruktor</summary>
        /// <param name="language"></param>
        /// <param name="cuMeasures"></param>
        public frmChangeID(ref ClassLanguage language, ref ClassCADdyMessdaten cuMeasures)
        {
            this.language = language;
            this.cuMeasures = cuMeasures;
            InitializeComponent();
            setLanguage();
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmChangeID_Title");
            tabControl1.Text = language.getLanguageText("frmChangeID_TAB_IR");
            lblPointnumber.Text = language.getLanguageText("frmChangeID_TIR_Pointnumber");
            lblPointIdNew.Text = language.getLanguageText("frmChangeID_TIR_IDnew");
            toolTip1.SetToolTip(cbPunktnummer, language.getLanguageText("frmChangeID_Tooltip_Pointnumber"));
            btnPktChangeID.Text = language.getLanguageText("frmChangeID_BTN_MakeIt");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            if ((cuMeasures != null) && (cuMeasures.HasMessdaten))
            {
                List<String> pointnumbers = new List<String>();
                cbPunktnummer.Enabled = true;
                tbNewId.Enabled = true;
                pointnumbers = cuMeasures.getDestinctPointnumbers();
                btnPktChangeID.Enabled = true;
                cbPunktnummer.Items.Clear();
                cbPunktnummer.Items.AddRange(pointnumbers.ToArray());
            }
            else
            {
                cbPunktnummer.Enabled = false;
                tbNewId.Enabled = false;
                btnPktChangeID.Enabled = false;
            }
        }

        private void btnPktChangeID_Click(object sender, EventArgs e)
        {
            if ((cuMeasures != null) && (cuMeasures.HasMessdaten))
            {
                cuMeasures.getMeasuresFromCurrentCADdy(settings);
                Double newId = Double.NaN;
                if (ClassConverters.StringToDouble(tbNewId.Text, out newId))
                {
                    if (cuMeasures.setPointNumberToIDe(cbPunktnummer.Text, newId))
                        cuMeasures.formatCurrentToCADdy(settings);
                }
            }
        }
    }
}
