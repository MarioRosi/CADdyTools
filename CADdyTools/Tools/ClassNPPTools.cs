using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Tools
{
    /// <summary></summary>
    public class ClassNPPTools
    {
        /// <summary>Gibt die offenen Dateien zurück</summary>
        /// <returns></returns>
        public static List<String> getOpenFileNames()
        {
            List<String> result = new List<String>();
            Int32 openFileCount = getOpenFileCount();
            if (openFileCount > 0)
            {
                using (OwnClikeStringArray cStringArray = new OwnClikeStringArray(openFileCount, Win32.MAX_PATH))
                {
                    if (Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETOPENFILENAMES, cStringArray.NativePointer, openFileCount) != IntPtr.Zero)
                    {
                        foreach (var filename in cStringArray.ManagedStringsUnicode)
                        {
                            result.Add(filename.ToString());
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>Anzahl der geöfnetten Dateiene</summary>
        /// <returns></returns>
        public static int getOpenFileCount()
        {            
            return (int)Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETNBOPENFILES, 0, (int)NppMsg.ALL_OPEN_FILES);
        }

        public static void switchToFile(String filename)
        {            
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SWITCHTOFILE, 0, filename);
        }

        public static void closefile(String filename, Boolean withoutSave)
        {
            if (getOpenFileNames().Contains(filename))
            {
                switchToFile(filename);
                if (!withoutSave)
                    Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SAVECURRENTFILE, 0, 0);
                else
                {
                    IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
                    editor.SetSavePoint();
                }
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_MENUCOMMAND, 0, NppMenuCmd.IDM_FILE_CLOSE);
            }
        }

        public static void newfile(String filename)
        {
            if (!getOpenFileNames().Contains(filename))
            {
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_MENUCOMMAND, 0, NppMenuCmd.IDM_FILE_NEW);
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SAVECURRENTFILEAS, 0, filename);
            }
        }

        public static String getCurrentFile()
        {
            var path = new StringBuilder(2000);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETFULLCURRENTPATH, 0, path);
            return path.ToString();            
        }

        public static IntPtr getPluginMenuHandle()
        {
            return Win32.SendMessage(PluginBase.nppData._nppHandle, 2049u, 0, 0);
        }

        internal static IntPtr FindPluginMenuItem(uint commandId, out uint index)
        {
            IntPtr pluginMenuHandle = ClassNPPTools.getPluginMenuHandle();
            index = 0u;
            if (pluginMenuHandle == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }
            uint num = 0u;
            while ((ulong)num < (ulong)((long)Win32Extendet.GetMenuItemCount(pluginMenuHandle)))
            {
                IntPtr subMenu = Win32Extendet.GetSubMenu(pluginMenuHandle, num, true);
                if (!(subMenu == IntPtr.Zero))
                {
                    uint num2 = 0u;
                    while ((ulong)num2 < (ulong)((long)Win32Extendet.GetMenuItemCount(subMenu)))
                    {
                        if (Win32Extendet.GetMenuItemId(subMenu, num2, true) == commandId)
                        {
                            index = num2;
                            return subMenu;
                        }
                        num2 += 1u;
                    }
                }
                num += 1u;
            }
            return IntPtr.Zero;
        }

        public static bool enablePluginMenuFunction(int myMenuIndex, bool enable)
        {
            bool result = false;
            uint uIDEnableItem;
            IntPtr intPtr = ClassNPPTools.FindPluginMenuItem((uint)PluginBase._funcItems.Items[myMenuIndex]._cmdID, out uIDEnableItem);
            if (intPtr != IntPtr.Zero)
            {
                uint uEnable = 1024u;
                if (!enable)
                {
                    uEnable = 1025u;
                }
                result = Win32Extendet.EnableMenuItem(intPtr, uIDEnableItem, uEnable);
            }
            return result;
        }

    }
}
