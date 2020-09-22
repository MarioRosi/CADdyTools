using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace org.rosenbohm.csharp.Tools
{
	public class Win32Extendet
	{
		public struct NMHDR
		{
			public IntPtr hwndFrom;

			public uint idFrom;

			public uint code;
		}

		public struct COMBOBOXINFO
		{
			public int cbSize;

			public RECT rcItem;

			public RECT rcButton;

			public IntPtr stateButton;

			public IntPtr hwndCombo;

			public IntPtr hwndItem;

			public IntPtr hwndList;
		}

		public struct MENUITEMINFO
		{
			public uint cbSize;

			public uint fMask;

			public uint fType;

			public uint fState;

			public uint wID;

			public IntPtr hSubMenu;

			public IntPtr hbmpChecked;

			public IntPtr hbmpUnchecked;

			public IntPtr dwItemData;

			public IntPtr dwTypeData;

			public uint cch;

			public IntPtr hbmpItem;

			public static uint Size
			{
				get
				{
					return (uint)Marshal.SizeOf(typeof(Win32Extendet.MENUITEMINFO));
				}
			}
		}

		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		public enum BeepType : uint
		{
			SimpleBeep = 4294967295u,
			MB_OK = 0u,
			MB_ICONERROR = 16u,
			MB_ICONQUESTION = 32u,
			MB_ICONEXCLAMATION = 48u,
			MB_ICONASTERISK = 64u
		}

		public struct REBARBANDINFO
		{
			public int cbSize;

			public int fMask;

			public int fStyle;

			public int clrFore;

			public int clrBack;

			public IntPtr lpText;

			public int cch;

			public int iImage;

			public IntPtr hwndChild;

			public int cxMinChild;

			public int cyMinChild;

			public int cx;

			public IntPtr hbmBack;

			public int wID;

			public int cyChild;

			public int cyMaxChild;

			public int cyIntegral;

			public int cxIdeal;

			public IntPtr lParam;

			public int cxHeader;
		}

		public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 256;

		public const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;

		public const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;

		public const int MAX_PATH = 260;

		public const uint MF_BYCOMMAND = 0u;

		public const uint MF_BYPOSITION = 1024u;

		public const uint MF_CHECKED = 8u;

		public const uint MF_UNCHECKED = 0u;

		public const uint MF_ENABLED = 0u;

		public const uint MF_GRAYED = 1u;

		public const uint MF_DISABLED = 2u;

		public const int MA_ACTIVATE = 1;

		public const int MA_ACTIVATEANDEAT = 2;

		public const int MA_NOACTIVATE = 3;

		public const int MA_NOACTIVATEANDEAT = 4;

		public const int WA_INACTIVE = 0;

		public const int WA_ACTIVE = 1;

		public const int WA_CLICKACTIVE = 2;

		public const int WM_CREATE = 1;

		public const int WM_DESTROY = 2;

		public const int WM_ACTIVATE = 6;

		public const int WM_ACTIVATEAPP = 28;

		public const int WM_MOUSEACTIVATE = 33;

		public const int WM_NOTIFY = 78;

		public const int EM_SETMARGINS = 211;

		public const int EM_GETMARGINS = 211;

		public const int WM_KEYDOWN = 256;

		public const int WM_KEYUP = 257;

		public const int WM_CHAR = 258;

		public const int WM_UNICHAR = 265;

		public const int WM_INITDIALOG = 272;

		public const int WM_COMMAND = 273;

		public const int WM_REFLECT = 8192;

		public const int EM_SETCUEBANNER = 5377;

		public const int EC_LEFTMARGIN = 1;

		public const int EC_RIGHTMARGIN = 2;

		public const int SW_HIDE = 0;

		public const int SW_SHOWNOACTIVATE = 4;

		public const int SWP_NOSIZE = 1;

		public const int SWP_NOMOVE = 2;

		public const uint SWP_NOACTIVATE = 16u;

		public static IntPtr HWND_TOP = (IntPtr)0;

		public static IntPtr HWND_TOPMOST = (IntPtr)(-1);

		public const int GWL_WNDPROC = -4;

		public const int GWL_HINSTANCE = -6;

		public const int GWL_HWNDPARENT = -8;

		public const int GWL_STYLE = -16;

		public const int GWL_EXSTYLE = -20;

		public const int GWL_USERDATA = -21;

		public const int GWL_ID = -12;

		public const int WS_CLIPCHILDREN = 33554432;

		public const int WS_CHILD = 1073741824;

		public const int BS_PUSHBUTTON = 0;

		public const int BS_DEFPUSHBUTTON = 1;

		public const int BS_CHECKBOX = 2;

		public const int BS_AUTOCHECKBOX = 3;

		public const int BS_RADIOBUTTON = 4;

		public const int BS_3STATE = 5;

		public const int BS_AUTO3STATE = 6;

		public const int BS_GROUPBOX = 7;

		public const int BS_USERBUTTON = 8;

		public const int BS_AUTORADIOBUTTON = 9;

		public const int BS_PUSHBOX = 10;

		public const int BS_OWNERDRAW = 11;

		public const int BS_TYPEMASK = 15;

		public const int BS_LEFTTEXT = 32;

		public const int BS_TEXT = 0;

		public const int BS_ICON = 64;

		public const int BS_BITMAP = 128;

		public const int BS_LEFT = 256;

		public const int BS_RIGHT = 512;

		public const int BS_CENTER = 768;

		public const int BS_TOP = 1024;

		public const int BS_BOTTOM = 2048;

		public const int BS_VCENTER = 3072;

		public const int BS_PUSHLIKE = 4096;

		public const int BS_MULTILINE = 8192;

		public const int BS_NOTIFY = 16384;

		public const int BS_FLAT = 32768;

		public const int BS_RIGHTBUTTON = 32;

		public const int WS_EX_DLGMODALFRAME = 1;

		public const int WS_EX_NOPARENTNOTIFY = 4;

		public const int WS_EX_TOPMOST = 8;

		public const int WS_EX_ACCEPTFILES = 16;

		public const int WS_EX_TRANSPARENT = 32;

		public const int WS_EX_MDICHILD = 64;

		public const int WS_EX_TOOLWINDOW = 128;

		public const int WS_EX_WINDOWEDGE = 256;

		public const int WS_EX_CLIENTEDGE = 512;

		public const int WS_EX_CONTEXTHELP = 1024;

		public const int WS_EX_RIGHT = 4096;

		public const int WS_EX_LEFT = 0;

		public const int WS_EX_RTLREADING = 8192;

		public const int WS_EX_LTRREADING = 0;

		public const int WS_EX_LEFTSCROLLBAR = 16384;

		public const int WS_EX_RIGHTSCROLLBAR = 0;

		public const int WS_EX_CONTROLPARENT = 65536;

		public const int WS_EX_STATICEDGE = 131072;

		public const int WS_EX_APPWINDOW = 262144;

		public const int WS_EX_OVERLAPPEDWINDOW = 768;

		public const int WS_EX_PALETTEWINDOW = 392;

		public const uint MIIM_BITMAP = 128u;

		public const uint MIIM_CHECKMARKS = 8u;

		public const uint MIIM_DATA = 32u;

		public const uint MIIM_FTYPE = 256u;

		public const uint MIIM_ID = 2u;

		public const uint MIIM_STATE = 1u;

		public const uint MIIM_STRING = 64u;

		public const uint MIIM_SUBMENU = 4u;

		public const uint MIIM_TYPE = 16u;

		public const uint MFT_BITMAP = 4u;

		public const uint MFT_MENUBARBREAK = 32u;

		public const uint MFT_MENUBREAK = 64u;

		public const uint MFT_OWNERDRAW = 256u;

		public const uint MFT_RADIOCHECK = 512u;

		public const uint MFT_RIGHTJUSTIFY = 16384u;

		public const uint MFT_RIGHTORDER = 8192u;

		public const uint MFT_SEPARATOR = 2048u;

		public const uint MFT_STRING = 0u;

		public const uint MFS_CHECKED = 8u;

		public const uint MFS_DEFAULT = 4096u;

		public const uint MFS_DISABLED = 3u;

		public const uint MFS_ENABLED = 0u;

		public const uint MFS_GRAYED = 3u;

		public const uint MFS_HILITE = 128u;

		public const uint MFS_UNCHECKED = 0u;

		public const uint MFS_UNHILITE = 0u;

		public const int RBS_TOOLTIPS = 256;

		public const int RBS_VARHEIGHT = 512;

		public const int RBS_BANDBORDERS = 1024;

		public const int RBS_FIXEDORDER = 2048;

		public const int RBBS_BREAK = 1;

		public const int RBBS_FIXEDSIZE = 2;

		public const int RBBS_CHILDEDGE = 4;

		public const int RBBS_HIDDEN = 8;

		public const int RBBS_NOVERT = 16;

		public const int RBBS_FIXEDBMP = 32;

		public const int RBBS_VARIABLEHEIGHT = 64;

		public const int RBBS_GRIPPERALWAYS = 128;

		public const int RBBS_NOGRIPPER = 256;

		public const int RBBS_USECHEVRON = 512;

		public const int RBBS_HIDETITLE = 1024;

		public const int RBBS_TOPALIGN = 2048;

		public const int RBBIM_STYLE = 1;

		public const int RBBIM_COLORS = 2;

		public const int RBBIM_TEXT = 4;

		public const int RBBIM_IMAGE = 8;

		public const int RBBIM_CHILD = 16;

		public const int RBBIM_CHILDSIZE = 32;

		public const int RBBIM_SIZE = 64;

		public const int RBBIM_BACKGROUND = 128;

		public const int RBBIM_ID = 256;

		public const int RBBIM_IDEALSIZE = 512;

		public const int RBBIM_LPARAM = 1024;

		public const int RBBIM_HEADERSIZE = 2048;

		public const int RB_INSERTBANDA = 1025;

		public const int RB_INSERTBANDW = 1034;

		public const int RB_DELETEBAND = 1026;

		public const int RB_GETBARINFO = 1027;

		public const int RB_SETBARINFO = 1028;

		public const int RB_SETBANDINFOA = 1030;

		public const int RB_SETBANDINFOW = 1035;

		public const int RB_SETPARENT = 1031;

		public const int RB_HITTEST = 1032;

		public const int RB_GETRECT = 1033;

		public const int RB_GETBANDCOUNT = 1036;

		public const int RB_GETROWCOUNT = 1037;

		public const int RB_GETROWHEIGHT = 1038;

		public const int RB_IDTOINDEX = 1040;

		public const int RB_GETTOOLTIPS = 1041;

		public const int RB_SETTOOLTIPS = 1042;

		public const int RB_SETBKCOLOR = 1043;

		public const int RB_GETBKCOLOR = 1044;

		public const int RB_SETTEXTCOLOR = 1045;

		public const int RB_GETTEXTCOLOR = 1046;

		public const int RB_SIZETORECT = 1047;

		public const int RB_BEGINDRAG = 1048;

		public const int RB_ENDDRAG = 1049;

		public const int RB_DRAGMOVE = 1050;

		public const int RB_GETBARHEIGHT = 1051;

		public const int RB_GETBANDINFOW = 1052;

		public const int RB_GETBANDINFOA = 1053;

		public const int RB_MINIMIZEBAND = 1054;

		public const int RB_MAXIMIZEBAND = 1055;

		public const int RB_GETBANDBORDERS = 1058;

		public const int RB_SHOWBAND = 1059;

		public const int RB_SETPALETTE = 1061;

		public const int RB_GETPALETTE = 1062;

		public const int RB_MOVEBAND = 1063;

		public const int RB_GETBANDMARGINS = 1064;

		public const int RB_PUSHCHEVRON = 1067;

		public const int RB_SETBANDWIDTH = 1068;

		public const int TCM_FIRST = 4864;

		public const int TCM_GETIMAGELIST = 4866;

		public const int TCM_SETIMAGELIST = 4867;

		public const int TCM_GETITEMCOUNT = 4868;

		public const int TCM_GETITEMA = 4869;

		public const int TCM_GETITEMW = 4924;

		public const int TCM_SETITEMA = 4870;

		public const int TCM_SETITEMW = 4925;

		public const int TCM_INSERTITEMA = 4871;

		public const int TCM_INSERTITEMW = 4926;

		public const int TCM_DELETEITEM = 4872;

		public const int TCM_DELETEALLITEMS = 4873;

		public const int TCM_GETITEMRECT = 4874;

		public const int TCM_GETCURSEL = 4875;

		public const int TCM_SETCURSEL = 4876;

		public const int TCM_HITTEST = 4877;

		public const int TCM_SETITEMEXTRA = 4878;

		public const int TCM_ADJUSTRECT = 4904;

		public const int TCM_SETITEMSIZE = 4905;

		public const int TCM_REMOVEIMAGE = 4906;

		public const int TCM_SETPADDING = 4907;

		public const int TCM_GETROWCOUNT = 4908;

		public const int TCM_GETCURFOCUS = 4911;

		public const int TCM_SETCURFOCUS = 4912;

		public const int TCM_SETMINTABWIDTH = 4913;

		public const int TCM_DESELECTALL = 4914;

		public const int TCM_HIGHLIGHTITEM = 4915;

		public const int TCM_SETEXTENDEDSTYLE = 4916;

		public const int TCM_GETEXTENDEDSTYLE = 4917;

		public const int TCN_SELCHANGE = -551;

		public const int LB_ADDSTRING = 384;

		public const int LB_INSERTSTRING = 385;

		public const int LB_DELETESTRING = 386;

		public const int LB_SELITEMRANGEEX = 387;

		public const int LB_RESETCONTENT = 388;

		public const int LB_SETSEL = 389;

		public const int LB_SETCURSEL = 390;

		public const int LB_GETSEL = 391;

		public const int LB_GETCURSEL = 392;

		public const int LB_GETTEXT = 393;

		public const int LB_GETTEXTLEN = 394;

		public const int LB_GETCOUNT = 395;

		public const int LB_SELECTSTRING = 396;

		public const int LB_DIR = 397;

		public const int LB_GETTOPINDEX = 398;

		public const int LB_FINDSTRING = 399;

		public const int LB_GETSELCOUNT = 400;

		public const int LB_GETSELITEMS = 401;

		public const int LB_SETTABSTOPS = 402;

		public const int LB_GETHORIZONTALEXTENT = 403;

		public const int LB_SETHORIZONTALEXTENT = 404;

		public const int LB_SETCOLUMNWIDTH = 405;

		public const int LB_ADDFILE = 406;

		public const int LB_SETTOPINDEX = 407;

		public const int LB_GETITEMRECT = 408;

		public const int LB_GETITEMDATA = 409;

		public const int LB_SETITEMDATA = 410;

		public const int LB_SELITEMRANGE = 411;

		public const int LB_SETANCHORINDEX = 412;

		public const int LB_GETANCHORINDEX = 413;

		public const int LB_SETCARETINDEX = 414;

		public const int LB_GETCARETINDEX = 415;

		public const int LB_SETITEMHEIGHT = 416;

		public const int LB_GETITEMHEIGHT = 417;

		public const int LB_FINDSTRINGEXACT = 418;

		public const int LB_SETLOCALE = 421;

		public const int LB_GETLOCALE = 422;

		public const int LB_SETCOUNT = 423;

		public const int LB_INITSTORAGE = 424;

		public const int LB_ITEMFROMPOINT = 425;

		public const int CBN_SELCHANGE = 1;

		public const int DSTINVERT = 5570569;

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, NppMenuCmd lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, IntPtr lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, int lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, out int lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, IntPtr wParam, int lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, ref LangType lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, NppMsg Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, BabyGridMsg Msg, int wParam, int lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, BabyGridMsg Msg, ref _BGCELL wParam, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, SciMsg Msg, int wParam, IntPtr lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, SciMsg Msg, int wParam, string lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, SciMsg Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, SciMsg Msg, int wParam, int lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref Win32Extendet.REBARBANDINFO lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref Win32Extendet.NMHDR lParam);

		[DllImport("user32")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

		[DllImport("kernel32.dll")]
		public static extern int FormatMessage(int dwFlags, int lpSource, int dwMessageId, int dwLanguageId, ref string lpBuffer, int nSize, int Arguments);

		public static string GetErrorMessage(int errorCode)
		{
			int nSize = 255;
			string result = "";
			if (Win32Extendet.FormatMessage(4864, 0, errorCode, 0, ref result, nSize, 0) == 0)
			{
				return null;
			}
			return result;
		}

		[DllImport("kernel32")]
		public static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

		[DllImport("kernel32")]
		public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

		[DllImport("user32")]
		public static extern IntPtr GetMenu(IntPtr hWnd);

		[DllImport("user32")]
		public static extern int CheckMenuItem(IntPtr hmenu, int uIDCheckItem, int uCheck);

		[DllImport("user32.dll")]
		public static extern bool GetComboBoxInfo(IntPtr hwnd, ref Win32Extendet.COMBOBOXINFO pcbi);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetActiveWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr GetFocus();

		[DllImport("user32.dll")]
		public static extern IntPtr SetFocus(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll")]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowTextLength(IntPtr hWnd);

		public static string GetWindowText(IntPtr hWnd)
		{
			int windowTextLength = Win32Extendet.GetWindowTextLength(hWnd);
			if (windowTextLength <= 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(windowTextLength + 1);
			Win32Extendet.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetWindowText(IntPtr hwnd, string lpString);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		[DllImport("user32.dll")]
		public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
		private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

		public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size == 8)
			{
				return Win32Extendet.GetWindowLongPtr64(hWnd, nIndex);
			}
			return new IntPtr(Win32Extendet.GetWindowLong(hWnd, nIndex));
		}

		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
		private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
		{
			if (IntPtr.Size == 8)
			{
				return Win32Extendet.SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			}
			return new IntPtr(Win32Extendet.SetWindowLong(hWnd, nIndex, dwNewLong.ToInt32()));
		}

		[DllImport("user32.dll")]
		public static extern bool GetMenuItemInfoW(IntPtr hMenu, uint uItem, bool fByPosition, ref Win32Extendet.MENUITEMINFO lpmii);

		[DllImport("user32.dll")]
		public static extern bool SetMenuItemInfoW(IntPtr hMenu, uint uItem, bool fByPosition, [In] ref Win32Extendet.MENUITEMINFO lpmii);

		[DllImport("user32.dll")]
		public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		public static string GetMenuItemString(IntPtr hMenu, uint uItem, bool fByPosition)
		{
			Win32Extendet.MENUITEMINFO mENUITEMINFO = default(Win32Extendet.MENUITEMINFO);
			mENUITEMINFO.cbSize = Win32Extendet.MENUITEMINFO.Size;
			mENUITEMINFO.fMask = 256u;
			Win32Extendet.GetMenuItemInfoW(hMenu, uItem, fByPosition, ref mENUITEMINFO);
			string result = null;
			if ((mENUITEMINFO.fType & 2048u) == 0u)
			{
				mENUITEMINFO.dwTypeData = IntPtr.Zero;
				mENUITEMINFO.cch = 0u;
				mENUITEMINFO.fMask = 64u;
				Win32Extendet.GetMenuItemInfoW(hMenu, uItem, fByPosition, ref mENUITEMINFO);
				int cch = (int)mENUITEMINFO.cch;
				mENUITEMINFO.cch += 1u;
				IntPtr intPtr = Marshal.AllocHGlobal((cch + 1) * 2);
				mENUITEMINFO.dwTypeData = intPtr;
				mENUITEMINFO.fMask = 320u;
				Win32Extendet.GetMenuItemInfoW(hMenu, uItem, fByPosition, ref mENUITEMINFO);
				result = Marshal.PtrToStringUni(intPtr, cch);
				Marshal.FreeHGlobal(intPtr);
			}
			return result;
		}

		public static IntPtr GetSubMenu(IntPtr hMenu, uint uItem, bool fByPosition)
		{
			Win32Extendet.MENUITEMINFO mENUITEMINFO = default(Win32Extendet.MENUITEMINFO);
			mENUITEMINFO.cbSize = Win32Extendet.MENUITEMINFO.Size;
			mENUITEMINFO.fMask = 4u;
			Win32Extendet.GetMenuItemInfoW(hMenu, uItem, fByPosition, ref mENUITEMINFO);
			return mENUITEMINFO.hSubMenu;
		}

		public static uint GetMenuItemId(IntPtr hMenu, uint uItem, bool fByPosition)
		{
			Win32Extendet.MENUITEMINFO mENUITEMINFO = default(Win32Extendet.MENUITEMINFO);
			mENUITEMINFO.cbSize = Win32Extendet.MENUITEMINFO.Size;
			mENUITEMINFO.fMask = 2u;
			Win32Extendet.GetMenuItemInfoW(hMenu, uItem, fByPosition, ref mENUITEMINFO);
			return mENUITEMINFO.wID;
		}

		[DllImport("user32.dll")]
		public static extern int GetMenuItemCount(IntPtr hMenu);

		[DllImport("user32.dll")]
		public static extern int GetDlgCtrlID(IntPtr hwndCtl);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);

		[DllImport("user32.dll")]
		public static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumChildWindows(IntPtr hwndParent, Win32Extendet.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		public static bool EnumChildWindows(IntPtr hwndParent, Predicate<IntPtr> callback)
		{
			bool result = false;
			GCHandle value = GCHandle.Alloc(callback);
			try
			{
				Win32Extendet.EnumWindowsProc lpEnumFunc = new Win32Extendet.EnumWindowsProc(Win32Extendet.EnumChildWindowsCallback);
				Win32Extendet.EnumChildWindows(hwndParent, lpEnumFunc, GCHandle.ToIntPtr(value));
			}
			finally
			{
				if (value.IsAllocated)
				{
					value.Free();
				}
			}
			return result;
		}

		private static bool EnumChildWindowsCallback(IntPtr handle, IntPtr pointerToPredicate)
		{
			Predicate<IntPtr> expr_13 = GCHandle.FromIntPtr(pointerToPredicate).Target as Predicate<IntPtr>;
			if (expr_13 == null)
			{
				throw new InvalidCastException("GCHandle Target could not be cast as Predicate<IntPtr>");
			}
			return expr_13(handle);
		}

		public static List<IntPtr> GetChildWindows(IntPtr parent)
		{
			List<IntPtr> list = new List<IntPtr>();
			GCHandle value = GCHandle.Alloc(list);
			try
			{
				Win32Extendet.EnumWindowsProc lpEnumFunc = new Win32Extendet.EnumWindowsProc(Win32Extendet.GetChildWindowsCallback);
				Win32Extendet.EnumChildWindows(parent, lpEnumFunc, GCHandle.ToIntPtr(value));
			}
			finally
			{
				if (value.IsAllocated)
				{
					value.Free();
				}
			}
			return list;
		}

		private static bool GetChildWindowsCallback(IntPtr handle, IntPtr pointerToList)
		{
			List<IntPtr> expr_13 = GCHandle.FromIntPtr(pointerToList).Target as List<IntPtr>;
			if (expr_13 == null)
			{
				throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
			}
			expr_13.Add(handle);
			return true;
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MessageBeep(Win32Extendet.BeepType uType);

		[DllImport("kernel32")]
		public static extern bool AllocConsole();

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		public static string GetClassName(IntPtr hWnd)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			Win32Extendet.GetClassName(hWnd, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("gdi32.dll")]
		public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, uint dwRop);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);
	}
}
