using Kbg.NppPluginNET;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>ein Standpunkt in den CADdy Messdaten</summary>
    public class ClassCADdyStandpunkt
    {
        /// <summary>Punktnummer</summary>
        public String Punktnummer { get; set; }
        /// <summary>Instrumentenhöhe</summary>
        public Double I { get; set; }
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

        /// <summary>Anzielungen</summary>
        private List<ClassCADdyZielung> zielungen;
        /// <summary>Anzielungen</summary>
        internal List<ClassCADdyZielung> Zielungen
        {
            get { return zielungen; }
        }
        /// <summary>Konstruktor</summary>
        public ClassCADdyStandpunkt()
        {
            zielungen = new List<ClassCADdyZielung>();
        }

        /// <summary>Konstruktor</summary>
        /// <param name="punktnummer"></param>
        /// <param name="i"></param>
        /// <param name="code"></param>
        /// <param name="bemerkung">default = null</param>
        public ClassCADdyStandpunkt(String punktnummer, Double i, String code, String bemerkung = null)
        {
            this.Punktnummer = punktnummer;
            this.I = i;
            this.Code = code;
            this.Bemerkung = bemerkung;
            this.zielungen = new List<ClassCADdyZielung>();
        }

        /// <summary>Gibt einen CADdy formatierten String zurück</summary>
        /// <param name="settings"></param>
        /// <returns></returns>

        public String getCADdyFormatString(Settings settings)
        {
            String result = new String(' ', 255);
            String temp = ClassStringTools.lSetFull(Punktnummer, settings.PointName_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.PointName_Start - 1, settings.PointName_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this.I, settings.Decimalseperator, "", settings.Messd_I_Decimals, settings.Messd_I_Decimals, false), settings.Messd_I_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_I_Start - 1, settings.Messd_I_Length);

            temp = ClassStringTools.lSetFull(Code, settings.Messd_STPKCode_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_STPKCode_Start - 1, settings.Messd_STPKCode_Length);

            if (!ClassStringTools.IsNullOrWhiteSpace(Bemerkung))
            {
                temp = ClassStringTools.lSetFull(Bemerkung, settings.Messd_STPKDescript_Length, " ");
                ClassStringTools.overrideSubStr(ref result, temp, settings.Messd_STPKDescript_Start - 1, settings.Messd_STPKDescript_Length);
            }
            return result.TrimEnd(' ');
        }

        /// <summary>Gibt einen EXCELFormatiertenString zurück</summary>
        /// <returns></returns>
        public String getExcelFormatString()
        {
            String result = Punktnummer + "\t\t\t\t";

            result += ClassConverters.ToString(this.I, ",", "") + "\t";
            result += Code + "\t";

            if (!ClassStringTools.IsNullOrWhiteSpace(Bemerkung))
                result += Bemerkung;
            return result;
        }


    }
}
