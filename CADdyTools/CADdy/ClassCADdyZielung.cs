using Kbg.NppPluginNET;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Datenzeile einer Anzielung</summary>
    public class ClassCADdyZielung
    {
        /// <summary>Punktnummer</summary>
        public String Zielpunkt { get; set; }
        /// <summary>Reflektorhöhe</summary>
        public Double D { get; set; }
        /// <summary>Richtung</summary>
        public Double Hz { get; set; }
        /// <summary>Vertikalwinkel</summary>
        public Double V { get; set; }
        /// <summary>Schrägstrecke</summary>
        public Double S { get; set; }
        /// <summary>Code</summary>
        public String Code { get; set; }
        /// <summary>Bemerkung</summary>
        public String Bemerkung { get; set; }

        /// <summary>In welcher zeile bin ich?</summary>
        private Int32 lineNumber;
        /// <summary>In welcher zeile bin ich?</summary>
        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }

        /// <summary>Konstruktor</summary>
        /// <param name="zielpunkt"></param>
        /// <param name="d"></param>
        /// <param name="hz"></param>
        /// <param name="v"></param>
        /// <param name="s"></param>
        /// <param name="code"></param>
        /// <param name="bemerkung">default = null</param>
        public ClassCADdyZielung(String zielpunkt, Double d, Double hz, Double v, Double s, String code, String bemerkung = null)
        {
            Zielpunkt = zielpunkt;
            D = d;
            Hz = hz;
            V = v;
            S = s;
            Code = code;
            Bemerkung = bemerkung;
        }
        /// <summary>Leerkonstruktor</summary>
        public ClassCADdyZielung()
        { }

        /// <summary>Gibt einen CADdy formatierten String zurück</summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public String getCADdyFormatString(Settings settings)
        {
            String result = new String(' ', 255);
            String temp = ClassStringTools.lSetFull(Zielpunkt, settings.PointName_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.PointName_Start - 1, settings.PointName_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this.Hz, settings.Decimalseperator, "", settings.Messd_Hz_Decimals, settings.Messd_Hz_Decimals, false), settings.Messd_Hz_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_Hz_Start - 1, settings.Messd_Hz_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this.S, settings.Decimalseperator, "", settings.Messd_S_Decimals, settings.Messd_S_Decimals, false), settings.Messd_S_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_S_Start - 1, settings.Messd_S_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this.V, settings.Decimalseperator, "", settings.Messd_V_Decimals, settings.Messd_V_Decimals, false), settings.Messd_V_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_V_Start - 1, settings.Messd_V_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this.D, settings.Decimalseperator, "", settings.Messd_D_Decimals, settings.Messd_D_Decimals, false), settings.Messd_D_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_D_Start - 1, settings.Messd_D_Length);

            temp = ClassStringTools.lSetFull(Code, settings.Messd_Code_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_Code_Start - 1, settings.Messd_Code_Length);

            if (!ClassStringTools.IsNullOrWhiteSpace(Bemerkung))
            {
                temp = ClassStringTools.lSetFull(Bemerkung, settings.Messd_Descript_Length, " ");
                ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_Descript_Start - 1, settings.Messd_Descript_Length);
            }
            return result.TrimEnd(' ');
        }

        /// <summary>Gibt einen EXCELFormatiertenString zurück</summary>
        /// <returns></returns>
        public String getExcelFormatString()
        {
            String result = Zielpunkt + "\t";

            result += ClassConverters.ToString(this.Hz, ",", "") + "\t";
            result += ClassConverters.ToString(this.S, ",", "") + "\t";
            result += ClassConverters.ToString(this.V, ",", "") + "\t";
            result += ClassConverters.ToString(this.D, ",", "") + "\t";
            result += Code + "\t";

            if (!ClassStringTools.IsNullOrWhiteSpace(Bemerkung))
                result += Bemerkung;
            return result;
        }

    }
}
