using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using org.rosenbohm.csharp.CADdy;
using org.rosenbohm.csharp.Tools;
using org.rosenbohm.csharp.CADdyTools.Forms;

namespace Kbg.NppPluginNET
{
    /* 
     * Make New Release
     * 1. compile x86 & x64
     * 2. File CADdyTools.dll + CADdyTools_Lang.ini => CADdyTools_vAAAA_xBB.zip (AAAA = akt. Version z.Zt. 1137 BB = 86/64)
     * 3. calc SHA-256-Hash  NP++->Werkzeuge->SHA-256->Aus Dateien erstellen (aus den *.zip!)
     * 
     * 7ccbfb712e3b6757137f4921de6e6f4f83f9c258248137690c0dd5de9262c5dd  CADdyTools_v1137_x86.zip
     * 65c03a40c28dd1b65489aa5dee4df5219ac1db476b751a9c3312aea3cb60cda2  CADdyTools_v1137_x64.zip
     * 
     * 64bit eintrag
     * 
       {
			"folder-name": "CADdyTools",
			"display-name": "CADdyTools",
			"version": "1.1.3.7",
			"id": "7ccbfb712e3b6757137f4921de6e6f4f83f9c258248137690c0dd5de9262c5dd",
			"repository": "https://github.com/MarioRosi/CADdyTools/releases/download/1.1.3.7/CADdyTools_v1137_x64.zip",
			"description": "Notepad++-Plugin for manipulate CADdy-formated coordinate- and measure-textfiles",
			"author": "Mario Rosenbohm",
			"homepage": "https://github.com/MarioRosi/CADdyTools"
		},
     
     * 32bit eintrag
     * 
       {
			"folder-name": "CADdyTools",
			"display-name": "CADdyTools",
			"version": "1.1.3.7",
			"id": "7ccbfb712e3b6757137f4921de6e6f4f83f9c258248137690c0dd5de9262c5dd",
			"repository": "https://github.com/MarioRosi/CADdyTools/releases/download/1.1.3.7/CADdyTools_v1137_x86.zip",
			"description": "Notepad++-Plugin for manipulate CADdy-formated coordinate- and measure-textfiles",
			"author": "Mario Rosenbohm",
			"homepage": "https://github.com/MarioRosi/CADdyTools"
		},

         
         */

