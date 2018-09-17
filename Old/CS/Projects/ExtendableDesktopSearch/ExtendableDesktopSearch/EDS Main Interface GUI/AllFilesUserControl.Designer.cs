namespace ExtendableDesktopSearch
{
    partial class AllFilesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllFilesUserControl));
            this.cmsInAllFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AllFilesPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.bProperties = new System.Windows.Forms.Button();
            this.tbQuery = new ExtendableDesktopSearch.BannerTextBox();
            this.bSearchInAllFiles = new ExtendableDesktopSearch.GlassButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cobAttributes = new System.Windows.Forms.ComboBox();
            this.cbAttributes = new System.Windows.Forms.CheckBox();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.dtpToInAllFiles = new System.Windows.Forms.DateTimePicker();
            this.cbDateInAllFiles = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lClearInputFieldsInAllFiles = new System.Windows.Forms.Label();
            this.dtpFromInFiles = new System.Windows.Forms.DateTimePicker();
            this.tbFileNameInAllFiles = new ExtendableDesktopSearch.BannerTextBox();
            this.cobSizeMetricsInFiles = new System.Windows.Forms.ComboBox();
            this.tbSizeToInFiles = new ExtendableDesktopSearch.NumericTextBox();
            this.tbSizeFromInFiles = new ExtendableDesktopSearch.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInAllFiles = new ExtendableDesktopSearch.ResultsPanel();
            this.bDelete = new ExtendableDesktopSearch.GlassButton();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInAllFiles = new ExtendableDesktopSearch.ListViewEx();
            this.cmsInAllFiles.SuspendLayout();
            this.AllFilesPropertiesPanel.SuspendLayout();
            this.pResultsInAllFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsInAllFiles
            // 
            this.cmsInAllFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFolder,
            this.tsmiOpen,
            this.tsmiEdit,
            this.toolStripSeparator1,
            this.tsmiDelete,
            this.tsmiCopyTo,
            this.toolStripSeparator2,
            this.tsmiProperties});
            this.cmsInAllFiles.Name = "cmslvresult";
            this.cmsInAllFiles.Size = new System.Drawing.Size(145, 148);
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
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(144, 22);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
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
            // cmsProperties
            // 
            this.cmsProperties.Name = "cmsProperties";
            this.cmsProperties.Size = new System.Drawing.Size(61, 4);
            // 
            // AllFilesPropertiesPanel
            // 
            this.AllFilesPropertiesPanel.Caption = "Search for any file";
            this.AllFilesPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("AllFilesPropertiesPanel.CaptionImage")));
            this.AllFilesPropertiesPanel.Controls.Add(this.bProperties);
            this.AllFilesPropertiesPanel.Controls.Add(this.tbQuery);
            this.AllFilesPropertiesPanel.Controls.Add(this.label2);
            this.AllFilesPropertiesPanel.Controls.Add(this.label10);
            this.AllFilesPropertiesPanel.Controls.Add(this.cobAttributes);
            this.AllFilesPropertiesPanel.Controls.Add(this.cbAttributes);
            this.AllFilesPropertiesPanel.Controls.Add(this.cobDate);
            this.AllFilesPropertiesPanel.Controls.Add(this.dtpToInAllFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.cbDateInAllFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.label7);
            this.AllFilesPropertiesPanel.Controls.Add(this.lClearInputFieldsInAllFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.dtpFromInFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.bSearchInAllFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.tbFileNameInAllFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.cobSizeMetricsInFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.tbSizeToInFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.tbSizeFromInFiles);
            this.AllFilesPropertiesPanel.Controls.Add(this.label5);
            this.AllFilesPropertiesPanel.Controls.Add(this.label4);
            this.AllFilesPropertiesPanel.Controls.Add(this.label3);
            this.AllFilesPropertiesPanel.Controls.Add(this.label1);
            this.AllFilesPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllFilesPropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.AllFilesPropertiesPanel.Name = "AllFilesPropertiesPanel";
            this.AllFilesPropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.AllFilesPropertiesPanel.TabIndex = 2;
            // 
            // bProperties
            // 
            this.bProperties.ContextMenuStrip = this.cmsProperties;
            this.bProperties.Image = ((System.Drawing.Image)(resources.GetObject("bProperties.Image")));
            this.bProperties.Location = new System.Drawing.Point(195, 332);
            this.bProperties.Name = "bProperties";
            this.bProperties.Size = new System.Drawing.Size(29, 25);
            this.bProperties.TabIndex = 11;
            this.bProperties.UseVisualStyleBackColor = true;
            this.bProperties.Click += new System.EventHandler(this.bProperties_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbQuery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbQuery.BannerText = "Enter file attributes";
            this.tbQuery.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuery.Location = new System.Drawing.Point(17, 305);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(206, 21);
            this.tbQuery.Submit = this.bSearchInAllFiles;
            this.tbQuery.TabIndex = 10;
            this.tbQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAllFiles_KeyPress);
            // 
            // bSearchInAllFiles
            // 
            this.bSearchInAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSearchInAllFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInAllFiles.BackgroundImage")));
            this.bSearchInAllFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInAllFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.bSearchInAllFiles.FlatAppearance.BorderSize = 0;
            this.bSearchInAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInAllFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInAllFiles.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInAllFiles.Image")));
            this.bSearchInAllFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInAllFiles.Location = new System.Drawing.Point(124, 440);
            this.bSearchInAllFiles.Name = "bSearchInAllFiles";
            this.bSearchInAllFiles.Size = new System.Drawing.Size(100, 32);
            this.bSearchInAllFiles.TabIndex = 12;
            this.bSearchInAllFiles.Text = "Search";
            this.bSearchInAllFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInAllFiles.UseVisualStyleBackColor = true;
            this.bSearchInAllFiles.Click += new System.EventHandler(this.bSearchInAllFiles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Query:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(14, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "--------------------Advanced--------------------";
            // 
            // cobAttributes
            // 
            this.cobAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobAttributes.Enabled = false;
            this.cobAttributes.FormattingEnabled = true;
            this.cobAttributes.Items.AddRange(new object[] {
            "Archive",
            "Compressed",
            "Device",
            "Directory",
            "Encrypted",
            "Hidden",
            "Normal",
            "NotContentIndexed",
            "Offline",
            "Readonly",
            "ReparsePoint",
            "SparseFile",
            "System",
            "Temporary"});
            this.cobAttributes.Location = new System.Drawing.Point(89, 226);
            this.cobAttributes.MaxDropDownItems = 15;
            this.cobAttributes.Name = "cobAttributes";
            this.cobAttributes.Size = new System.Drawing.Size(135, 21);
            this.cobAttributes.TabIndex = 9;
            // 
            // cbAttributes
            // 
            this.cbAttributes.AutoSize = true;
            this.cbAttributes.Location = new System.Drawing.Point(18, 228);
            this.cbAttributes.Name = "cbAttributes";
            this.cbAttributes.Size = new System.Drawing.Size(73, 17);
            this.cbAttributes.TabIndex = 8;
            this.cbAttributes.Text = "&Attribute:";
            this.cbAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAttributes.UseVisualStyleBackColor = true;
            this.cbAttributes.CheckedChanged += new System.EventHandler(this.cbAttributes_CheckedChanged);
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
            this.cobDate.Location = new System.Drawing.Point(46, 153);
            this.cobDate.Name = "cobDate";
            this.cobDate.Size = new System.Drawing.Size(95, 21);
            this.cobDate.TabIndex = 5;
            // 
            // dtpToInAllFiles
            // 
            this.dtpToInAllFiles.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInAllFiles.Enabled = false;
            this.dtpToInAllFiles.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInAllFiles.Location = new System.Drawing.Point(134, 190);
            this.dtpToInAllFiles.Name = "dtpToInAllFiles";
            this.dtpToInAllFiles.Size = new System.Drawing.Size(90, 21);
            this.dtpToInAllFiles.TabIndex = 7;
            // 
            // cbDateInAllFiles
            // 
            this.cbDateInAllFiles.AutoSize = true;
            this.cbDateInAllFiles.Location = new System.Drawing.Point(18, 155);
            this.cbDateInAllFiles.Name = "cbDateInAllFiles";
            this.cbDateInAllFiles.Size = new System.Drawing.Size(160, 17);
            this.cbDateInAllFiles.TabIndex = 4;
            this.cbDateInAllFiles.Text = "                                     &Date";
            this.cbDateInAllFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInAllFiles.UseVisualStyleBackColor = true;
            this.cbDateInAllFiles.CheckedChanged += new System.EventHandler(this.cbCreatedDateInAllFiles_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(113, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "to";
            // 
            // lClearInputFieldsInAllFiles
            // 
            this.lClearInputFieldsInAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lClearInputFieldsInAllFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInAllFiles.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInAllFiles.Image")));
            this.lClearInputFieldsInAllFiles.Location = new System.Drawing.Point(15, 438);
            this.lClearInputFieldsInAllFiles.Name = "lClearInputFieldsInAllFiles";
            this.lClearInputFieldsInAllFiles.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInAllFiles.TabIndex = 13;
            this.lClearInputFieldsInAllFiles.Click += new System.EventHandler(this.lClearInputFieldsInAllFiles_Click);
            // 
            // dtpFromInFiles
            // 
            this.dtpFromInFiles.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInFiles.Enabled = false;
            this.dtpFromInFiles.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInFiles.Location = new System.Drawing.Point(18, 190);
            this.dtpFromInFiles.Name = "dtpFromInFiles";
            this.dtpFromInFiles.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInFiles.TabIndex = 6;
            // 
            // tbFileNameInAllFiles
            // 
            this.tbFileNameInAllFiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileNameInAllFiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileNameInAllFiles.BannerText = "Enter all or part of the file name";
            this.tbFileNameInAllFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameInAllFiles.Location = new System.Drawing.Point(18, 72);
            this.tbFileNameInAllFiles.Name = "tbFileNameInAllFiles";
            this.tbFileNameInAllFiles.Size = new System.Drawing.Size(206, 21);
            this.tbFileNameInAllFiles.Submit = this.bSearchInAllFiles;
            this.tbFileNameInAllFiles.TabIndex = 0;
            this.tbFileNameInAllFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAllFiles_KeyPress);
            // 
            // cobSizeMetricsInFiles
            // 
            this.cobSizeMetricsInFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSizeMetricsInFiles.FormattingEnabled = true;
            this.cobSizeMetricsInFiles.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobSizeMetricsInFiles.Location = new System.Drawing.Point(166, 116);
            this.cobSizeMetricsInFiles.Name = "cobSizeMetricsInFiles";
            this.cobSizeMetricsInFiles.Size = new System.Drawing.Size(58, 21);
            this.cobSizeMetricsInFiles.TabIndex = 3;
            // 
            // tbSizeToInFiles
            // 
            this.tbSizeToInFiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeToInFiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeToInFiles.BannerText = "Maximum";
            this.tbSizeToInFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeToInFiles.Location = new System.Drawing.Point(89, 116);
            this.tbSizeToInFiles.Name = "tbSizeToInFiles";
            this.tbSizeToInFiles.Size = new System.Drawing.Size(52, 21);
            this.tbSizeToInFiles.Submit = this.bSearchInAllFiles;
            this.tbSizeToInFiles.TabIndex = 2;
            this.tbSizeToInFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAllFiles_KeyPress);
            // 
            // tbSizeFromInFiles
            // 
            this.tbSizeFromInFiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeFromInFiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeFromInFiles.BannerText = "Minimum";
            this.tbSizeFromInFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeFromInFiles.Location = new System.Drawing.Point(18, 116);
            this.tbSizeFromInFiles.Name = "tbSizeFromInFiles";
            this.tbSizeFromInFiles.Size = new System.Drawing.Size(52, 21);
            this.tbSizeFromInFiles.Submit = this.bSearchInAllFiles;
            this.tbSizeFromInFiles.TabIndex = 1;
            this.tbSizeFromInFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAllFiles_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(147, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(75, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 98);
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
            // pResultsInAllFiles
            // 
            this.pResultsInAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInAllFiles.Caption = "Results";
            this.pResultsInAllFiles.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInAllFiles.CaptionImage")));
            this.pResultsInAllFiles.Controls.Add(this.bDelete);
            this.pResultsInAllFiles.Controls.Add(this.lPageNumber);
            this.pResultsInAllFiles.Controls.Add(this.LLNextPage);
            this.pResultsInAllFiles.Controls.Add(this.llPrevPage);
            this.pResultsInAllFiles.Controls.Add(this.lvResultsInAllFiles);
            this.pResultsInAllFiles.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInAllFiles.Location = new System.Drawing.Point(245, 5);
            this.pResultsInAllFiles.Name = "pResultsInAllFiles";
            this.pResultsInAllFiles.Size = new System.Drawing.Size(710, 492);
            this.pResultsInAllFiles.TabIndex = 4;
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bDelete.BackgroundImage")));
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
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
            this.lPageNumber.TabIndex = 5;
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
            // lvResultsInAllFiles
            // 
            this.lvResultsInAllFiles.AllowColumnReorder = true;
            this.lvResultsInAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInAllFiles.CheckBoxes = true;
            this.lvResultsInAllFiles.ContextMenuStrip = this.cmsInAllFiles;
            this.lvResultsInAllFiles.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInAllFiles.FullRowSelect = true;
            this.lvResultsInAllFiles.GridLines = true;
            this.lvResultsInAllFiles.Location = new System.Drawing.Point(14, 54);
            this.lvResultsInAllFiles.Name = "lvResultsInAllFiles";
            this.lvResultsInAllFiles.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInAllFiles.TabIndex = 2;
            this.lvResultsInAllFiles.UseCompatibleStateImageBehavior = false;
            this.lvResultsInAllFiles.View = System.Windows.Forms.View.Details;
            // 
            // AllFilesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AllFilesPropertiesPanel);
            this.Controls.Add(this.pResultsInAllFiles);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AllFilesUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.cmsInAllFiles.ResumeLayout(false);
            this.AllFilesPropertiesPanel.ResumeLayout(false);
            this.AllFilesPropertiesPanel.PerformLayout();
            this.pResultsInAllFiles.ResumeLayout(false);
            this.pResultsInAllFiles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel AllFilesPropertiesPanel;
        private System.Windows.Forms.CheckBox cbDateInAllFiles;
        private System.Windows.Forms.Label lClearInputFieldsInAllFiles;
        private GlassButton bSearchInAllFiles;
        private BannerTextBox tbFileNameInAllFiles;
        private System.Windows.Forms.DateTimePicker dtpToInAllFiles;
        private System.Windows.Forms.DateTimePicker dtpFromInFiles;
        private System.Windows.Forms.ComboBox cobSizeMetricsInFiles;
        private NumericTextBox tbSizeToInFiles;
        private NumericTextBox tbSizeFromInFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ResultsPanel pResultsInAllFiles;
        private GlassButton bDelete;
        private System.Windows.Forms.Label lPageNumber;
        private System.Windows.Forms.LinkLabel LLNextPage;
        private System.Windows.Forms.LinkLabel llPrevPage;
        private ListViewEx lvResultsInAllFiles;
        private System.Windows.Forms.ComboBox cobDate;
        private System.Windows.Forms.ComboBox cobAttributes;
        private System.Windows.Forms.CheckBox cbAttributes;
        private System.Windows.Forms.ContextMenuStrip cmsInAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiProperties;
        private BannerTextBox tbQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bProperties;
        private System.Windows.Forms.ContextMenuStrip cmsProperties;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
    }
}
