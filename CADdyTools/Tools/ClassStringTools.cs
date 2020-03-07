using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>Modifizierer für buchstaben (0,1,2,3,4,5)(a,à,á,â,ã,ä)</summary>
    public enum CharModifier
    {
        /// <summary>a</summary>
        none = 0,
        /// <summary>à</summary>
        gravis = 1,
        /// <summary>á</summary>
        apostrophe = 2,
        /// <summary>â</summary>
        caret = 3,
        /// <summary>ã</summary>
        tild = 4,
        /// <summary>ä</summary>
        doublepoint = 5
    }


    /// <summary>Tolls zum manipulieren von Texten</summary>
    public class ClassStringTools
    {
        /// <summary>Liste einmal erzeugen</summary>
        private static List<String> myList;
        /// <summary>Liste einmal erzeugen</summary>
        protected static List<String> MyList
        {
            get
            {
                if (myList == null)
                    myList = new List<String>();
                return myList;
            }
        }

        /// <summary>
        /// Zerpflückt einen String in ein Array und ignoriert dabei mehrere aufeinanderfolgende Trennzeichen
        /// <example>
        /// z.B.: "                 918        4478215.4788        5795933.3584               0.000            045"
        /// = Ergebnis(0)="918"
        /// = Ergebnis(1)="4478215.4788"
        /// = Ergebnis(2)="5795933.3584"
        /// = Ergebnis(3)="0.000"
        /// = Ergebnis(4)="045"
        /// </example>
        /// Wenn "IgnoreFirstDelimiter" = True werden Trennzeichen vor dem ersten Wert/Text ignoriert
        /// </summary>
        /// <param name="Text">Der zu parsende Text</param>
        /// <param name="Delimiter">das Trennzeichen</param>
        /// <param name="IgnoreFirstDelimiter">True= Trennzeichen am anfang des Textes werden ignoriert.</param>
        /// <returns></returns>
        public static String[] GetFieldsManyDelimiters(String Text, char Delimiter, bool IgnoreFirstDelimiter)
        {
            MyList.Clear();
            char chChar = '\0';
            string strFeld = "";
            bool boWarDelim = false;
            for (int intCount = 0; intCount <= Text.Length - 1; intCount++)
            {
                chChar = Text[intCount];
                if ((chChar == Delimiter))
                {
                    if (((intCount == 0) & (!IgnoreFirstDelimiter)))
                    {
                        myList.Add("");
                        boWarDelim = true;
                    }
                    else if (((intCount == 0) & (IgnoreFirstDelimiter)))
                    {
                        boWarDelim = true;
                    }
                    if ((!boWarDelim))
                    {
                        myList.Add(strFeld);
                        strFeld = "";
                        boWarDelim = true;
                    }
                }
                else if ((chChar != Delimiter))
                {
                    strFeld += chChar;
                    boWarDelim = false;
                }
                if ((((intCount == Text.Length - 1) & (!boWarDelim)) & (strFeld.Length > 0)))
                {
                    myList.Add(strFeld);
                }
            }
            if (myList.Count > 0)
                return myList.ToArray();
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Delimiter"></param>
        /// <param name="IgnoreFirstDelimiter"></param>
        /// <returns></returns>
        private static String[] oldGetFieldsManyDelimiters(String Text, char Delimiter, bool IgnoreFirstDelimiter)
        {
            String[] ergebnis = null;
            char chChar = '\0';
            string strFeld = "";
            bool boWarDelim = false;
            int intCount = 0;
            int intFieldCount = 1;
            Array.Resize(ref ergebnis, intFieldCount);
            for (intCount = 0; intCount <= Text.Length - 1; intCount++)
            {
                chChar = Text[intCount];
                if ((chChar == Delimiter))
                {
                    if (((intCount == 0) & (!IgnoreFirstDelimiter)))
                    {
                        ergebnis[0] = "";
                        intFieldCount += 1;
                        boWarDelim = true;
                    }
                    else if (((intCount == 0) & (IgnoreFirstDelimiter)))
                    {
                        boWarDelim = true;
                    }
                    if ((!boWarDelim))
                    {
                        if ((intFieldCount > 1))
                        {
                            Array.Resize(ref ergebnis, intFieldCount);
                        }
                        ergebnis[intFieldCount - 1] = strFeld;
                        intFieldCount += 1;
                        strFeld = "";
                        boWarDelim = true;
                    }
                }
                else if ((chChar != Delimiter))
                {
                    strFeld += chChar;
                    boWarDelim = false;
                }
                if ((((intCount == Text.Length - 1) & (!boWarDelim)) & (strFeld.Length > 0)))
                {
                    if ((intFieldCount > 1))
                    {
                        Array.Resize(ref ergebnis, intFieldCount);
                    }
                    ergebnis[intFieldCount - 1] = strFeld;
                }
            }
            return ergebnis;
        }

        /// <summary>entfernt umschließende Anführungszeichen</summary>
        /// <param name="fromThisList"></param>
        public static void removeQuotationMarks(ref List<String> fromThisList)
        {
            if (fromThisList != null)
            {
                for (Int32 i = 0; i < fromThisList.Count; i++)
                {
                    fromThisList[i] = removeQuotationMarks(fromThisList[i]);
                }
            }
        }
        /// <summary>entfernt umschließende Anführungszeichen</summary>
        /// <param name="fromThisArray"></param>
        public static void removeQuotationMarks(ref String[] fromThisArray)
        {
            if (fromThisArray != null)
            {
                for (Int32 i = 0; i < fromThisArray.Length; i++)
                {
                    fromThisArray[i] = removeQuotationMarks(fromThisArray[i]);
                }
            }
        }
        /// <summary>Entfernt die Führenden und Abschließenden Anfürungszeichen</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static String removeQuotationMarks(String Value)
        {
            if (!String.IsNullOrEmpty(Value))
            {
                if (Value[0] == '"') Value = Value.Remove(0, 1);
                if (Value[Value.Length - 1] == '"') Value = Value.Remove(Value.Length - 1);
            }
            return Value;
        }

        /// <summary>Entfernt alle, auch innere Leerzeichen</summary>
        /// <param name="value">der zu Trimmende Text</param>
        /// <returns>value ohne ein leerzeichen</returns>
        public static String TrimInner(String value)
        {
            String ergebnis = "";
            foreach (Char zeichen in value)
            {
                if (zeichen != ' ')
                    ergebnis += zeichen;
            }
            return ergebnis;
        }
        ///<summary>Entfernt alle alphanumerischen Zeichen aus dem String
        ///<example>"123w456r789" => "123456789"</example>
        /// </summary>
        /// <param name="strText">der String aus dem die alphanumerischen Zeichen entfernt werden sollen</param>
        /// <returns>einen String ohne alphanumerischen Zeichen</returns>
        public static string GetNumeric(string strText)
        {
            string strErgebnis = null;
            strErgebnis = "";
            foreach (char zeichen in strText)
            {
                if ((char.IsNumber(zeichen)))
                    strErgebnis += zeichen;
                else if (strErgebnis.Length == 0)
                {
                    if (zeichen == '-')
                        strErgebnis += "-";
                }

            }
            return strErgebnis;
        }

        ///<summary>Entfernt alle alphanumerischen Zeichen außer "E" "." "," aus dem String
        ///<example>"-1,23w456E-789" => "-1,23456E-789"</example>
        /// </summary>
        /// <param name="strText">der String aus dem die alphanumerischen Zeichen entfernt werden sollen</param>
        /// <returns>einen String ohne alphanumerischen Zeichen</returns>
        public static string GetExpNumeric(string strText)
        {
            string strErgebnis = null;
            bool HabeinE = false;
            string GrossZeichen;
            strErgebnis = "";
            foreach (char zeichen in strText)
            {
                if ((char.IsNumber(zeichen)))
                    strErgebnis += zeichen;
                else if (!HabeinE)
                {
                    GrossZeichen = "";
                    GrossZeichen += zeichen;
                    if (GrossZeichen.ToUpper() == "E")
                    {
                        if (strErgebnis.Length > 0)
                        {
                            strErgebnis += "E";
                            HabeinE = true;
                        }
                    }
                }
                else if (zeichen == '-')
                {
                    if ((strErgebnis.Length == 0) || (HabeinE && strErgebnis.EndsWith("E")))
                        strErgebnis += "-";
                }
                else if (zeichen == '.')
                {
                    strErgebnis += ".";
                }
                else if (zeichen == ',')
                {
                    strErgebnis += ",";
                }
            }
            return strErgebnis;
        }

        /// <summary>String.replicate</summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static String replicate(String value, Int32 count)
        {
            if (String.IsNullOrEmpty(value)) return String.Empty;
            if (count < 1) return String.Empty;
            String ergebnis = String.Empty;
            for (Int32 i = 0; i < count; i++)
                ergebnis += value;
            return ergebnis;
        }

        ///<summary>Entfernt alle numerischen Zeichen aus dem String
        ///<example>"123w456r789" => "wr"</example>
        /// </summary>
        /// <param name="strText">der String aus dem die numerischen Zeichen entfernt werden sollen</param>
        /// <returns>einen String ohne numerischen Zeichen</returns>
        public static string GetAlpha(string strText)
        {
            string strErgebnis = null;
            strErgebnis = "";
            foreach (char zeichen in strText)
            {
                if ((char.IsLetter(zeichen))) strErgebnis += zeichen;
            }
            return strErgebnis;
        }

        /// <summary>Testet ob das Object (String) eine Zahl ist</summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>Prüft, ob ein String == null oder leer ist</summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(String strText)
        {
            if (strText == null) return true;
            if (strText.Length == 0) return true;
            return false;
        }
        /// <summary>Ersatz für .Net3.5</summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(String strText)
        {
            if (strText == null) return true;
            if (strText.Length == 0) return true;
            if (strText.Trim().Length == 0) return true;
            return false;
        }

        /// <summary>Gibt immer mindestens einen leeren String zurück,
        /// normal einen String.Trim() zurück</summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static String trimToEmpty(String strText)
        {
            if (strText == null) return "";
            return strText.Trim();
        }
        /// <summary>Gibt bei einem leeren String "null" zurück,
        /// sonst einen String.Trim()</summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static String trimToNull(String strText)
        {
            if (trimToEmpty(strText).Length == 0) return null;
            return strText.Trim();
        }

        /// <summary>Kontrolliert, ob der Pfad / Dateiname den MSDos 8.3 - Namensregeln entspricht</summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static bool IsNameIsMSDOSLike(string strText)
        {
            if (String.IsNullOrEmpty(strText)) return false;
            string[] arrSplit = strText.Split(new char[] { '\\' });
            foreach (string strSplit in arrSplit)
            {
                if (strSplit.Contains('.'))
                {
                    string[] arrNameSplit = strSplit.Split(new char[] { '.' });
                    if (arrNameSplit.Length > 0)
                    {
                        foreach (string strNameSplit in arrNameSplit)
                        {
                            if (strNameSplit.Length > 8) return false;
                        }
                    }
                    else
                    {
                        if (strSplit.Length > 8) return false;
                    }
                }
            }
            return true;
        }

        /// <summary>Gibt das mit dem CharModifier modifizierte Zeichen zurück </summary>
        /// <param name="c"></param>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public static Char getModifiedChar(Char c, CharModifier modifier)
        {
            //éúíóáý
            String ergebnis = new String(new Char[] { c });
            switch (c)
            {
                case 'a':
                case 'A':
                    switch (modifier)
                    {
                        case CharModifier.gravis:
                            ergebnis = "à";
                            break;
                        case CharModifier.apostrophe:
                            ergebnis = "á";
                            break;
                        case CharModifier.caret:
                            ergebnis = "â";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ä";
                            break;
                        case CharModifier.tild:
                            ergebnis = "ã";
                            break;
                    }
                    if (c == 'A') ergebnis = ergebnis.ToUpper();
                    break;
                case 'e':
                case 'E':
                    switch (modifier)
                    {
                        case CharModifier.gravis:
                            ergebnis = "è";
                            break;
                        case CharModifier.apostrophe:
                            ergebnis = "é";
                            break;
                        case CharModifier.caret:
                            ergebnis = "ê";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ë";
                            break;
                    }
                    if (c == 'E') ergebnis = ergebnis.ToUpper();
                    break;
                case 'i':
                case 'I':
                    switch (modifier)
                    {
                        case CharModifier.gravis:
                            ergebnis = "ì";
                            break;
                        case CharModifier.apostrophe:
                            ergebnis = "í";
                            break;
                        case CharModifier.caret:
                            ergebnis = "î";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ï";
                            break;
                    }
                    if (c == 'I') ergebnis = ergebnis.ToUpper();
                    break;
                case 'o':
                case 'O':
                    switch (modifier)
                    {
                        case CharModifier.gravis:
                            ergebnis = "ò";
                            break;
                        case CharModifier.apostrophe:
                            ergebnis = "ó";
                            break;
                        case CharModifier.caret:
                            ergebnis = "ô";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ö";
                            break;
                        case CharModifier.tild:
                            ergebnis = "õ";
                            break;
                    }
                    if (c == 'O') ergebnis = ergebnis.ToUpper();
                    break;
                case 'u':
                case 'U':
                    switch (modifier)
                    {
                        case CharModifier.gravis:
                            ergebnis = "ù";
                            break;
                        case CharModifier.apostrophe:
                            ergebnis = "ú";
                            break;
                        case CharModifier.caret:
                            ergebnis = "û";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ü";
                            break;
                    }
                    if (c == 'U') ergebnis = ergebnis.ToUpper();
                    break;
                case 'y':
                case 'Y':
                    switch (modifier)
                    {
                        case CharModifier.apostrophe:
                            ergebnis = "ý";
                            break;
                        case CharModifier.doublepoint:
                            ergebnis = "ÿ";
                            break;
                    }
                    if (c == 'Y') ergebnis = ergebnis.ToUpper();
                    break;
                case 'n':
                case 'N':
                    switch (modifier)
                    {
                        case CharModifier.tild:
                            ergebnis = "ñ";
                            break;
                    }
                    if (c == 'N') ergebnis = ergebnis.ToUpper();
                    break;
            }
            return ergebnis[0];
        }

        /// <summary>Gibt eine Double aus dem Text.
        /// Wenn der Text keine Zahl ist, dann Double.NaN</summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Double getDouble(String text)
        {
            Double temp;
            if (ClassConverters.StringToDouble(text, out temp))
                return temp;
            else
                return Double.NaN;
        }
        /// <summary>Formatiert einen String anhand einer Double Zahl
        /// und den Nachkommastellen</summary>
        /// <param name="value"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static String setDouble(Double value, Int32 decimals)
        {
            if (Double.IsInfinity(value) || Double.IsNaN(value) || Double.IsNegativeInfinity(value)
                || Double.IsPositiveInfinity(value)) return null;
            String format = "0";
            if (decimals > 0) format += "." + replicate("0", decimals);
            return value.ToString(format).Trim();
        }
        /// <summary>Formatiert einen String anhand einer Double Zahl
        /// und den Nachkommastellen. Es wird immer mind. 0.0 zurück gegeben</summary>
        /// <param name="value"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static String setDoubleNotNull(Double value, Int32 decimals)
        {
            if (Double.IsInfinity(value) || Double.IsNaN(value) || Double.IsNegativeInfinity(value)
                || Double.IsPositiveInfinity(value)) value = 0.0;
            String format = "0";
            if (decimals > 0) format += "." + replicate("0", decimals);
            return value.ToString(format).Trim();
        }
        /// <summary>Formatiert einen String anhand einer Double Zahl
        /// und den Nachkommastellen. Es wird immer mind. 0.0 zurück gegeben</summary>
        /// <param name="value"></param>
        /// <param name="decimals"></param>
        /// <param name="decimalSeperator"></param>
        /// <returns></returns>
        public static String setDoubleNotNull(Double value, Int32 decimals, char decimalSeperator)
        {
            if (Double.IsInfinity(value) || Double.IsNaN(value) || Double.IsNegativeInfinity(value)
                || Double.IsPositiveInfinity(value)) value = 0.0;
            String format = "0";
            if (decimals > 0) format += "." + replicate("0", decimals);
            String result = value.ToString(format, CultureInfo.InvariantCulture);
            if (decimalSeperator != '.') result.Replace('.', decimalSeperator);
            return result;
        }
        /// <summary>Gibt das Ende es Textes als Double zurück, wenn das Ende ein Double ist.
        /// Erkennt auch ".,"</summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Boolean getLastNumbersAsDouble(String text, out Double result)
        {
            Int32 i;
            return getLastNumbersAsDouble(text, out result, out i);
        }
        /// <summary>Gibt das Ende es Textes als Double zurück und die Pos ab der die Zahl beginnt
        /// , wenn das Ende ein Double ist. Erkennt auch ".,"</summary>
        /// <param name="text"></param>
        /// <param name="result">Double.NaN = fehler</param>
        /// <param name="lastNumberPos">-1 = fehler</param>
        /// <returns>True erfolg</returns>
        public static Boolean getLastNumbersAsDouble(String text, out Double result, out Int32 lastNumberPos)
        {
            if (!IsNullOrWhiteSpace(text))
            {
                if (Char.IsDigit(text.Last()))
                {
                    String teil = "";
                    Int32 pos;
                    for (pos = text.Length - 1; pos >= 0; pos--)
                    {
                        if ((Char.IsDigit(text[pos])) || ((text[pos] == '.') || (text[pos] == ',')))
                            teil = text[pos] + teil;
                        else
                        {
                            pos++; // es war die nächste Pos
                            break;
                        }
                    }
                    if (teil.Length > 0)
                    {
                        //TODO: Nächste Patchday aktivieren !! if (pos == -1) pos = 0;
                        lastNumberPos = pos;
                        return ClassConverters.StringToDouble(teil, out result);
                    }
                }
            }
            lastNumberPos = -1;
            result = Double.NaN;
            return false;

        }

        /// <summary>Gibt einen 'hochgezählten' Text zurück</summary>
        /// <param name="numbertext"></param>
        /// <returns></returns>
        public static String getTextIncrement(String numbertext)
        {
            String defaultPunktnummer = numbertext;
            Double lastnumber;
            Int32 numberPos;
            if (ClassStringTools.getLastNumbersAsDouble(defaultPunktnummer, out lastnumber, out numberPos))
            {
                if (!Double.IsNaN(lastnumber))
                {
                    Int32 digits = ClassMath.getDigitCount(lastnumber);
                    lastnumber += ClassMath.getDigitFactor(lastnumber);
                    if (numberPos == -1) numberPos = 0;
                    String pktNr = defaultPunktnummer.Substring(0, numberPos) + ClassConverters.ToString(lastnumber, ".", "", digits, true).Trim();
                    if (pktNr.Length < defaultPunktnummer.Length)
                    {
                        Int32 nullen = defaultPunktnummer.Length - pktNr.Length;
                        pktNr = defaultPunktnummer.Substring(0, numberPos) + new String('0', nullen) +
                            ClassConverters.ToString(lastnumber, ".", "", digits, true).Trim();
                    }
                    defaultPunktnummer = pktNr;
                }
            }
            return defaultPunktnummer;
        }

        /// <summary>Gibt eine Double aus dem Text.
        /// Wenn der Text keine Zahl ist, dann 0</summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Int32 getInt32(String text)
        {
            Int32 temp;
            if (Int32.TryParse(text, out temp))
                return temp;
            else
                return 0;
        }
        /// <summary>Formatiert einen String anhand einer Int32 Zahl</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String setSint32(Int32 value)
        {
            return value.ToString("0").Trim();
        }

        /// <summary>Gibt einen Linksbündigen String mit der Länge length zurück,
        /// ist text kürzer als length wird mit space aufgefüllt</summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        public static String lSetFull(String text, Int32 length, String space)
        {
            text = text.Trim();
            if (text.Length < length)
            {
                text = text + replicate(space, (length - text.Length) + 2);
            }
            return text.Substring(0, length);
        }
        /// <summary>Gibt einen rechtsbündigen String mit der Länge length zurück,
        /// ist text kürzer als length wird mit space aufgefüllt</summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        public static String rSetFull(String text, Int32 length, String space)
        {
            text = text.Trim();
            if (text.Length < length)
            {
                text = replicate(space, (length - text.Length) + 2) + text;
            }
            return text.Substring(text.Length - length, length);
        }

        /// <summary>In dem String toOverride wird ab startPos mit dem String newText bis length überschrieben.
        /// Ist toOverride kürzer als start + (length oder newText.Length) wird angehangen!</summary>
        /// <param name="toOverride"></param>
        /// <param name="newText"></param>
        /// <param name="start">Startposition 0-basierend</param>
        /// <param name="length">optional (-1=default= länge von newText)</param>
        public static void overrideSubStr(ref String toOverride, String newText, Int32 start, Int32 length = -1)
        {
            if (!String.IsNullOrEmpty(newText))
            {
                if (!String.IsNullOrEmpty(toOverride))
                {
                    Int32 cuLength = length;

                    if (cuLength < 0) cuLength = newText.Length;
                    String pre = "";
                    if (start > 0) pre = toOverride.Substring(0, start);
                    String post = "";
                    if (toOverride.Length > (start + cuLength)) post = toOverride.Substring(start  + cuLength);
                    toOverride = pre + newText + post;
                }
            }
        }
    }
}
