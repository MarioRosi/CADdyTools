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
    public partial class frmTranslateCoord : Form
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
        public frmTranslateCoord(ref ClassLanguage language, ref ClassCADdyPunkte points)
        {
            this.language = language;
            this.points = points;
            InitializeComponent();
            setLanguage();
        }

        /// <summary>Sprachtexte setzten</summary>
        private void setLanguage()
        {
            Text = language.getLanguageText("frmTranslateCoord_Title");
            tabControl1.Text = language.getLanguageText("frmTranslateCoord_TAB");
            lblTranslRW.Text = language.getLanguageText("frmTranslateCoord_RW");
            lblTranslHW.Text = language.getLanguageText("frmTranslateCoord_HW");
            lblTranslHO.Text = language.getLanguageText("frmTranslateCoord_HO");
            btnMakeTransl.Text = language.getLanguageText("frmTranslateCoord_BTN_MakeIt");
        }


        private void btnPktRotation_Click(object sender, EventArgs e)
        {
            if ((points != null) && (points.HasPunkte))
            {
                String trw = tbTranslRW.Text;
                String thw = tbTranslHW.Text;
                String tho = tbTranslHO.Text;
                Double dtRW;
                Double dtHW;
                Double dtHO;
                ClassConverters.StringToDouble(tbTranslRW.Text, out dtRW);
                ClassConverters.StringToDouble(tbTranslHW.Text, out dtHW);
                ClassConverters.StringToDouble(tbTranslHO.Text, out dtHO);
                if (points.translateCoords(dtRW, dtHW, dtHO))
                    points.formatCurrentToCADdy(settings);
            }
        }

        public void readCuDatas()
        {
            if (points.HasPunkte)
            {
                btnMakeTransl.Enabled = true;
            }
            else
            {
                btnMakeTransl.Enabled = false;
            }
        }
    }
}
