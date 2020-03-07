using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>Stellt Funktionen zum unscharfen Vergleichen zur Verfügung</summary>
    public class ClassFuzzyLogic
    {
        /// <summary>Vergleicht zwei Strings 'unscharf' =>(= .Normalize().ToUpper().Trim())</summary>
        /// <param name="a">String für den Vergleich</param>
        /// <param name="b">String für den Vergleich</param>
        /// <returns>True => ist gleich</returns>
        public static bool FuzzyEqual(string a, string b)
        {
            if ((!string.IsNullOrEmpty(a)) && (!string.IsNullOrEmpty(b)))
            {
                string a1 = a.Normalize().ToUpper().Trim();
                string b1 = b.Normalize().ToUpper().Trim();
                if (a1.CompareTo(b1) != 0)
                    return false;
            }
            else
                if (!((string.IsNullOrEmpty(a)) && (string.IsNullOrEmpty(b))))
                    return false;
            return true;
        }

        /// <summary>Vergleicht zwei Double-Zahlen 'unscharf' =>(runden auf dec-Nachkommastellen)</summary>
        /// <param name="a">Double-Zahl für den Vergleich</param>
        /// <param name="b">Double-Zahl für den Vergleich</param>
        /// <param name="dec">Anzahl der Nachkommastellen mit denen Verglichen wird</param>
        /// <returns>True => ist gleich</returns>
        public static bool FuzzyEqual(double a, double b, int dec)
        {
            //if (Math.Round(a+Math.Pow(10,-dec-1), dec) != Math.Round(b+Math.Pow(10,-dec-1), dec)) return false;
            //if (Math.Round(a , dec) != Math.Round(b , dec)) 
            if (Math.Round(Math.Abs(a - b) * Math.Pow(10, (double)dec), 0) > 1)
                return false;
            return true;
        }

        /// <summary>Vergleicht zwei Double-Zahlen 'unscharf' =>(runden auf dec-Nachkommastellen)</summary>
        /// <param name="a">Double-Zahl für den Vergleich</param>
        /// <param name="b">Double-Zahl für den Vergleich</param>
        /// <param name="dec">Anzahl der Nachkommastellen mit denen Verglichen wird</param>
        /// <returns>-1 a(kleiner)b, 0 a==b, 1 a(grösser)b</returns>
        public static int FuzzyCompare(double a, double b, int dec)
        {
            if (Math.Round(a, dec) < Math.Round(b, dec)) return -1;
            if (Math.Round(a, dec) > Math.Round(b, dec)) return 1;
            return 0;
        }

        ///// <summary>Vergleicht zwei Double-Zahlen 'unscharf' =>(runden auf dec-Nachkommastellen)</summary>
        ///// <param name="a">Double-Zahl für den Vergleich</param>
        ///// <param name="b">Double-Zahl für den Vergleich</param>
        ///// <param name="maxDiff">Maximal erlaubte Abweichung</param>
        ///// <returns>True => ist gleich</returns>
        //public static bool FuzzyEqual(double a, double b, Double maxDiff)
        //{
        //    //if (Math.Round(a+Math.Pow(10,-dec-1), dec) != Math.Round(b+Math.Pow(10,-dec-1), dec)) return false;
        //    if (((a - Math.Abs(maxDiff)) <= b) && (b <= (a + Math.Abs(maxDiff)))) return false;
        //    return true;
        //}

        /// <summary>Vergleicht zwei Double-Zahlen 'unscharf' =>(runden auf dec-Nachkommastellen)</summary>
        /// <param name="a">Double-Zahl für den Vergleich</param>
        /// <param name="b">Double-Zahl für den Vergleich</param>
        /// <param name="maxDiff">Maximal erlaubte Abweichung</param>
        /// <returns>-1 a(kleiner)b, 0 a==b, 1 a(grösser)b</returns>
        public static int FuzzyCompare(double a, double b, Double maxDiff)
        {
            if (Double.IsNaN(a) && !Double.IsNaN(b)) return 1;
            if (!Double.IsNaN(a) && Double.IsNaN(b)) return -1;
            if (Double.IsNaN(a) && Double.IsNaN(b)) return 0;
            if ((a - Math.Abs(maxDiff)) > b) return -1;
            if ((a + Math.Abs(maxDiff)) < b) return 1;
            return 0;
        }


        /// <summary>Vergleicht zwei Decimal-Zahlen 'unscharf' =>(runden auf dec-Nachkommastellen)</summary>
        /// <param name="a">Decimal-Zahl für den Vergleich</param>
        /// <param name="b">Decimal-Zahl für den Vergleich</param>
        /// <param name="dec">Anzahl der Nachkommastellen mit denen Verglichen wird</param>
        /// <returns>True => ist gleich</returns>
        public static bool FuzzyEqual(decimal a, decimal b, int dec)
        {
            if (Math.Abs((a - b) * decimal.Parse(Math.Pow(10, dec + 1).ToString())) == 5.0m)
            {
                if (Math.Round(Math.Abs(a) + decimal.Parse(Math.Pow(10, -dec - 1).ToString()), dec) != Math.Round(Math.Abs(b) + decimal.Parse(Math.Pow(10, -dec - 1).ToString()), dec))
                    return false;
            }
            else
            {
                if (Math.Round(a, dec) != Math.Round(b, dec))
                    return false;
            }
            return true;
        }
    }
}
