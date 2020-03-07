using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace org.rosenbohm.csharp.Settingshelper
{
    /// <summary>Basisklasse, stellt Funktiuonen für das serialisieren und Deserialisieren in eine INI-Datei zur Verfügung</summary>
    /// https://www.autohotkey.com/boards/viewtopic.php?f=6&t=38511
    public class INISettingsBase
    {
        /// <summary>MaxSize für INI-STring</summary>
        private static int capacity = 512;
        #region Imports
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key,
            string defaultValue, StringBuilder value, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string section, string key,
            string value, string filePath);
        #endregion Imports
        #region Eigenschaften
        /// <summary>Filepath der INidatei</summary>
        protected String iniFilename;
        /// <summary>Speichert veränderungen an den Properties, wird durch LoadConfig und Saveconfig auf false gesetzt.</summary>
        protected bool propertyIsChanging;
        #endregion Eigenschaften

        #region Properties
        /// <summary>Filepath der INidatei</summary>
        [INIIgnoreThis(true)]
        public string IniFilename
        {
            get { return iniFilename; }
            set { iniFilename = value; }
        }
        /// <summary>!!! READONLY Wurden eigenschaften seit dem letzten Laden / Speichern geändert?</summary>
        [INIIgnoreThis(true)]
        public bool IsAnyPropertyChanging
        {
            get { return propertyIsChanging; }
        }
        #endregion Properties

        #region Konstruktoren
        /// <summary>Basiskonstruktor</summary>
        /// <param name="iniFilename"></param>
        public INISettingsBase(String iniFilename)
        {
            this.iniFilename = iniFilename;
            setDefaults();
            load();
        }
        #endregion Konstruktoren
        #region events
        /// <summary>Benutzen um die propertys auf Veränderung zu überwachen!</summary>
        protected void PropertyChanged() { propertyIsChanging = true; }

        /// <summary>Prüft ob oldValue != newValue und setzt ggf. propertyIsChanging = true; </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>True ist verändert, false keine Änderung</returns>
        protected Boolean checkPropertyIsChanging(Object oldValue, Object newValue)
        {
            Boolean result = false;
            if (oldValue != null)
            {
                if (!oldValue.Equals(newValue)) result = true;
            }
            else
            {
                if (newValue != null) result = true;
            }
            if (result) propertyIsChanging = true;
            return result;
        }
        #endregion events
        #region Methoden
        /// <summary>Setzt die Properties anhand der Defaultwerte</summary>
        public void setDefaults()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                try
                {
                    DefaultValueAttribute defValue = (DefaultValueAttribute)Attribute.GetCustomAttribute(property, typeof(DefaultValueAttribute));
                    string strDefValue = "";
                    if (defValue != null)
                    {
                        if (defValue.Value != null)
                        {
                            strDefValue = defValue.Value.ToString();
                            object defObject = null;
                            switch (property.PropertyType.Name)
                            {
                                case "Boolean":
                                case "Int64":
                                case "Int16":
                                case "Int32":
                                case "Decimal":
                                case "Float":
                                case "Double":
                                case "Color":
                                case "String":
                                    ClassConverters.getValueFromString(strDefValue, property.PropertyType, out defObject);
                                    break;
                                case "Char":
                                    // DefaultValueAttribute ist schon ein Char
                                    //Char c;
                                    // if (ClassConverters.StringToChar(strDefValue, out c)) 
                                    property.SetValue(this, strDefValue[0], null);
                                    break;
                                default:
                                    if (property.PropertyType.IsEnum)
                                        ClassConverters.getValueFromString(strDefValue, property.PropertyType, out defObject);
                                    else
                                        defObject = (object)strDefValue;
                                    break;
                            }
                            property.SetValue(this, defObject, null);
                        }
                    }
                }
                catch
                { }
            }
        }
        /// <summary>Laden der Settings</summary>
        public void load()
        {
            if (System.IO.File.Exists(iniFilename))
            {
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    Boolean canNext = false;
                    String groupName = "Main";
                    String propertyName = property.Name;
                    String defString = null;
                    DefaultValueAttribute defValue = (DefaultValueAttribute)Attribute.GetCustomAttribute(property, typeof(DefaultValueAttribute));
                    if (defValue != null) ClassConverters.getStringFromValue(defValue.Value, property.PropertyType, out defString);
                    INIIgnoreThis ignorePropAttrib = (INIIgnoreThis)Attribute.GetCustomAttribute(property, typeof(INIIgnoreThis));
                    if (ignorePropAttrib == null)
                        canNext = true;
                    else
                        canNext = !ignorePropAttrib.IgnoreThis;
                    if (canNext)
                    {

                        INIGroupName groupNameAttrib = (INIGroupName)Attribute.GetCustomAttribute(property, typeof(INIGroupName));
                        if (groupNameAttrib != null) groupName = groupNameAttrib.GName;
                        INIPropertyName propertyNameAttrib = (INIPropertyName)Attribute.GetCustomAttribute(property, typeof(INIPropertyName));
                        if (propertyNameAttrib != null) propertyName = propertyNameAttrib.Name;
                        String loadedValue = readStringFromIni(groupName, propertyName, defString);
                        Object setObject = null;
                        if (ClassConverters.getValueFromString(loadedValue, property.PropertyType, out setObject))
                            property.SetValue(this, setObject, null);
                    }
                }
            }
        }
        /// <summary>Speichern der Settings</summary>
        public void save()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                Boolean canNext = false;
                String groupName = "Main";
                String propertyName = property.Name;
                INIIgnoreThis ignorePropAttrib = (INIIgnoreThis)Attribute.GetCustomAttribute(property, typeof(INIIgnoreThis));
                if (ignorePropAttrib == null)
                    canNext = true;
                else
                    canNext = !ignorePropAttrib.IgnoreThis;
                if (canNext)
                {
                    String saveValue = null;
                    ClassConverters.getStringFromValue(property.GetValue(this, null), property.PropertyType, out saveValue);

                    INIGroupName groupNameAttrib = (INIGroupName)Attribute.GetCustomAttribute(property, typeof(INIGroupName));
                    if (groupNameAttrib != null) groupName = groupNameAttrib.GName;

                    INIPropertyName propertyNameAttrib = (INIPropertyName)Attribute.GetCustomAttribute(property, typeof(INIPropertyName));
                    if (propertyNameAttrib != null) propertyName = propertyNameAttrib.Name;

                    WritePrivateProfileString(groupName, propertyName, saveValue, iniFilename);
                }
            }
        }
        /// <summary>Liet sauber einen Text aus der INI-Datei</summary>
        /// <param name="groupName"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        private String readStringFromIni(String groupName, String propertyName, String defaultString)
        {
            var value = new StringBuilder(capacity);
            GetPrivateProfileString(groupName, propertyName, defaultString, value, value.Capacity, iniFilename);
            return value.ToString();
        }
        #endregion Methoden

    }
}
