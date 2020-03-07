using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>in System.Math fehlende Funktionen</summary>
    public class ClassMath
    {
        /// <summary>Gibt die Anzahl der Nachkommastellen der Zahl zurück</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 getDigitCount(Double value)
        {
            return (Decimal.GetBits((Decimal)value)[3] >> 16) & 0x000000FF;
        }

        /// <summary>Gibt die Anzahl der Nachkommastellen der Zahl als 0.0xxx1 (ohne nk = 1) zurück</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double getDigitFactor(Double value)
        {
            return Math.Pow(0.1, ((Decimal.GetBits((Decimal)value)[3] >> 16) & 0x000000FF));
        }

        /// <summary>Rundet eine Double Zahl auf die angegebene Genauigkeit,
        /// Wenn die Zahl genau in der Mitte liegt wird auf die gerade Zahl gerundet(0 ist gerade)</summary>
        /// <param name="value"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static Double round(Double value, Double precision)
        {
            if (Double.IsNaN(value)) return Double.NaN;
            if (Double.IsNaN(precision)) return Double.NaN;
            Double factor = 1.0 / precision;
            Double result = Math.Round(value * factor, 0, MidpointRounding.ToEven) / factor;
            return result;
        }

        /// <summary>prüft, ob sich 'checkThis' zwischen a und b befindet.</summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="checkThis"></param>
        /// <returns></returns>
        public static Boolean isBetween(Double a, Double b, Double checkThis)
        {
            Double min = Math.Min(a, b);
            Double max = Math.Max(a, b);
            return ((checkThis >= min) && (checkThis <= max));
        }

        /// <summary>Gibt einen Formatierten String zurük, der die (genutzen) Nachkommastellen von precision holt</summary>
        /// <param name="value"></param>
        /// <param name="decimalSeperator"></param>
        /// <param name="groupSeperator"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static String ToString(Double value, String decimalSeperator, String groupSeperator, Double precision)
        {
            Int32 nks = getDigitCount(precision);
            return ClassConverters.ToString(value, decimalSeperator, groupSeperator, nks, true);
        }

        /// <summary>Test, ob sich die value im 'normalen' Zahlenbereich (Double.MaxValue >= value >= Double.MinValue) befindet,
        /// Und ob es nicht NAN oder IsInfinity o.ä ist</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean isGoodDouble(Double value)
        {
            if (!Double.IsNaN(value))
            {
                if (!Double.IsInfinity(value))
                {
                    if (!Double.IsNegativeInfinity(value))
                    {
                        if (!Double.IsPositiveInfinity(value))
                        {
                            if (value <= Double.MaxValue)
                            {
                                if (value >= Double.MinValue)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>Gibt eine Liste von Rasterwerten zurück, die einem bei 0.0 beginnenden Raster mit den Abschnitten 'ratser'
        /// entsprechen und zwischen start und ende liegen. Start muss kleiner ende sein</summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="raster"></param>
        /// <returns></returns>
        public static List<Double> getRaster(Double start, Double end, Double raster)
        {
            List<Double> result = new List<Double>();
            if (start < end)
            {
                Double firstRaster = Math.Round((start / raster), 0, MidpointRounding.AwayFromZero) * raster;
                while (firstRaster <= end)
                {
                    if (firstRaster >= start)
                        result.Add(firstRaster);
                    firstRaster += raster;
                }
            }
            return result;
        }
    }
}
