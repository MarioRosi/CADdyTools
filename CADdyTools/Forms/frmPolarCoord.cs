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
    public partial class frmPolarCoord : Form
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
        public frmPolarCoord(ref ClassLanguage language, ref ClassCADdyPunkte points)
        {
            this.language = language;
            this.points = points;
            InitializeComponent();
            setLanguage();
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmPolarCoord_Title");
            tabControl1.Text = language.getLanguageText("frmPolarCoord_TAB");
            lblStartpoint.Text = language.getLanguageText("frmPolarCoord_Startpoint");
            lblEndpoint.Text = language.getLanguageText("frmPolarCoord_Endpoint");
            btnMakeCalc.Text = language.getLanguageText("frmPolarCoord_MakeCalc");

            lblRiwi.Text = language.getLanguageText("frmPolarCoord_Riwi");
            lblLength.Text = language.getLanguageText("frmPolarCoord_Length");
            lbldeltaH.Text = language.getLanguageText("frmPolarCoord_DeltaElev");
            lblDistance.Text = language.getLanguageText("frmPolarCoord_Distance");
            lblClination.Text = language.getLanguageText("frmPolarCoord_Clination");
        }

        /// <summary>Die aktuellen Punktnummern und Codes auslesen</summary>
        public void readCuDatas()
        {
            List<String> pointnumbers = new List<String>();
            if (points.HasPunkte)
            {
                pointnumbers = points.getDestinctPointnumbers();
                btnMakeCalc.Enabled = true;
                cbStartpoint.Enabled = true;
                cbEndpoint.Enabled = true;
            }
            else
            {
                btnMakeCalc.Enabled = false;
                cbStartpoint.Enabled = false;
                cbEndpoint.Enabled = false;
            }
            cbStartpoint.Items.Clear();
            cbStartpoint.Items.AddRange(pointnumbers.ToArray());
            cbEndpoint.Items.Clear();
            cbEndpoint.Items.AddRange(pointnumbers.ToArray());
            resetCalc();
        }


        private void btnMakeCalc_Click(object sender, EventArgs e)
        {
            if ((points != null) && (points.HasPunkte))
            {
                resetCalc();
                if (cbStartpoint.Text != cbEndpoint.Text)
                {
                    ClassCADdyPunkt first = points.getPointByName(cbStartpoint.Text);
                    ClassCADdyPunkt second = points.getPointByName(cbEndpoint.Text);
                    if ((first != null) & (second != null))
                    {
                        ClassCADdyPunkt delta = second - first;
                        tbRiwi.Text = ClassConverters.ToString(delta.gonRiwi(), ".", "", 4, false);
                        tbLength.Text = ClassConverters.ToString(delta.length(), ".", "", 3, false);
                        tbDeltaH.Text = ClassConverters.ToString(delta.Hoehe, ".", "", 3, false);
                        tbDistance.Text = ClassConverters.ToString(delta.distance(), ".", "", 3, false);
                        tbClination.Text = ClassConverters.ToString(delta.clination(), ".", "", 1, false);
                    }
                }
            }
        }

        private void resetCalc()
        {
            tbRiwi.Text = "";
            tbLength.Text = "";
            tbDeltaH.Text = "";
            tbLength.Text = "";
            tbClination.Text = "";            
        }
    }
}
