using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Security;
using System.Drawing.Drawing2D;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    #region Central class for sharing data across all classes of the project
    static class GlobalData
    {
        internal static Dictionary<string, IEDSParser> Parsers;
        internal static List<string> PropertyList;
        internal static List<RenamedEventArgs> RenamedFiles;
        internal static StringCollection CreatedFiles;
        internal static StringCollection DeletedFiles;
        internal static StringCollection ChangedFiles;
        internal static EDSIndexer Indexer;//= new EDSIndexer();
        internal static StringDictionary FileTypes;

        static GlobalData()
        {
            Parsers = new Dictionary<string, IEDSParser>(64);
            PropertyList = new List<string>();
            RenamedFiles = new List<RenamedEventArgs>(32);
            CreatedFiles = new StringCollection();
            DeletedFiles = new StringCollection();
            ChangedFiles = new StringCollection();

            //create file type dictionary and populate the members
            FileTypes = new StringDictionary();
            CreateFileTypeDictionary();

            IndexRootPath = Environment.GetEnvironmentVariable("appdata") + @"\EDS\indexes\";
            EmailIndexPath = Environment.GetEnvironmentVariable("appdata") + @"\EDS\email indexes\";
            Directory.CreateDirectory(IndexRootPath);
        }

        #region Code to extract the descriptive information for every file type from the registry
        static void CreateFileTypeDictionary()
        {
            FileTypes.Add("*", "( all file types )");
            RegistryKey rk = Registry.ClassesRoot;
            foreach (string ext in rk.GetSubKeyNames())
            {
                if (ext[0] == '.' && ext.Length < 7)
                {
                    //open .ext key
                    RegistryKey subKey = rk.OpenSubKey(ext);
                    //read the default value in .ext key
                    string defaultValue = (string)subKey.GetValue("");
                    if (!string.IsNullOrEmpty(defaultValue))
                    {
                        RegistryKey subKey2 = rk.OpenSubKey(defaultValue);
                        if (subKey2 != null)
                        {
                            defaultValue = (string)subKey2.GetValue("");

                            if (!string.IsNullOrEmpty(defaultValue))
                                FileTypes.Add(ext, defaultValue);

                            subKey2.Close();
                        }
                    }
                    subKey.Close();
                }
            }
            rk.Close();
        }
        #endregion

        private static string ProjectPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
        private static string ResourceFolder = ProjectPath + @"\resources\";
        internal static string PdfinfoexePath = ResourceFolder + "pdfinfo.exe";
        internal static string PdftotextexePath = ResourceFolder + "pdftotext.exe";
        internal static string AntidocexePath = ResourceFolder + @"antiword\antiword.exe";
        internal static string OutputFile = Path.GetTempPath() + Path.GetRandomFileName();
        internal static string ParserFolder = ProjectPath + @"\parsers\";
        internal static string DefaultExtensions = "";// ".3g2 .3gp .3gp2 .aa .aac .ac3 .aif .aiff .amc .amr .ape .asf .asf .asm .asx .au .avi .bat .bmp .bz2 .c .cda .cdda .cmd .cpp .cs .dll .doc .dts .dv .emf .exe .flac .gif .gsm .gz .h .htm .html .ivf .java .jpeg .jpg .js .m1v .m2v .m3u .m4a .m4b .m4e .mid .midi .mkv .mod .mov .mp2 .mp2v .mp3 .mp4 .mp4 .mpa .mpa .mpc .mpe .mpeg .mpg .mps .mpv .mpv2 .mswmm .nt .ofr .ogg .ogm .pdf .pl .png .py .qt .ra .ram .ram .rar .rm .rv .sys  .tar .tiff .txt .vb .vbs .wav .wave .wm .wma .wmf .wmp .wmv .wmx .wvx .xml .zip";
        internal static List<string> Drives = new List<string>(Environment.GetLogicalDrives()); //new string[] { @"c:\WINDOWS\system32", @"c:\WINDOWS\web\wallpaper",@"C:\windOWS\media",@"C:\windows\help\tours\windowsmediaplayer\Video", });//
        internal static string IndexRootPath;
        internal static string EmailIndexPath;
        internal static string args;
        internal static string DocFileTypes = "";//".rar .zip .gz .tar .bz2 .doc .pdf .html .htm .xml .txt .c .h .cpp .cs .java .bat .cmd .nt .pl .py .asm .js .vbs .vb .dll .exe .sys";
        internal static string AudioFileTypes = "";//".asf .au .aiff .aac .amr .aif .ape .ac3 .aa .cda .cdda .dts .flac .gsm .mp3 .mp4 .m4a .m4b .mid .midi .mpc .mpa .m3u .ogg .ofr .ra .wma .wav .wave";
        internal static string VideoFileTypes = "";// ".3g2 .3gp .3gp2 .amc .asx .avi .dv .ivf .m1v .m2v .m4e .mkv .mov .mod .mp2 .mp2v .mpe .mpeg .mpg .mps .mpv .mpv2 .mswmm .ogm .qt .ram .rm .rv .wm .wmp .wmv .wmx .wvx";
        internal static string ImageFileTypes = "";//".bmp .emf .jpeg .jpg .png .gif .tiff .wmf";

        internal static MainForm MainForm = null;
        internal static StatusStrip MainStatusStrip = null;
        internal static Label lIndexingStatus = null;
        internal static bool IndexingCompleted = false;
        internal static bool RunCrawler = true;         //Boolean variable which indicates whether the scheduler should be run or not
        internal static bool RunScheduler = true;
        internal static bool RunMonitor = false;
        internal static bool RunEmailIndexer = false;

        public static string AutoEllipsis(string str)
        {
            string modified = str;
            int len = 25;
            if (str.Length > len)
            {
                modified = str.Substring(0, len);
                modified += "...";
            }
            return modified;
        }

    }
    #endregion

    #region Some graphics utility functions for drawing round and semi round rectangles etc
    static class GraphicsHelper
    {
        public static void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        public static void FillRoundRect(Graphics g, Brush b, float X, float Y, float width, float height, float radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.FillPath(b, gp);
            gp.Dispose();
        }
        public static void FillSemiRoundRect(Graphics g, Brush b, float X, float Y, float width, float height, float radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90); //lt
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90); //rt
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddRectangle(new Rectangle((int)X, (int)(Y + 2 * radius), (int)width, (int)(height - 2 * radius)));
            gp.CloseFigure();
            g.FillPath(b, gp);
            gp.Dispose();

            //draw borderline below header
            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle((int)X, (int)(height), (int)width, (int)(height)), Color.FromArgb(172, 168, 153), Color.FromArgb(150, 146, 130), 30);
            g.FillRectangle(lgb, new Rectangle((int)X, (int)(height), (int)width, 6));
            lgb.Dispose();

        }
    }
    #endregion

    #region Some Win32 API utility functions for dealing with file properties( especially file path > 256 characters)
    [SuppressUnmanagedCodeSecurity()]
    static class Win32Helper
    {

        [DllImport("shlwapi.dll")]
        public static extern bool PathFileExists(string path);

        //File Exists or not
        public static bool PathExist(string path)
        {
            //check whether the file path is preceeded with \\?\ 
            if (!path.StartsWith(@"\\?\")) path = @"\\?\" + path;

            return PathFileExists(path);
        }

        //File size 
        public static long FileSize(string path)
        {
            //check whether the file path is preceeded with \\?\ 
            if (!path.StartsWith(@"\\?\")) path = @"\\?\" + path;
            WIN32_FILE_ATTRIBUTE_DATA data;
            if (GetFileAttributesEx(path, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out data))
            {
                long size = 0;
                size |= data.nFileSizeHigh;
                size <<= 32;
                size |= data.nFileSizeLow;
                return size;
            }
            return 0;
        }

        //Creation Time
        public static DateTime CreatedTime(string path)
        {
            //check whether the file path is preceeded with \\?\ 
            if (!path.StartsWith(@"\\?\")) path = @"\\?\" + path;
            WIN32_FILE_ATTRIBUTE_DATA data;
            if (GetFileAttributesEx(path, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out data))
            {
                SYSTEMTIME st;
                FileTimeToSystemTime(ref data.ftLastWriteTime, out st);
                return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second);
                //return st.Year + "" + st.Month + "" + st.Day;
            }
            else
            {
                throw new Exception("Created Time Exception");
            }
        }

        //Last Access Time
        public static DateTime LastAccessTime(string path)
        {
            //check whether the file path is preceeded with \\?\ 
            if (!path.StartsWith(@"\\?\")) path = @"\\?\" + path;
            WIN32_FILE_ATTRIBUTE_DATA data;
            if (GetFileAttributesEx(path, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out data))
            {
                SYSTEMTIME st;
                FileTimeToSystemTime(ref data.ftLastWriteTime, out st);
                return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second);
                //return st.Year + "" + st.Month + "" + st.Day;
            }
            else
            {
                throw new Exception("LastAccess Time Exception");
            }
        }

        //Last Modified Time
        public static DateTime LastModifiedTime(string path)
        {
            //check whether the file path is preceeded with \\?\ 
            if (!path.StartsWith(@"\\?\")) path = @"\\?\" + path;
            WIN32_FILE_ATTRIBUTE_DATA data;
            if (GetFileAttributesEx(path, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out data))
            {
                SYSTEMTIME st;
                FileTimeToSystemTime(ref data.ftLastWriteTime, out st);
                return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second);
                //return st.Year + "" + st.Month + "" + st.Day;
            }
            else
            {
                throw new Exception("LastModified Time Exception");
            }
        }
        //GetAttributes......
        public static string GetAttributes(string path)
        {
            string attrib = ""; ;
            int res = GetFileAttributes(path);
            if ((res & 1) == 1) attrib += "ReadOnly, ";
            if ((res & 2) == 2) attrib += "Hidden, ";
            if ((res & 4) == 4) attrib += "System, ";
            if ((res & 16) == 16) attrib += "Directory, ";
            if ((res & 32) == 32) attrib += "Archive, ";
            if ((res & 64) == 64) attrib += "Device, ";
            if ((res & 128) == 128) attrib += "Normal, ";
            if ((res & 256) == 256) attrib += "Temporary, ";
            if ((res & 512) == 512) attrib += "SparseFile, ";
            if ((res & 1024) == 1024) attrib += "ReparsePoint, ";
            if ((res & 2048) == 2048) attrib += "Compressed, ";
            if ((res & 4096) == 4096) attrib += "Offline, ";
            if ((res & 8192) == 8192) attrib += "NotContentIndexed, ";
            if ((res & 16384) == 16384) attrib += "Encrypted, ";

            return attrib;
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetFileAttributes(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool GetFileAttributesEx(string lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, out WIN32_FILE_ATTRIBUTE_DATA fileData);

        [StructLayout(LayoutKind.Sequential)]
        private struct WIN32_FILE_ATTRIBUTE_DATA
        {
            public FileAttributes dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
        }
        private enum GET_FILEEX_INFO_LEVELS
        {
            GetFileExInfoStandard,
            GetFileExMaxInfoLevel
        }

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        static extern bool FileTimeToSystemTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime, out SYSTEMTIME lpSystemTime);

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            [MarshalAs(UnmanagedType.U2)]
            public short Year;
            [MarshalAs(UnmanagedType.U2)]
            public short Month;
            [MarshalAs(UnmanagedType.U2)]
            public short DayOfWeek;
            [MarshalAs(UnmanagedType.U2)]
            public short Day;
            [MarshalAs(UnmanagedType.U2)]
            public short Hour;
            [MarshalAs(UnmanagedType.U2)]
            public short Minute;
            [MarshalAs(UnmanagedType.U2)]
            public short Second;
            [MarshalAs(UnmanagedType.U2)]
            public short Milliseconds;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SHObjectProperties(IntPtr hwnd, uint dwType, String filename, String page);

        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        #region Shell File Copy, Delete Operation Interop Code

        struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public int wFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTo;
            public uint fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProgressTitle;
        }
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);

        public static void SHFileDelete(string path)
        {
            SHFILEOPSTRUCT sfo = new SHFILEOPSTRUCT();
            sfo.hwnd = GlobalData.MainForm.Handle;
            sfo.fAnyOperationsAborted = false;
            sfo.wFunc = 0x0003; //delete
            sfo.fFlags = 0x0040 | 0x0400;//recycle bin | no error UI
            sfo.pFrom = path;
            sfo.pTo = null;
            sfo.hNameMappings = IntPtr.Zero;

            SHFileOperation(ref sfo);
        }
        public static void SHFileCopy(string from, string to)
        {
            SHFILEOPSTRUCT sfo = new SHFILEOPSTRUCT();
            sfo.hwnd = GlobalData.MainForm.Handle;
            sfo.fAnyOperationsAborted = false;
            sfo.wFunc = 0x0002; //copy
            sfo.fFlags = 0x0400;// no error UI
            sfo.pFrom = from;
            sfo.pTo = to;
            sfo.hNameMappings = IntPtr.Zero;

            SHFileOperation(ref sfo);
        }
        #endregion

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        #region Icon extraction Wrapper

        public enum IconSize
        {
            Small,
            Large
        }
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);


        public static Icon Extract(string File, IconSize Size)
        {
            IntPtr hIcon;
            SHFILEINFO shinfo = new SHFILEINFO();

            if (Size == IconSize.Large)
            {
                hIcon = SHGetFileInfo(File, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            }
            else
            {
                hIcon = SHGetFileInfo(File, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            }
            if (hIcon != IntPtr.Zero)
                return Icon.FromHandle(shinfo.hIcon);
            return null;
        }

        public static Icon Extract(string File)
        {
            return Extract(File, IconSize.Small);
        }
        #endregion

    }
    #endregion
}
