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
     * 
     * b6b60ec05f86e7458d93e632c9f1c533034c28cb400d0445082e29fbf4967e73  CADdyTools_v1015_x64.zip
edeebc3b835e0335b6bce9ddf366ca312e9ab01168da30e45143a65759a4bd68  CADdyTools_v1015_x86.zip

     * 64bit eintrag
     * 
       {
			"folder-name": "CADdyTools",
			"display-name": "CADdyTools",
			"version": "1.0.1.5",
			"id": "b6b60ec05f86e7458d93e632c9f1c533034c28cb400d0445082e29fbf4967e73",
			"repository": "https://github.com/MarioRosi/CADdyTools/releases/download/1.0.1.5/CADdyTools_v1015_x64.zip",
			"description": "Notepad++-Plugin for manipulate CADdy-formated coordinate- and measure-textfiles",
			"author": "Mario Rosenbohm",
			"homepage": "https://github.com/MarioRosi/CADdyTools"
		},
     
     * 32bit eintrag
     * 
       {
			"folder-name": "CADdyTools",
			"display-name": "CADdyTools",
			"version": "1.0.1.5",
			"id": "edeebc3b835e0335b6bce9ddf366ca312e9ab01168da30e45143a65759a4bd68",
			"repository": "https://github.com/MarioRosi/CADdyTools/releases/download/1.0.1.5/CADdyTools_v1015_x86.zip",
			"description": "Notepad++-Plugin for manipulate CADdy-formated coordinate- and measure-textfiles",
			"author": "Mario Rosenbohm",
			"homepage": "https://github.com/MarioRosi/CADdyTools"
		},

         
         */

    class Main
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

        internal const string PluginName = "CADdyTools";
        static String iniFilePath = null;

        static ClassLanguage pluginLanguage = null;
        static Settings pluginSettings = null;

        static frmCADdyToolsSettings frmSettings = null;
        static int idFrmSettings = -10001;

        static frmAbout frmAboutprt = null;

        static frmChangeCode frmChange = null;
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
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
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
            

            PluginBase.SetCommand(0, pluginLanguage.getLanguageText("Menue_Coord"), dummy);
            PluginBase.SetCommand(11, pluginLanguage.getLanguageText("Menue_Coord_FormCADdy"), formatCADdyKoord, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(12, pluginLanguage.getLanguageText("Menue_Coord_FormExcel"), formatExcelKoord, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(20, pluginLanguage.getLanguageText("Menue_Coord_Sort"), dummy);
            PluginBase.SetCommand(21, pluginLanguage.getLanguageText("Menue_Coord_SortCol1"), sortByNumber, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(22, pluginLanguage.getLanguageText("Menue_Coord_SortCol2"), sortByEast, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(23, pluginLanguage.getLanguageText("Menue_Coord_SortCol3"), sortByNorth, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(24, pluginLanguage.getLanguageText("Menue_Coord_SortCol4"), sortByElev, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(25, pluginLanguage.getLanguageText("Menue_Coord_SortCol5"), sortByCode, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(30, pluginLanguage.getLanguageText("Menue_Coord_Rotation"), rotateCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(31, pluginLanguage.getLanguageText("Menue_Coord_Translation"), translateCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(32, pluginLanguage.getLanguageText("Menue_Coord_Transformation"), transformationCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(33, pluginLanguage.getLanguageText("Menue_Coord_Polar"), polarCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(34, pluginLanguage.getLanguageText("Menue_Coord_Compare"), compareCoordDialog, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(69, "----", null);
            PluginBase.SetCommand(70, pluginLanguage.getLanguageText("Menue_Measure"), dummy);
            PluginBase.SetCommand(71, pluginLanguage.getLanguageText("Menue_Measure_FormCADdy"), formatCADdyMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(72, pluginLanguage.getLanguageText("Menue_Measure_FormExcel"), formatExcelMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(73, pluginLanguage.getLanguageText("Menue_Measure_FormCAPLAN"), formatCAPLANMessaten, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(74, pluginLanguage.getLanguageText("Menue_Measure_SetID"), changeIDDialog);
            PluginBase.SetCommand(79, "----", null);
            PluginBase.SetCommand(80, pluginLanguage.getLanguageText("Menue_MeasCode"), dummy);
            PluginBase.SetCommand(81, pluginLanguage.getLanguageText("Menue_ChangeCode"), changeCodeDialog);
            PluginBase.SetCommand(98, "----", null);
            PluginBase.SetCommand(99, pluginLanguage.getLanguageText("Menue_Settings"), settingsDialog);
            PluginBase.SetCommand(100, "About ...", aboutDialog);            
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
            cuTabWhatIsThis = ClassCADdyWhatIAm.check(pluginSettings);
            switch (cuTabWhatIsThis)
            {
                case enWhatIAm.CADdyCoord:
                    cADdyPoints.getPointsFromCurrentCADdy(pluginSettings);
                    cADdyMessdaten.clear();
                    break;
                case enWhatIAm.CADdyMeasure:
                    cADdyMessdaten.getMeasuresFromCurrentCADdy(pluginSettings);
                    cADdyPoints.clear();
                    break;
            }
            if (frmChange != null) frmChange.readCuDatas();
            if (frmChangeid != null) frmChangeid.readCuDatas();
            if (frmRotate != null) frmRotate.readCuDatas();
            if (frmPolar != null) frmPolar.readCuDatas();
            if (frmCompare != null) frmCompare.readCuDatas();
            if (frmTranslate != null) frmTranslate.readCuDatas();
            if (frmTransform != null) frmTransform.readCuDatas();
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
            if (frmChange != null)
            {
                frmChange.Close();
                frmChange = null;
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
            if (frmChange == null)
            {
                frmChange = new frmChangeCode(ref pluginLanguage, ref cADdyPoints, ref cADdyMessdaten);
                frmChange.setFromSetting(ref pluginSettings, ref notepad);
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
                _nppTbData.hClient = frmChange.Handle;
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
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, frmChange.Handle);
            }
            frmChange.readCuDatas();

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
        }
    }
}