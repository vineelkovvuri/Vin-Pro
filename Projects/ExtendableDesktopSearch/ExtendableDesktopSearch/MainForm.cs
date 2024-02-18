#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
using System.IO;
using Lucene.Net.Index;
#endregion
namespace ExtendableDesktopSearch
{
    public partial class MainForm : Form
    {
        AllFilesUserControl allFilesUC;
        DocumentsUserControl documentsUC;
        AudioUserControl audioUC;
        VideoUserControl videoUC;
        PicturesUserControl pictureUC;
        EmailUserControl emailUC;
        //  SettingsUserControl settingsUC;

        #region Main Constructor of the application
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            GlobalData.MainForm = this;

            InitializeComponent();

            InitializeFileDispatcher(); //Create instances of all parsers

            CreateUserControls();

            Settings.LoadSettings();

            RegisterEDSProtocol();

            InitializeStatusBar();

            if (!GlobalData.IndexingCompleted)
                InitializeFileSystemCrawler();

            if (GlobalData.RunMonitor)
                InitializeFileSystemMonitor();

            //if(GlobalData.RunEmailIndexer)
            //    InitializeEmailIndexer();

        }

        private void InitializeEmailIndexer()
        {
            Thread t = new Thread(delegate()
            {
                new EDSEmailIndexer().StartEmailIndexing();
            });
            t.Start();
        }

        #endregion

        #region Code to initiate File Dispatcher
        private void InitializeFileDispatcher()
        {
            new FileDispatcher();       //Used to create a list of all installed plugins of the app
        }
        #endregion

        #region Code to calculate and display number of files got indexed on the status bar
        private void InitializeStatusBar()
        {
            //calculating the number of files got indexed
            //setting the doc count
            int docCount = 0;
            try
            {
                foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                {
                    IndexReader ir = IndexReader.Open(dir);
                    docCount += ir.NumDocs();
                    ir.Close();
                }
            }
            catch (FileNotFoundException noFileEx)
            {
                /* if 'segment' file is missing in the %appdata%\eds\indexes folder 
                   then delete files present in indexes folder*/
                foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                    Directory.Delete(dir, true);
            }

            //setting the status label
            tsslDocCount.Text = docCount + " documents indexed";

            //set the searching status label initially invisible
            tsslSearchingStatus.Visible = false;

            //set the indexing status
            if (GlobalData.IndexingCompleted) lIndexingStatus.Text = "Indexing: Completed 100%";
            else lIndexingStatus.Text = "Indexing: Partial";

            //Making the following controls visible globally
            GlobalData.MainStatusStrip = ssStatusStrip;
            GlobalData.lIndexingStatus = lIndexingStatus;
        }
        #endregion

        #region Code to initiate File System Monitor
        private void InitializeFileSystemMonitor()
        {
            FileSystemMonitor fsw = FileSystemMonitor.GetInstance();
            foreach (string drive in Environment.GetLogicalDrives())
                fsw.AddMonitor(drive);
            fsw.StartAllMonitors();
        }
        #endregion

        #region Code to initiate File System Crawler
        private void InitializeFileSystemCrawler()
        {
            Thread crawlerThread = new Thread(delegate()
            {
                new FileSystemCrawler().StartCrawler();
            });
            crawlerThread.Start();  //Start the Crawling Thread
        }
        #endregion

        #region Code to Register EDS Protocol to Registry
        private void RegisterEDSProtocol()
        {
            try
            {
                string path = "\"" + Application.ExecutablePath + "\"" + "   \"" + "%1" + "\"";
                RegistryKey rk = Registry.ClassesRoot;
                rk = rk.CreateSubKey("EDS");
                rk.SetValue("", "URL:EDS Protocol");
                rk.SetValue("URL Protocol", "\"" + "\"");
                rk.CreateSubKey("DefaultIcon");
                rk = rk.CreateSubKey("shell");
                rk = rk.CreateSubKey("open");
                rk = rk.CreateSubKey("command");
                rk.SetValue("", path);
                rk.Close();
            }
            catch { MessageBox.Show("This program should be run with administator privilages inorder to register 'eds:' protocol", "Extendable Desktop Search", MessageBoxButtons.OK); }
        }
        #endregion

        #region Code to create the user controls (document,audio,video,email user controls)
        private void CreateUserControls()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            allFilesUC = new AllFilesUserControl();
            documentsUC = new DocumentsUserControl();
            videoUC = new VideoUserControl();
            pictureUC = new PicturesUserControl();
            emailUC = new EmailUserControl();
            audioUC = new AudioUserControl();
            // settingsUC = new SettingsUserControl();

            allFilesUC.Location =
            documentsUC.Location =
            audioUC.Location =
            videoUC.Location =
            pictureUC.Location =
            emailUC.Location =
                //settingsUC.Location =
            new Point(1, 80);

