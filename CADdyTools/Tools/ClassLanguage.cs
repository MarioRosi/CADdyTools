using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary>Gibt den Sprachtext zurück</summary>
    public class ClassLanguage
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

        /// <summary>der Dateiname der Sprachendatei</summary>
        private String languageFileName;
        /// <summary></summary>
        private String language;
        /// <summary>GroupName für die Sprache</summary>
        private String groupName;

        /// <summary>Konstruktor</summary>
        /// <param name="languageFileName"></param>
        /// <param name="language"></param>
        public ClassLanguage(String languageFileName)
        {
            this.languageFileName = languageFileName;
            this.language = getLanguage();
            this.groupName = "Language_" + this.language;
        }

        /// <summary>Gibt die aktuelle Sprachwahl aus der '/AppData/Roaming/Notepad++/nativeLang.xml#/NotepadPlus/Native-Langue#name#' zurück</summary>
        /// <returns></returns>
        private String getLanguage()
        {
            String result = "EN";
            StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            String iniFilePath = sbIniFilePath.ToString();
            if (iniFilePath.EndsWith(@"plugins\Config"))
            {
                iniFilePath = iniFilePath.Replace(@"\plugins\Config", @"\nativeLang.xml");
                String readline = null;
                Int16 counter = 0;
                //    <Native-Langue name="English" filename="english.xml" version="6.8.2">
                if (System.IO.File.Exists(iniFilePath))
                {

                    using (System.IO.StreamReader fileReader = System.IO.File.OpenText(iniFilePath))
                    {
                        while (counter < 30) // check counterMax
                        {
                            readline = fileReader.ReadLine();
                            counter++;
                            if (readline.ToLowerInvariant().Contains("<native-langue"))
                            {
                                string[] split = Regex.Split(readline, "^(.*)(<Native-Langue)(\\s+)(name=\")(((?!\").)*)(\")(.*)$");
                                if ((split != null) && (split.Length > 4))
                                    readline = split[5];
                                else
                                    readline = null;
                                counter = 31; // Set counter to => max
                            }
                            else
                                readline = null;
                        }
                        fileReader.Close();
                    }
                    if (readline != null)
                    {
                        switch (readline.ToLowerInvariant())
                        {
                            case "deutsch":
                                result = "DE";
                                break;
                            case "english":
                                result = "EN";
                                break;
                            default:
                                result = "EN";
                                break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>Gibt den Sprachtext für die aktuelle Sprache zurück</summary>
        /// <param name="lagnuageFilePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public String getLanguageText(String name)
        {
            var value = new StringBuilder(capacity);
            if (System.IO.File.Exists(languageFileName))
                GetPrivateProfileString(groupName, name, "not Text found", value, value.Capacity, languageFileName);
            String result = value.ToString();

            result = result.Replace(@"\n", "\n");
            return result;
        }

    }
}
