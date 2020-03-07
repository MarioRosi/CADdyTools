using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Speicherklasse für CADdyPunkte
    /// Die Operatoren ==, !=, Equals(object b) wurden überschrieben</summary>
    public class ClassCADdyPunkt : Object
    {
        #region "Eigenschaften"
        private String _punktnummer;
        /// <summary>Property für die Punktnummer</summary>
        public String Punktnummer
        {
            get
            {
                if (_punktnummer == null)
                    return "";
                else
                    return _punktnummer;
            }
            set { _punktnummer = value; }
        }

        private double _rechtswert;
        /// <summary>Property Rechtswert für den Punkt</summary>
        public double Rechtswert
        {
            get { return _rechtswert; }
            set { _rechtswert = value; }
        }

        private double _hochwert;
        /// <summary>Property Hochwert für den Punkt</summary>
        public double Hochwert
        {
            get { return _hochwert; }
            set { _hochwert = value; }
        }

        private double _hoehe;
        /// <summary>Property Höhe für den Punkt</summary>
        public double Hoehe
        {
            get { return _hoehe; }
            set { _hoehe = value; }
        }

        private String _bemerkung;
        /// <summary>Property Bemerkung / Description für den Punkt </summary>
        public String Bemerkung
        {
            get
            {
                if (_bemerkung == null)
                    return "";
                else
                    return _bemerkung;
            }
            set { _bemerkung = value; }
        }

        private String _code;
        /// <summary>Property Code/Symbol/Block für den Punkt</summary>
        public String Code
        {
            get
            {
                if (_code == null)
                    return "";
                else
                    return _code;
            }
            set { _code = value; }
        }

        /// <summary>In welcher zeile bin ich?</summary>
        private Int32 lineNumber;
        /// <summary>In welcher zeile bin ich?</summary>
        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }
        #endregion //"Eigenschaften"

        #region "Methoden"
        /// <summary>
        /// Konstruktor
        /// </summary>
        public ClassCADdyPunkt()
        {

        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="rechtswert"></param>
        /// <param name="hochwert"></param>
        /// <param name="hoehe"></param>
        public ClassCADdyPunkt(double rechtswert, double hochwert, double hoehe)
        {
            this._rechtswert = rechtswert;
            this._hochwert = hochwert;
            this._hoehe = hoehe;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="punktnummer"></param>
        /// <param name="rechtswert"></param>
        /// <param name="hochwert"></param>
        /// <param name="hoehe"></param>
        /// <param name="code"></param>
        public ClassCADdyPunkt(String punktnummer, double rechtswert, double hochwert, double hoehe, string code)
        {
            this._punktnummer = punktnummer;
            this._rechtswert = rechtswert;
            this._hochwert = hochwert;
            this._hoehe = hoehe;
            this._code = code;
        }

        /// <summary>Berechnet den RIWI in Gon aus dem Delta</summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public Double gonRiwiTo(ClassCADdyPunkt target)
        {
            ClassCADdyPunkt delta = target - this;
            if (delta.Hochwert == 0.0)
            {
                if (delta.Rechtswert > 0.0)
                    return 100.0;
                else if (delta.Rechtswert < 0.0)
                    return 300.0;
                return Double.NaN;
            }
            if (delta.Rechtswert == 0.0)
            {
                if (delta.Hochwert > 0.0) return 0.0;
                return 200.0;
            }
            Double ergebnis = Math.Atan(delta.Rechtswert / delta.Hochwert) * (200.0 / Math.PI);
            // Quadrantenkorrektur
            if (delta.Hochwert < 0.0)
                ergebnis += 200.0;
            else if ((delta.Rechtswert < 0.0) && (delta.Hochwert >= 0.0))
                ergebnis += 400.0;
            return ergebnis;
        }

        /// <summary>Richtungswinkel aus mir als Delta-Punkt(Vektor)</summary>
        /// <returns></returns>
        public Double gonRiwi()
        {
            if (Hochwert == 0.0)
            {
                if (Rechtswert > 0.0)
                    return 100.0;
                else if (Rechtswert < 0.0)
                    return 300.0;
                return Double.NaN;
            }
            if (Rechtswert == 0.0)
            {
                if (Hochwert > 0.0) return 0.0;
                return 200.0;
            }
            Double ergebnis = Math.Atan(Rechtswert / Hochwert) * (200.0 / Math.PI);
            // Quadrantenkorrektur
            if (Hochwert < 0.0)
                ergebnis += 200.0;
            else if ((Rechtswert < 0.0) && (Hochwert >= 0.0))
                ergebnis += 400.0;
            return ergebnis;
        }

        /// <summary>2d-Strecke aus mir als Delta-Punkt(Vektor)</summary>
        /// <returns></returns>
        public Double length()
        {
            return Math.Sqrt(Math.Pow(Hochwert, 2) + Math.Pow(Rechtswert, 2));
        }

        /// <summary>3d-Strecke aus mir als Delta-Punkt(Vektor)</summary>
        /// <returns></returns>
        public Double distance()
        {
            return Math.Sqrt(Math.Pow(Hochwert, 2) + Math.Pow(Rechtswert, 2)+Math.Pow(Hoehe,2));
        }

        /// <summary>Gefälle aus mir als Delta-Punkt(Vektor)</summary>
        /// <returns></returns>
        public Double clination()
        {
            return Hoehe / Math.Sqrt(Math.Pow(Hochwert, 2) + Math.Pow(Rechtswert, 2)) * 100;
        }



        /// <summary>Vergleicht diesen Punkt mit Punkt b
        /// 'unscharf' d.h. alle texte werden mit ToUpper() verglichen,
        /// alle Zahlen nur auf 0,000 verglichen</summary>
        /// <param name="b">der zu vergleichende Punkt</param>
        /// <returns>True = beide gleich | False = nicht gleich</returns>
        public bool FuzzyEqual(ClassCADdyPunkt b)
        {
            // beide null oder beide die gleiche Instance
            if (System.Object.ReferenceEquals(this, b)) return true;
            //Punktnummer
            if (!ClassFuzzyLogic.FuzzyEqual(this._punktnummer, b._punktnummer)) return false;
            // Hochwert
            if (!ClassFuzzyLogic.FuzzyEqual(this._hochwert, b._hochwert, 3)) return false;
            // Rechtswert
            if (!ClassFuzzyLogic.FuzzyEqual(this._rechtswert, b._rechtswert, 3)) return false;
            // Höhe
            if (!ClassFuzzyLogic.FuzzyEqual(this._hoehe, b._hoehe, 3)) return false;
            // Code
            if (!ClassFuzzyLogic.FuzzyEqual(this._code, b._code)) return false;
            // Bemerkung
            if (!ClassFuzzyLogic.FuzzyEqual(this._bemerkung, b._bemerkung)) return false;
            // Beide gleich
            return true;
        }

        /// <summary>erzeugt einen Neuen Punkt, der die Differenzen a-b enthält.
        /// Unterschiede in Strings werden als Text 'abc != CDE' angezeigt</summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ClassCADdyPunkt operator -(ClassCADdyPunkt a, ClassCADdyPunkt b)
        {
            ClassCADdyPunkt ergebnis = new ClassCADdyPunkt();
            if (a == b)
            {
                ergebnis.Punktnummer = a.Punktnummer;
            }
            else
            {
                if (a.Punktnummer != b.Punktnummer)
                    ergebnis.Punktnummer = a.Punktnummer + " <> " + b.Punktnummer;
                else
                    ergebnis.Punktnummer = a.Punktnummer;
                ergebnis._rechtswert = a._rechtswert - b._rechtswert;
                ergebnis._hochwert = a._hochwert - b._hochwert;
                ergebnis._hoehe = a._hoehe - b._hoehe;
                if (a.Code != b.Code) ergebnis.Code = a.Code + " <> " + b.Code;
                if (a.Bemerkung != b.Bemerkung) ergebnis.Bemerkung = a.Bemerkung + " <> " + b.Bemerkung;
            }
            return ergebnis;
        }
        /// <summary>Überladung des Operators ==</summary>
        /// <param name="a">einer der zu vergleichenden DBKPunkte</param>
        /// <param name="b">der andere zu vergleichende DBKPunkt</param>
        /// <returns>True = beide gleich | False ungleich</returns>
        public static bool operator ==(ClassCADdyPunkt a, ClassCADdyPunkt b)
        {
            // beide null oder beide die gleiche Instance
            if (System.Object.ReferenceEquals(a, b)) return true;
            if (System.Object.ReferenceEquals(a, null)) return false;
            if (System.Object.ReferenceEquals(b, null)) return false;
            //Punktnummer
            if ((a._punktnummer != null) && (b._punktnummer != null))
            {
                if (a._punktnummer.CompareTo(b._punktnummer) != 0) return false;
            }
            else
                return false;
            // Hochwert
            if (a._hochwert != b._hochwert) return false;
            // Rechtswert
            if (a._rechtswert != b._rechtswert) return false;
            // Höhe
            if (a._hoehe != b._hoehe) return false;
            // Code
            if ((a._code != null) && (b._code != null))
            {
                if (a._code.CompareTo(b._code) != 0) return false;
            }
            else
                return false;

            // Bemerkung
            if ((a._bemerkung != null) && (b._bemerkung != null))
            {
                if (a._bemerkung.CompareTo(b._bemerkung) != 0) return false;
            }
            else
                return false;


            // Beide gleich
            return true;
        }
        /// <summary>Überladung des Operators !=</summary>
        /// <param name="a">einer der zu vergleichenden DBKPunkte</param>
        /// <param name="b">der andere zu vergleichende DBKPunkt</param>
        /// <returns>True = ungleich | False = beide gleich </returns>
        public static bool operator !=(ClassCADdyPunkt a, ClassCADdyPunkt b)
        {
            return !(a == b);
        }
        /// <summary>Vergleicht diesen Punkt mit Punkt b</summary>
        /// <param name="b">der zu vergleichende Punkt</param>
        /// <returns>True = beide gleich | False ungleich</returns>
        public override bool Equals(object b)
        {
            if (b == null) return false;
            return (this == (ClassCADdyPunkt)b);
        }
        /// <summary>gibt den HashCode zurück</summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>Erzeugt eine Textausgabe des Punktes
        /// im Format [Punktnummer](Rechtswert|Hochwert|Hoehe|Code|Punktklasse|Bemerkung|Projekt)</summary>
        /// <returns></returns>
        public override string ToString()
        {
            String ergebnis = "[" + this.Punktnummer + "](" + this.Rechtswert.ToString("0.000").Trim() + "|" +
                              this.Hochwert.ToString("0.000").Trim() + "|" + this.Hoehe.ToString("0.000").Trim() + "|" + this.Code.Trim() + "|" + this.Bemerkung.Trim() + ")";
            return ergebnis;
        }
        /// <summary>Gibt einen CADdy formatierten String zurück</summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public String getCADdyFormatString(Settings settings)
        {
            String result = new String(' ', 255);
            String temp = ClassStringTools.lSetFull(_punktnummer, settings.PointName_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.PointName_Start - 1, settings.PointName_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this._rechtswert, settings.Decimalseperator, "", settings.Koord_RW_E_Decimals, settings.Koord_RW_E_Decimals, false), settings.Koord_RW_E_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Koord_RW_E_Start - 1, settings.Koord_RW_E_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this._hochwert, settings.Decimalseperator, "", settings.Koord_HW_N_Decimals, settings.Koord_HW_N_Decimals, false), settings.Koord_HW_N_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Koord_HW_N_Start - 1, settings.Koord_HW_N_Length);

            temp = ClassStringTools.rSetFull(ClassConverters.ToString(this._hoehe, settings.Decimalseperator, "", settings.Koord_Elev_Decimals, settings.Koord_Elev_Decimals, false), settings.Koord_Elev_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Koord_Elev_Start - 1, settings.Koord_Elev_Length);

            temp = ClassStringTools.lSetFull(_code, settings.Koord_Code_Length, " ");
            ClassStringTools.overrideSubStr(ref result, temp, settings.Koord_Code_Start - 1, settings.Koord_Code_Length);

            if (!ClassStringTools.IsNullOrWhiteSpace(_bemerkung))
            {
                temp = ClassStringTools.lSetFull(_bemerkung, settings.Koord_Descript_Length, " ");
                ClassStringTools.overrideSubStr(ref result, temp, settings.Koord_Descript_Start - 1, settings.Koord_Descript_Length);
            }
            return result.TrimEnd(' ');
        }

        /// <summary>Gibt einen EXCELFormatiertenString zurück</summary>
        /// <returns></returns>
        public String getExcelFormatString()
        {
            String result = _punktnummer + "\t";

            result += ClassConverters.ToString(this._rechtswert, ",", "") + "\t";
            result += ClassConverters.ToString(this._hochwert, ",", "") + "\t";
            result += ClassConverters.ToString(this._hoehe, ",", "") + "\t";
            result += _code + "\t";

            if (!ClassStringTools.IsNullOrWhiteSpace(_bemerkung))
                result += _bemerkung;
            return result;
        }

        public ClassCADdyPunkt getAsCopy()
        {
            ClassCADdyPunkt result = new ClassCADdyPunkt(_punktnummer, _rechtswert, _hochwert, _hoehe, _code);
            result._bemerkung = _bemerkung;
            result.lineNumber = lineNumber;
            return result;
        }
        #endregion //"Methoden"


    }
}