            //documentsUC.Anchor =
            //audioUC.Anchor =
            //videoUC.Anchor =
            //pictureUC.Anchor =
            //emailUC.Anchor =
            //settingsUC.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region Code to move a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Code to Add and Remove the User Controls from the form when the user clicks the main buttons( Documents,Audio,Video,Emails)
        private void pbAllFiles_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            allFilesUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(allFilesUC);
        }
        private void pbDocuments_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            documentsUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(documentsUC);
        }

        private void pbAudio_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            audioUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(audioUC);
        }

        private void pbVideo_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            videoUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(videoUC);
        }

        private void pbPictures_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            pictureUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(pictureUC);
        }

        private void pbEmails_CheckedChanged(object sender, EventArgs e)
        {
            filterList.Clear();
            UserControl temp;
            foreach (Control c in this.Controls)
                if ((temp = c as UserControl) != null)
                    this.Controls.Remove(temp);
            emailUC.Size = new Size(this.Width - 10, this.Height - 150);
            this.Controls.Add(emailUC);
        }

        private void pbSettings_CheckedChanged(object sender, EventArgs e)
        {
            //filterList.Clear();
            //UserControl temp;
            //foreach (Control c in this.Controls)
            //    if ((temp = c as UserControl) != null)
            //        this.Controls.Remove(temp);
            //settingsUC.Size = new Size(this.Width - 10, this.Height - 150);
            //this.Controls.Add(settingsUC);
        }
        #endregion

        #region Code for handling commandline arguments in the form load event
        //given through run prompt or explorer address bar(EDS Protocol)
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Invoke documents panel as the default one when the application is loaded
            pbDocuments.Checked = true;

            //Register Win+S as the Hotkey 
            RegisterHotKey(this.Handle, 1, MOD_WIN, (int)Keys.S);

            //if arguments are given to the application, invoke the documents panel and perform the search with the given arguments.
            if (GlobalData.args != null)
            {
                TextBox fileName = allFilesUC.Controls["AllFilesPropertiesPanel"].Controls["tbFileNameInAllFiles"] as TextBox;
                fileName.Text = GlobalData.args;
                Button searchButton = allFilesUC.Controls["AllFilesPropertiesPanel"].Controls["bSearchInAllFiles"] as Button;
                searchButton.PerformClick();
                pbAllFiles.PerformClick();
                GlobalData.args = null;
            }
        }
        #endregion

        #region Code to handle System Tray Contextmenu Items
        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }
        bool TrayClose = false;
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            TrayClose = true;
            this.Close();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TrayClose)             //Dont Close the application if it not exited from system tray
            {
                e.Cancel = true;
                this.Visible = false;   //And perhaps hide the application to system tray
            }
            else                        // if app is closed from system tray ...... do the cleanup stuff
            {
                GlobalData.RunCrawler = false;  //Stop the crawler if it is running....
                GlobalData.RunScheduler = false;//Stop the scheduler if it is running....
                if (!GlobalData.IndexingCompleted && GlobalData.RunMonitor)
                    FileSystemMonitor.GetInstance().StopAllMonitors(); // Stop all monitors
                Settings.SaveSettings();        //Save settings of the application at its exit
                UnregisterHotKey(this.Handle, 1);//Unregister HotKey on application exit
            }
        }

        #region Code for filtering result entries
        List<ListViewItem> filterList = new List<ListViewItem>();
        Color c1 = Color.FromArgb(247, 247, 247);
        Color c2 = Color.White;

        private void tbFilterResults_TextChanged(object sender, EventArgs e)
        {
            //  if (this.Controls[4] != settingsUC)
            {
                string filter = tbFilterResults.Text;
                // user control   //panel    //listview      
                ListViewEx lv = this.Controls[4].Controls[1].Controls[4] as ListViewEx;

                if (filterList.Count == 0)
                {
                    foreach (ListViewItem lvi in lv.Items)
                        filterList.Add(lvi);
                }
                if (filterList.Count != 0)
                {
                    lv.Items.Clear();
                    int i = 0;
                    bool found = false;
                    lv.BeginUpdate();
                    foreach (ListViewItem lvi in filterList)
                    {
                        found = false;
                        foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        {

                            if (lvsi.Text.ToLower().Contains(filter))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                                lvsi.BackColor = (i & 1) == 0 ? c1 : c2;
                            lv.Items.Add(lvi);
                            i++;
                        }
                    }
                    lv.EndUpdate();
                }
            }
        }
        #endregion

        #region Code to register WIN+S hotkey
        [DllImport("user32.dll")]
        public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private const int MOD_ALT = 0x1;
        private const int MOD_CONTROL = 0x2;
        private const int MOD_WIN = 0x8;
        private const int WM_HOTKEY = 0x312;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
                if (!Visible)
                    this.Visible = true;
            base.WndProc(ref m);
        }
        #endregion

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible) this.Visible = true;
        }
    }
}