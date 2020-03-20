using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>Classe für die stabile String -=- Zahlen Konvertierung</summary>
    public class ClassConverters
    {
        /// <summary>Trennzeichenfolge für Arrays</summary>
        public const String ListDelimiter = "';'";

        #region IsConvertableTests
        /// <summary>Tester, ist der Typ der Property ein direkt Konvertierbarer Typ?
        /// Nein, dann muss er eine DataObjectBean sein</summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public static Boolean isNativeConvertable(Type valueType)
        {
            Boolean result = false;
            if (valueType == typeof(Int16))
                result = true;
            else if (valueType == typeof(Int16?))
                result = true;
            else if (valueType == typeof(Int32))
                result = true;
            else if (valueType == typeof(Int32?))
                result = true;
            else if (valueType == typeof(Int64))
                result = true;
            else if (valueType == typeof(Int64?))
                result = true;
            else if (valueType == typeof(Double))
                result = true;
            else if (valueType == typeof(Double?))
                result = true;
            else if (valueType == typeof(DateTime))
                result = true;
            else if (valueType == typeof(DateTime?))
                result = true;
            else if (valueType == typeof(Boolean))
                result = true;
            else if (valueType == typeof(Boolean?))
                result = true;
            else if (valueType == typeof(Char))
                result = true;
            else if (valueType == typeof(Char?))
                result = true;
            else if (valueType == typeof(Decimal))
                result = true;
            else if (valueType == typeof(Decimal?))
                result = true;
            else if (valueType == typeof(float))
                result = true;
            else if (valueType == typeof(float?))
                result = true;
            else if (valueType == typeof(Guid))
                result = true;
            else if (valueType == typeof(Guid?))
                result = true;
            else if (valueType == typeof(String))
                result = true;
            else if (valueType == typeof(Enum))
                result = true;
            else if (valueType == typeof(System.Drawing.Color))
                result = true;
            else if (valueType.IsEnum)
                result = true;
            else if (valueType.BaseType == typeof(Array))
                result = true;
            return result;
        }
        /// <summary>NoStatic aufruf für das Interface</summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public Boolean isNativeConvertableNoStatic(Type valueType)
        {
            return isNativeConvertable(valueType);
        }
        #endregion IsConvertableTests

        #region StringTo..
        /// <summary>Wandelt einen String "0,1"in einen Boolean um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToBoolean(String Value, out Boolean Result)
        {
            if (!String.IsNullOrWhiteSpace(Value))
            {
                if (Value == "1")
                    Result = true;
                else
                    Result = false;
                return true;
            }
            Result = false;
            return false;
        }
        /// <summary>Wandelt einen String "0,1,false,true,null"in einen Boolean? um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToBoolean(String Value, out Boolean? Result)
        {
            if (!ClassStringTools.IsNullOrWhiteSpace(Value))
            {
                if (Value == "null")
                    Result = null;
                else if (Value == "1")
                    Result = true;
                else if (Value.ToLower() == "true")
                    Result = true;
                else
                    Result = false;
                return true;
            }
            Result = null;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine double konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToDouble(string Value, out double Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "NaN")
            {
                Result = double.NaN;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (double.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0.0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine double konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToDouble(string Value, out double? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            if (ClassStringTools.trimToEmpty(Value) == "NaN")
            {
                Result = Double.NaN;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            Double temp;
            if (Double.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0.0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine decimal konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToDecimal(string Value, out decimal Result)
        {
            if (!String.IsNullOrEmpty(Value))
            {
                if (Value[0] == '"') Value = Value.Remove(0);
                if (Value[Value.Length - 1] == '"') Value = Value.Remove(Value.Length - 1);
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (decimal.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0.0m;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine decimal konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToDecimal(string Value, out decimal? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            if (!String.IsNullOrEmpty(Value))
            {
                if (Value[0] == '"') Value = Value.Remove(0);
                if (Value[Value.Length - 1] == '"') Value = Value.Remove(Value.Length - 1);
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            decimal temp;
            if (decimal.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0.0m;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine float konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToFloat(string Value, out float Result)
        {
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (float.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0.0f;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen Floating-Number-String in eine float konvertiert</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" => 1000.123)
        /// ("-1.6E-3" "-1,6E-3" = -0.0016)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToFloat(string Value, out float? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            float temp;
            if (float.TryParse(NormalFloatingNumber(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0.0f;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int16-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt16(string Value, out Int16 Result)
        {
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (Int16.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int16-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt16(string Value, out Int16? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            Int16 temp;
            if (Int16.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int32-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt32(string Value, out Int32 Result)
        {
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (Int32.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int32-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt32(string Value, out Int32? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            Int32 temp;
            if (Int32.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int64-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt64(string Value, out Int64 Result)
        {
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            if (Int64.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out Result))
                return true;
            Result = 0;
            return false;
        }
        /// <summary>Sehr stabile Funktion, welche einen ZahlenString in eine Int64-Zahl umwandelt.
        /// Eventuell vorhandene Nachkommawerte werden entfernt</summary>
        /// <param name="Value">ZahlText ("1 000.123" "1 000,123" "1.000,123" "1,000.123" " => 1000)
        /// ("-1.6E-3" "-1,6E-3" = 0) ("-1.6E+3" "-1,6E+3" = -1600)</param>
        /// <param name="Result">Ausgabe Zahl</param>
        /// <returns>true = i.O. | false = Error</returns>
        public static bool StringToInt64(string Value, out Int64? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencyDecimalSeparator = ".";
            ni.CurrencyGroupSeparator = "";
            Int64 temp;
            if (Int64.TryParse(NormalInteger(Value), NumberStyles.Any, ni, out temp))
            {
                Result = temp;
                return true;
            }
            Result = 0;
            return false;
        }
        /// <summary>Wandelt einen String mit einem UTF32Code in einen Char um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToChar(String Value, out Char Result)
        {
            Int32 i;
            if (ClassConverters.StringToInt32(Value, out i))
            {
                Result = Char.ConvertFromUtf32(i)[0];
                return true;
            }
            Result = ' ';
            return false;
        }
        /// <summary>Wandelt einen String mit einem UTF32Code in einen Char um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToChar(String Value, out Char? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            Int32 i;
            if (ClassConverters.StringToInt32(Value, out i))
            {
                Result = Char.ConvertFromUtf32(i)[0];
                return true;
            }
            Result = ' ';
            return false;
        }
        /// <summary>Wandelt einen String in eine Guid um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToGuid(String Value, out Guid Result)
        {
            try
            {
                Result = new Guid(Value);
                return true;
            }
            catch
            {
                Result = Guid.Empty;
                return false;
            }
        }
        /// <summary>Wandelt einen String in eine Guid um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToGuid(String Value, out Guid? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            try
            {
                Result = new Guid(Value);
                return true;
            }
            catch
            {
                Result = Guid.Empty;
                return false;
            }
        }
        /// <summary>Wandelt einen String in eine DateTime um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToDateTime(String Value, out DateTime Result)
        {
            if (DateTime.TryParse(Value, out Result))
                return true;
            Result = new DateTime();
            return false;
        }
        /// <summary>Wandelt einen String in eine DateTime um</summary>
        /// <param name="Value"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static bool StringToDateTime(String Value, out DateTime? Result)
        {
            if (ClassStringTools.trimToEmpty(Value) == "null")
            {
                Result = null;
                return true;
            }
            DateTime temp;
            if (DateTime.TryParse(Value, out temp))
            {
                Result = temp;
                return true;
            }
            Result = new DateTime();
            return false;
        }
        /// <summary>Wandelt einen String in eine Typisierte Enum um</summary>
        /// <param name="value"></param>
        /// <param name="typeOfEnum"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool StringToEnum(String value, Type typeOfEnum, out Object result)
        {
            try
            {
                if (Nullable.GetUnderlyingType(typeOfEnum) != null)
                {
                    if (value == "null")
                    {
                        result = null;
                        return true;
                    }
                }
                result = Enum.Parse(typeOfEnum, value);
                return true;
            }
            catch { }
            result = null;
            return false;
        }
        /// <summary>Wandelt einen Text in eine Farbe um (A0R255G255B255) = transparent</summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Boolean stringToDrawingColor(String value, out System.Drawing.Color result)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                value = value.ToUpper();
                if ((value.Contains("A")) && (value.Contains("R")) && (value.Contains("G")) && (value.Contains("B")))
                {
                    Int16 a = 0;
                    Int16 r = 255;
                    Int16 g = 255;
                    Int16 b = 255;
                    Int16.TryParse(value.Substring(value.IndexOf('A') + 1, value.IndexOf('R') - value.IndexOf('A') - 1), out a);
                    Int16.TryParse(value.Substring(value.IndexOf('R') + 1, value.IndexOf('G') - value.IndexOf('R') - 1), out r);
                    Int16.TryParse(value.Substring(value.IndexOf('G') + 1, value.IndexOf('B') - value.IndexOf('G') - 1), out g);
                    Int16.TryParse(value.Substring(value.IndexOf('B') + 1), out b);
                    result = System.Drawing.Color.FromArgb(a, r, g, b);
                    return true;
                }
            }
            result = System.Drawing.Color.Transparent;
            return false;
        }
        #endregion StringTo..

        #region InVariantCulture
        /// <summary>Gibt eine String im Format "1000" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(Int16 Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im Format "1000" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(Int32 Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im Format "1000" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(Int64 Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im Format "1000.123456" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(double Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im Format "1000.123456" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(decimal Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im Format "1000.123456" zurück</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToInvariantCultureString(float Value)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        #endregion InVariantCulture

        #region generische Aufrufe
        /// <summary>Gibt einen Text des Inhaltes der value zurück. Umwandlung entsprechend seines Types</summary>
        /// <param name="text">Der Text</param>
        /// <param name="valueType"></param>
        /// <param name="result">das Objekt aus dem text in den Typ</param>
        /// <returns></returns>
        public static Boolean getValueFromString(String text, Type valueType, out object result)
        {
            Boolean isOkay = false;
            result = null;
            if (valueType == typeof(Int16))
            {
                Int16 temp;
                if (StringToInt16(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Int16?))
            {
                Int16? temp;
                if (StringToInt16(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Int32))
            {
                Int32 temp;
                if (StringToInt32(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Int32?))
            {
                Int32? temp;
                if (StringToInt32(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Int64))
            {
                Int64 temp;
                if (StringToInt64(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Int64?))
            {
                Int64? temp;
                if (StringToInt64(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Double))
            {
                Double temp;
                if (StringToDouble(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Double?))
            {
                Double? temp;
                if (StringToDouble(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(DateTime))
            {
                DateTime temp;
                if (StringToDateTime(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(DateTime?))
            {
                DateTime? temp;
                if (StringToDateTime(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Boolean))
            {
                Boolean temp;
                if (StringToBoolean(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Boolean?))
            {
                Boolean? temp = false;
                if (StringToBoolean(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Char))
            {
                Char temp;
                if (StringToChar(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Char?))
            {
                Char? temp;
                if (StringToChar(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Decimal))
            {
                Decimal temp;
                if (StringToDecimal(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Decimal?))
            {
                Decimal? temp;
                if (StringToDecimal(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(float))
            {
                float temp;
                if (StringToFloat(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(float?))
            {
                float? temp;
                if (StringToFloat(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Guid))
            {
                Guid temp;
                if (StringToGuid(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(Guid?))
            {
                Guid? temp;
                if (StringToGuid(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType == typeof(String))
            {
                isOkay = true;
                result = text;
            }
            else if (valueType == typeof(Enum))
            {
                isOkay = StringToEnum(text, valueType, out result);
            }
            else if (valueType == typeof(System.Drawing.Color))
            {
                System.Drawing.Color temp;
                if (stringToDrawingColor(text, out temp))
                {
                    isOkay = true;
                    result = temp;
                }
            }
            else if (valueType.IsEnum)
            {
                isOkay = StringToEnum(text, valueType, out result);
            }
            else if (valueType.BaseType == typeof(Array))
            {
                String[] items = text.Split(new String[] { ListDelimiter }, StringSplitOptions.None);
                Type itemType = valueType.GetElementType();
                result = Array.CreateInstance(itemType, items.Length);
                Object itemValue;
                for (Int32 i = 0; i < items.Length; i++)
                {
                    if (getValueFromString(items[i], itemType, out itemValue))
                        ((Array)result).SetValue(itemValue, i);
                }
            }
            return isOkay;
        }
        /// <summary>Gibt einen Text des Inhaltes der value zurück. Umwandlung entsprechend seines Types</summary>
        /// <param name="value"></param>
        /// <param name="valueType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Boolean getStringFromValue(Object value, Type valueType, out String result)
        {
            Boolean isOkay = true;
            result = null;
            result = "  ";
            try
            {
                if (valueType == typeof(Int16))
                    result = ClassConverters.ToString((Int16)value, ".", "");
                else if (valueType == typeof(Int16?))
                    result = ClassConverters.ToString((Int16?)value, ".", "");
                else if (valueType == typeof(Int32))
                    result = ClassConverters.ToString((Int32)value, ".", "");
                else if (valueType == typeof(Int32?))
                    result = ClassConverters.ToString((Int32?)value, ".", "");
                else if (valueType == typeof(Int64))
                    result = ClassConverters.ToString((Int64)value, ".", "");
                else if (valueType == typeof(Int64?))
                    result = ClassConverters.ToString((Int64?)value, ".", "");
                else if (valueType == typeof(Double))
                    result = ClassConverters.ToString((Double)value, ".", "");
                else if (valueType == typeof(Double?))
                    result = ClassConverters.ToString((Double?)value, ".", "");
                else if (valueType == typeof(DateTime))
                    result = ClassConverters.ToString((DateTime)value);
                else if (valueType == typeof(DateTime?))
                    result = ClassConverters.ToString((DateTime?)value);
                else if (valueType == typeof(Boolean))
                    result = ClassConverters.ToString((Boolean)value);
                else if (valueType == typeof(Boolean?))
                    result = ClassConverters.ToString((Boolean?)value);
                else if (valueType == typeof(Char))
                    result = ClassConverters.ToString((Char)value);
                else if (valueType == typeof(Char?))
                    result = ClassConverters.ToString((Char)value);
                else if (valueType == typeof(Decimal))
                    result = ClassConverters.ToString((Decimal)value, ".", "");
                else if (valueType == typeof(Decimal?))
                    result = ClassConverters.ToString((Decimal?)value, ".", "");
                else if (valueType == typeof(float))
                    result = ClassConverters.ToString((float)value, ".", "");
                else if (valueType == typeof(float?))
                    result = ClassConverters.ToString((float?)value, ".", "");
                else if (valueType == typeof(Guid))
                    result = ClassConverters.ToString((Guid)value);
                else if (valueType == typeof(Guid?))
                    result = ClassConverters.ToString((Guid)value);
                else if (valueType == typeof(String))
                    result = (String)value;
                else if (valueType == typeof(Enum))
                    result = ClassConverters.ToString((Enum)value);
                else if (valueType == typeof(System.Drawing.Color))
                    result = ToString((System.Drawing.Color)value);
                else if (valueType.IsEnum)
                    result = ClassConverters.ToString((Enum)value);
                else if (valueType.BaseType == typeof(Array))
                {
                    result = "";
                    String itemString;
                    Type itemType = valueType.GetElementType();
                    foreach (Object item in (Array)value)
                    {
                        if (ClassConverters.getStringFromValue(item, itemType, out itemString))
                            result += itemString + ListDelimiter;
                    }
                    if (result.EndsWith(ListDelimiter))
                        result = result.Remove(result.Length - ListDelimiter.Length);
                }
                else
                    isOkay = false;
            }
            catch  { }
            return isOkay;
        }
        /// <summary>Nicht statische Funktion zum Überschreiben und weiter nutzen in Derivaten</summary>
        /// <param name="text"></param>
        /// <param name="valueType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public Boolean getValueFromStringNoStatic(String text, Type valueType, out object result)
        {
            return ClassConverters.getValueFromString(text, valueType, out result);
        }
        /// <summary>Nicht statische Funktion zum Überschreiben und weiter nutzen in Derivaten</summary>
        /// <param name="value"></param>
        /// <param name="valueType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public Boolean getStringFromValueNoStatic(Object value, Type valueType, out String result)
        {
            return ClassConverters.getStringFromValue(value, valueType, out result);
        }
        #endregion generische Aufrufe

        #region ToString
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(double Value, string DecimalSeperator, string GroupSeparator)
        {
            // geändert von G auf F20 um Gleitkommewete zu verhindern
            return removeFinalZeros(Value.ToString("F20", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(double? Value, string DecimalSeperator, string GroupSeparator)
        {
            // geändert von G auf F20 um Gleitkommewete zu verhindern
            if (Value == null) return "null";
            return removeFinalZeros(Value.Value.ToString("F20", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <param name="digits">Anzahl Nachkommastellen</param>
        /// <returns></returns>
        public static string ToString(double Value, string DecimalSeperator, string GroupSeparator, int digits)
        {
            Value = Math.Round(Value, digits, MidpointRounding.ToEven);
            // geändert von G auf F20 um Gleitkommewete zu verhindern
            String format = "F" + digits.ToString().Trim();
            return Value.ToString(format, CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <param name="digits">Anzahl Nachkommastellen</param>
        /// <returns></returns>
        public static string ToString(double? Value, string DecimalSeperator, string GroupSeparator, int digits)
        {
            if (Value == null) return "null";
            double temp = Math.Round(Value.Value, digits, MidpointRounding.ToEven);
            // geändert von G auf F20 um Gleitkommewete zu verhindern
            String format = "F" + digits.ToString().Trim();
            return temp.ToString(format, CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <param name="digits">Anzahl Nachkommastellen</param>
        /// <param name="naNasWithSpace"></param>
        /// <returns></returns>
        public static string ToString(double Value, string DecimalSeperator, string GroupSeparator, int digits, Boolean naNasWithSpace)
        {
            if (Double.IsNaN(Value)) return "";
            if (Double.IsInfinity(Value)) return "";
            if (Double.IsNegativeInfinity(Value)) return "";
            if (Double.IsPositiveInfinity(Value)) return "";
            if (Value >= Double.MaxValue) return "";
            if (Value <= Double.MinValue) return "";
            Value = Math.Round(Value, digits, MidpointRounding.ToEven);
            String format = "{0:0.";
            if (digits > 0)
                format += new String('0', digits) + "}";
            else
                format += "##}";
            return String.Format(CultureInfo.InvariantCulture, format, Value).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <param name="digits">Anzahl Nachkommastellen</param>
        /// <param name="cut0ToDigit">wenn die Nachkommastellen 0 sind, dann nur diese Anzahl</param>
        /// <param name="naNasWithSpace"></param>
        /// <returns></returns>
        public static string ToString(double Value, string DecimalSeperator, string GroupSeparator, int digits, int cut0ToDigit, Boolean naNasWithSpace)
        {
            if (Double.IsNaN(Value)) return "";
            if (Double.IsInfinity(Value)) return "";
            if (Double.IsNegativeInfinity(Value)) return "";
            if (Double.IsPositiveInfinity(Value)) return "";
            if (Value >= Double.MaxValue) return "";
            if (Value <= Double.MinValue) return "";
            Value = Math.Round(Value, digits, MidpointRounding.ToEven);
            String format = "{0:0.";
            if (digits > 0)
                format += new String('0', digits) + "}";
            else
                format += "##}";
            String result = String.Format(CultureInfo.InvariantCulture, format, Value).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
            if (cut0ToDigit < digits)
            {
                for (int i = 1; i <= digits - cut0ToDigit; i++)
                {
                    if (result.Last() == '0')
                    {
                        result = result.Remove(result.Length - 1);
                    }
                    else
                        break;
                }
            }
            return result;
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <param name="digits">Anzahl Nachkommastellen</param>
        /// <param name="naNasWithSpace"></param>
        /// <returns></returns>
        public static string ToString(double? Value, string DecimalSeperator, string GroupSeparator, int digits, Boolean naNasWithSpace)
        {
            if (Value == null) return "null";
            if (Double.IsNaN(Value.Value)) return "NaN";
            if (Double.IsInfinity(Value.Value)) return "";
            if (Double.IsNegativeInfinity(Value.Value)) return "";
            if (Double.IsPositiveInfinity(Value.Value)) return "";
            if (Value >= Double.MaxValue) return "";
            if (Value <= Double.MinValue) return "";
            Value = Math.Round(Value.Value, digits, MidpointRounding.ToEven);
            String format = "{0:0.";
            if (digits > 0)
                format += new String('0', digits) + "}";
            else
                format += "##}";
            return String.Format(CultureInfo.InvariantCulture, format, Value).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
            //return String.Format(format, Value).Replace(".", "#").Replace(",", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(decimal Value, string DecimalSeperator, string GroupSeparator)
        {
            // geändert von G auf F28 um Gleitkommewete zu verhindern
            return removeFinalZeros(Value.ToString("F28", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(decimal? Value, string DecimalSeperator, string GroupSeparator)
        {
            if (Value == null) return "null";
            // geändert von G auf F28 um Gleitkommewete zu verhindern
            return removeFinalZeros(Value.Value.ToString("F28", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(float Value, string DecimalSeperator, string GroupSeparator)
        {
            return removeFinalZeros(Value.ToString("G", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(float? Value, string DecimalSeperator, string GroupSeparator)
        {
            if (Value == null) return "null";
            // geändert von G auf F10 um Gleitkommewete zu verhindern
            return removeFinalZeros(Value.Value.ToString("F10", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator));
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int16 Value, string DecimalSeperator, string GroupSeparator)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int16? Value, string DecimalSeperator, string GroupSeparator)
        {
            if (Value == null) return "null";
            return Value.Value.ToString("G", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int32 Value, string DecimalSeperator, string GroupSeparator)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int32? Value, string DecimalSeperator, string GroupSeparator)
        {
            if (Value == null) return "null";
            return Value.Value.ToString("G", CultureInfo.InvariantCulture).Replace(",", "#").Replace(".", DecimalSeperator).Replace("#", GroupSeparator);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int64 Value, string DecimalSeperator, string GroupSeparator)
        {
            return Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Gibt eine String im angegebene Format zurück</summary>
        /// <param name="Value"></param>
        /// <param name="DecimalSeperator">Dezimalstellentrenner</param>
        /// <param name="GroupSeparator">Tausendertrenner</param>
        /// <returns></returns>
        public static string ToString(Int64? Value, string DecimalSeperator, string GroupSeparator)
        {
            if (Value == null) return "null";
            return Value.Value.ToString("G", CultureInfo.InvariantCulture);
        }
        /// <summary>Wandelt eine Color in eine ARGB-Text um</summary>
        /// <param name="thisColor"></param>
        /// <returns></returns>
        public static String ToString(System.Drawing.Color thisColor)
        {
            if (thisColor == null) return "A0R255G255B255"; // transparent
            return "A" + thisColor.A.ToString().Trim() + "R" + thisColor.R.ToString().Trim() + "G" + thisColor.G.ToString().Trim() + "B" + thisColor.B.ToString().Trim();
        }
        /// <summary>Wandelt einen Char in einen Text mit der Codnummer in UTF32 um</summary>
        /// <param name="thisChar"></param>
        /// <returns></returns>
        public static String ToString(Char thisChar)
        {
            String s = "A" + thisChar;
            Int32 i = Char.ConvertToUtf32(s, 1);
            return ClassConverters.ToString(i, "", "");
        }
        /// <summary>Wandelt einen Boolean in Text um</summary>
        /// <param name="thisBool"></param>
        /// <returns></returns>
        public static String ToString(Boolean thisBool)
        {
            return thisBool ? "1" : "0";
        }
        /// <summary>Wandelt einen Boolean? in Text um (null=null)</summary>
        /// <param name="thisBool"></param>
        /// <returns></returns>
        public static String ToString(Boolean? thisBool)
        {
            if (thisBool == null) return "null";
            return thisBool.Value ? "1" : "0";
        }
        /// <summary>Wandelt eine GUID in einen Text um</summary>
        /// <param name="thisGuid"></param>
        /// <returns></returns>
        public static String ToString(Guid thisGuid)
        {
            if (thisGuid == null) return Guid.Empty.ToString();
            return thisGuid.ToString();
        }
        /// <summary>Wandelt eine DateTime in eine Text (05/01/2009 09:00:00)</summary>
        /// <param name="thisDateTime"></param>
        /// <returns></returns>
        public static String ToString(DateTime thisDateTime)
        {
            return thisDateTime.ToString("dd.MM.yyyy HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
        }
        /// <summary>Wandelt eine DateTime in eine Text (05/01/2009 09:00:00)</summary>
        /// <param name="thisDateTime"></param>
        /// <returns></returns>
        public static String ToString(DateTime? thisDateTime)
        {
            if (thisDateTime == null) return "null";
            return thisDateTime.Value.ToString("dd.MM.yyyy HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
        }
        /// <summary>Wandelt eine Enum in Ihren TextString um</summary>
        /// <param name="thisEnum"></param>
        /// <returns></returns>
        public static String ToString(Enum thisEnum)
        {
            return thisEnum.ToString();
        }
        #endregion ToString

        #region Typisierte Funktionen
        /// <summary>Wandelt eine DateTime in eine Text (15.01.2012)</summary>
        /// <param name="thisDateTime"></param>
        /// <returns></returns>
        public static String prettyPrintDate(DateTime thisDateTime)
        {
            return thisDateTime.ToString("dd.MM.yyyy");
        }
        /// <summary>Wandelt eine DateTime in eine Text (15.01.2012)</summary>
        /// <param name="thisDateTime"></param>
        /// <returns></returns>
        public static String prettyPrintDate(DateTime? thisDateTime)
        {
            if (thisDateTime == null) return "null";
            return thisDateTime.Value.ToString("dd.MM.yyyy");
        }

        /// <summary>Normalisiert einen Zahlenstring für eine Integer - Zahl.
        /// Entfernt eventuell vorhandenen Tausendertrenner und Nachkommastellen.
        /// ("1 000.123"=1000; "1 000,123"=1000; "1.000,123" = 1000
        /// Normalisiert eine Exponentialzahl (1E3 = 1000)</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string NormalInteger(string value)
        {
            if (ClassStringTools.IsNullOrWhiteSpace(value)) return value;
            string result = ClassStringTools.GetExpNumeric(value.Trim());
            if (result.Contains("E"))
            {
                string[] splits = result.Split('E');
                if (splits.Length == 2)
                {
                    Int64 zahl;
                    Int64 potenz;
                    Int64 wert;
                    if (Int64.TryParse(splits[0], out zahl))
                    {
                        if (Int64.TryParse(splits[1], out potenz))
                        {
                            wert = zahl * ((Int64)Math.Pow(10.0, potenz));
                            result = wert.ToString("D").Replace(".", "").Replace(",", "").Trim().Replace(" ", "");
                        }
                    }

                }
            }
            else
            {
                // Testen, ob Kommazahl => Ja = Nachkomma wird abgeschnitten!!            
                if (result.Contains(",") && result.Contains("."))
                {
                    int PosA = result.IndexOf(",");
                    int PosB = result.IndexOf(".");
                    if (PosA > PosB) // "1.000,123" => "1.000"
                        result = result.Remove(PosA);
                    else             // "1,000.123" => "1.000"
                        result = result.Remove(PosB);
                }
                else if (result.Contains(",") && result.Contains(" ")) // "1 000,123" => "1 000"
                    result = result.Remove(value.IndexOf(","));
                else if (value.Contains(".") && value.Contains(" ")) // "1 000.123" => "1 000"
                    result = result.Remove(value.IndexOf("."));

                // "1 000", "1.000", "1,000" => "1000"
                result = result.Replace(".", "").Replace(",", "").Replace(" ", "");
            }
            return result;
        }
        /// <summary>Konvertiert einen Zehlen-String in ein InvariantCulture-ZahlenText = "1234.5678"</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static string NormalFloatingNumber(string Value)
        {
            if (String.IsNullOrEmpty(Value))
                Value = "";
            else
                Value = Value.Trim();
            // Testen, ob Tausender Trenner vorhabden sind  = Entfernen
            if (Value.Contains(",") && Value.Contains("."))
            {
                int PosA = Value.IndexOf(",");
                int PosB = Value.IndexOf(".");
                if (PosA > PosB) // "1.000,123" = "1000.123"
                    Value = Value.Replace(".", "").Replace(",", ".");
                else             // "1,000.123" = "1000.123"
                    Value = Value.Replace(",", "");
            }
            else if (Value.Contains(","))
            {
                Value = Value.Replace(",", ".");
            }
            string result = Value.Replace(" ", "").ToUpper();
            if (result.Contains("E"))
            {
                string[] splits = result.Split('E');
                if (splits.Length == 2)
                {
                    decimal zahl;
                    double potenz;
                    decimal wert;
                    NumberFormatInfo ni = new NumberFormatInfo();
                    ni.NumberDecimalSeparator = ".";
                    ni.NumberGroupSeparator = "";
                    try
                    {
                        zahl = Convert.ToDecimal(splits[0].Replace(",", "."), ni);
                        if (double.TryParse(splits[1], out potenz))
                        {
                            wert = zahl * ((decimal)Math.Pow(10.0, potenz));
                            result = wert.ToString("G", CultureInfo.InvariantCulture);
                        }
                    }
                    catch
                    {
                        result = "0.0";
                    }
                }
            }
            return result;
        }

        #endregion Typisierte Funktionen

        #region Hilfsfunktionen
        /// <summary>Gibt die anzahl der Nachkommastellen der Zahl zurück</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int getDigits(Double value)
        {
            String temp = value.ToString("F", CultureInfo.InvariantCulture);
            int posDecimal = temp.LastIndexOf('.');
            int result = 0;
            for (int t = posDecimal + 1; t < temp.Length; t++)
            {
                if (temp[t] != '0')
                    result = t - posDecimal;
            }
            return result;
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
        /// <summary>Entfernt aus einem ZahlenString ('123.123000') die abschließenden '0',
        /// es bleibt aber mindestens '0.0' erhalten</summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static String removeFinalZeros(String Value)
        {
            if (Value.Contains('.'))
            {
                Int32 minPos = Value.IndexOf('.') + 1;
                Int32 cutPos = minPos + 1;
                for (Int32 i = Value.Length - 1; i > minPos; i--)
                {
                    if (Value[i] != '0')
                    {
                        cutPos = i;
                        break;
                    }
                }
                if ((cutPos + 1) < Value.Length)
                    return Value.Remove(cutPos + 1);
                else
                    return Value;
            }
            return Value;
        }
        #endregion Hilfsfunktionen
    }
}
