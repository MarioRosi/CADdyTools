using Kbg.NppPluginNET;
using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Test, was bin ich (aktuelle Datei / Editor)</summary>
    public class ClassCADdyWhatIAm
    {
        /// <summary>Testet, um welche Datenstruktut es sich handeln könnte</summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static enWhatIAm check( Settings settings)
        {
            enWhatIAm result = enWhatIAm.iDontKnown;
            IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());

            if (editor.GetLineCount() > 0)
            {
                String cuLine = editor.GetLine(0);
                cuLine = cuLine.Replace('\t', ' '); // Tab durch Leerzeichen ersetzten
                cuLine = cuLine.Replace(',', settings.Decimalseperator[0]); // , durch . ersetzten
                String[] split = ClassStringTools.GetFieldsManyDelimiters(cuLine, ' ', true);
                if (split != null)
                {

                    switch (split.Length)
                    {
                        case 3:
                            if (split[settings.PointName_Column - 1].StartsWith("-"))
                                result = enWhatIAm.CADdyMeasure;
                            break;
                        case 4:
                            if (split[settings.PointName_Column - 1].StartsWith("-"))
                                result = enWhatIAm.CADdyMeasure;
                            else if (split[settings.Koord_RW_E_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_RW_E_Column - 1]))
                            {
                                if (split[settings.Koord_HW_N_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_HW_N_Column - 1]))
                                {
                                    if (split[settings.Koord_Elev_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_Elev_Column - 1]))
                                    {
                                        // Koordinaten ohne Code
                                        result = enWhatIAm.CADdyCoord;
                                    }
                                }
                            }
                            break;
                        case 5:
                            if (split[settings.Koord_RW_E_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_RW_E_Column - 1]))
                            {
                                if (split[settings.Koord_HW_N_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_HW_N_Column - 1]))
                                {
                                    if (split[settings.Koord_Elev_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Koord_Elev_Column - 1]))
                                    {
                                        if (!split[settings.Koord_Code_Column - 1].Contains(settings.Decimalseperator))
                                        {
                                            result = enWhatIAm.CADdyCoord;
                                        }
                                    }
                                }
                            }
                            if (result == enWhatIAm.iDontKnown)
                            {
                                if (split[settings.Messd_Hz_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_Hz_Column - 1]))
                                {
                                    if (split[settings.Messd_V_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_V_Column - 1]))
                                    {
                                        if (split[settings.Messd_S_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_S_Column - 1]))
                                        {
                                            if (split[settings.Messd_D_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_D_Column]))
                                            {
                                                result = enWhatIAm.CADdyMeasure;

                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 6:
                            if (split[settings.Koord_RW_E_Column - 1].Contains(settings.Decimalseperator))
                            {
                                if (split[settings.Koord_HW_N_Column - 1].Contains(settings.Decimalseperator))
                                {
                                    if (split[settings.Koord_Elev_Column - 1].Contains(settings.Decimalseperator))
                                    {
                                        if (!split[settings.Koord_Code_Column - 1].Contains(settings.Decimalseperator))
                                        {
                                            result = enWhatIAm.CADdyCoord;
                                        }
                                    }
                                }
                            }
                            if (result == enWhatIAm.iDontKnown)
                            {
                                if (split[settings.Messd_Hz_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_Hz_Column - 1]))
                                {
                                    if (split[settings.Messd_V_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_V_Column - 1]))
                                    {
                                        if (split[settings.Messd_S_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_S_Column - 1]))
                                        {
                                            if (split[settings.Messd_D_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_D_Column - 1]))
                                            {
                                                if (!split[settings.Messd_Code_Column - 1].Contains(settings.Decimalseperator))
                                                {
                                                    result = enWhatIAm.CADdyMeasure;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 7:
                            if (split[settings.Messd_Hz_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_Hz_Column - 1]))
                            {
                                if (split[settings.Messd_V_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_V_Column - 1]))
                                {
                                    if (split[settings.Messd_S_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_S_Column - 1]))
                                    {
                                        if (split[settings.Messd_D_Column - 1].Contains(settings.Decimalseperator) || ClassStringTools.IsNumeric(split[settings.Messd_D_Column - 1]))
                                        {
                                            if (!split[settings.Messd_Code_Column - 1].Contains(settings.Decimalseperator))
                                            {
                                                result = enWhatIAm.CADdyMeasure;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }
    }
}
