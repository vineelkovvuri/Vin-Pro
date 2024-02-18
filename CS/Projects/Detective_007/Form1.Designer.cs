namespace Detective_007
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tpDisclaimer = new System.Windows.Forms.TabControl();
            this.tpWindowTitle = new System.Windows.Forms.TabPage();
            this.bDeleteWindowTitles = new System.Windows.Forms.Button();
            this.lvWindowTitles = new System.Windows.Forms.ListView();
            this.chWindowTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTimeWindowTiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpKeyData = new System.Windows.Forms.TabPage();
            this.bClearData = new System.Windows.Forms.Button();
            this.tbKeyData = new System.Windows.Forms.TextBox();
            this.tpScreenCapture = new System.Windows.Forms.TabPage();
            this.BClearScreen = new System.Windows.Forms.Button();
            this.bDeleteScreenCapture = new System.Windows.Forms.Button();
            this.bPlayScreenCapture = new System.Windows.Forms.Button();
            this.lvScreenCapture = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbFileOperations = new System.Windows.Forms.TabPage();
            this.cbFileCreated = new System.Windows.Forms.CheckBox();
            this.cbFileChanged = new System.Windows.Forms.CheckBox();
            this.cbFileRenamed = new System.Windows.Forms.CheckBox();
            this.cbFileDeleted = new System.Windows.Forms.CheckBox();
            this.bFileOperationSave = new System.Windows.Forms.Button();
            this.bCleartb3 = new System.Windows.Forms.Button();
            this.lvResulttb3 = new System.Windows.Forms.ListView();
            this.chFileNametp3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileOperationtp3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTimetp3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPathtp3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.gbMonitoring = new System.Windows.Forms.GroupBox();
            this.cbFileMonitor = new System.Windows.Forms.CheckBox();
            this.cbKeyLogger = new System.Windows.Forms.CheckBox();
            this.cbScreenCaptures = new System.Windows.Forms.CheckBox();
            this.cbWindowTitles = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bChangePassword = new System.Windows.Forms.Button();
            this.cbPasswordProtection = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rAllUsers = new System.Windows.Forms.RadioButton();
            this.rCurrentUser = new System.Windows.Forms.RadioButton();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.gbScreenCaptureSettings = new System.Windows.Forms.GroupBox();
            this.nupScreenCaptureTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bScreenCaptureBrowse = new System.Windows.Forms.Button();
            this.tbScreenSavePath = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbDisclaimer = new System.Windows.Forms.TextBox();
            this.cbStartStop = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbInfoPic = new System.Windows.Forms.PictureBox();
            this.ttWebsiteURL = new System.Windows.Forms.ToolTip(this.components);
            this.tpDisclaimer.SuspendLayout();
            this.tpWindowTitle.SuspendLayout();
            this.tpKeyData.SuspendLayout();
            this.tpScreenCapture.SuspendLayout();
            this.tbFileOperations.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.gbMonitoring.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbScreenCaptureSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScreenCaptureTimeInterval)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // tpDisclaimer
            // 
            this.tpDisclaimer.Controls.Add(this.tpWindowTitle);
            this.tpDisclaimer.Controls.Add(this.tpKeyData);
            this.tpDisclaimer.Controls.Add(this.tpScreenCapture);
            this.tpDisclaimer.Controls.Add(this.tbFileOperations);
            this.tpDisclaimer.Controls.Add(this.tpSettings);
            this.tpDisclaimer.Controls.Add(this.tabPage1);
            this.tpDisclaimer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDisclaimer.Location = new System.Drawing.Point(12, 67);
            this.tpDisclaimer.Name = "tpDisclaimer";
            this.tpDisclaimer.SelectedIndex = 0;
            this.tpDisclaimer.Size = new System.Drawing.Size(535, 241);
            this.tpDisclaimer.TabIndex = 0;
            this.tpDisclaimer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tpDisclaimer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tpWindowTitle
            // 
            this.tpWindowTitle.Controls.Add(this.bDeleteWindowTitles);
            this.tpWindowTitle.Controls.Add(this.lvWindowTitles);
            this.tpWindowTitle.Location = new System.Drawing.Point(4, 22);
            this.tpWindowTitle.Name = "tpWindowTitle";
            this.tpWindowTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tpWindowTitle.Size = new System.Drawing.Size(527, 215);
            this.tpWindowTitle.TabIndex = 0;
            this.tpWindowTitle.Text = "Window Titles";
            this.tpWindowTitle.UseVisualStyleBackColor = true;
            // 
            // bDeleteWindowTitles
            // 
            this.bDeleteWindowTitles.Enabled = false;
            this.bDeleteWindowTitles.Location = new System.Drawing.Point(225, 174);
            this.bDeleteWindowTitles.Name = "bDeleteWindowTitles";
            this.bDeleteWindowTitles.Size = new System.Drawing.Size(75, 23);
            this.bDeleteWindowTitles.TabIndex = 2;
            this.bDeleteWindowTitles.Text = "&Clear";
            this.bDeleteWindowTitles.UseVisualStyleBackColor = true;
            this.bDeleteWindowTitles.Click += new System.EventHandler(this.bDeleteWindowTitles_Click);
            // 
            // lvWindowTitles
            // 
            this.lvWindowTitles.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvWindowTitles.AllowColumnReorder = true;
            this.lvWindowTitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWindowTitle,
            this.chTimeWindowTiles});
            this.lvWindowTitles.FullRowSelect = true;
            this.lvWindowTitles.GridLines = true;
            this.lvWindowTitles.Location = new System.Drawing.Point(6, 6);
            this.lvWindowTitles.Name = "lvWindowTitles";
            this.lvWindowTitles.Size = new System.Drawing.Size(515, 157);
            this.lvWindowTitles.TabIndex = 1;
            this.lvWindowTitles.UseCompatibleStateImageBehavior = false;
            this.lvWindowTitles.View = System.Windows.Forms.View.Details;
            this.lvWindowTitles.ItemActivate += new System.EventHandler(this.lvWindowTitles_ItemActivate);
            this.lvWindowTitles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvWindowTitles_ItemSelectionChanged);
            // 
            // chWindowTitle
            // 
            this.chWindowTitle.Text = "Window Title";
            this.chWindowTitle.Width = 290;
            // 
            // chTimeWindowTiles
            // 
            this.chTimeWindowTiles.Text = "Time";
            this.chTimeWindowTiles.Width = 316;
            // 
            // tpKeyData
            // 
            this.tpKeyData.Controls.Add(this.bClearData);
            this.tpKeyData.Controls.Add(this.tbKeyData);
            this.tpKeyData.Location = new System.Drawing.Point(4, 22);
            this.tpKeyData.Name = "tpKeyData";
            this.tpKeyData.Padding = new System.Windows.Forms.Padding(3);
            this.tpKeyData.Size = new System.Drawing.Size(527, 215);
            this.tpKeyData.TabIndex = 3;
            this.tpKeyData.Text = "Key Logger";
            this.tpKeyData.UseVisualStyleBackColor = true;
            // 
            // bClearData
            // 
            this.bClearData.AutoSize = true;
            this.bClearData.Location = new System.Drawing.Point(225, 174);
            this.bClearData.Name = "bClearData";
            this.bClearData.Size = new System.Drawing.Size(75, 23);
            this.bClearData.TabIndex = 1;
            this.bClearData.Text = "&Clear";
            this.bClearData.UseVisualStyleBackColor = true;
            this.bClearData.Click += new System.EventHandler(this.bClearData_Click);
            // 
            // tbKeyData
            // 
            this.tbKeyData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(238)))));
            this.tbKeyData.Location = new System.Drawing.Point(6, 6);
            this.tbKeyData.Multiline = true;
            this.tbKeyData.Name = "tbKeyData";
            this.tbKeyData.ReadOnly = true;
            this.tbKeyData.Size = new System.Drawing.Size(515, 157);
            this.tbKeyData.TabIndex = 0;
            // 
            // tpScreenCapture
            // 
            this.tpScreenCapture.Controls.Add(this.BClearScreen);
            this.tpScreenCapture.Controls.Add(this.bDeleteScreenCapture);
            this.tpScreenCapture.Controls.Add(this.bPlayScreenCapture);
            this.tpScreenCapture.Controls.Add(this.lvScreenCapture);
            this.tpScreenCapture.Location = new System.Drawing.Point(4, 22);
            this.tpScreenCapture.Name = "tpScreenCapture";
            this.tpScreenCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenCapture.Size = new System.Drawing.Size(527, 215);
            this.tpScreenCapture.TabIndex = 1;
            this.tpScreenCapture.Text = "Screen Capture";
            this.tpScreenCapture.UseVisualStyleBackColor = true;
            // 
            // BClearScreen
            // 
            this.BClearScreen.AutoSize = true;
            this.BClearScreen.Enabled = false;
            this.BClearScreen.Location = new System.Drawing.Point(16, 174);
            this.BClearScreen.Name = "BClearScreen";
            this.BClearScreen.Size = new System.Drawing.Size(75, 23);
            this.BClearScreen.TabIndex = 1;
            this.BClearScreen.Text = "&Clear";
            this.BClearScreen.UseVisualStyleBackColor = true;
            // 
            // bDeleteScreenCapture
            // 
            this.bDeleteScreenCapture.Enabled = false;
            this.bDeleteScreenCapture.Location = new System.Drawing.Point(225, 174);
            this.bDeleteScreenCapture.Name = "bDeleteScreenCapture";
            this.bDeleteScreenCapture.Size = new System.Drawing.Size(75, 23);
            this.bDeleteScreenCapture.TabIndex = 2;
            this.bDeleteScreenCapture.Text = "&Delete";
            this.bDeleteScreenCapture.UseVisualStyleBackColor = true;
            this.bDeleteScreenCapture.Click += new System.EventHandler(this.bDeleteScreenCapture_Click);
            // 
            // bPlayScreenCapture
            // 
            this.bPlayScreenCapture.Enabled = false;
            this.bPlayScreenCapture.Location = new System.Drawing.Point(436, 174);
            this.bPlayScreenCapture.Name = "bPlayScreenCapture";
            this.bPlayScreenCapture.Size = new System.Drawing.Size(75, 23);
            this.bPlayScreenCapture.TabIndex = 3;
            this.bPlayScreenCapture.Text = "&Play";
            this.bPlayScreenCapture.UseVisualStyleBackColor = true;
            this.bPlayScreenCapture.Click += new System.EventHandler(this.bPlayScreenCapture_Click);
            // 
            // lvScreenCapture
            // 
            this.lvScreenCapture.AllowColumnReorder = true;
            this.lvScreenCapture.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chTime});
            this.lvScreenCapture.FullRowSelect = true;
            this.lvScreenCapture.GridLines = true;
            this.lvScreenCapture.Location = new System.Drawing.Point(6, 6);
            this.lvScreenCapture.Name = "lvScreenCapture";
            this.lvScreenCapture.Size = new System.Drawing.Size(515, 157);
            this.lvScreenCapture.TabIndex = 0;
            this.lvScreenCapture.UseCompatibleStateImageBehavior = false;
            this.lvScreenCapture.View = System.Windows.Forms.View.Details;
            this.lvScreenCapture.ItemActivate += new System.EventHandler(this.lvScreenCapture_ItemActivate);
            this.lvScreenCapture.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvScreenCapture_ItemSelectionChanged);
            // 
            // chFileName
            // 
            this.chFileName.Text = "File Name";
            this.chFileName.Width = 115;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 240;
            // 
            // tbFileOperations
            // 
            this.tbFileOperations.Controls.Add(this.cbFileCreated);
            this.tbFileOperations.Controls.Add(this.cbFileChanged);
            this.tbFileOperations.Controls.Add(this.cbFileRenamed);
            this.tbFileOperations.Controls.Add(this.cbFileDeleted);
            this.tbFileOperations.Controls.Add(this.bFileOperationSave);
            this.tbFileOperations.Controls.Add(this.bCleartb3);
            this.tbFileOperations.Controls.Add(this.lvResulttb3);
            this.tbFileOperations.Location = new System.Drawing.Point(4, 22);
            this.tbFileOperations.Name = "tbFileOperations";
            this.tbFileOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tbFileOperations.Size = new System.Drawing.Size(527, 215);
            this.tbFileOperations.TabIndex = 4;
            this.tbFileOperations.Text = "File Monitor";
            this.tbFileOperations.UseVisualStyleBackColor = true;
            // 
            // cbFileCreated
            // 
            this.cbFileCreated.AutoSize = true;
            this.cbFileCreated.Checked = true;
            this.cbFileCreated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileCreated.Location = new System.Drawing.Point(160, 170);
            this.cbFileCreated.Name = "cbFileCreated";
            this.cbFileCreated.Size = new System.Drawing.Size(66, 17);
            this.cbFileCreated.TabIndex = 2;
            this.cbFileCreated.Text = "Created";
            this.cbFileCreated.UseVisualStyleBackColor = true;
            // 
            // cbFileChanged
            // 
            this.cbFileChanged.AutoSize = true;
            this.cbFileChanged.Checked = true;
            this.cbFileChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileChanged.Location = new System.Drawing.Point(287, 193);
            this.cbFileChanged.Name = "cbFileChanged";
            this.cbFileChanged.Size = new System.Drawing.Size(73, 17);
            this.cbFileChanged.TabIndex = 5;
            this.cbFileChanged.Text = "Changed";
            this.cbFileChanged.UseVisualStyleBackColor = true;
            // 
            // cbFileRenamed
            // 
            this.cbFileRenamed.AutoSize = true;
            this.cbFileRenamed.Checked = true;
            this.cbFileRenamed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileRenamed.Location = new System.Drawing.Point(287, 170);
            this.cbFileRenamed.Name = "cbFileRenamed";
            this.cbFileRenamed.Size = new System.Drawing.Size(74, 17);
            this.cbFileRenamed.TabIndex = 4;
            this.cbFileRenamed.Text = "Renamed";
            this.cbFileRenamed.UseVisualStyleBackColor = true;
            // 
            // cbFileDeleted
            // 
            this.cbFileDeleted.AutoSize = true;
            this.cbFileDeleted.Checked = true;
            this.cbFileDeleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileDeleted.Location = new System.Drawing.Point(160, 193);
            this.cbFileDeleted.Name = "cbFileDeleted";
            this.cbFileDeleted.Size = new System.Drawing.Size(66, 17);
            this.cbFileDeleted.TabIndex = 3;
            this.cbFileDeleted.Text = "Deleted";
            this.cbFileDeleted.UseVisualStyleBackColor = true;
            // 
            // bFileOperationSave
            // 
            this.bFileOperationSave.Enabled = false;
            this.bFileOperationSave.Location = new System.Drawing.Point(437, 174);
            this.bFileOperationSave.Name = "bFileOperationSave";
            this.bFileOperationSave.Size = new System.Drawing.Size(75, 23);
            this.bFileOperationSave.TabIndex = 6;
            this.bFileOperationSave.Text = "&Save";
            this.bFileOperationSave.UseVisualStyleBackColor = true;
            this.bFileOperationSave.Click += new System.EventHandler(this.bFileOperationSave_Click);
            // 
            // bCleartb3
            // 
            this.bCleartb3.Enabled = false;
            this.bCleartb3.Location = new System.Drawing.Point(16, 174);
            this.bCleartb3.Name = "bCleartb3";
            this.bCleartb3.Size = new System.Drawing.Size(75, 23);
            this.bCleartb3.TabIndex = 1;
            this.bCleartb3.Text = "&Clear";
            this.bCleartb3.UseVisualStyleBackColor = true;
            this.bCleartb3.Click += new System.EventHandler(this.bCleartb3_Click);
            // 
            // lvResulttb3
            // 
            this.lvResulttb3.AllowColumnReorder = true;
            this.lvResulttb3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileNametp3,
            this.chFileOperationtp3,
            this.chTimetp3,
            this.chPathtp3});
            this.lvResulttb3.FullRowSelect = true;
            this.lvResulttb3.GridLines = true;
            this.lvResulttb3.Location = new System.Drawing.Point(6, 6);
            this.lvResulttb3.Name = "lvResulttb3";
            this.lvResulttb3.Size = new System.Drawing.Size(515, 157);
            this.lvResulttb3.TabIndex = 0;
            this.lvResulttb3.UseCompatibleStateImageBehavior = false;
            this.lvResulttb3.View = System.Windows.Forms.View.Details;
            this.lvResulttb3.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvResulttb3_ItemSelectionChanged);
            // 
            // chFileNametp3
            // 
            this.chFileNametp3.Text = "File Name";
            this.chFileNametp3.Width = 133;
            // 
            // chFileOperationtp3
            // 
            this.chFileOperationtp3.Text = "Operation";
            this.chFileOperationtp3.Width = 107;
            // 
            // chTimetp3
            // 
            this.chTimetp3.Text = "Time";
            this.chTimetp3.Width = 122;
            // 
            // chPathtp3
            // 
            this.chPathtp3.Text = "Path";
            this.chPathtp3.Width = 177;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.gbMonitoring);
            this.tpSettings.Controls.Add(this.groupBox2);
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.Controls.Add(this.gbScreenCaptureSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(527, 215);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // gbMonitoring
            // 
            this.gbMonitoring.Controls.Add(this.cbFileMonitor);
            this.gbMonitoring.Controls.Add(this.cbKeyLogger);
            this.gbMonitoring.Controls.Add(this.cbScreenCaptures);
            this.gbMonitoring.Controls.Add(this.cbWindowTitles);
            this.gbMonitoring.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMonitoring.Location = new System.Drawing.Point(366, 86);
            this.gbMonitoring.Name = "gbMonitoring";
            this.gbMonitoring.Size = new System.Drawing.Size(155, 123);
            this.gbMonitoring.TabIndex = 3;
            this.gbMonitoring.TabStop = false;
            this.gbMonitoring.Text = "Monitors";
            // 
            // cbFileMonitor
            // 
            this.cbFileMonitor.AutoSize = true;
            this.cbFileMonitor.Checked = true;
            this.cbFileMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileMonitor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFileMonitor.Location = new System.Drawing.Point(10, 98);
            this.cbFileMonitor.Name = "cbFileMonitor";
            this.cbFileMonitor.Size = new System.Drawing.Size(89, 17);
            this.cbFileMonitor.TabIndex = 3;
            this.cbFileMonitor.Text = "File Monitor";
            this.cbFileMonitor.UseVisualStyleBackColor = true;
            // 
            // cbKeyLogger
            // 
            this.cbKeyLogger.AutoSize = true;
            this.cbKeyLogger.Checked = true;
            this.cbKeyLogger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeyLogger.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKeyLogger.Location = new System.Drawing.Point(10, 72);
            this.cbKeyLogger.Name = "cbKeyLogger";
            this.cbKeyLogger.Size = new System.Drawing.Size(82, 17);
            this.cbKeyLogger.TabIndex = 2;
            this.cbKeyLogger.Text = "Key Logger";
            this.cbKeyLogger.UseVisualStyleBackColor = true;
            // 
            // cbScreenCaptures
            // 
            this.cbScreenCaptures.AutoSize = true;
            this.cbScreenCaptures.Checked = true;
            this.cbScreenCaptures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScreenCaptures.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbScreenCaptures.Location = new System.Drawing.Point(10, 46);
            this.cbScreenCaptures.Name = "cbScreenCaptures";
            this.cbScreenCaptures.Size = new System.Drawing.Size(109, 17);
            this.cbScreenCaptures.TabIndex = 1;
            this.cbScreenCaptures.Text = "Screen Captures";
            this.cbScreenCaptures.UseVisualStyleBackColor = true;
            // 
            // cbWindowTitles
            // 
            this.cbWindowTitles.AutoSize = true;
            this.cbWindowTitles.Checked = true;
            this.cbWindowTitles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWindowTitles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWindowTitles.Location = new System.Drawing.Point(10, 20);
            this.cbWindowTitles.Name = "cbWindowTitles";
            this.cbWindowTitles.Size = new System.Drawing.Size(99, 17);
            this.cbWindowTitles.TabIndex = 0;
            this.cbWindowTitles.Text = "Window Titles";
            this.cbWindowTitles.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bChangePassword);
            this.groupBox2.Controls.Add(this.cbPasswordProtection);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(179, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password Protection";
            // 
            // bChangePassword
            // 
            this.bChangePassword.Enabled = false;
            this.bChangePassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangePassword.Location = new System.Drawing.Point(32, 65);
            this.bChangePassword.Name = "bChangePassword";
            this.bChangePassword.Size = new System.Drawing.Size(116, 23);
            this.bChangePassword.TabIndex = 1;
            this.bChangePassword.Text = "Change Password";
            this.bChangePassword.UseVisualStyleBackColor = true;
            this.bChangePassword.Click += new System.EventHandler(this.bChangePassword_Click);
            // 
            // cbPasswordProtection
            // 
            this.cbPasswordProtection.AutoSize = true;
            this.cbPasswordProtection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPasswordProtection.Location = new System.Drawing.Point(8, 35);
            this.cbPasswordProtection.Name = "cbPasswordProtection";
            this.cbPasswordProtection.Size = new System.Drawing.Size(164, 17);
            this.cbPasswordProtection.TabIndex = 0;
            this.cbPasswordProtection.Text = "Enable Pasword Protection";
            this.cbPasswordProtection.UseVisualStyleBackColor = true;
            this.cbPasswordProtection.CheckedChanged += new System.EventHandler(this.cbPasswordProtection_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rAllUsers);
            this.groupBox1.Controls.Add(this.rCurrentUser);
            this.groupBox1.Controls.Add(this.cbStartWithWindows);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stealth Settings";
            // 
            // rAllUsers
            // 
            this.rAllUsers.AutoSize = true;
            this.rAllUsers.Enabled = false;
            this.rAllUsers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rAllUsers.Location = new System.Drawing.Point(35, 72);
            this.rAllUsers.Name = "rAllUsers";
            this.rAllUsers.Size = new System.Drawing.Size(69, 17);
            this.rAllUsers.TabIndex = 2;
            this.rAllUsers.Text = "All Users";
            this.rAllUsers.UseVisualStyleBackColor = true;
            this.rAllUsers.CheckedChanged += new System.EventHandler(this.rAllUsers_CheckedChanged);
            // 
            // rCurrentUser
            // 
            this.rCurrentUser.AutoSize = true;
            this.rCurrentUser.Enabled = false;
            this.rCurrentUser.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rCurrentUser.Location = new System.Drawing.Point(35, 53);
            this.rCurrentUser.Name = "rCurrentUser";
            this.rCurrentUser.Size = new System.Drawing.Size(117, 17);
            this.rCurrentUser.TabIndex = 1;
            this.rCurrentUser.Text = "Current User Only";
            this.rCurrentUser.UseVisualStyleBackColor = true;
            this.rCurrentUser.CheckedChanged += new System.EventHandler(this.rCurrentUser_CheckedChanged);
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartWithWindows.Location = new System.Drawing.Point(14, 34);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(130, 17);
            this.cbStartWithWindows.TabIndex = 0;
            this.cbStartWithWindows.Text = "Start With Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.CheckedChanged += new System.EventHandler(this.cbStartWithWindows_CheckedChanged);
            // 
            // gbScreenCaptureSettings
            // 
            this.gbScreenCaptureSettings.Controls.Add(this.nupScreenCaptureTimeInterval);
            this.gbScreenCaptureSettings.Controls.Add(this.label2);
            this.gbScreenCaptureSettings.Controls.Add(this.label1);
            this.gbScreenCaptureSettings.Controls.Add(this.bScreenCaptureBrowse);
            this.gbScreenCaptureSettings.Controls.Add(this.tbScreenSavePath);
            this.gbScreenCaptureSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbScreenCaptureSettings.Location = new System.Drawing.Point(6, 6);
            this.gbScreenCaptureSettings.Name = "gbScreenCaptureSettings";
            this.gbScreenCaptureSettings.Size = new System.Drawing.Size(515, 74);
            this.gbScreenCaptureSettings.TabIndex = 0;
            this.gbScreenCaptureSettings.TabStop = false;
            this.gbScreenCaptureSettings.Text = "Screen Capture Settings";
            // 
            // nupScreenCaptureTimeInterval
            // 
            this.nupScreenCaptureTimeInterval.DecimalPlaces = 1;
            this.nupScreenCaptureTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupScreenCaptureTimeInterval.Location = new System.Drawing.Point(128, 47);
            this.nupScreenCaptureTimeInterval.Name = "nupScreenCaptureTimeInterval";
            this.nupScreenCaptureTimeInterval.Size = new System.Drawing.Size(49, 20);
            this.nupScreenCaptureTimeInterval.TabIndex = 2;
            this.nupScreenCaptureTimeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupScreenCaptureTimeInterval.ValueChanged += new System.EventHandler(this.nupScreenCaptureTimeInterval_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time Interval(min):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Capture Location:";
            // 
            // bScreenCaptureBrowse
            // 
            this.bScreenCaptureBrowse.AutoSize = true;
            this.bScreenCaptureBrowse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bScreenCaptureBrowse.Location = new System.Drawing.Point(409, 17);
            this.bScreenCaptureBrowse.Name = "bScreenCaptureBrowse";
            this.bScreenCaptureBrowse.Size = new System.Drawing.Size(29, 23);
            this.bScreenCaptureBrowse.TabIndex = 1;
            this.bScreenCaptureBrowse.Text = "....";
            this.bScreenCaptureBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bScreenCaptureBrowse.UseVisualStyleBackColor = true;
            this.bScreenCaptureBrowse.Click += new System.EventHandler(this.bScreenCaptureBrowse_Click);
            // 
            // tbScreenSavePath
            // 
            this.tbScreenSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tbScreenSavePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbScreenSavePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScreenSavePath.Location = new System.Drawing.Point(128, 22);
            this.tbScreenSavePath.Name = "tbScreenSavePath";
            this.tbScreenSavePath.ReadOnly = true;
            this.tbScreenSavePath.Size = new System.Drawing.Size(316, 15);
            this.tbScreenSavePath.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbDisclaimer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 215);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Disclaimer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbDisclaimer
            // 
            this.tbDisclaimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDisclaimer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisclaimer.Location = new System.Drawing.Point(3, 3);
            this.tbDisclaimer.Multiline = true;
            this.tbDisclaimer.Name = "tbDisclaimer";
            this.tbDisclaimer.ReadOnly = true;
            this.tbDisclaimer.Size = new System.Drawing.Size(521, 209);
            this.tbDisclaimer.TabIndex = 0;
            this.tbDisclaimer.Text = "\r\n\r\n\r\n\r\n\r\nThe author of this software is not at all responsible for any illegal u" +
    "se of it";
            this.tbDisclaimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbStartStop
            // 
            this.cbStartStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbStartStop.AutoSize = true;
            this.cbStartStop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartStop.Location = new System.Drawing.Point(16, 327);
            this.cbStartStop.Name = "cbStartStop";
            this.cbStartStop.Size = new System.Drawing.Size(103, 23);
            this.cbStartStop.TabIndex = 2;
            this.cbStartStop.Text = "Start Monitoring";
            this.cbStartStop.UseVisualStyleBackColor = true;
            this.cbStartStop.CheckedChanged += new System.EventHandler(this.cbStartStop_CheckedChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(455, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Stealth Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.BackColor = System.Drawing.Color.Transparent;
            this.lInfo.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.lInfo.Location = new System.Drawing.Point(93, 22);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(122, 19);
            this.lInfo.TabIndex = 4;
            this.lInfo.Text = "Logs window titles";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(262, 322);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 37);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.ttWebsiteURL.SetToolTip(this.pictureBox1, "http://www.vineelkumarreddy.com");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbInfoPic
            // 
            this.pbInfoPic.BackColor = System.Drawing.Color.Transparent;
            this.pbInfoPic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbInfoPic.Image = global::Detective_007.Properties.Resources.image1;
            this.pbInfoPic.Location = new System.Drawing.Point(22, 7);
            this.pbInfoPic.Name = "pbInfoPic";
            this.pbInfoPic.Size = new System.Drawing.Size(48, 48);
            this.pbInfoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbInfoPic.TabIndex = 8;
            this.pbInfoPic.TabStop = false;
            // 
            // ttWebsiteURL
            // 
            this.ttWebsiteURL.ToolTipTitle = "Author Website:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 361);
            this.Controls.Add(this.pbInfoPic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbStartStop);
            this.Controls.Add(this.tpDisclaimer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detective 007 - By Vineel Kumar Reddy";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.tpDisclaimer.ResumeLayout(false);
            this.tpWindowTitle.ResumeLayout(false);
            this.tpKeyData.ResumeLayout(false);
            this.tpKeyData.PerformLayout();
            this.tpScreenCapture.ResumeLayout(false);
            this.tpScreenCapture.PerformLayout();
            this.tbFileOperations.ResumeLayout(false);
            this.tbFileOperations.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.gbMonitoring.ResumeLayout(false);
            this.gbMonitoring.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbScreenCaptureSettings.ResumeLayout(false);
            this.gbScreenCaptureSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScreenCaptureTimeInterval)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tpDisclaimer;
        private System.Windows.Forms.TabPage tpWindowTitle;
        private System.Windows.Forms.TabPage tpScreenCapture;
        private System.Windows.Forms.ListView lvWindowTitles;
        private System.Windows.Forms.ColumnHeader chWindowTitle;
        private System.Windows.Forms.ColumnHeader chTimeWindowTiles;
        private System.Windows.Forms.ListView lvScreenCapture;
        private System.Windows.Forms.Button bPlayScreenCapture;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.Button bDeleteScreenCapture;
        private System.Windows.Forms.CheckBox cbStartStop;
        private System.Windows.Forms.Button bDeleteWindowTitles;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.GroupBox gbScreenCaptureSettings;
        private System.Windows.Forms.TextBox tbScreenSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bScreenCaptureBrowse;
        private System.Windows.Forms.NumericUpDown nupScreenCaptureTimeInterval;
        private System.Windows.Forms.Button BClearScreen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.RadioButton rAllUsers;
        private System.Windows.Forms.RadioButton rCurrentUser;
        private System.Windows.Forms.TabPage tpKeyData;
        private System.Windows.Forms.Button bClearData;
        private System.Windows.Forms.TextBox tbKeyData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbPasswordProtection;
        private System.Windows.Forms.Button bChangePassword;
        private System.Windows.Forms.TabPage tbFileOperations;
        private System.Windows.Forms.ListView lvResulttb3;
        private System.Windows.Forms.ColumnHeader chFileNametp3;
        private System.Windows.Forms.ColumnHeader chFileOperationtp3;
        private System.Windows.Forms.ColumnHeader chTimetp3;
        private System.Windows.Forms.ColumnHeader chPathtp3;
        private System.Windows.Forms.Button bCleartb3;
        private System.Windows.Forms.CheckBox cbFileCreated;
        private System.Windows.Forms.CheckBox cbFileChanged;
        private System.Windows.Forms.CheckBox cbFileRenamed;
        private System.Windows.Forms.CheckBox cbFileDeleted;
        private System.Windows.Forms.Button bFileOperationSave;
        private System.Windows.Forms.GroupBox gbMonitoring;
        private System.Windows.Forms.CheckBox cbFileMonitor;
        private System.Windows.Forms.CheckBox cbKeyLogger;
        private System.Windows.Forms.CheckBox cbScreenCaptures;
        private System.Windows.Forms.CheckBox cbWindowTitles;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbInfoPic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbDisclaimer;
        private System.Windows.Forms.ToolTip ttWebsiteURL;
    }
}

