using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace TempForm
{
    public partial class MainForm : Form
    {

        List<FileInfo> fileList = new List<FileInfo>();
        public MainForm()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            AllocConsole();
            InitializeComponent();
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Select the directory to find duplicate files...";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!lbDirectories.Items.Contains(fbd.SelectedPath)) lbDirectories.Items.Add(fbd.SelectedPath);
            }
            fbd.Dispose();
        }

        private void lbDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            bRemove.Enabled = lbDirectories.SelectedItems.Count != 0;
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            lbDirectories.Items.Remove(lbDirectories.SelectedItem);
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            lvResults.Items.Clear();
            lvResults.Groups.Clear();
            bAdd.Enabled = bStart.Enabled = false;
            TotalFileCount = 0;
            currentFile = 0;
            Thread workerThread = new Thread(() =>
            {
                //calculate total files

                foreach (string item in lbDirectories.Items)
                    CreateFileList(item);
                lFileProcessing.Text = "Files List Creation Completed";

                lFileProcessing.Text = "Preparing results list";
                lvResults.BeginUpdate();
                int j = 0;
                int groupCount = 1;
                while (currentFile < TotalFileCount)
                {
                    FileInfo file1 = fileList[j];
                    int i = 0;
                    currentFile++;
                    while (i < fileList.Count)
                    {
                        FileInfo file2 = fileList[i];
                        if (file1.FileName != file2.FileName)
                        {
                            if (file1.Length == file2.Length)
                            {
                                if (CompareFiles(file1.FileName, file2.FileName))
                                {
                                    ListViewItem lvi;
                                    //Create a group if it is not already present
                                    if (lvResults.Groups[file1.FileName] == null)
                                    {
                                        lvResults.Groups.Add(file1.FileName, groupCount + "");
                                        lvi = new ListViewItem(file1.FileName);
                                        lvi.Group = lvResults.Groups[file1.FileName];
                                        lvResults.Items.Add(lvi);
                                        groupCount++;
                                    }
                                    lvi = new ListViewItem(file2.FileName);
                                    lvi.Group = lvResults.Groups[file1.FileName];
                                    lvResults.Items.Add(lvi);

                                    fileList.RemoveAt(i);   //remove the element if it is identical to actual file
                                    i--;
                                    currentFile++;
                                }
                            }
                        }
                        i++;
                    }
                    j++;
                    pbProgress.Value = (int)((currentFile / (double)TotalFileCount) * 100);
                    lFileProcessing.Text = file1.FileName;
                }
                lvResults.EndUpdate();
                lFileProcessing.Text = "Completed";
                bAdd.Enabled = bStart.Enabled = true;
            });
            workerThread.Priority = ThreadPriority.AboveNormal;
            workerThread.Start();

        }
        int TotalFileCount = 0;

        [DllImport("kernel32")]
        static extern void AllocConsole();

        int currentFile = 0;
        private void CreateFileList(string path)
        {
            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    TotalFileCount++;
                    fileList.Add(new FileInfo { FileName = file, Length = FileSize(file) });
                }
            }
            catch (Exception e) { Trace.Write(e); }

            foreach (string dir in Directory.GetDirectories(path))
                CreateFileList(dir);
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            if (lvResults.SelectedItems.Count != 0)
            {
                Process.Start(Path.GetDirectoryName(lvResults.SelectedItems[0].SubItems[0].Text));
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvResults.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in lvResults.SelectedItems)
                {
                    SHFileDelete(lvi.SubItems[0].Text + '\0' + '\0', this.Handle);
                    lvResults.Items.Remove(lvi);
                }
            }
        }

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

        public static void SHFileDelete(string path, IntPtr handle)
        {
            SHFILEOPSTRUCT sfo = new SHFILEOPSTRUCT();
            sfo.hwnd = handle;
            sfo.fAnyOperationsAborted = false;
            sfo.wFunc = 0x0003; //delete
            sfo.fFlags = 0x0040 | 0x0400;//recycle bin | no error UI
            sfo.pFrom = path;
            sfo.pTo = null;
            sfo.hNameMappings = IntPtr.Zero;

            SHFileOperation(ref sfo);
        }

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
        public bool CompareFiles(string file1, string file2)
        {
            FileStream fs1 = File.OpenRead(file1),
                fs2 = File.OpenRead(file2);

            int b1 = 0, b2 = 0;
            byte[] buf1 = new byte[4 * 1024], buf2 = new byte[4 * 1024];

            for (b1 = fs1.Read(buf1, 0, 4 * 1024), b2 = fs2.Read(buf2, 0, 4 * 1024);
                b1 != 0 || b2 != 0;
                b1 = fs1.Read(buf1, 0, 4 * 1024), b2 = fs2.Read(buf2, 0, 4 * 1024))
                for (int i = 0; i < 4 * 1024; i++)
                    if (buf1[i] != buf2[i]) break;


            fs1.Close();
            fs2.Close();
            if (b1 == 0 && b2 == 0) return true;
            else return false;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (lvResults.SelectedItems.Count != 0)
            {
                Process.Start(lvResults.SelectedItems[0].SubItems[0].Text);
            }
        }

        class FileInfo
        {
            public string FileName;
            public long Length;
        }
    }
}
