using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>Vereinfachung von Regex Abfragen</summary>
    public class ClassRegexTools
    {
        /// <summary> der zu verwendende Regexausdruck</summary>
        private String regexSearch;

        /// <summary>der regex Matcher</summary>
        private Regex checker;

        /// <summary>Konstruktor</summary>
        /// <param name="searchString"></param>
        public ClassRegexTools(String searchString)
        {
            parseSearchString(searchString);
        }

        /// <summary>Suchstring umsetzten</summary>
        /// <param name="sString"></param>
        private void parseSearchString(String sString)
        {
            if (!ClassStringTools.IsNullOrWhiteSpace(sString))
            {
                if (sString == "*")
                    regexSearch = ".*";
                else if (sString.StartsWith("*"))
                {
                    sString = sString.Replace(".", @"\.");
                    regexSearch = "^(.*)(" + sString.Substring(1) + ")$";
                }
                else if (sString.EndsWith("*"))
                {
                    sString = sString.Replace(".", @"\.");
                    regexSearch = "^(" + sString.Substring(0, sString.Length - 1) + ")(.*)$";
                }
                else if (Regex.IsMatch(sString, @"^(?:\w|\d|\s|\.|-)*$"))
                    regexSearch = "^(" + sString + ")$";
                else
                    regexSearch = sString;
                checker = new Regex(regexSearch);
            }
        }
        public Boolean isMatch(String checkIt)
        {
            return checker.IsMatch(checkIt);
        }
    }
}