    /// <summary>Enum zur erzeugung der Menüids</summary>
    internal enum CADdyToolsMenuId
    {
        Menue_Coord = 0,
        Menue_Coord_FormCADdy = 1,
        Menue_Coord_FormExcel = 2,
        Menue_Coord_Sort = 3,
        Menue_Coord_SortCol1 = 4,
        Menue_Coord_SortCol2 = 5,
        Menue_Coord_SortCol3 = 6,
        Menue_Coord_SortCol4 = 7,
        Menue_Coord_SortCol5 = 8,
        Menue_Coord_Rotation = 9,
        Menue_Coord_Translation = 10,
        Menue_Coord_Transformation = 11,
        Menue_Coord_Polar = 12,
        Menue_Coord_Compare = 13,
        Menue_Dummy_1 = 14,
        Menue_Measure = 15,
        Menue_Measure_FormCADdy = 16,
        Menue_Measure_FormExcel = 17,
        Menue_Measure_FormCAPLAN = 18,
        Menue_Measure_SetID = 19,
        Menue_Dummy_2 = 20,
        Menue_MeasCode = 21,
        Menue_ChangeCode = 22,
        Menue_Dummy_3 = 23,
        Menue_Settings = 24,
        About = 25
    }
    internal class Main
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        }
        internal static RECT nppMainRect = new RECT();

        public static Boolean isFuctionSwitch = false;

        internal const string PluginName = "CADdyTools";
        static String iniFilePath = null;

        static ClassLanguage pluginLanguage = null;
        static Settings pluginSettings = null;

        static frmCADdyToolsSettings frmSettings = null;
        static int idFrmSettings = -10001;

        static frmAbout frmAboutprt = null;

        static frmChangeCode frmChangeCod = null;
        static int idFrmChangeCode = -10002;

        static frmChangeID frmChangeid = null;
        static int idFrmChangeId = -10003;

        static frmRotateCoord frmRotate = null;
        static int idFrmRotate = -10004;

        static frmTranslateCoord frmTranslate = null;
        static int idFrmTranslate = -10005;

        static frmPolarCoord frmPolar = null;
        static int idFrmPolar = -10006;

        static frmCompareCoord frmCompare = null;
        static int idFrmCompare = -10007;

        static frmTransformCoord frmTransform = null;
        static int idFrmTransform = -10008;


        static ClassCADdyPunkte cADdyPoints = null;
        static ClassCADdyMessdaten cADdyMessdaten = null;
        /// <summary>Was ist der aktuelle Typ</summary>
        static enWhatIAm cuTabWhatIsThis;

        static Bitmap CADdy = Properties.Resources.CADdyTools;
        static Bitmap calc = Properties.Resources.calc;
        static Bitmap change = Properties.Resources.change;
        static Bitmap compare = Properties.Resources.compare;
        static Bitmap info = Properties.Resources.info;
        static Bitmap move = Properties.Resources.move;
        static Bitmap rotate = Properties.Resources.rotate;
        static Bitmap transf = Properties.Resources.transform;
        static Bitmap settings = Properties.Resources.settings;

        static Icon tbIcon = null;
        //static IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
        static INotepadPPGateway notepad = new NotepadPPGateway();


        public static void OnNotification(ScNotification notification)
        {
            // 1010u = ???
            if (notification.Header.Code == 1010u)
            {
                Main.bufferIsActivated();
            }
        }

        internal static void CommandMenuInit()
        {
            StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            String settingsFilePath = Path.Combine(iniFilePath, PluginName + ".ini");
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETNPPDIRECTORY, Win32.MAX_PATH, sbIniFilePath);
            iniFilePath = sbIniFilePath.ToString();
            String languageFilePath = Path.Combine(iniFilePath, @"plugins\" + PluginName + @"\" + PluginName + "_Lang.ini");
            pluginSettings = new Settings(settingsFilePath);
            pluginSettings.load();
            pluginLanguage = new ClassLanguage(languageFilePath);

            cADdyPoints = new ClassCADdyPunkte(ref pluginLanguage);
            cADdyMessdaten = new ClassCADdyMessdaten(ref pluginLanguage);


            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord, pluginLanguage.getLanguageText("Menue_Coord"), dummy);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_FormCADdy, pluginLanguage.getLanguageText("Menue_Coord_FormCADdy"), formatCADdyKoord, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_FormExcel, pluginLanguage.getLanguageText("Menue_Coord_FormExcel"), formatExcelKoord, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Sort, pluginLanguage.getLanguageText("Menue_Coord_Sort"), dummy);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_SortCol1, pluginLanguage.getLanguageText("Menue_Coord_SortCol1"), sortByNumber, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_SortCol2, pluginLanguage.getLanguageText("Menue_Coord_SortCol2"), sortByEast, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_SortCol3, pluginLanguage.getLanguageText("Menue_Coord_SortCol3"), sortByNorth, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_SortCol4, pluginLanguage.getLanguageText("Menue_Coord_SortCol4"), sortByElev, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_SortCol5, pluginLanguage.getLanguageText("Menue_Coord_SortCol5"), sortByCode, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Rotation, pluginLanguage.getLanguageText("Menue_Coord_Rotation"), rotateCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Translation, pluginLanguage.getLanguageText("Menue_Coord_Translation"), translateCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Transformation, pluginLanguage.getLanguageText("Menue_Coord_Transformation"), transformationCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Polar, pluginLanguage.getLanguageText("Menue_Coord_Polar"), polarCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Coord_Compare, pluginLanguage.getLanguageText("Menue_Coord_Compare"), compareCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Dummy_1, "----", null);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Measure, pluginLanguage.getLanguageText("Menue_Measure"), dummy);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Measure_FormCADdy, pluginLanguage.getLanguageText("Menue_Measure_FormCADdy"), formatCADdyMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Measure_FormExcel, pluginLanguage.getLanguageText("Menue_Measure_FormExcel"), formatExcelMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Measure_FormCAPLAN, pluginLanguage.getLanguageText("Menue_Measure_FormCAPLAN"), formatCAPLANMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Measure_SetID, pluginLanguage.getLanguageText("Menue_Measure_SetID"), changeIDDialog);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Dummy_2, "----", null);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_MeasCode, pluginLanguage.getLanguageText("Menue_MeasCode"), dummy);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_ChangeCode, pluginLanguage.getLanguageText("Menue_ChangeCode"), changeCodeDialog);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Dummy_3, "----", null);
            PluginBase.SetCommand((int)CADdyToolsMenuId.Menue_Settings, pluginLanguage.getLanguageText("Menue_Settings"), settingsDialog);
            PluginBase.SetCommand((int)CADdyToolsMenuId.About, "About ...", aboutDialog);
        }

        internal static void SetToolBarIcon()
        {
            /*
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idFrmSettings]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
            */
        }

        /// <summary>Tabreiter wurde aktiviert!</summary>
        internal static void bufferIsActivated()
        {
            if (!Main.isFuctionSwitch)
            {
                Main.cuTabWhatIsThis = ClassCADdyWhatIAm.check(pluginSettings);

                if (cuTabWhatIsThis != enWhatIAm.CADdyCoord)
                {
                    if (cuTabWhatIsThis == enWhatIAm.CADdyMeasure)
                    {
                        Main.cADdyMessdaten.getMeasuresFromCurrentCADdy(Main.pluginSettings);
                        Main.cADdyPoints.clear();
                    }
                }
                else if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
                {
                    Main.cADdyPoints.getPointsFromCurrentCADdy(Main.pluginSettings);
                    Main.cADdyMessdaten.clear();
                }
                else
                {

                }
                int num = ClassNPPTools.getOpenFileCount() - 1;


                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_FormCADdy, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_FormExcel, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_SortCol1, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_SortCol2, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_SortCol3, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_SortCol4, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_SortCol5, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Rotation, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Translation, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Transformation, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord && num == 2);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Polar, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Compare, Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord && num == 2);

                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Measure_FormCADdy, Main.cuTabWhatIsThis == enWhatIAm.CADdyMeasure);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Measure_FormExcel, Main.cuTabWhatIsThis == enWhatIAm.CADdyMeasure);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Measure_FormCAPLAN, Main.cuTabWhatIsThis == enWhatIAm.CADdyMeasure);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Measure_SetID, Main.cuTabWhatIsThis == enWhatIAm.CADdyMeasure);

                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_ChangeCode, Main.cuTabWhatIsThis > enWhatIAm.iDontKnown);
                

                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Coord_Sort, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Measure, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_MeasCode, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Dummy_1, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Dummy_2, false);
                ClassNPPTools.enablePluginMenuFunction((int)CADdyToolsMenuId.Menue_Dummy_3, false);

                if (Main.frmChangeCod != null)
                {
                    if (Main.cuTabWhatIsThis != enWhatIAm.iDontKnown)
                    {
                        Main.frmChangeCod.readCuDatas();
                    }
                    else
                    {
                        Main.frmChangeCod.closeMe();
                        Main.frmChangeCod.Dispose();
                        Main.frmChangeCod = null;
                    }
                }
                if (Main.frmChangeid != null)
                {
                    if (Main.cuTabWhatIsThis == enWhatIAm.CADdyMeasure)
                    {
                        Main.frmChangeid.readCuDatas();
                    }
                    else
                    {
                        Main.frmChangeid.closeMe();
                        Main.frmChangeid.Dispose();
                        Main.frmChangeid = null;
                    }
                }
                if (Main.cuTabWhatIsThis == enWhatIAm.CADdyCoord)
                {
                    if (Main.frmRotate != null)
                    {
                        Main.frmRotate.readCuDatas();
                    }
                    if (Main.frmPolar != null)
                    {
                        Main.frmPolar.readCuDatas();
                    }
                    if (Main.frmTranslate != null)
                    {
                        Main.frmTranslate.readCuDatas();
                    }
                    if (num != 2)
                    {
                        if (Main.frmCompare != null)
                        {
                            Main.frmCompare.closeMe();
                            Main.frmCompare.Dispose();
                            Main.frmCompare = null;
                        }
                        if (Main.frmTransform != null)
                        {
                            Main.frmTransform.closeMe();
                            Main.frmTransform.Dispose();
                            Main.frmTransform = null;
                            return;
                        }
                    }
                }
                else
                {
                    if (Main.frmRotate != null)
                    {
                        Main.frmRotate.closeMe();
                        Main.frmRotate.Dispose();
                        Main.frmRotate = null;
                    }
                    if (Main.frmPolar != null)
                    {
                        Main.frmPolar.closeMe();
                        Main.frmPolar.Dispose();
                        Main.frmPolar = null;
                    }
                    if (Main.frmCompare != null)
                    {
                        Main.frmCompare.closeMe();
                        Main.frmCompare.Dispose();
                        Main.frmCompare = null;
                    }
                    if (Main.frmTranslate != null)
                    {
                        Main.frmTranslate.closeMe();
                        Main.frmTranslate.Dispose();
                        Main.frmTranslate = null;
                    }
                    if (Main.frmTransform != null)
                    {
                        Main.frmTransform.closeMe();
                        Main.frmTransform.Dispose();
                        Main.frmTransform = null;
                    }
                }
            }
        }

        internal static void aboutDialog()
        {
            if (frmAboutprt == null) frmAboutprt = new frmAbout();
            GetWindowRect(PluginBase.nppData._nppHandle, ref nppMainRect);
            frmAboutprt.showDialog((nppMainRect.left + nppMainRect.right) / 2, (nppMainRect.top + nppMainRect.bottom) / 2);
        }

        internal static void PluginCleanUp()
        {
            pluginSettings.save();
            if (frmAboutprt != null)
            {
                frmAboutprt.Close();
                frmAboutprt = null;
            }
            if (frmSettings != null)
            {
                frmSettings.Close();
                frmSettings = null;
            }
            if (frmChangeCod != null)
            {
                frmChangeCod.Close();
                frmChangeCod = null;
            }
            if (frmChangeid != null)
            {
                frmChangeid.Close();
                frmChangeid = null;
            }
            if (frmCompare != null)
            {
                frmCompare.Close();
                frmCompare = null;
            }
            if (frmPolar != null)
            {
                frmPolar.Close();
                frmPolar = null;
            }
            if (frmRotate != null)
            {
                frmRotate.Close();
                frmRotate = null;
            }
            if (frmTransform != null)
            {
                frmTransform.Close();
                frmTransform = null;
            }
            if (frmTranslate != null)
            {
                frmTranslate.Close();
                frmTranslate = null;
            }
        }

        /// <summary>Dummyfunktion</summary>
        internal static void dummy() { }

        /// <summary>Arbeitsfunktion für CADdy Formatiert</summary>
        internal static void formatCADdyKoord()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }

        /// <summary>Koordinatendatei nach Punktnummern sortieren</summary>
        internal static void sortByNumber()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.sortBy(enPointColumn.colPointnumber);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }
        /// <summary>Koordinatendatei nach Rechtswert sortieren</summary>
        internal static void sortByEast()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.sortBy(enPointColumn.colEast);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }
        /// <summary>Koordinatendatei nach Hochwert sortieren</summary>
        internal static void sortByNorth()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.sortBy(enPointColumn.colNorth);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }
        /// <summary>Koordinatendatei nach Höhe sortieren</summary>
        internal static void sortByElev()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.sortBy(enPointColumn.colElev);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }
        /// <summary>Koordinatendatei nach Code sortieren</summary>
        internal static void sortByCode()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.sortBy(enPointColumn.colCode);
                cADdyPoints.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }

        /// <summary>Arbeitsfunktion für Excel Formatiert</summary>
        internal static void formatExcelKoord()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyCoord)
            {
                cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                cADdyPoints.formatCurrentToExcel();
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyPunkte_NoPoints"));
        }

        /// <summary>CADdy-Messdatenformat</summary>
        internal static void formatCADdyMessaten()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyMeasure)
            {
                cADdyMessdaten.getMeasuresFromCurrentCADdy(pluginSettings);
                cADdyMessdaten.formatCurrentToCADdy(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyMessdaten_NoMeasures"));
        }
        /// <summary>CAPLAN-Messdatenformat, nur einen Standpunkt mit mehreren Sätzen</summary>
        internal static void formatCAPLANMessaten()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyMeasure)
            {
                cADdyMessdaten.getMeasuresFromCurrentCADdy(pluginSettings);
                cADdyMessdaten.formatCurrentToCAPLAN(pluginSettings);
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyMessdaten_NoMeasures"));
        }
        /// <summary>Excel Spaltenformat (TAB+Komma)</summary>
        internal static void formatExcelMessaten()
        {
            if (cuTabWhatIsThis == enWhatIAm.CADdyMeasure)
            {
                cADdyMessdaten.getMeasuresFromCurrentCADdy(pluginSettings);
                cADdyMessdaten.formatCurrentToExcel();
            }
            else
                MessageBox.Show(pluginLanguage.getLanguageText("MSGBox_ClassCADdyMessdaten_NoMeasures"));
        }

        /// <summary>Anzeige des Einstellungsdialoges</summary>
        internal static void settingsDialog()
        {
            if (frmSettings == null)
            {
                frmSettings = new frmCADdyToolsSettings(ref pluginLanguage);
                frmSettings.setFromSetting(ref pluginSettings);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(settings, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmSettings.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmSettings_Title");
                _nppTbData.dlgID = idFrmSettings;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmSettings.Handle);
            }
        }

        /// <summary>Anzeige des Code-Tausch-Dialoges</summary>
        internal static void changeCodeDialog()
        {
            if (frmChangeCod == null)
            {
                frmChangeCod = new frmChangeCode(ref pluginLanguage, ref cADdyPoints, ref cADdyMessdaten);
                frmChangeCod.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(change, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmChangeCod.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmChangeCode_Title");
                _nppTbData.dlgID = idFrmChangeId;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmChangeCod.Handle);
            }
            frmChangeCod.readCuDatas();

        }

        /// <summary>Anzeige Instrumenten- / Reflektorhöhen-tausch/setzt Dialog</summary>
        internal static void changeIDDialog()
        {
            if (frmChangeid == null)
            {
                frmChangeid = new frmChangeID(ref pluginLanguage, ref cADdyMessdaten);
                frmChangeid.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(change, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmChangeid.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmChangeID_Title");
                _nppTbData.dlgID = idFrmChangeCode;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmChangeid.Handle);
            }
            frmChangeid.readCuDatas();
        }
        /// <summary>Anzeige Instrumenten- / Reflektorhöhen-tausch/setzt Dialog</summary>
        internal static void rotateCoordDialog()
        {
            if (frmRotate == null)
            {
                frmRotate = new frmRotateCoord(ref pluginLanguage, ref cADdyPoints);
                frmRotate.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(rotate, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmRotate.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmRotateCoord_Title"); ;
                _nppTbData.dlgID = idFrmRotate;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmChangeid.Handle);
            }
            frmRotate.readCuDatas();
        }
        /// <summary>Anzeige Koordinatenverschieben Dialog</summary>
        internal static void translateCoordDialog()
        {
            if (frmTranslate == null)
            {
                frmTranslate = new frmTranslateCoord(ref pluginLanguage, ref cADdyPoints);
                frmTranslate.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(move, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmTranslate.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmTranslateCoord_Title"); ;
                _nppTbData.dlgID = idFrmTranslate;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmTranslate.Handle);
            }
            frmTranslate.readCuDatas();
        }
        /// <summary>Anzeige Koordinatenverschieben Dialog</summary>
        internal static void polarCoordDialog()
        {
            if (frmPolar == null)
            {
                frmPolar = new frmPolarCoord(ref pluginLanguage, ref cADdyPoints);
                frmPolar.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(calc, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmPolar.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmPolarCoord_Title"); ;
                _nppTbData.dlgID = idFrmPolar;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmPolar.Handle);
            }
            frmPolar.readCuDatas();
        }
        /// <summary>Anzeige Koordinatenverschieben Dialog</summary>
        internal static void compareCoordDialog()
        {
            if (frmCompare == null)
            {
                frmCompare = new frmCompareCoord(ref pluginLanguage);
                frmCompare.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(compare, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmCompare.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmCompareCoord_Title"); ;
                _nppTbData.dlgID = idFrmCompare;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);

                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmCompare.Handle);
            }
            frmCompare.readCuDatas();
        }
        /// <summary>Anzeige Koordinatenverschieben Dialog</summary>
        internal static void transformationCoordDialog()
        {
            if (frmTransform == null)
            {
                frmTransform = new frmTransformCoord(ref pluginLanguage);
                frmTransform.setFromSetting(ref pluginSettings, ref notepad);
                using (Bitmap newBmp = new Bitmap(16, 16))
                {
                    Graphics g = Graphics.FromImage(newBmp);
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.Fuchsia;
                    colorMap[0].NewColor = Color.FromKnownColor(KnownColor.ButtonFace);
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(colorMap);
                    g.DrawImage(transf, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, attr);
                    tbIcon = Icon.FromHandle(newBmp.GetHicon());
                }

                NppTbData _nppTbData = new NppTbData();
                _nppTbData.hClient = frmTransform.Handle;
                _nppTbData.pszName = pluginLanguage.getLanguageText("frmTransformCoord_Title"); ;
                _nppTbData.dlgID = idFrmTransform;
                _nppTbData.uMask = NppTbMsg.DWS_DF_CONT_RIGHT | NppTbMsg.DWS_ICONTAB | NppTbMsg.DWS_ICONBAR;
                _nppTbData.hIconTab = (uint)tbIcon.Handle;
                _nppTbData.pszModuleName = PluginName;
                IntPtr _ptrNppTbData = Marshal.AllocHGlobal(Marshal.SizeOf(_nppTbData));
                Marshal.StructureToPtr(_nppTbData, _ptrNppTbData, false);
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMREGASDCKDLG, 0, _ptrNppTbData);
            }
            else
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmTransform.Handle);
            }
            frmTransform.readCuDatas();
            frmTransform.setMinWidth();
        }

        internal static void setMenuToCoord()
        {

        }

        internal static void setMenuToMeasures()
        {

        }

        internal static void sellAllOff()
        {

        }
    }
}