using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>CADdy Messaten</summary>
    public class ClassCADdyMessdaten
    {
        /// <summary>Spracheinstellung</summary>
        private ClassLanguage language;
        /// <summary>Standpunktdaten</summary>
        private List<ClassCADdyStandpunkt> standpunkte;
        /// <summary>Sind überhaupt Messdaten vorhanden</summary>
        private Boolean hasMessdaten;
        /// <summary>Haben wir Messdaten</summary>
        public bool HasMessdaten
        {
            get { return hasMessdaten; }
        }

        public ClassCADdyMessdaten(ref ClassLanguage language)
        {
            this.language = language;
            standpunkte = new List<ClassCADdyStandpunkt>();
        }

        /// <summary>Messdatenspeicher leeren</summary>
        public void clear()
        {
            standpunkte.Clear();
            hasMessdaten = false;
        }

        /// <summary>Trennt die Punkte aus dem Aktuellem Text</summary>
        /// <param name="settings"></param>
        public void getMeasuresFromCurrentCADdy(Settings settings)
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            standpunkte.Clear();
            if (editor != null)
            {
                Int32 countLines = editor.GetLineCount();
                ClassCADdyStandpunkt cuStandpunkt = null;
                for (Int32 lc = 0; lc < countLines; lc++)
                {
                    String cuLine = editor.GetLine(lc);
                    // Auch Excel Splitbar machen ;-)
                    cuLine = cuLine.Replace('\t', ' '); // Tab durch Leerzeichen ersetzten
                    cuLine = cuLine.Replace(',', settings.Decimalseperator[0]); // , durch . ersetzten
                    String[] split = ClassStringTools.GetFieldsManyDelimiters(cuLine, ' ', true);
                    if (split != null)
                    {
                        if ((4 >= split.Length) && (split.Length >= 3)) // Standpunkt
                        {
                            if (split[0].StartsWith("-"))
                            {
                                if (cuStandpunkt != null) standpunkte.Add(cuStandpunkt);
                                cuStandpunkt = new ClassCADdyStandpunkt();
                                cuStandpunkt.LineNumber = lc;
                                cuStandpunkt.Punktnummer = ClassStringTools.trimToEmpty(split[settings.PointName_Column - 1]);
                                if (settings.PointName_ToUpper) cuStandpunkt.Punktnummer = cuStandpunkt.Punktnummer.ToUpper();
                                Double temp = Double.NaN;
                                if (ClassConverters.StringToDouble(split[settings.Messd_I_Column - 1], out temp))
                                {
                                    cuStandpunkt.I = temp;
                                    // code
                                    cuStandpunkt.Code = ClassStringTools.trimToEmpty(split[settings.Messd_STPKCode_Column - 1]);
                                    if (split.Length == 4)
                                    {   // code
                                        cuStandpunkt.Bemerkung = ClassStringTools.trimToEmpty(split[settings.Messd_STPKDescript_Column - 1]);
                                    }
                                }
                            }
                        }
                        if (split.Length >= 5) // = Zielpunkt
                        {
                            if (cuStandpunkt != null)
                            {
                                ClassCADdyZielung zielung = new ClassCADdyZielung();
                                {
                                    zielung.Zielpunkt = ClassStringTools.trimToEmpty(split[settings.PointName_Column - 1]);
                                    if (settings.PointName_ToUpper) zielung.Zielpunkt = zielung.Zielpunkt.ToUpper();
                                    if (!ClassStringTools.IsNullOrWhiteSpace(zielung.Zielpunkt))
                                    {
                                        Double temp = Double.NaN;
                                        if (ClassConverters.StringToDouble(split[settings.Messd_Hz_Column - 1], out temp))
                                        {
                                            zielung.Hz = temp;
                                            if (ClassConverters.StringToDouble(split[settings.Messd_S_Column - 1], out temp))
                                            {
                                                zielung.S = temp;
                                                if (ClassConverters.StringToDouble(split[settings.Messd_V_Column - 1], out temp))
                                                {
                                                    zielung.V = temp;
                                                    if (ClassConverters.StringToDouble(split[settings.Messd_D_Column - 1], out temp))
                                                    {
                                                        zielung.D = temp;
                                                        if (split.Length >= 6)
                                                        {   // code
                                                            zielung.Code = ClassStringTools.trimToEmpty(split[settings.Messd_Code_Column - 1]);
                                                            if (split.Length >= 7)
                                                            {   // Beschreibung
                                                                zielung.Bemerkung = ClassStringTools.trimToEmpty(split[settings.Messd_Descript_Column - 1]);
                                                            }
                                                        }
                                                    }
                                                    zielung.LineNumber = lc;
                                                    cuStandpunkt.Zielungen.Add(zielung);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // den letzten nicht vergessen
                if (cuStandpunkt != null) standpunkte.Add(cuStandpunkt);
            }
            hasMessdaten = standpunkte.Count > 0;
        }

        /// <summary>Gibt eine CADdy-Formatierte Liste zurück</summary>
        /// <param name="settings"></param>
        public void formatCurrentToCADdy(Settings settings)
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            if (standpunkte.Count > 0)
            {
                Position selStart = editor.GetSelectionStart();
                Position selEnd = editor.GetSelectionEnd();
                editor.BeginUndoAction();
                Position oldPos = editor.GetCurrentPos();
                editor.ClearAll();
                foreach (ClassCADdyStandpunkt item in standpunkte)
                {
                    String temp = item.getCADdyFormatString(settings);
                    editor.AppendText(temp.Length + 1, temp + "\n");
                    foreach (ClassCADdyZielung ziel in item.Zielungen)
                    {
                        temp = ziel.getCADdyFormatString(settings);
                        editor.AppendText(temp.Length + 1, temp + "\n");
                    }
                }
                editor.SetSelection(selStart.Value, selEnd.Value);
                editor.SetCurrentPos(oldPos);
                editor.EndUndoAction();
            }
        }

        /// <summary>Gibt eine CADdy-Formatierte Liste zurück</summary>
        /// <param name="settings"></param>
        public void formatCurrentToCAPLAN(Settings settings)
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            if (standpunkte.Count > 0)
            {
                editor.BeginUndoAction();
                Position oldPos = editor.GetCurrentPos();
                editor.ClearAll();
                Dictionary<String, List<Int32>> stpkIndex = new Dictionary<String, List<Int32>>();
                for (Int32 counter = 0; counter < standpunkte.Count; counter++)
                {
                    if (!stpkIndex.Keys.Contains(standpunkte[counter].Punktnummer))
                        stpkIndex.Add(standpunkte[counter].Punktnummer, new List<Int32>());
                    stpkIndex[standpunkte[counter].Punktnummer].Add(counter);
                }
                foreach (KeyValuePair<String, List<Int32>> stId in stpkIndex)
                {
                    String temp = standpunkte[stId.Value[0]].getCADdyFormatString(settings);
                    editor.AppendText(temp.Length + 1, temp + "\n");
                    foreach (Int32 stpkId in stId.Value)
                    {
                        foreach (ClassCADdyZielung ziel in standpunkte[stpkId].Zielungen)
                        {
                            temp = ziel.getCADdyFormatString(settings);
                            editor.AppendText(temp.Length + 1, temp + "\n");
                        }
                    }
                }
                editor.SetCurrentPos(oldPos);
                editor.EndUndoAction();
            }
        }

        /// <summary>Gibt eine Excel-Formatierte Liste zurück</summary>
        public void formatCurrentToExcel()
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            if (standpunkte.Count > 0)
            {
                editor.BeginUndoAction();
                Position oldPos = editor.GetCurrentPos();
                editor.ClearAll();
                foreach (ClassCADdyStandpunkt item in standpunkte)
                {
                    String temp = item.getExcelFormatString();
                    editor.AppendText(temp.Length + 1, temp + "\n");
                    foreach (ClassCADdyZielung ziel in item.Zielungen)
                    {
                        temp = ziel.getExcelFormatString();
                        editor.AppendText(temp.Length + 1, temp + "\n");
                    }
                }
                editor.SetCurrentPos(oldPos);
                editor.EndUndoAction();
            }                            
        }

        /// <summary>Setzt die Punktnummern auf den angegebenen Code</summary>
        /// <param name="pointnumber"></param>
        /// <param name="newCode"></param>
        /// <returns>true = es wurde mind. ein Code geändert</returns>
        public Boolean setPointNumberToCode(String pointnumber, String newCode)
        {
            Boolean allPoints = false;
            Boolean hasAnyChanged = false;
            if (ClassStringTools.IsNullOrWhiteSpace(pointnumber)) pointnumber = "*";
            if (!ClassStringTools.IsNullOrWhiteSpace(newCode))
            {
                ClassRegexTools regexT = null;
                if (pointnumber == "*")
                    allPoints = true;
                else
                    regexT = new ClassRegexTools(pointnumber);
                IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
                int sLnrStart = -1;
                int sLnrEnd = -1;
                if (editor != null)
                {
                    sLnrStart = editor.LineFromPosition(editor.GetSelectionStart());
                    sLnrEnd = editor.LineFromPosition(editor.GetSelectionEnd());
                    if (editor.GetColumn(editor.GetSelectionEnd()) < 2)
                        sLnrEnd--;
                }
                foreach (ClassCADdyStandpunkt item in standpunkte)
                {
                    if (allPoints || regexT.isMatch(item.Punktnummer.Substring(1)))
                    {
                        if ((sLnrStart >= 0) && (sLnrEnd >= 0))
                        {
                            if ((item.LineNumber >= sLnrStart) && (item.LineNumber <= sLnrEnd))
                            {
                                item.Code = newCode;
                                hasAnyChanged = true;
                            }
                        }
                        else
                        {
                            item.Code = newCode;
                            hasAnyChanged = true;
                        }
                    }
                    foreach (ClassCADdyZielung ziel in item.Zielungen)
                    {
                        if (allPoints || regexT.isMatch(ziel.Zielpunkt))
                        {
                            if ((sLnrStart >= 0) && (sLnrEnd >= 0))
                            {
                                if ((ziel.LineNumber >= sLnrStart) && (ziel.LineNumber <= sLnrEnd))
                                {
                                    ziel.Code = newCode;
                                    hasAnyChanged = true;
                                }
                            }
                            else
                            {
                                ziel.Code = newCode;
                                hasAnyChanged = true;
                            }
                        }
                    }
                }
            }
            return hasAnyChanged;
        }
        /// <summary>Setzt den vorhanden Code auf den angegebenen Code</summary>
        /// <param name="oldCode"></param>
        /// <param name="newCode"></param>
        /// <returns>true = es wurde mind. ein Code geändert</returns>
        public Boolean setOldCodeToNewCode(String oldCode, String newCode)
        {
            Boolean allPoints = false;
            Boolean hasAnyChanged = false;
            if (ClassStringTools.IsNullOrWhiteSpace(oldCode)) oldCode = "*";
            if (!ClassStringTools.IsNullOrWhiteSpace(newCode))
            {
                ClassRegexTools regexT = null;
                if (oldCode == "*")
                    allPoints = true;
                else
                    regexT = new ClassRegexTools(oldCode);
                foreach (ClassCADdyStandpunkt item in standpunkte)
                {
                    if (allPoints || regexT.isMatch(item.Code))
                    {
                        item.Code = newCode;
                        hasAnyChanged = true;
                    }
                    foreach (ClassCADdyZielung ziel in item.Zielungen)
                    {
                        if (allPoints || regexT.isMatch(ziel.Code))
                        {
                            ziel.Code = newCode;
                            hasAnyChanged = true;
                        }
                    }
                }
            }
            return hasAnyChanged;
        }
        /// <summary>Gibt eine unsortierte Liste der Punktnummern zurück</summary>
        /// <returns></returns>
        public List<String> getDestinctPointnumbers()
        {
            List<String> result = new List<String>();
            foreach (ClassCADdyStandpunkt stpk in standpunkte)
            {
                String stpkNr = stpk.Punktnummer;
                if (stpkNr.StartsWith("-")) stpkNr = stpkNr.Substring(1);
                if (!result.Contains(stpkNr))
                    result.Add(stpkNr);
                foreach (ClassCADdyZielung ziel in stpk.Zielungen)
                {
                    if (!result.Contains(ziel.Zielpunkt))
                        result.Add(ziel.Zielpunkt);
                }
            }
            return result;
        }
        /// <summary>Gibt eine unsortierte Liste der Codes zurück</summary>
        /// <returns></returns>
        public List<String> getDestinctCodes()
        {
            List<String> result = new List<String>();
            foreach (ClassCADdyStandpunkt stpk in standpunkte)
            {
                if (!result.Contains(stpk.Code))
                    result.Add(stpk.Code);
                foreach (ClassCADdyZielung ziel in stpk.Zielungen)
                {
                    if (!result.Contains(ziel.Code))
                        result.Add(ziel.Code);
                }
            }
            return result;
        }

        /// <summary>Setzt die Punktnummern auf den angegebenen Code</summary>
        /// <param name="pointnumber"></param>
        /// <param name="i_d"></param>
        /// <returns>true = es wurde mind. ein Code geändert</returns>
        public Boolean setPointNumberToIDe(String pointnumber, Double i_d)
        {
            Boolean allPoints = false;
            Boolean hasAnyChanged = false;
            if (ClassStringTools.IsNullOrWhiteSpace(pointnumber)) pointnumber = "*";
            if (!Double.IsNaN(i_d))
            {
                ClassRegexTools regexT = null;
                if (pointnumber == "*")
                    allPoints = true;
                else
                    regexT = new ClassRegexTools(pointnumber);
                foreach (ClassCADdyStandpunkt item in standpunkte)
                {
                    if (allPoints || regexT.isMatch(item.Punktnummer.Substring(1)))
                    {
                        item.I = i_d;
                        hasAnyChanged = true;
                    }
                    foreach (ClassCADdyZielung ziel in item.Zielungen)
                    {
                        if (allPoints || regexT.isMatch(ziel.Zielpunkt))
                        {
                            ziel.D = i_d;
                            hasAnyChanged = true;
                        }
                    }
                }
            }
            return hasAnyChanged;
        }
    }
}
