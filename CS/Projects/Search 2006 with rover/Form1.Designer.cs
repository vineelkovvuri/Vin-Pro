namespace Search_2006
{
    using System.IO;
    using System.Windows.Forms;
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.bexclude = new System.Windows.Forms.Button();
            this.bbrowse = new System.Windows.Forms.Button();
            this.clbdrives = new System.Windows.Forms.CheckedListBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.rbdate = new System.Windows.Forms.RadioButton();
            this.nudto = new System.Windows.Forms.NumericUpDown();
            this.rbword = new System.Windows.Forms.RadioButton();
            this.rbname = new System.Windows.Forms.RadioButton();
            this.cobsize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudfrom = new System.Windows.Forms.NumericUpDown();
            this.lfrom = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.cobdate = new System.Windows.Forms.ComboBox();
            this.cobword = new System.Windows.Forms.ComboBox();
            this.cobname = new System.Windows.Forms.ComboBox();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.rbsize = new System.Windows.Forms.RadioButton();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.cbbasedonpermissions = new System.Windows.Forms.CheckBox();
            this.cbhiddendir = new System.Windows.Forms.CheckBox();
            this.cbarchive = new System.Windows.Forms.CheckBox();
            this.cbsubdir = new System.Windows.Forms.CheckBox();
            this.cbhidden = new System.Windows.Forms.CheckBox();
            this.cbreadonly = new System.Windows.Forms.CheckBox();
            this.cbsystemfolder = new System.Windows.Forms.CheckBox();
            this.cbcase = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb2llselect = new System.Windows.Forms.LinkLabel();
            this.bpause = new System.Windows.Forms.Button();
            this.bstop = new System.Windows.Forms.Button();
            this.bstart = new System.Windows.Forms.Button();
            this.lvresults = new System.Windows.Forms.ListView();
            this.checks = new System.Windows.Forms.ColumnHeader();
            this.filename = new System.Windows.Forms.ColumnHeader();
            this.filepath = new System.Windows.Forms.ColumnHeader();
            this.filesize = new System.Windows.Forms.ColumnHeader();
            this.chFileExt = new System.Windows.Forms.ColumnHeader();
            this.cmslvresult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiopencontaining = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiopenit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmirename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmidelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicopyto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiproperties = new System.Windows.Forms.ToolStripMenuItem();
            this.bdefault = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmifile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiexit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmitools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiclearhistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmicontextmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.hideRovertsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmihelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiballoontips = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiabout = new System.Windows.Forms.ToolStripMenuItem();
            this.epname = new System.Windows.Forms.ErrorProvider(this.components);
            this.epword = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstatus = new System.Windows.Forms.Label();
            this.tphelp = new System.Windows.Forms.ToolTip(this.components);
            this.axAgent1 = new AxAgentObjects.AxAgent();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfrom)).BeginInit();
            this.gb3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmslvresult.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 56);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 269);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.gb2);
            this.tabPage1.Controls.Add(this.gb1);
            this.tabPage1.Controls.Add(this.gb3);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.bexclude);
            this.gb2.Controls.Add(this.bbrowse);
            this.gb2.Controls.Add(this.clbdrives);
            this.gb2.Location = new System.Drawing.Point(6, 135);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(266, 102);
            this.gb2.TabIndex = 4;
            this.gb2.TabStop = false;
            this.gb2.Text = "2. Path or Location";
            this.tphelp.SetToolTip(this.gb2, resources.GetString("gb2.ToolTip"));
            // 
            // bexclude
            // 
            this.bexclude.AutoSize = true;
            this.bexclude.BackColor = System.Drawing.SystemColors.Control;
            this.bexclude.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bexclude.Location = new System.Drawing.Point(141, 70);
            this.bexclude.Name = "bexclude";
            this.bexclude.Size = new System.Drawing.Size(112, 23);
            this.bexclude.TabIndex = 2;
            this.bexclude.Text = "Exclude Directories";
            this.bexclude.UseVisualStyleBackColor = false;
            this.bexclude.Click += new System.EventHandler(this.bexclude_Click);
            // 
            // bbrowse
            // 
            this.bbrowse.BackColor = System.Drawing.SystemColors.Control;
            this.bbrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bbrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bbrowse.Location = new System.Drawing.Point(79, 70);
            this.bbrowse.Name = "bbrowse";
            this.bbrowse.Size = new System.Drawing.Size(56, 23);
            this.bbrowse.TabIndex = 1;
            this.bbrowse.Text = "Browse";
            this.bbrowse.UseVisualStyleBackColor = false;
            this.bbrowse.Click += new System.EventHandler(this.bbrowse_Click);
            // 
            // clbdrives
            // 
            this.clbdrives.CheckOnClick = true;
            this.clbdrives.FormattingEnabled = true;
            this.clbdrives.Location = new System.Drawing.Point(12, 16);
            this.clbdrives.Name = "clbdrives";
            this.clbdrives.Size = new System.Drawing.Size(63, 79);
            this.clbdrives.TabIndex = 2;
            this.clbdrives.SelectedIndexChanged += new System.EventHandler(this.clbdrives_SelectedIndexChanged);
            // 
            // gb1
            // 
            this.gb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb1.Controls.Add(this.rbdate);
            this.gb1.Controls.Add(this.nudto);
            this.gb1.Controls.Add(this.rbword);
            this.gb1.Controls.Add(this.rbname);
            this.gb1.Controls.Add(this.cobsize);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.lto);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.nudfrom);
            this.gb1.Controls.Add(this.lfrom);
            this.gb1.Controls.Add(this.dtpto);
            this.gb1.Controls.Add(this.cobdate);
            this.gb1.Controls.Add(this.cobword);
            this.gb1.Controls.Add(this.cobname);
            this.gb1.Controls.Add(this.dtpfrom);
            this.gb1.Controls.Add(this.rbsize);
            this.gb1.Location = new System.Drawing.Point(6, 6);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(615, 123);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "1. Choose a searching criteria";
            // 
            // rbdate
            // 
            this.rbdate.AutoSize = true;
            this.rbdate.Location = new System.Drawing.Point(246, 19);
            this.rbdate.Name = "rbdate";
            this.rbdate.Size = new System.Drawing.Size(48, 17);
            this.rbdate.TabIndex = 24;
            this.rbdate.Text = "&Date";
            this.tphelp.SetToolTip(this.rbdate, resources.GetString("rbdate.ToolTip"));
            this.rbdate.UseVisualStyleBackColor = true;
            this.rbdate.CheckedChanged += new System.EventHandler(this.rbdate_CheckedChanged);
            // 
            // nudto
            // 
            this.nudto.Enabled = false;
            this.nudto.Location = new System.Drawing.Point(426, 92);
            this.nudto.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudto.Name = "nudto";
            this.nudto.Size = new System.Drawing.Size(85, 20);
            this.nudto.TabIndex = 38;
            this.nudto.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // rbword
            // 
            this.rbword.AutoSize = true;
            this.rbword.Location = new System.Drawing.Point(19, 68);
            this.rbword.Name = "rbword";
            this.rbword.Size = new System.Drawing.Size(54, 17);
            this.rbword.TabIndex = 23;
            this.rbword.Text = "&Word:";
            this.tphelp.SetToolTip(this.rbword, resources.GetString("rbword.ToolTip"));
            this.rbword.UseVisualStyleBackColor = true;
            this.rbword.CheckedChanged += new System.EventHandler(this.rbword_CheckedChanged);
            // 
            // rbname
            // 
            this.rbname.AutoSize = true;
            this.rbname.Checked = true;
            this.rbname.Location = new System.Drawing.Point(19, 19);
            this.rbname.Name = "rbname";
            this.rbname.Size = new System.Drawing.Size(56, 17);
            this.rbname.TabIndex = 22;
            this.rbname.TabStop = true;
            this.rbname.Text = "&Name:";
            this.tphelp.SetToolTip(this.rbname, resources.GetString("rbname.ToolTip"));
            this.rbname.UseVisualStyleBackColor = true;
            this.rbname.CheckedChanged += new System.EventHandler(this.rbname_CheckedChanged);
            // 
            // cobsize
            // 
            this.cobsize.Enabled = false;
            this.cobsize.FormattingEnabled = true;
            this.cobsize.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobsize.Location = new System.Drawing.Point(517, 91);
            this.cobsize.Name = "cobsize";
            this.cobsize.Size = new System.Drawing.Size(75, 21);
            this.cobsize.TabIndex = 34;
            this.cobsize.Text = "KB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Max:";
            // 
            // lto
            // 
            this.lto.AutoSize = true;
            this.lto.Location = new System.Drawing.Point(397, 44);
            this.lto.Name = "lto";
            this.lto.Size = new System.Drawing.Size(23, 13);
            this.lto.TabIndex = 21;
            this.lto.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Min:";
            // 
            // nudfrom
            // 
            this.nudfrom.Enabled = false;
            this.nudfrom.Location = new System.Drawing.Point(307, 91);
            this.nudfrom.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudfrom.Name = "nudfrom";
            this.nudfrom.Size = new System.Drawing.Size(84, 20);
            this.nudfrom.TabIndex = 37;
            // 
            // lfrom
            // 
            this.lfrom.AutoSize = true;
            this.lfrom.Location = new System.Drawing.Point(272, 44);
            this.lfrom.Name = "lfrom";
            this.lfrom.Size = new System.Drawing.Size(33, 13);
            this.lfrom.TabIndex = 20;
            this.lfrom.Text = "From:";
            // 
            // dtpto
            // 
            this.dtpto.Enabled = false;
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(426, 41);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(85, 20);
            this.dtpto.TabIndex = 19;
            // 
            // cobdate
            // 
            this.cobdate.Enabled = false;
            this.cobdate.FormattingEnabled = true;
            this.cobdate.Items.AddRange(new object[] {
            "Modified",
            "Created",
            "Accessed"});
            this.cobdate.Location = new System.Drawing.Point(517, 41);
            this.cobdate.Name = "cobdate";
            this.cobdate.Size = new System.Drawing.Size(75, 21);
            this.cobdate.TabIndex = 18;
            this.cobdate.Text = "Modified";
            // 
            // cobword
            // 
            this.cobword.Enabled = false;
            this.cobword.FormattingEnabled = true;
            this.cobword.Location = new System.Drawing.Point(39, 91);
            this.cobword.Name = "cobword";
            this.cobword.Size = new System.Drawing.Size(174, 21);
            this.cobword.TabIndex = 17;
            this.cobword.Validated += new System.EventHandler(this.cobword_Validated);
            // 
            // cobname
            // 
            this.cobname.FormattingEnabled = true;
            this.cobname.Location = new System.Drawing.Point(39, 41);
            this.cobname.Name = "cobname";
            this.cobname.Size = new System.Drawing.Size(174, 21);
            this.cobname.Sorted = true;
            this.cobname.TabIndex = 0;
            this.cobname.Validated += new System.EventHandler(this.cobname_Validated);
            // 
            // dtpfrom
            // 
            this.dtpfrom.Enabled = false;
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(307, 41);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(84, 20);
            this.dtpfrom.TabIndex = 15;
            // 
            // rbsize
            // 
            this.rbsize.AutoSize = true;
            this.rbsize.Location = new System.Drawing.Point(246, 68);
            this.rbsize.Name = "rbsize";
            this.rbsize.Size = new System.Drawing.Size(45, 17);
            this.rbsize.TabIndex = 33;
            this.rbsize.Text = "&Size";
            this.tphelp.SetToolTip(this.rbsize, resources.GetString("rbsize.ToolTip"));
            this.rbsize.UseVisualStyleBackColor = true;
            this.rbsize.CheckedChanged += new System.EventHandler(this.rbsize_CheckedChanged);
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.cbbasedonpermissions);
            this.gb3.Controls.Add(this.cbhiddendir);
            this.gb3.Controls.Add(this.cbarchive);
            this.gb3.Controls.Add(this.cbsubdir);
            this.gb3.Controls.Add(this.cbhidden);
            this.gb3.Controls.Add(this.cbreadonly);
            this.gb3.Controls.Add(this.cbsystemfolder);
            this.gb3.Controls.Add(this.cbcase);
            this.gb3.Location = new System.Drawing.Point(278, 135);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(343, 102);
            this.gb3.TabIndex = 3;
            this.gb3.TabStop = false;
            this.gb3.Text = "3. Advanced Options";
            // 
            // cbbasedonpermissions
            // 
            this.cbbasedonpermissions.AutoSize = true;
            this.cbbasedonpermissions.Location = new System.Drawing.Point(141, 14);
            this.cbbasedonpermissions.Name = "cbbasedonpermissions";
            this.cbbasedonpermissions.Size = new System.Drawing.Size(89, 17);
            this.cbbasedonpermissions.TabIndex = 14;
            this.cbbasedonpermissions.Text = "File Attributes";
            this.cbbasedonpermissions.UseVisualStyleBackColor = true;
            this.cbbasedonpermissions.CheckedChanged += new System.EventHandler(this.cbbasedonpermissions_CheckedChanged);
            // 
            // cbhiddendir
            // 
            this.cbhiddendir.AutoSize = true;
            this.cbhiddendir.Location = new System.Drawing.Point(12, 81);
            this.cbhiddendir.Name = "cbhiddendir";
            this.cbhiddendir.Size = new System.Drawing.Size(97, 17);
            this.cbhiddendir.TabIndex = 6;
            this.cbhiddendir.Text = "Hidden Folders";
            this.tphelp.SetToolTip(this.cbhiddendir, "  Hidden Directories\r\n  ----------------------\r\n   This option makes Search 2006\r" +
                    "\n   to search in hidden directories also.\r\n   This is not enabled by default\r\n\r\n" +
                    "");
            this.cbhiddendir.UseVisualStyleBackColor = true;
            // 
            // cbarchive
            // 
            this.cbarchive.AutoSize = true;
            this.cbarchive.Checked = true;
            this.cbarchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbarchive.Enabled = false;
            this.cbarchive.Location = new System.Drawing.Point(156, 78);
            this.cbarchive.Name = "cbarchive";
            this.cbarchive.Size = new System.Drawing.Size(62, 17);
            this.cbarchive.TabIndex = 13;
            this.cbarchive.Text = "Archive";
            this.cbarchive.UseVisualStyleBackColor = true;
            // 
            // cbsubdir
            // 
            this.cbsubdir.AutoSize = true;
            this.cbsubdir.Checked = true;
            this.cbsubdir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbsubdir.Location = new System.Drawing.Point(12, 37);
            this.cbsubdir.Name = "cbsubdir";
            this.cbsubdir.Size = new System.Drawing.Size(114, 17);
            this.cbsubdir.TabIndex = 4;
            this.cbsubdir.Text = "Include S&ubfolders";
            this.tphelp.SetToolTip(this.cbsubdir, resources.GetString("cbsubdir.ToolTip"));
            this.cbsubdir.UseVisualStyleBackColor = true;
            // 
            // cbhidden
            // 
            this.cbhidden.AutoSize = true;
            this.cbhidden.Enabled = false;
            this.cbhidden.Location = new System.Drawing.Point(156, 56);
            this.cbhidden.Name = "cbhidden";
            this.cbhidden.Size = new System.Drawing.Size(60, 17);
            this.cbhidden.TabIndex = 12;
            this.cbhidden.Text = "Hidden";
            this.cbhidden.UseVisualStyleBackColor = true;
            // 
            // cbreadonly
            // 
            this.cbreadonly.AutoSize = true;
            this.cbreadonly.Enabled = false;
            this.cbreadonly.Location = new System.Drawing.Point(156, 34);
            this.cbreadonly.Name = "cbreadonly";
            this.cbreadonly.Size = new System.Drawing.Size(74, 17);
            this.cbreadonly.TabIndex = 11;
            this.cbreadonly.Text = "Read-only";
            this.cbreadonly.UseVisualStyleBackColor = true;
            // 
            // cbsystemfolder
            // 
            this.cbsystemfolder.AutoSize = true;
            this.cbsystemfolder.Checked = true;
            this.cbsystemfolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbsystemfolder.Location = new System.Drawing.Point(12, 59);
            this.cbsystemfolder.Name = "cbsystemfolder";
            this.cbsystemfolder.Size = new System.Drawing.Size(97, 17);
            this.cbsystemfolder.TabIndex = 5;
            this.cbsystemfolder.Text = "S&ystem Folders";
            this.tphelp.SetToolTip(this.cbsystemfolder, resources.GetString("cbsystemfolder.ToolTip"));
            this.cbsystemfolder.UseVisualStyleBackColor = true;
            // 
            // cbcase
            // 
            this.cbcase.AutoSize = true;
            this.cbcase.Location = new System.Drawing.Point(12, 15);
            this.cbcase.Name = "cbcase";
            this.cbcase.Size = new System.Drawing.Size(96, 17);
            this.cbcase.TabIndex = 3;
            this.cbcase.Text = "&Case Sensitive";
            this.tphelp.SetToolTip(this.cbcase, resources.GetString("cbcase.ToolTip"));
            this.cbcase.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Largest File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb2llselect);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Largest File:";
            // 
            // tb2llselect
            // 
            this.tb2llselect.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(126)))), ((int)(((byte)(220)))));
            this.tb2llselect.AutoSize = true;
            this.tb2llselect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb2llselect.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(112)))), ((int)(((byte)(41)))));
            this.tb2llselect.Location = new System.Drawing.Point(9, 20);
            this.tb2llselect.Name = "tb2llselect";
            this.tb2llselect.Size = new System.Drawing.Size(91, 13);
            this.tb2llselect.TabIndex = 0;
            this.tb2llselect.TabStop = true;
            this.tb2llselect.Text = "Select a Directory";
            this.tb2llselect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.tb2llselect_LinkClicked);
            // 
            // bpause
            // 
            this.bpause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bpause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bpause.BackgroundImage")));
            this.bpause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bpause.Location = new System.Drawing.Point(663, 162);
            this.bpause.Name = "bpause";
            this.bpause.Size = new System.Drawing.Size(75, 23);
            this.bpause.TabIndex = 9;
            this.bpause.Text = "Pause";
            this.bpause.UseVisualStyleBackColor = true;
            this.bpause.Click += new System.EventHandler(this.bpause_Click);
            // 
            // bstop
            // 
            this.bstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bstop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bstop.BackgroundImage")));
            this.bstop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bstop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bstop.Location = new System.Drawing.Point(663, 224);
            this.bstop.Name = "bstop";
            this.bstop.Size = new System.Drawing.Size(75, 23);
            this.bstop.TabIndex = 10;
            this.bstop.Text = "Stop";
            this.bstop.UseVisualStyleBackColor = true;
            this.bstop.Click += new System.EventHandler(this.bstop_Click);
            // 
            // bstart
            // 
            this.bstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bstart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bstart.BackgroundImage")));
            this.bstart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bstart.Location = new System.Drawing.Point(663, 100);
            this.bstart.Name = "bstart";
            this.bstart.Size = new System.Drawing.Size(75, 23);
            this.bstart.TabIndex = 8;
            this.bstart.Text = "Start";
            this.bstart.UseVisualStyleBackColor = true;
            this.bstart.Click += new System.EventHandler(this.bstart_Click);
            // 
            // lvresults
            // 
            this.lvresults.AllowColumnReorder = true;
            this.lvresults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvresults.AutoArrange = false;
            this.lvresults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checks,
            this.filename,
            this.filepath,
            this.filesize,
            this.chFileExt});
            this.lvresults.ContextMenuStrip = this.cmslvresult;
            this.lvresults.FullRowSelect = true;
            this.lvresults.GridLines = true;
            this.lvresults.Location = new System.Drawing.Point(12, 336);
            this.lvresults.Name = "lvresults";
            this.lvresults.Size = new System.Drawing.Size(635, 150);
            this.lvresults.TabIndex = 8;
            this.lvresults.UseCompatibleStateImageBehavior = false;
            this.lvresults.View = System.Windows.Forms.View.Details;
            this.lvresults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvresults_ColumnClick);
            // 
            // checks
            // 
            this.checks.Text = "#";
            this.checks.Width = 56;
            // 
            // filename
            // 
            this.filename.Text = "File Name";
            this.filename.Width = 119;
            // 
            // filepath
            // 
            this.filepath.Text = "File Path";
            this.filepath.Width = 219;
            // 
            // filesize
            // 
            this.filesize.Text = "File Size(Bytes)";
            this.filesize.Width = 97;
            // 
            // chFileExt
            // 
            this.chFileExt.Text = "File Extension";
            this.chFileExt.Width = 102;
            // 
            // cmslvresult
            // 
            this.cmslvresult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiopencontaining,
            this.tsmiopenit,
            this.toolStripSeparator1,
            this.tsmirename,
            this.tsmidelete,
            this.tsmicopyto,
            this.toolStripSeparator2,
            this.tsmiproperties});
            this.cmslvresult.Name = "cmslvresult";
            this.cmslvresult.Size = new System.Drawing.Size(199, 148);
            // 
            // tsmiopencontaining
            // 
            this.tsmiopencontaining.Image = ((System.Drawing.Image)(resources.GetObject("tsmiopencontaining.Image")));
            this.tsmiopencontaining.Name = "tsmiopencontaining";
            this.tsmiopencontaining.Size = new System.Drawing.Size(198, 22);
            this.tsmiopencontaining.Text = "Open Containing Folder";
            this.tsmiopencontaining.Click += new System.EventHandler(this.tsmiopencontaining_Click);
            // 
            // tsmiopenit
            // 
            this.tsmiopenit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiopenit.Image")));
            this.tsmiopenit.Name = "tsmiopenit";
            this.tsmiopenit.Size = new System.Drawing.Size(198, 22);
            this.tsmiopenit.Text = "Open it";
            this.tsmiopenit.Click += new System.EventHandler(this.tsmiopenit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // tsmirename
            // 
            this.tsmirename.Image = ((System.Drawing.Image)(resources.GetObject("tsmirename.Image")));
            this.tsmirename.Name = "tsmirename";
            this.tsmirename.Size = new System.Drawing.Size(198, 22);
            this.tsmirename.Text = "Rename";
            this.tsmirename.Click += new System.EventHandler(this.tsmirename_Click);
            // 
            // tsmidelete
            // 
            this.tsmidelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmidelete.Image")));
            this.tsmidelete.Name = "tsmidelete";
            this.tsmidelete.Size = new System.Drawing.Size(198, 22);
            this.tsmidelete.Text = "Delete";
            this.tsmidelete.Click += new System.EventHandler(this.tsmidelete_Click);
            // 
            // tsmicopyto
            // 
            this.tsmicopyto.Image = ((System.Drawing.Image)(resources.GetObject("tsmicopyto.Image")));
            this.tsmicopyto.Name = "tsmicopyto";
            this.tsmicopyto.Size = new System.Drawing.Size(198, 22);
            this.tsmicopyto.Text = "Copy to";
            this.tsmicopyto.Click += new System.EventHandler(this.tsmicopyto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // tsmiproperties
            // 
            this.tsmiproperties.Image = ((System.Drawing.Image)(resources.GetObject("tsmiproperties.Image")));
            this.tsmiproperties.Name = "tsmiproperties";
            this.tsmiproperties.Size = new System.Drawing.Size(198, 22);
            this.tsmiproperties.Text = "Properties";
            this.tsmiproperties.Click += new System.EventHandler(this.tsmiproperties_Click);
            // 
            // bdefault
            // 
            this.bdefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdefault.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bdefault.BackgroundImage")));
            this.bdefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bdefault.Location = new System.Drawing.Point(663, 283);
            this.bdefault.Name = "bdefault";
            this.bdefault.Size = new System.Drawing.Size(75, 23);
            this.bdefault.TabIndex = 11;
            this.bdefault.Text = "Set Default";
            this.tphelp.SetToolTip(this.bdefault, "    Set Defaults\r\n    ---------------\r\n   This will restore Search 2006\r\n   setti" +
                    "ng to its defaults.Better \r\n   to use it when you are not able \r\n   decide which" +
                    " option to select.");
            this.bdefault.UseVisualStyleBackColor = true;
            this.bdefault.Click += new System.EventHandler(this.bdefault_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmifile,
            this.tsmitools,
            this.tsmihelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmifile
            // 
            this.tsmifile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiexit});
            this.tsmifile.Name = "tsmifile";
            this.tsmifile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.tsmifile.Size = new System.Drawing.Size(35, 20);
            this.tsmifile.Text = "&File";
            // 
            // tsmiexit
            // 
            this.tsmiexit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiexit.Image")));
            this.tsmiexit.Name = "tsmiexit";
            this.tsmiexit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiexit.Size = new System.Drawing.Size(143, 22);
            this.tsmiexit.Text = "E&xit";
            this.tsmiexit.Click += new System.EventHandler(this.tsmiexit_Click);
            // 
            // tsmitools
            // 
            this.tsmitools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiclearhistory,
            this.tsmicontextmenu,
            this.hideRovertsmi});
            this.tsmitools.Name = "tsmitools";
            this.tsmitools.Size = new System.Drawing.Size(44, 20);
            this.tsmitools.Text = "&Tools";
            // 
            // tsmiclearhistory
            // 
            this.tsmiclearhistory.Image = ((System.Drawing.Image)(resources.GetObject("tsmiclearhistory.Image")));
            this.tsmiclearhistory.Name = "tsmiclearhistory";
            this.tsmiclearhistory.Size = new System.Drawing.Size(153, 22);
            this.tsmiclearhistory.Text = "Clear History";
            this.tsmiclearhistory.Click += new System.EventHandler(this.tsmiclearhistory_Click);
            // 
            // tsmicontextmenu
            // 
            this.tsmicontextmenu.CheckOnClick = true;
            this.tsmicontextmenu.Name = "tsmicontextmenu";
            this.tsmicontextmenu.Size = new System.Drawing.Size(153, 22);
            this.tsmicontextmenu.Text = "Context Menu";
            this.tsmicontextmenu.Click += new System.EventHandler(this.tsmicontextmenu_Click);
            // 
            // hideRovertsmi
            // 
            this.hideRovertsmi.Name = "hideRovertsmi";
            this.hideRovertsmi.Size = new System.Drawing.Size(153, 22);
            this.hideRovertsmi.Text = "Hide Rover";
            this.hideRovertsmi.Click += new System.EventHandler(this.hideRoverToolStripMenuItem_Click);
            // 
            // tsmihelp
            // 
            this.tsmihelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiballoontips,
            this.tsmiabout});
            this.tsmihelp.Name = "tsmihelp";
            this.tsmihelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.tsmihelp.Size = new System.Drawing.Size(40, 20);
            this.tsmihelp.Text = "&Help";
            // 
            // tsmiballoontips
            // 
            this.tsmiballoontips.Checked = true;
            this.tsmiballoontips.CheckOnClick = true;
            this.tsmiballoontips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiballoontips.Name = "tsmiballoontips";
            this.tsmiballoontips.Size = new System.Drawing.Size(141, 22);
            this.tsmiballoontips.Text = "Balloon Tips";
            this.tsmiballoontips.Click += new System.EventHandler(this.tsmiballoontips_Click);
            // 
            // tsmiabout
            // 
            this.tsmiabout.Image = ((System.Drawing.Image)(resources.GetObject("tsmiabout.Image")));
            this.tsmiabout.Name = "tsmiabout";
            this.tsmiabout.Size = new System.Drawing.Size(141, 22);
            this.tsmiabout.Text = "&About";
            this.tsmiabout.Click += new System.EventHandler(this.tsmiabout_Click);
            // 
            // epname
            // 
            this.epname.BlinkRate = 750;
            this.epname.ContainerControl = this;
            // 
            // epword
            // 
            this.epword.BlinkRate = 750;
            this.epword.ContainerControl = this;
            // 
            // lstatus
            // 
            this.lstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstatus.AutoSize = true;
            this.lstatus.BackColor = System.Drawing.Color.Transparent;
            this.lstatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstatus.ForeColor = System.Drawing.Color.White;
            this.lstatus.Location = new System.Drawing.Point(12, 489);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(223, 16);
            this.lstatus.TabIndex = 13;
            this.lstatus.Text = "Status : Search 2006 is Currently Idle";
            // 
            // tphelp
            // 
            this.tphelp.AutoPopDelay = 25000;
            this.tphelp.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tphelp.InitialDelay = 100;
            this.tphelp.IsBalloon = true;
            this.tphelp.ReshowDelay = 10;
            this.tphelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tphelp.ToolTipTitle = "Help From Search 2006";
            // 
            // axAgent1
            // 
            this.axAgent1.Enabled = true;
            this.axAgent1.Location = new System.Drawing.Point(689, 398);
            this.axAgent1.Name = "axAgent1";
            this.axAgent1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgent1.OcxState")));
            this.axAgent1.Size = new System.Drawing.Size(32, 32);
            this.axAgent1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AcceptButton = this.bstart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.AutoScrollMinSize = new System.Drawing.Size(0, 100);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.bstop;
            this.ClientSize = new System.Drawing.Size(761, 514);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.bpause);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.lvresults);
            this.Controls.Add(this.bdefault);
            this.Controls.Add(this.bstop);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bstart);
            this.Controls.Add(this.axAgent1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 493);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search 2006 By K.Vineel Kumar Reddy";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfrom)).EndInit();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmslvresult.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.ComboBox cobword;
        private System.Windows.Forms.ComboBox cobname;
        private System.Windows.Forms.Label lfrom;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.ComboBox cobdate;
        private System.Windows.Forms.Label lto;
        private System.Windows.Forms.RadioButton rbdate;
        private System.Windows.Forms.RadioButton rbword;
        private System.Windows.Forms.RadioButton rbname;
        private System.Windows.Forms.NumericUpDown nudto;
        private System.Windows.Forms.NumericUpDown nudfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobsize;
        private System.Windows.Forms.RadioButton rbsize;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.Button bpause;
        private System.Windows.Forms.Button bstop;
        private System.Windows.Forms.Button bstart;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.CheckedListBox clbdrives;
        private System.Windows.Forms.ListView lvresults;
        private System.Windows.Forms.ColumnHeader filename;
        private System.Windows.Forms.ColumnHeader filepath;
        private System.Windows.Forms.ColumnHeader filesize;
        private System.Windows.Forms.ColumnHeader checks;
        private System.Windows.Forms.Button bdefault;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmifile;
        private System.Windows.Forms.ToolStripMenuItem tsmiexit;
        private System.Windows.Forms.ToolStripMenuItem tsmihelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiabout;
        private System.Windows.Forms.CheckBox cbsubdir;
        private System.Windows.Forms.CheckBox cbsystemfolder;
        private System.Windows.Forms.CheckBox cbcase;
        private System.Windows.Forms.Button bbrowse;

        private System.Windows.Forms.CheckBox cbreadonly;
        private System.Windows.Forms.CheckBox cbhidden;
        private System.Windows.Forms.CheckBox cbarchive;
        private System.Windows.Forms.ContextMenuStrip cmslvresult;
        private System.Windows.Forms.ToolStripMenuItem tsmiopencontaining;
        private System.Windows.Forms.ToolStripMenuItem tsmiopenit;
        private System.Windows.Forms.ToolStripMenuItem tsmirename;
        private System.Windows.Forms.ToolStripMenuItem tsmidelete;
        private System.Windows.Forms.ToolStripMenuItem tsmicopyto;
        private System.Windows.Forms.ToolStripMenuItem tsmitools;
        private System.Windows.Forms.ToolStripMenuItem tsmiclearhistory;
        private System.Windows.Forms.CheckBox cbhiddendir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiproperties;
        private System.Windows.Forms.ErrorProvider epname;
        private System.Windows.Forms.ErrorProvider epword;
        private System.Windows.Forms.Button bexclude;
        private ToolStripMenuItem tsmicontextmenu;
        private Label lstatus;
        private ToolTip tphelp;
        private ToolStripMenuItem tsmiballoontips;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private LinkLabel tb2llselect;
        private ToolStripMenuItem hideRovertsmi;
        private ColumnHeader chFileExt;
        private CheckBox cbbasedonpermissions;
        private Label label2;



    }
}

