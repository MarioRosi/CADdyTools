using Kbg.NppPluginNET;
using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Liest CADdy-Punktlisten ein und Schreibt diese</summary>
    public class ClassCADdyPunkte
    {
        #region Eigenschaften
        /// <summary>Spracheinstellung</summary>
        private ClassLanguage language;

        private List<ClassCADdyPunkt> punkte;
        /// <summary>Sind überhaupt Daten vorhanden?</summary>
        private Boolean hasPunkte;
        /// <summary>Sind überhaupt Daten vorhanden?</summary>
        public bool HasPunkte
        {
            get { return hasPunkte; }
        }

        public List<ClassCADdyPunkt> Punkte
        {
            get { return punkte; }
        }
        #endregion Eigenschaften

        #region Methoden
        /// <summary>Constructor</summary>
        /// <param name="language"></param>
        public ClassCADdyPunkte(ref ClassLanguage language)
        {
            this.language = language;
            punkte = new List<ClassCADdyPunkt>();
        }

        /// <summary>Destruktor</summary>
        ~ClassCADdyPunkte()
        {
            language = null;
            punkte.Clear();
        }

        /// <summary>daten leeren</summary>
        public void clear()
        {
            punkte.Clear();
            hasPunkte = false;
        }


        /// <summary>Sortiert die Punkte nach der angegebenen Spalte</summary>
        /// <param name="column"></param>
        public void sortBy(enPointColumn column)
        {
            switch (column)
            {
                case enPointColumn.colPointnumber:
                    punkte.Sort((a, b) => a.Punktnummer.CompareTo(b.Punktnummer));
                    break;
                case enPointColumn.colEast:
                    punkte.Sort((a, b) => a.Rechtswert.CompareTo(b.Rechtswert));
                    break;
                case enPointColumn.colNorth:
                    punkte.Sort((a, b) => a.Hochwert.CompareTo(b.Hochwert));
                    break;
                case enPointColumn.colElev:
                    punkte.Sort((a, b) => a.Hoehe.CompareTo(b.Hoehe));
                    break;
                case enPointColumn.colCode:
                    punkte.Sort((a, b) => a.Code.CompareTo(b.Code));
                    break;
            }
        }

        /// <summary>Trennt die Punkte aus dem aktuellem Text</summary>
        /// <param name="settings"></param>
        public void getPointsFromCurrentCADdy(Settings settings)
        {
            getPointsFromEditor(settings, new ScintillaGateway(PluginBase.GetCurrentScintilla()));
        }

        /// <summary>Trennt die Punkte aus dem angegebenen Text</summary>
        /// <param name="settings"></param>
        /// <param name="editor"></param>
        public void getPointsFromEditor(Settings settings, IScintillaGateway editor)
        {
            punkte.Clear();
            if (editor != null)
            {
                Int32 countLines = editor.GetLineCount();
                for (Int32 lc = 0; lc < countLines; lc++)
                {
                    String cuLine = editor.GetLine(lc);
                    // Auch Excel Splitbar machen ;-)
                    cuLine = cuLine.Replace('\t', ' '); // Tab durch Leerzeichen ersetzten
                    cuLine = cuLine.Replace(',', settings.Decimalseperator[0]); // , durch . ersetzten
                    String[] split = ClassStringTools.GetFieldsManyDelimiters(cuLine, ' ', true);
                    if (split != null)
                    {
                        if (split.Length >= 4) // mind PNR R H E
                        {
                            ClassCADdyPunkt newPoint = new ClassCADdyPunkt();
                            {
                                newPoint.Punktnummer = ClassStringTools.trimToEmpty(split[settings.PointName_Column - 1]);
                                if (settings.PointName_ToUpper) newPoint.Punktnummer = newPoint.Punktnummer.ToUpper();
                                if (!ClassStringTools.IsNullOrWhiteSpace(newPoint.Punktnummer))
                                {
                                    Double temp = Double.NaN;
                                    if (ClassConverters.StringToDouble(split[settings.Koord_RW_E_Column - 1], out temp))
                                    {
                                        newPoint.Rechtswert = temp;
                                        if (ClassConverters.StringToDouble(split[settings.Koord_HW_N_Column - 1], out temp))
                                        {
                                            newPoint.Hochwert = temp;
                                            if (ClassConverters.StringToDouble(split[settings.Koord_Elev_Column - 1], out temp))
                                            {
                                                newPoint.Hoehe = temp;
                                                newPoint.LineNumber = lc;
                                                if (split.Length >= 5)
                                                {   // code
                                                    newPoint.Code = ClassStringTools.trimToEmpty(split[settings.Koord_Code_Column - 1]);
                                                    if (split.Length >= 6)
                                                    {   // code
                                                        newPoint.Bemerkung = ClassStringTools.trimToEmpty(split[settings.Koord_Descript_Column - 1]);
                                                    }
                                                }
                                                punkte.Add(newPoint);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            hasPunkte = punkte.Count > 0;
        }

        /// <param name="settings"></param>
        public void formatCurrentToCADdy(Settings settings)
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            if (Punkte.Count > 0)
            {
                Position oldPos = editor.GetCurrentPos();
                Position selStart = editor.GetSelectionStart();
                Position selEnd = editor.GetSelectionEnd();
                editor.BeginUndoAction();
                editor.ClearAll();
                foreach (ClassCADdyPunkt item in Punkte)
                {
                    String temp = item.getCADdyFormatString(settings);
                    editor.AppendText(temp.Length + 1, temp + Environment.NewLine);
                }
                editor.ConvertEOLs(0);
                editor.EndUndoAction();
                editor.SetCurrentPos(oldPos);
                editor.SetSelection(selStart.Value, selEnd.Value);
                //editor.ClearSelectionToCursor();
            }
        }

        /// <summary>Gibt eine Excel-Formatierte Liste zurück</summary>
        public void formatCurrentToExcel()
        {
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());            
            if (Punkte.Count > 0)
            {
                Position oldPos = editor.GetCurrentPos();
                editor.BeginUndoAction();
                editor.ClearAll();
                foreach (ClassCADdyPunkt item in Punkte)
                {
                    String temp = item.getExcelFormatString();
                    editor.AppendText(temp.Length + 1, temp + Environment.NewLine);
                }
                editor.ConvertEOLs(0);
                editor.EndUndoAction();
                editor.SetCurrentPos(oldPos);
                editor.ClearSelectionToCursor();
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
                ClassRegexTools regexT = null;
                if (pointnumber == "*")
                    allPoints = true;
                else
                    regexT = new ClassRegexTools(pointnumber);
                foreach (ClassCADdyPunkt item in Punkte)
                {
                    if (allPoints || regexT.isMatch(item.Punktnummer))
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
                foreach (ClassCADdyPunkt item in Punkte)
                {
                    if (allPoints || regexT.isMatch(item.Code))
                    {
                        item.Code = newCode;
                        hasAnyChanged = true;
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
            foreach (ClassCADdyPunkt item in Punkte)
            {
                if (!result.Contains(item.Punktnummer))
                    result.Add(item.Punktnummer);
            }
            return result;
        }
        /// <summary>Gibt eine unsortierte Liste der Codes zurück</summary>
        /// <returns></returns>
        public List<String> getDestinctCodes()
        {
            List<String> result = new List<String>();
            foreach (ClassCADdyPunkt item in Punkte)
            {
                if (!ClassStringTools.IsNullOrWhiteSpace(item.Code))
                {
                    if (!result.Contains(item.Code))
                        result.Add(item.Code);
                }
            }
            return result;
        }

        /// <summary>Gibt den Punkt mit dem namen zurück</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassCADdyPunkt getPointByName(String name)
        {
            ClassCADdyPunkt result = null;
            foreach (ClassCADdyPunkt item in Punkte)
            {
                if (name.Equals(item.Punktnummer))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        /// <summary>Berechnet eine Koordinatentranslation und Koordinatenrotation </summary>
        /// <param name="rPName">Wird im Rotierten System (0,0,0)</param>
        /// <param name="dPName">Wird im rotierten System polar(direction,Distanz rPoint zu dPoint)</param>
        /// <param name="direction"></param>
        /// <param name="setRPointZTo0">Soll auch Z auf Null gesetzt werden?</param>
        public Boolean rotateCoords(String rPName, String dPName, Double direction, Boolean setRPointZTo0)
        {
            Boolean result = false;
            ClassCADdyPunkt rPoint = getPointByName(rPName);
            ClassCADdyPunkt dPoint = getPointByName(dPName);
            if ((rPoint != null) && (dPoint != null))
            {
                Double translRW = -rPoint.Rechtswert;
                Double translHW = -rPoint.Hochwert;
                Double translZW = -rPoint.Hoehe;
                if (!setRPointZTo0) translZW = 0.0;
                // 1. Translation
                foreach (ClassCADdyPunkt item in Punkte)
                {
                    item.Rechtswert += translRW;
                    item.Hochwert += translHW;
                    item.Hoehe += translZW;
                }
                rPoint = getPointByName(rPName);
                dPoint = getPointByName(dPName);
                if ((rPoint != null) && (dPoint != null))
                {
                    Double dirOld = rPoint.gonRiwiTo(dPoint);
                    Double dirDelta = direction - dirOld;
                    // Richtung +- drehen, mathematisch ist linksrum
                    Double dirRad = -1.0 * dirDelta / 200 * Math.PI;
                    //2. Rotation
                    foreach (ClassCADdyPunkt item in Punkte)
                    {
                        Double x = item.Rechtswert;
                        Double y = item.Hochwert;
                        item.Rechtswert = x * Math.Cos(dirRad) - y * Math.Sin(dirRad);
                        item.Hochwert = x * Math.Sin(dirRad) + y * Math.Cos(dirRad);
                    }
                    result = true;
                }
            }
            return result;
        }

        /// <summary>Koordinaten verschieben</summary>
        /// <param name="tRW"></param>
        /// <param name="tHW"></param>
        /// <param name="tHO"></param>
        /// <param name="settings"></param>
        public Boolean translateCoords(Double tRW, Double tHW, Double tHO)
        {
            Boolean hasAnyChanged = false;
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            int sLnrStart = -1;
            int sLnrEnd = -1;
            if (editor != null)
            {
                sLnrStart = editor.LineFromPosition(editor.GetSelectionStart());
                sLnrEnd = editor.LineFromPosition(editor.GetSelectionEnd());
                if (editor.GetColumn(editor.GetSelectionEnd()) < 2)
                    sLnrEnd--;
                if ((sLnrEnd - sLnrStart) <= 0) sLnrStart = sLnrEnd = -1;
            }
            if (Double.IsNaN(tRW)) tRW = 0.0;
            if (Double.IsNaN(tHW)) tHW = 0.0;
            if (Double.IsNaN(tHO)) tHO = 0.0;
            foreach (ClassCADdyPunkt item in Punkte)
            {
                if ((sLnrStart >= 0) && (sLnrEnd >= 0))
                {
                    if ((item.LineNumber >= sLnrStart) && (item.LineNumber <= sLnrEnd))
                    {
                        item.Rechtswert += tRW;
                        item.Hochwert += tHW;
                        item.Hoehe += tHO;
                        hasAnyChanged = true;
                    }
                }
                else
                {
                    item.Rechtswert += tRW;
                    item.Hochwert += tHW;
                    item.Hoehe += tHO;
                    hasAnyChanged = true;
                }
            }
            return hasAnyChanged;
        }
        #endregion Methoden
    }
}