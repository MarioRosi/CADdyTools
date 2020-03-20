using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Settingshelper;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kbg.NppPluginNET
{
    /// <summary>Einstellunge für Koordtools</summary>
    public class Settings : INISettingsBase
    {

        #region Properties
        /// <summary>Punktname Spalte</summary>
        [DefaultValue(typeof( Int16),"1"), INIGroupName("All")]
        public Int16 PointName_Column { get; set; }
        /// <summary>Punktname Start</summary>
        [DefaultValue(typeof(Int16), "1"), INIGroupName("All")]
        public Int16 PointName_Start { get; set; }
        /// <summary>Punktname Länge</summary>
        [DefaultValue(typeof(Int16), "18"), INIGroupName("All")]
        public Int16 PointName_Length { get; set; }

        /// <summary>Punktname immer groß</summary>
        [DefaultValue(true), INIGroupName("All")]
        public Boolean PointName_ToUpper { get; set; }

        /// <summary>Zeichen für den Dezimaltrenner</summary>
        [DefaultValue(typeof(String),"."), INIGroupName("All")]
        public String Decimalseperator { get; set; }

        #region Koordinatendaten
        /// <summary>Rechtswert Spalte</summary>
        [DefaultValue(typeof(Int16), "2"), INIGroupName("coord"), INIPropertyName("RW_E_Column")]
        public Int16 Koord_RW_E_Column { get; set; }
        /// <summary>Rechtswert Start</summary>
        [DefaultValue(typeof(Int16), "19"), INIGroupName("coord"), INIPropertyName("RW_E_Start")]
        public Int16 Koord_RW_E_Start { get; set; }
        /// <summary>Rechtswert Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("coord"), INIPropertyName("RW_E_Decimals")]
        public Int16 Koord_RW_E_Decimals { get; set; }
        /// <summary>Rechtswert Länge</summary>
        [DefaultValue(typeof(Int16), "14"), INIGroupName("coord"), INIPropertyName("RW_E_Length")]
        public Int16 Koord_RW_E_Length { get; set; }

        /// <summary>Hochwert Spalte</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("coord"), INIPropertyName("HW_N_Column")]
        public Int16 Koord_HW_N_Column { get; set; }
        /// <summary>Hochwert Start</summary>
        [DefaultValue(typeof(Int16), "33"), INIGroupName("coord"), INIPropertyName("HW_N_Start")]
        public Int16 Koord_HW_N_Start { get; set; }
        /// <summary>Hochwert Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("coord"), INIPropertyName("HW_N_Decimals")]
        public Int16 Koord_HW_N_Decimals { get; set; }
        /// <summary>Hochwert Länge</summary>
        [DefaultValue(typeof(Int16), "14"), INIGroupName("coord"), INIPropertyName("HW_N_Length")]
        public Int16 Koord_HW_N_Length { get; set; }

        /// <summary>Höhe Spalte</summary>
        [DefaultValue(typeof(Int16), "4"), INIGroupName("coord"), INIPropertyName("Elev_Column")]
        public Int16 Koord_Elev_Column { get; set; }
        /// <summary>Höhe Start</summary>
        [DefaultValue(typeof(Int16), "48"), INIGroupName("coord"), INIPropertyName("Elev_Start")]
        public Int16 Koord_Elev_Start { get; set; }
        /// <summary>Höhe Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "4"), INIGroupName("coord"), INIPropertyName("Elev_Decimals")]
        public Int16 Koord_Elev_Decimals { get; set; }
        /// <summary>Höhe Länge</summary>
        [DefaultValue(typeof(Int16), "10"), INIGroupName("coord"), INIPropertyName("Elev_Length")]
        public Int16 Koord_Elev_Length { get; set; }

        /// <summary>Punktcode bei Koordinaten  Spalte</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("coord"), INIPropertyName("Code_Column")]
        public Int16 Koord_Code_Column { get; set; }
        /// <summary>Punktcode bei Koordinaten Start</summary>
        [DefaultValue(typeof(Int16), "59"), INIGroupName("coord"), INIPropertyName("Code_Start")]
        public Int16 Koord_Code_Start { get; set; }
        /// <summary>Punktcode bei Koordinaten Länge</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("coord"), INIPropertyName("Code_Length")]
        public Int16 Koord_Code_Length { get; set; }

        /// <summary>Beschreibung bei Koordinaten Spalte</summary>
        [DefaultValue(typeof(Int16), "6"), INIGroupName("coord"), INIPropertyName("Descript_Column")]
        public Int16 Koord_Descript_Column { get; set; }
        /// <summary>Beschreibung bei Koordinaten Start</summary>
        [DefaultValue(typeof(Int16), "63"), INIGroupName("coord"), INIPropertyName("Descript_Start")]
        public Int16 Koord_Descript_Start { get; set; }
        /// <summary>Beschreibung bei Koordinaten Länge</summary>
        [DefaultValue(typeof(Int16), "20"), INIGroupName("coord"), INIPropertyName("Descript_Length")]
        public Int16 Koord_Descript_Length { get; set; }
        #endregion Koordinatendaten

        #region Messdaten
        #region Standpunkt
        /// <summary>Instrumentenhöhe Spalte</summary>
        [DefaultValue(typeof(Int16), "2"), INIGroupName("measure"), INIPropertyName("I_Column")]
        public Int16 Messd_I_Column { get; set; }
        /// <summary>Instrumentenhöhe Start</summary>
        [DefaultValue(typeof(Int16), "19"), INIGroupName("measure"), INIPropertyName("I_Start")]
        public Int16 Messd_I_Start { get; set; }
        /// <summary>Instrumentenhöhe Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("I_Decimals")]
        public Int16 Messd_I_Decimals { get; set; }
        /// <summary>Instrumentenhöhe Länge</summary>
        [DefaultValue(typeof(Int16), "8"), INIGroupName("measure"), INIPropertyName("I_Length")]
        public Int16 Messd_I_Length { get; set; }

        /// <summary>Punktcode Standpunkt Spalte</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("STPKCode_Column")]
        public Int16 Messd_STPKCode_Column { get; set; }
        /// <summary>Punktcode Standpunkt Start</summary>
        [DefaultValue(typeof(Int16), "28"), INIGroupName("measure"), INIPropertyName("STPKCode_Start")]
        public Int16 Messd_STPKCode_Start { get; set; }
        /// <summary>Punktcode Standpunkt Länge</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("STPKCode_Length")]
        public Int16 Messd_STPKCode_Length { get; set; }

        /// <summary>Beschreibung bei Standpunkt Spalte</summary>
        [DefaultValue(typeof(Int16), "4"), INIGroupName("measure"), INIPropertyName("STPKDescript_Column")]
        public Int16 Messd_STPKDescript_Column { get; set; }
        /// <summary>Beschreibung bei Standpunkt Start</summary>
        [DefaultValue(typeof(Int16), "32"), INIGroupName("measure"), INIPropertyName("STPKDescript_Start")]
        public Int16 Messd_STPKDescript_Start { get; set; }
        /// <summary>Beschreibung bei Standpunkt Länge</summary>
        [DefaultValue(typeof(Int16), "20"), INIGroupName("measure"), INIPropertyName("STPKDescript_Length")]
        public Int16 Messd_STPKDescript_Length { get; set; }

        #endregion Standpunkt
        /// <summary>Richtung Spalte</summary>
        [DefaultValue(typeof(Int16), "2"), INIGroupName("measure"), INIPropertyName("Dz_Column")]
        public Int16 Messd_Hz_Column { get; set; }
        /// <summary>Richtung Start</summary>
        [DefaultValue(typeof(Int16), "19"), INIGroupName("measure"), INIPropertyName("Hz_Start")]
        public Int16 Messd_Hz_Start { get; set; }
        /// <summary>Richtung Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("measure"), INIPropertyName("Hz_Decimals")]
        public Int16 Messd_Hz_Decimals { get; set; }
        /// <summary>Richtung Länge</summary>
        [DefaultValue(typeof(Int16), "10"), INIGroupName("measure"), INIPropertyName("Hz_Length")]
        public Int16 Messd_Hz_Length { get; set; }

        /// <summary>Strecke Spalte</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("S_Column")]
        public Int16 Messd_S_Column { get; set; }
        /// <summary>Strecke Start</summary>
        [DefaultValue(typeof(Int16), "29"), INIGroupName("measure"), INIPropertyName("S_Start")]
        public Int16 Messd_S_Start { get; set; }
        /// <summary>Strecke Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "4"), INIGroupName("measure"), INIPropertyName("S_Decimals")]
        public Int16 Messd_S_Decimals { get; set; }
        /// <summary>Strecke Länge</summary>
        [DefaultValue(typeof(Int16), "11"), INIGroupName("measure"), INIPropertyName("S_Length")]
        public Int16 Messd_S_Length { get; set; }

        /// <summary>Vertikalwinkel Spalte</summary>
        [DefaultValue(typeof(Int16), "4"), INIGroupName("measure"), INIPropertyName("V_Column")]
        public Int16 Messd_V_Column { get; set; }
        /// <summary>Vertikalwinkel Start</summary>
        [DefaultValue(typeof(Int16), "41"), INIGroupName("measure"), INIPropertyName("V_Start")]
        public Int16 Messd_V_Start { get; set; }
        /// <summary>Vertikalwinkel Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("measure"), INIPropertyName("V_Decimals")]
        public Int16 Messd_V_Decimals { get; set; }
        /// <summary>Vertikalwinkel Länge</summary>
        [DefaultValue(typeof(Int16), "10"), INIGroupName("measure"), INIPropertyName("V_Length")]
        public Int16 Messd_V_Length { get; set; }

        /// <summary>Reflektorhöhe Spalte</summary>
        [DefaultValue(typeof(Int16), "5"), INIGroupName("measure"), INIPropertyName("D_Column")]
        public Int16 Messd_D_Column { get; set; }
        /// <summary>Reflektorhöhe Start</summary>
        [DefaultValue(typeof(Int16), "52"), INIGroupName("measure"), INIPropertyName("D_Start")]
        public Int16 Messd_D_Start { get; set; }
        /// <summary>Reflektorhöhe Nachkommastellen</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("D_Decimals")]
        public Int16 Messd_D_Decimals { get; set; }
        /// <summary>Reflektorhöhe Länge</summary>
        [DefaultValue(typeof(Int16), "8"), INIGroupName("measure"), INIPropertyName("D_Length")]
        public Int16 Messd_D_Length { get; set; }

        /// <summary>Punktcode Spalte</summary>
        [DefaultValue(typeof(Int16), "6"), INIGroupName("measure"), INIPropertyName("Code_Column")]
        public Int16 Messd_Code_Column { get; set; }
        /// <summary>Punktcode bei Koordinaten Start</summary>
        [DefaultValue(typeof(Int16), "61"), INIGroupName("measure"), INIPropertyName("Code_Start")]
        public Int16 Messd_Code_Start { get; set; }
        /// <summary>Punktcode bei Koordinaten Länge</summary>
        [DefaultValue(typeof(Int16), "3"), INIGroupName("measure"), INIPropertyName("Code_Length")]
        public Int16 Messd_Code_Length { get; set; }

        /// <summary>Beschreibung bei Koordinaten Spalte</summary>
        [DefaultValue(typeof(Int16), "7"), INIGroupName("measure"), INIPropertyName("Descript_Column")]
        public Int16 Messd_Descript_Column { get; set; }
        /// <summary>Beschreibung bei Koordinaten Start</summary>
        [DefaultValue(typeof(Int16), "65"), INIGroupName("measure"), INIPropertyName("Descript_Start")]
        public Int16 Messd_Descript_Start { get; set; }
        /// <summary>Beschreibung bei Koordinaten Länge</summary>
        [DefaultValue(typeof(Int16), "20"), INIGroupName("measure"), INIPropertyName("Descript_Length")]
        public Int16 Messd_Descript_Length { get; set; }        
        
        #endregion Messdaten

        #endregion Properties

        #region Konstruktoren
        /// <summary>Konstruktor, liest gleich die Settings ein</summary>
        /// <param name="iniFilePath"></param>
        public Settings(String iniFilePath) : base(iniFilePath)
        {
            
        }
        #endregion Konstruktoren
    }
}
