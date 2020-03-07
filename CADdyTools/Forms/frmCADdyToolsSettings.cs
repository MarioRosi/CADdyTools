using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    public partial class frmCADdyToolsSettings : Form
    {
        /// <summary>Sprache</summary>
        private ClassLanguage language;
        /// <summary>Die Einstellungen</summary>
        private Settings settings;
        /// <summary>Konstruktor</summary>
        /// <param name="language"></param>
        public frmCADdyToolsSettings(ref ClassLanguage language)
        {
            this.language = language;
            InitializeComponent();
            setLanguage();
        }

        private void setLanguage()
        {
            Text = language.getLanguageText("frmSettings_Title");

            btnApplay.Text = language.getLanguageText("frmSettings_BTNOkay");
            btnSetDefault.Text = language.getLanguageText("frmSettings_BTNSetDefault");


            tabPAllg.Text = language.getLanguageText("frmSettings_TAB_General");
            gbPointnumber.Text = language.getLanguageText("frmSettings_Group_PointName");
            cb_PointnameToupper.Text = language.getLanguageText("frmSettings_PointName_Uppercase");

            gbTrenner.Text = language.getLanguageText("frmSettings_Delimiter");
            lblDelimiter.Text = language.getLanguageText("frmSettings_Delimiter");

            tabPCoord.Text = language.getLanguageText("frmSettings_TAB_Coord");
            gb_RW.Text = language.getLanguageText("frmSettings_Group_East");
            gb_HW.Text = language.getLanguageText("frmSettings_Group_North");
            gb_Elev.Text = language.getLanguageText("frmSettings_Group_Elev");
            gb_CoordCode.Text = language.getLanguageText("frmSettings_Group_C_Code");
            gbDescript.Text = language.getLanguageText("frmSettings_Group_C_Descript");

            tabPMessdaten.Text = language.getLanguageText("frmSettings_TAB_Measure");
            gbStandpunkt.Text = language.getLanguageText("frmSettings_Group_Position");
            gb_I.Text = language.getLanguageText("frmSettings_Group_P_InstrH");
            gb_STCode.Text = language.getLanguageText("frmSettings_Group_P_Code");
            gb_STDescr.Text = language.getLanguageText("frmSettings_Group_P_Descript");
            gbZielungen.Text = language.getLanguageText("frmSettings_Group_Target");
            gb_ZielHz.Text = language.getLanguageText("frmSettings_Group_T_Direction");
            gb_ZielV.Text = language.getLanguageText("frmSettings_Group_T_Zenith");
            gb_ZielS.Text = language.getLanguageText("frmSettings_Group_T_Distance");
            gb_ZielD.Text = language.getLanguageText("frmSettings_Group_T_Reflector");
            gb_ZielCode.Text = language.getLanguageText("frmSettings_Group_T_Code");
            gb_ZielDescr.Text = language.getLanguageText("frmSettings_Group_T_Descript");

            lblColum1.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum2.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum3.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum4.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum5.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum6.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum7.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum8.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum9.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum10.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum11.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum12.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum13.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum14.Text = language.getLanguageText("frmSettings_Label_Column");
            lblColum15.Text = language.getLanguageText("frmSettings_Label_Column");

            lblStart1.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart2.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart3.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart4.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart5.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart6.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart7.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart8.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart9.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart10.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart11.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart12.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart13.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart14.Text = language.getLanguageText("frmSettings_Label_Start");
            lblStart15.Text = language.getLanguageText("frmSettings_Label_Start");

            lblLength1.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength2.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength3.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength4.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength5.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength6.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength7.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength8.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength9.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength10.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength11.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength12.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength13.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength14.Text = language.getLanguageText("frmSettings_Label_Length");
            lblLength15.Text = language.getLanguageText("frmSettings_Label_Length");

            lblDecimal2.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal3.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal4.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal7.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal10.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal11.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal12.Text = language.getLanguageText("frmSettings_Label_Decimal");
            lblDecimal13.Text = language.getLanguageText("frmSettings_Label_Decimal");

        }

        /// <summary>Textboxenwerte Setzen</summary>
        /// <param name="fromthis"></param>
        public void setFromSetting(ref Settings fromthis)
        {
            settings = fromthis;
            reset();
        }

        /// <summary>Textwerte in die Settings übernehmen</summary>
        private void applaySettings()
        {
            Int16 temp;
            ClassConverters.StringToInt16(tb_PointNameStart.Text, out temp);
            settings.PointName_Start = temp;
            ClassConverters.StringToInt16(tb_PointNameLength.Text, out temp);
            settings.PointName_Length = temp;
            ClassConverters.StringToInt16(tb_PointNameColumn.Text, out temp);
            settings.PointName_Column = temp;

            settings.Decimalseperator = tbDecimalseperator.Text;

            settings.PointName_ToUpper = cb_PointnameToupper.Checked;

            ClassConverters.StringToInt16(tb_CoordRWStart.Text, out temp);
            settings.Koord_RW_E_Start = temp;
            ClassConverters.StringToInt16(tb_CoordRWLength.Text, out temp);
            settings.Koord_RW_E_Length = temp;
            ClassConverters.StringToInt16(tb_CoordRWDecimals.Text, out temp);
            settings.Koord_RW_E_Decimals = temp;
            ClassConverters.StringToInt16(tb_CoordRWColumn.Text, out temp);
            settings.Koord_RW_E_Column = temp;

            ClassConverters.StringToInt16(tb_CoordHWStart.Text, out temp);
            settings.Koord_HW_N_Start = temp;
            ClassConverters.StringToInt16(tb_CoordHWLength.Text, out temp);
            settings.Koord_HW_N_Length = temp;
            ClassConverters.StringToInt16(tb_CoordHWDecimals.Text, out temp);
            settings.Koord_HW_N_Decimals = temp;
            ClassConverters.StringToInt16(tb_CoordHWColumn.Text, out temp);
            settings.Koord_HW_N_Column = temp;

            ClassConverters.StringToInt16(tb_CoordElevStart.Text, out temp);
            settings.Koord_Elev_Start = temp;
            ClassConverters.StringToInt16(tb_CoordElevLength.Text, out temp);
            settings.Koord_Elev_Length = temp;
            ClassConverters.StringToInt16(tb_CoordElevDecimals.Text, out temp);
            settings.Koord_Elev_Decimals = temp;
            ClassConverters.StringToInt16(tb_CoordElevColumn.Text, out temp);
            settings.Koord_Elev_Column = temp;

            ClassConverters.StringToInt16(tb_CoordCodeStart.Text, out temp);
            settings.Koord_Code_Start = temp;
            ClassConverters.StringToInt16(tb_CoordCodeLength.Text, out temp);
            settings.Koord_Code_Length = temp;
            ClassConverters.StringToInt16(tb_CoordCodeColumn.Text, out temp);
            settings.Koord_Code_Column = temp;

            ClassConverters.StringToInt16(tb_CoordDescriptStart.Text, out temp);
            settings.Koord_Descript_Start = temp;
            ClassConverters.StringToInt16(tb_CoordDescriptLength.Text, out temp);
            settings.Koord_Descript_Length = temp;
            ClassConverters.StringToInt16(tb_CoordDescriptColumn.Text, out temp);
            settings.Koord_Descript_Column = temp;


            ClassConverters.StringToInt16(tb_Messd_I_Start.Text, out temp);
            settings.Messd_I_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_I_Length.Text, out temp);
            settings.Messd_I_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_I_Decimals.Text, out temp);
            settings.Messd_I_Decimals = temp;
            ClassConverters.StringToInt16(tb_Messd_I_Column.Text, out temp);
            settings.Messd_I_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_STPKCode_Start.Text, out temp);
            settings.Messd_STPKCode_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_STPKCode_Length.Text, out temp);
            settings.Messd_STPKCode_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_STPKCode_Column.Text, out temp);
            settings.Messd_STPKCode_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_STPKDescript_Start.Text, out temp);
            settings.Messd_STPKDescript_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_STPKDescript_Length.Text, out temp);
            settings.Messd_STPKDescript_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_STPKDescript_Column.Text, out temp);
            settings.Messd_STPKDescript_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_Hz_Start.Text, out temp);
            settings.Messd_Hz_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_Hz_Length.Text, out temp);
            settings.Messd_Hz_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_Hz_Decimals.Text, out temp);
            settings.Messd_Hz_Decimals = temp;
            ClassConverters.StringToInt16(tb_Messd_Hz_Column.Text, out temp);
            settings.Messd_Hz_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_V_Start.Text, out temp);
            settings.Messd_V_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_V_Length.Text, out temp);
            settings.Messd_V_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_V_Decimals.Text, out temp);
            settings.Messd_V_Decimals = temp;
            ClassConverters.StringToInt16(tb_Messd_V_Column.Text, out temp);
            settings.Messd_V_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_S_Start.Text, out temp);
            settings.Messd_S_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_S_Length.Text, out temp);
            settings.Messd_S_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_S_Decimals.Text, out temp);
            settings.Messd_S_Decimals = temp;
            ClassConverters.StringToInt16(tb_Messd_S_Column.Text, out temp);
            settings.Messd_S_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_D_Start.Text, out temp);
            settings.Messd_D_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_D_Length.Text, out temp);
            settings.Messd_D_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_D_Decimals.Text, out temp);
            settings.Messd_D_Decimals = temp;
            ClassConverters.StringToInt16(tb_Messd_D_Column.Text, out temp);
            settings.Messd_D_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_Code_Start.Text, out temp);
            settings.Messd_Code_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_Code_Length.Text, out temp);
            settings.Messd_Code_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_Code_Column.Text, out temp);
            settings.Messd_Code_Column = temp;

            ClassConverters.StringToInt16(tb_Messd_Descript_Start.Text, out temp);
            settings.Messd_Descript_Start = temp;
            ClassConverters.StringToInt16(tb_Messd_Descript_Length.Text, out temp);
            settings.Messd_Descript_Length = temp;
            ClassConverters.StringToInt16(tb_Messd_Descript_Column.Text, out temp);
            settings.Messd_Descript_Column = temp;

        }

        private void reset()
        {
            if (settings != null)
            {
                tb_PointNameStart.Text = ClassConverters.ToString(settings.PointName_Start, ",", "");
                tb_PointNameLength.Text = ClassConverters.ToString(settings.PointName_Length, ",", "");
                tb_PointNameColumn.Text = ClassConverters.ToString(settings.PointName_Column, ",", "");

                tbDecimalseperator.Text = settings.Decimalseperator;
                cb_PointnameToupper.Checked = settings.PointName_ToUpper;

                tb_CoordRWStart.Text = ClassConverters.ToString(settings.Koord_RW_E_Start, ",", "");
                tb_CoordRWLength.Text = ClassConverters.ToString(settings.Koord_RW_E_Length, ",", "");
                tb_CoordRWDecimals.Text = ClassConverters.ToString(settings.Koord_RW_E_Decimals, ",", "");
                tb_CoordRWColumn.Text = ClassConverters.ToString(settings.Koord_RW_E_Column, ",", "");

                tb_CoordHWStart.Text = ClassConverters.ToString(settings.Koord_HW_N_Start, ",", "");
                tb_CoordHWLength.Text = ClassConverters.ToString(settings.Koord_HW_N_Length, ",", "");
                tb_CoordHWDecimals.Text = ClassConverters.ToString(settings.Koord_HW_N_Decimals, ",", "");
                tb_CoordHWColumn.Text = ClassConverters.ToString(settings.Koord_HW_N_Column, ",", "");

                tb_CoordElevStart.Text = ClassConverters.ToString(settings.Koord_Elev_Start, ",", "");
                tb_CoordElevLength.Text = ClassConverters.ToString(settings.Koord_Elev_Length, ",", "");
                tb_CoordElevDecimals.Text = ClassConverters.ToString(settings.Koord_Elev_Decimals, ",", "");
                tb_CoordElevColumn.Text = ClassConverters.ToString(settings.Koord_Elev_Column, ",", "");

                tb_CoordCodeStart.Text = ClassConverters.ToString(settings.Koord_Code_Start, ",", "");
                tb_CoordCodeLength.Text = ClassConverters.ToString(settings.Koord_Code_Length, ",", "");
                tb_CoordCodeColumn.Text = ClassConverters.ToString(settings.Koord_Code_Column, ",", "");

                tb_CoordDescriptStart.Text = ClassConverters.ToString(settings.Koord_Descript_Start, ",", "");
                tb_CoordDescriptLength.Text = ClassConverters.ToString(settings.Koord_Descript_Length, ",", "");
                tb_CoordDescriptColumn.Text = ClassConverters.ToString(settings.Koord_Descript_Column, ",", "");

                tb_Messd_I_Start.Text = ClassConverters.ToString(settings.Messd_I_Start, ",", "");
                tb_Messd_I_Length.Text = ClassConverters.ToString(settings.Messd_I_Length, ",", "");
                tb_Messd_I_Decimals.Text = ClassConverters.ToString(settings.Messd_I_Decimals, ",", "");
                tb_Messd_I_Column.Text = ClassConverters.ToString(settings.Messd_I_Column, ",", "");

                tb_Messd_STPKCode_Start.Text = ClassConverters.ToString(settings.Messd_STPKCode_Start, ",", "");
                tb_Messd_STPKCode_Length.Text = ClassConverters.ToString(settings.Messd_STPKCode_Length, ",", "");
                tb_Messd_STPKCode_Column.Text = ClassConverters.ToString(settings.Messd_STPKCode_Column, ",", "");

                tb_Messd_STPKDescript_Start.Text = ClassConverters.ToString(settings.Messd_STPKDescript_Start, ",", "");
                tb_Messd_STPKDescript_Length.Text = ClassConverters.ToString(settings.Messd_STPKDescript_Length, ",", "");
                tb_Messd_STPKDescript_Column.Text = ClassConverters.ToString(settings.Messd_STPKDescript_Column, ",", "");

                tb_Messd_Hz_Start.Text = ClassConverters.ToString(settings.Messd_Hz_Start, ",", "");
                tb_Messd_Hz_Length.Text = ClassConverters.ToString(settings.Messd_Hz_Length, ",", "");
                tb_Messd_Hz_Decimals.Text = ClassConverters.ToString(settings.Messd_Hz_Decimals, ",", "");
                tb_Messd_Hz_Column.Text = ClassConverters.ToString(settings.Messd_Hz_Column, ",", "");

                tb_Messd_V_Start.Text = ClassConverters.ToString(settings.Messd_V_Start, ",", "");
                tb_Messd_V_Length.Text = ClassConverters.ToString(settings.Messd_V_Length, ",", "");
                tb_Messd_V_Decimals.Text = ClassConverters.ToString(settings.Messd_V_Decimals, ",", "");
                tb_Messd_V_Column.Text = ClassConverters.ToString(settings.Messd_V_Column, ",", "");

                tb_Messd_S_Start.Text = ClassConverters.ToString(settings.Messd_S_Start, ",", "");
                tb_Messd_S_Length.Text = ClassConverters.ToString(settings.Messd_S_Length, ",", "");
                tb_Messd_S_Decimals.Text = ClassConverters.ToString(settings.Messd_S_Decimals, ",", "");
                tb_Messd_S_Column.Text = ClassConverters.ToString(settings.Messd_S_Column, ",", "");

                tb_Messd_D_Start.Text = ClassConverters.ToString(settings.Messd_D_Start, ",", "");
                tb_Messd_D_Length.Text = ClassConverters.ToString(settings.Messd_D_Length, ",", "");
                tb_Messd_D_Decimals.Text = ClassConverters.ToString(settings.Messd_D_Decimals, ",", "");
                tb_Messd_D_Column.Text = ClassConverters.ToString(settings.Messd_D_Column, ",", "");

                tb_Messd_Code_Start.Text = ClassConverters.ToString(settings.Messd_Code_Start, ",", "");
                tb_Messd_Code_Length.Text = ClassConverters.ToString(settings.Messd_Code_Length, ",", "");
                tb_Messd_Code_Column.Text = ClassConverters.ToString(settings.Messd_Code_Column, ",", "");

                tb_Messd_Descript_Start.Text = ClassConverters.ToString(settings.Messd_Descript_Start, ",", "");
                tb_Messd_Descript_Length.Text = ClassConverters.ToString(settings.Messd_Descript_Length, ",", "");
                tb_Messd_Descript_Column.Text = ClassConverters.ToString(settings.Messd_Descript_Column, ",", "");
            }
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(language.getLanguageText("frmSettings_MSGBox_Reset_Message"), language.getLanguageText("frmSettings_MSGBox_Reset_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                reset();
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {
            applaySettings();
        }
    }
}
