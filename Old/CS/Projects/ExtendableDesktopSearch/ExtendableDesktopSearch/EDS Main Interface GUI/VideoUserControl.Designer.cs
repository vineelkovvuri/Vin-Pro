namespace ExtendableDesktopSearch
{
    partial class VideoUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoUserControl));
            this.ttInVideo = new System.Windows.Forms.ToolTip(this.components);
            this.lClearInputFieldsInVideo = new System.Windows.Forms.Label();
            this.cmsInDocuments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDateInVideo = new System.Windows.Forms.CheckBox();
            this.bSearchInVideo = new ExtendableDesktopSearch.GlassButton();
            this.cobLengthMetricsInVideo = new System.Windows.Forms.ComboBox();
            this.tbLengthToInVideo = new ExtendableDesktopSearch.NumericTextBox();
            this.tbLengthFromInVideo = new ExtendableDesktopSearch.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFileNameInVideo = new ExtendableDesktopSearch.BannerTextBox();
            this.dtpToInVideo = new System.Windows.Forms.DateTimePicker();
            this.dtpFromInVideo = new System.Windows.Forms.DateTimePicker();
            this.cobSizeMetricsInVideo = new System.Windows.Forms.ComboBox();
            this.tbSizeToInVideo = new ExtendableDesktopSearch.NumericTextBox();
            this.tbSizeFromInVideo = new ExtendableDesktopSearch.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInVideo = new ExtendableDesktopSearch.ResultsPanel();
            this.bDelete = new ExtendableDesktopSearch.GlassButton();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInVideo = new ExtendableDesktopSearch.ListViewEx();
            this.cmsInDocuments.SuspendLayout();
            this.VideoPropertiesPanel.SuspendLayout();
            this.pResultsInVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lClearInputFieldsInVideo
            // 
            this.lClearInputFieldsInVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInVideo.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInVideo.Image")));
            this.lClearInputFieldsInVideo.Location = new System.Drawing.Point(15, 440);
            this.lClearInputFieldsInVideo.Name = "lClearInputFieldsInVideo";
            this.lClearInputFieldsInVideo.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInVideo.TabIndex = 12;
            this.ttInVideo.SetToolTip(this.lClearInputFieldsInVideo, "Clear all input fields");
            this.lClearInputFieldsInVideo.Click += new System.EventHandler(this.lClearInputFieldsInVideo_Click);
            // 
            // cmsInDocuments
            // 
            this.cmsInDocuments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFolder,
            this.tsmiOpen,
            this.toolStripSeparator1,
            this.tsmiDelete,
            this.tsmiCopyTo,
            this.toolStripSeparator2,
            this.tsmiProperties});
            this.cmsInDocuments.Name = "cmslvresult";
            this.cmsInDocuments.Size = new System.Drawing.Size(145, 126);
            // 
            // tsmiOpenFolder
            // 
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(144, 22);
            this.tsmiOpenFolder.Text = "Open Folder";
            this.tsmiOpenFolder.Click += new System.EventHandler(this.tsmiOpenFolder_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(144, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(144, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiCopyTo
            // 
            this.tsmiCopyTo.Name = "tsmiCopyTo";
            this.tsmiCopyTo.Size = new System.Drawing.Size(144, 22);
            this.tsmiCopyTo.Text = "Copy to";
            this.tsmiCopyTo.Click += new System.EventHandler(this.tsmiCopyTo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmiProperties
            // 
            this.tsmiProperties.Name = "tsmiProperties";
            this.tsmiProperties.Size = new System.Drawing.Size(144, 22);
            this.tsmiProperties.Text = "Properties";
            this.tsmiProperties.Click += new System.EventHandler(this.tsmiProperties_Click);
            // 
            // VideoPropertiesPanel
            // 
            this.VideoPropertiesPanel.Caption = "Search for video files";
            this.VideoPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("VideoPropertiesPanel.CaptionImage")));
            this.VideoPropertiesPanel.Controls.Add(this.cobDate);
            this.VideoPropertiesPanel.Controls.Add(this.label10);
            this.VideoPropertiesPanel.Controls.Add(this.cbDateInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.lClearInputFieldsInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.bSearchInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.cobLengthMetricsInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.tbLengthToInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.tbLengthFromInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.label2);
            this.VideoPropertiesPanel.Controls.Add(this.label8);
            this.VideoPropertiesPanel.Controls.Add(this.label9);
            this.VideoPropertiesPanel.Controls.Add(this.tbFileNameInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.dtpToInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.dtpFromInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.cobSizeMetricsInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.tbSizeToInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.tbSizeFromInVideo);
            this.VideoPropertiesPanel.Controls.Add(this.label5);
            this.VideoPropertiesPanel.Controls.Add(this.label7);
            this.VideoPropertiesPanel.Controls.Add(this.label4);
            this.VideoPropertiesPanel.Controls.Add(this.label3);
            this.VideoPropertiesPanel.Controls.Add(this.label1);
            this.VideoPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoPropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.VideoPropertiesPanel.Name = "VideoPropertiesPanel";
            this.VideoPropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.VideoPropertiesPanel.TabIndex = 0;
            // 
            // cobDate
            // 
            this.cobDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDate.Enabled = false;
            this.cobDate.FormattingEnabled = true;
            this.cobDate.Items.AddRange(new object[] {
            "Created",
            "Last Modified",
            "Last Accessed"});
            this.cobDate.Location = new System.Drawing.Point(45, 145);
            this.cobDate.Name = "cobDate";
            this.cobDate.Size = new System.Drawing.Size(95, 21);
            this.cobDate.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(15, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "--------------------Advanced--------------------";
            // 
            // cbDateInVideo
            // 
            this.cbDateInVideo.AutoSize = true;
            this.cbDateInVideo.Location = new System.Drawing.Point(18, 147);
            this.cbDateInVideo.Name = "cbDateInVideo";
            this.cbDateInVideo.Size = new System.Drawing.Size(160, 17);
            this.cbDateInVideo.TabIndex = 4;
            this.cbDateInVideo.Text = "                                     &Date";
            this.cbDateInVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInVideo.UseVisualStyleBackColor = true;
            this.cbDateInVideo.CheckedChanged += new System.EventHandler(this.cbDateInVideo_CheckedChanged);
            // 
            // bSearchInVideo
            // 
            this.bSearchInVideo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInVideo.BackgroundImage")));
            this.bSearchInVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInVideo.FlatAppearance.BorderSize = 0;
            this.bSearchInVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInVideo.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInVideo.Image")));
            this.bSearchInVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInVideo.Location = new System.Drawing.Point(124, 440);
            this.bSearchInVideo.Name = "bSearchInVideo";
            this.bSearchInVideo.Size = new System.Drawing.Size(100, 32);
            this.bSearchInVideo.TabIndex = 11;
            this.bSearchInVideo.Text = "Search";
            this.bSearchInVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInVideo.UseVisualStyleBackColor = true;
            this.bSearchInVideo.Click += new System.EventHandler(this.bSearchInVideo_Click);
            // 
            // cobLengthMetricsInVideo
            // 
            this.cobLengthMetricsInVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobLengthMetricsInVideo.FormattingEnabled = true;
            this.cobLengthMetricsInVideo.Items.AddRange(new object[] {
            "Sec",
            "Min",
            "Hour"});
            this.cobLengthMetricsInVideo.Location = new System.Drawing.Point(167, 246);
            this.cobLengthMetricsInVideo.Name = "cobLengthMetricsInVideo";
            this.cobLengthMetricsInVideo.Size = new System.Drawing.Size(58, 21);
            this.cobLengthMetricsInVideo.TabIndex = 10;
            // 
            // tbLengthToInVideo
            // 
            this.tbLengthToInVideo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLengthToInVideo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLengthToInVideo.BannerText = "Maximum";
            this.tbLengthToInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLengthToInVideo.Location = new System.Drawing.Point(90, 246);
            this.tbLengthToInVideo.MaxLength = 2;
            this.tbLengthToInVideo.Name = "tbLengthToInVideo";
            this.tbLengthToInVideo.Size = new System.Drawing.Size(52, 21);
            this.tbLengthToInVideo.Submit = this.bSearchInVideo;
            this.tbLengthToInVideo.TabIndex = 9;
            this.tbLengthToInVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInVideo_KeyPress);
            // 
            // tbLengthFromInVideo
            // 
            this.tbLengthFromInVideo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLengthFromInVideo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLengthFromInVideo.BannerText = "Minimum";
            this.tbLengthFromInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLengthFromInVideo.Location = new System.Drawing.Point(19, 246);
            this.tbLengthFromInVideo.MaxLength = 2;
            this.tbLengthFromInVideo.Name = "tbLengthFromInVideo";
            this.tbLengthFromInVideo.Size = new System.Drawing.Size(52, 21);
            this.tbLengthFromInVideo.Submit = this.bSearchInVideo;
            this.tbLengthFromInVideo.TabIndex = 8;
            this.tbLengthFromInVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInVideo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "in";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(76, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(16, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "&Duration:";
            // 
            // tbFileNameInVideo
            // 
            this.tbFileNameInVideo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileNameInVideo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileNameInVideo.BannerText = "Enter all or part of the file name";
            this.tbFileNameInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameInVideo.Location = new System.Drawing.Point(18, 72);
            this.tbFileNameInVideo.Name = "tbFileNameInVideo";
            this.tbFileNameInVideo.Size = new System.Drawing.Size(206, 21);
            this.tbFileNameInVideo.Submit = this.bSearchInVideo;
            this.tbFileNameInVideo.TabIndex = 0;
            this.tbFileNameInVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInVideo_KeyPress);
            // 
            // dtpToInVideo
            // 
            this.dtpToInVideo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInVideo.Enabled = false;
            this.dtpToInVideo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInVideo.Location = new System.Drawing.Point(134, 176);
            this.dtpToInVideo.Name = "dtpToInVideo";
            this.dtpToInVideo.Size = new System.Drawing.Size(90, 21);
            this.dtpToInVideo.TabIndex = 7;
            // 
            // dtpFromInVideo
            // 
            this.dtpFromInVideo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInVideo.Enabled = false;
            this.dtpFromInVideo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInVideo.Location = new System.Drawing.Point(18, 176);
            this.dtpFromInVideo.Name = "dtpFromInVideo";
            this.dtpFromInVideo.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInVideo.TabIndex = 6;
            // 
            // cobSizeMetricsInVideo
            // 
            this.cobSizeMetricsInVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSizeMetricsInVideo.FormattingEnabled = true;
            this.cobSizeMetricsInVideo.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobSizeMetricsInVideo.Location = new System.Drawing.Point(166, 115);
            this.cobSizeMetricsInVideo.Name = "cobSizeMetricsInVideo";
            this.cobSizeMetricsInVideo.Size = new System.Drawing.Size(58, 21);
            this.cobSizeMetricsInVideo.TabIndex = 3;
            // 
            // tbSizeToInVideo
            // 
            this.tbSizeToInVideo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeToInVideo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeToInVideo.BannerText = "Maximum";
            this.tbSizeToInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeToInVideo.Location = new System.Drawing.Point(89, 115);
            this.tbSizeToInVideo.Name = "tbSizeToInVideo";
            this.tbSizeToInVideo.Size = new System.Drawing.Size(52, 21);
            this.tbSizeToInVideo.Submit = this.bSearchInVideo;
            this.tbSizeToInVideo.TabIndex = 2;
            this.tbSizeToInVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInVideo_KeyPress);
            // 
            // tbSizeFromInVideo
            // 
            this.tbSizeFromInVideo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeFromInVideo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeFromInVideo.BannerText = "Minimum";
            this.tbSizeFromInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeFromInVideo.Location = new System.Drawing.Point(18, 115);
            this.tbSizeFromInVideo.Name = "tbSizeFromInVideo";
            this.tbSizeFromInVideo.Size = new System.Drawing.Size(52, 21);
            this.tbSizeFromInVideo.Submit = this.bSearchInVideo;
            this.tbSizeFromInVideo.TabIndex = 1;
            this.tbSizeFromInVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInVideo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(147, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "in";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(113, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(75, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File &Name:";
            // 
            // pResultsInVideo
            // 
            this.pResultsInVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInVideo.Caption = "Results";
            this.pResultsInVideo.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInVideo.CaptionImage")));
            this.pResultsInVideo.Controls.Add(this.bDelete);
            this.pResultsInVideo.Controls.Add(this.lPageNumber);
            this.pResultsInVideo.Controls.Add(this.LLNextPage);
            this.pResultsInVideo.Controls.Add(this.llPrevPage);
            this.pResultsInVideo.Controls.Add(this.lvResultsInVideo);
            this.pResultsInVideo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInVideo.Location = new System.Drawing.Point(245, 5);
            this.pResultsInVideo.Name = "pResultsInVideo";
            this.pResultsInVideo.Size = new System.Drawing.Size(710, 492);
            this.pResultsInVideo.TabIndex = 2;
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bDelete.BackgroundImage")));
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bDelete.FlatAppearance.BorderSize = 0;
            this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDelete.Image = ((System.Drawing.Image)(resources.GetObject("bDelete.Image")));
            this.bDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDelete.Location = new System.Drawing.Point(621, 440);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(74, 32);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Delete";
            this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // lPageNumber
            // 
            this.lPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lPageNumber.AutoSize = true;
            this.lPageNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPageNumber.Location = new System.Drawing.Point(290, 18);
            this.lPageNumber.Name = "lPageNumber";
            this.lPageNumber.Size = new System.Drawing.Size(0, 13);
            this.lPageNumber.TabIndex = 8;
            // 
            // LLNextPage
            // 
            this.LLNextPage.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.LLNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LLNextPage.AutoSize = true;
            this.LLNextPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLNextPage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LLNextPage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(151)))), ((int)(((byte)(135)))));
            this.LLNextPage.Location = new System.Drawing.Point(679, 18);
            this.LLNextPage.Name = "LLNextPage";
            this.LLNextPage.Size = new System.Drawing.Size(16, 13);
            this.LLNextPage.TabIndex = 1;
            this.LLNextPage.TabStop = true;
            this.LLNextPage.Text = ">";
            this.LLNextPage.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(151)))), ((int)(((byte)(135)))));
            this.LLNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLNextPage_LinkClicked);
            // 
            // llPrevPage
            // 
            this.llPrevPage.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.llPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llPrevPage.AutoSize = true;
            this.llPrevPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llPrevPage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llPrevPage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(151)))), ((int)(((byte)(135)))));
            this.llPrevPage.Location = new System.Drawing.Point(657, 18);
            this.llPrevPage.Name = "llPrevPage";
            this.llPrevPage.Size = new System.Drawing.Size(16, 13);
            this.llPrevPage.TabIndex = 0;
            this.llPrevPage.TabStop = true;
            this.llPrevPage.Text = "<";
            this.llPrevPage.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(151)))), ((int)(((byte)(135)))));
            this.llPrevPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPrevPage_LinkClicked);
            // 
            // lvResultsInVideo
            // 
            this.lvResultsInVideo.AllowColumnReorder = true;
            this.lvResultsInVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInVideo.CheckBoxes = true;
            this.lvResultsInVideo.ContextMenuStrip = this.cmsInDocuments;
            this.lvResultsInVideo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInVideo.FullRowSelect = true;
            this.lvResultsInVideo.GridLines = true;
            this.lvResultsInVideo.Location = new System.Drawing.Point(15, 55);
            this.lvResultsInVideo.Name = "lvResultsInVideo";
            this.lvResultsInVideo.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInVideo.TabIndex = 2;
            
            this.lvResultsInVideo.UseCompatibleStateImageBehavior = false;
            this.lvResultsInVideo.View = System.Windows.Forms.View.Details;
            // 
            // VideoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.VideoPropertiesPanel);
            this.Controls.Add(this.pResultsInVideo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VideoUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoUserControl_MouseDown);
            this.cmsInDocuments.ResumeLayout(false);
            this.VideoPropertiesPanel.ResumeLayout(false);
            this.VideoPropertiesPanel.PerformLayout();
            this.pResultsInVideo.ResumeLayout(false);
            this.pResultsInVideo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel VideoPropertiesPanel;
        private System.Windows.Forms.ComboBox cobLengthMetricsInVideo;
        private NumericTextBox tbLengthToInVideo;
        private NumericTextBox tbLengthFromInVideo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private BannerTextBox tbFileNameInVideo;
        private System.Windows.Forms.DateTimePicker dtpToInVideo;
        private System.Windows.Forms.DateTimePicker dtpFromInVideo;
        private System.Windows.Forms.ComboBox cobSizeMetricsInVideo;
        private NumericTextBox tbSizeToInVideo;
        private NumericTextBox tbSizeFromInVideo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ListViewEx lvResultsInVideo;
        private GlassButton bSearchInVideo;
        private System.Windows.Forms.Label lClearInputFieldsInVideo;
        private System.Windows.Forms.ToolTip ttInVideo;
        private ResultsPanel pResultsInVideo;
        private System.Windows.Forms.CheckBox cbDateInVideo;
        private System.Windows.Forms.LinkLabel LLNextPage;
        private System.Windows.Forms.LinkLabel llPrevPage;
        private System.Windows.Forms.Label lPageNumber;
        private GlassButton bDelete;
        private System.Windows.Forms.ContextMenuStrip cmsInDocuments;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiProperties;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cobDate;
    }
}
