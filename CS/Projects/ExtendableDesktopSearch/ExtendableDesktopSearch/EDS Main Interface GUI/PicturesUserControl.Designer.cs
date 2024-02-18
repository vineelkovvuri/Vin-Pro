namespace ExtendableDesktopSearch
{
    partial class PicturesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicturesUserControl));
            this.ttInPictures = new System.Windows.Forms.ToolTip(this.components);
            this.lClearInputFieldsInPictures = new System.Windows.Forms.Label();
            this.cmsInDocuments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.PicturePropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDateInPictures = new System.Windows.Forms.CheckBox();
            this.bSearchInPicture = new ExtendableDesktopSearch.GlassButton();
            this.tbHeightInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.tbVResInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.tbHresInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.tbWidthInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFileNameInPictures = new ExtendableDesktopSearch.BannerTextBox();
            this.dtpToInPictures = new System.Windows.Forms.DateTimePicker();
            this.dtpFromInPictures = new System.Windows.Forms.DateTimePicker();
            this.cobSizeMetricsInPictures = new System.Windows.Forms.ComboBox();
            this.tbSizeToInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.tbSizeFromInPictures = new ExtendableDesktopSearch.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInPicture = new ExtendableDesktopSearch.ResultsPanel();
            this.bDelete = new ExtendableDesktopSearch.GlassButton();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInPicture = new ExtendableDesktopSearch.ListViewEx();
            this.cmsInDocuments.SuspendLayout();
            this.PicturePropertiesPanel.SuspendLayout();
            this.pResultsInPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // lClearInputFieldsInPictures
            // 
            this.lClearInputFieldsInPictures.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInPictures.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInPictures.Image")));
            this.lClearInputFieldsInPictures.Location = new System.Drawing.Point(15, 440);
            this.lClearInputFieldsInPictures.Name = "lClearInputFieldsInPictures";
            this.lClearInputFieldsInPictures.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInPictures.TabIndex = 13;
            this.ttInPictures.SetToolTip(this.lClearInputFieldsInPictures, "Clear all input fields");
            this.lClearInputFieldsInPictures.Click += new System.EventHandler(this.lClearInputFieldsInPictures_Click);
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
            // PicturePropertiesPanel
            // 
            this.PicturePropertiesPanel.Caption = "Search for pictures";
            this.PicturePropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("PicturePropertiesPanel.CaptionImage")));
            this.PicturePropertiesPanel.Controls.Add(this.cobDate);
            this.PicturePropertiesPanel.Controls.Add(this.label10);
            this.PicturePropertiesPanel.Controls.Add(this.cbDateInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.lClearInputFieldsInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.bSearchInPicture);
            this.PicturePropertiesPanel.Controls.Add(this.tbHeightInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.tbVResInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.tbHresInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.tbWidthInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.label11);
            this.PicturePropertiesPanel.Controls.Add(this.label2);
            this.PicturePropertiesPanel.Controls.Add(this.label8);
            this.PicturePropertiesPanel.Controls.Add(this.label6);
            this.PicturePropertiesPanel.Controls.Add(this.label9);
            this.PicturePropertiesPanel.Controls.Add(this.tbFileNameInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.dtpToInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.dtpFromInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.cobSizeMetricsInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.tbSizeToInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.tbSizeFromInPictures);
            this.PicturePropertiesPanel.Controls.Add(this.label5);
            this.PicturePropertiesPanel.Controls.Add(this.label7);
            this.PicturePropertiesPanel.Controls.Add(this.label4);
            this.PicturePropertiesPanel.Controls.Add(this.label3);
            this.PicturePropertiesPanel.Controls.Add(this.label1);
            this.PicturePropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PicturePropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.PicturePropertiesPanel.Name = "PicturePropertiesPanel";
            this.PicturePropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.PicturePropertiesPanel.TabIndex = 1;
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
            this.cobDate.Location = new System.Drawing.Point(42, 145);
            this.cobDate.Name = "cobDate";
            this.cobDate.Size = new System.Drawing.Size(95, 21);
            this.cobDate.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(15, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "--------------------Advanced--------------------";
            // 
            // cbDateInPictures
            // 
            this.cbDateInPictures.AutoSize = true;
            this.cbDateInPictures.Location = new System.Drawing.Point(18, 147);
            this.cbDateInPictures.Name = "cbDateInPictures";
            this.cbDateInPictures.Size = new System.Drawing.Size(160, 17);
            this.cbDateInPictures.TabIndex = 4;
            this.cbDateInPictures.Text = "                                     &Date";
            this.cbDateInPictures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInPictures.UseVisualStyleBackColor = true;
            this.cbDateInPictures.CheckedChanged += new System.EventHandler(this.cbDateInPictures_CheckedChanged);
            // 
            // bSearchInPicture
            // 
            this.bSearchInPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInPicture.BackgroundImage")));
            this.bSearchInPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInPicture.FlatAppearance.BorderSize = 0;
            this.bSearchInPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInPicture.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInPicture.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInPicture.Image")));
            this.bSearchInPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInPicture.Location = new System.Drawing.Point(124, 440);
            this.bSearchInPicture.Name = "bSearchInPicture";
            this.bSearchInPicture.Size = new System.Drawing.Size(100, 32);
            this.bSearchInPicture.TabIndex = 12;
            this.bSearchInPicture.Text = "Search";
            this.bSearchInPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInPicture.UseVisualStyleBackColor = true;
            this.bSearchInPicture.Click += new System.EventHandler(this.bSearchInPicture_Click);
            // 
            // tbHeightInPictures
            // 
            this.tbHeightInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbHeightInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbHeightInPictures.BannerText = "Height";
            this.tbHeightInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeightInPictures.Location = new System.Drawing.Point(110, 248);
            this.tbHeightInPictures.Name = "tbHeightInPictures";
            this.tbHeightInPictures.Size = new System.Drawing.Size(70, 21);
            this.tbHeightInPictures.Submit = this.bSearchInPicture;
            this.tbHeightInPictures.TabIndex = 9;
            this.tbHeightInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // tbVResInPictures
            // 
            this.tbVResInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbVResInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbVResInPictures.BannerText = "Vertical";
            this.tbVResInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVResInPictures.Location = new System.Drawing.Point(110, 297);
            this.tbVResInPictures.Name = "tbVResInPictures";
            this.tbVResInPictures.Size = new System.Drawing.Size(70, 21);
            this.tbVResInPictures.Submit = this.bSearchInPicture;
            this.tbVResInPictures.TabIndex = 11;
            this.tbVResInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // tbHresInPictures
            // 
            this.tbHresInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbHresInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbHresInPictures.BannerText = "Horizontal";
            this.tbHresInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHresInPictures.Location = new System.Drawing.Point(18, 297);
            this.tbHresInPictures.Name = "tbHresInPictures";
            this.tbHresInPictures.Size = new System.Drawing.Size(70, 21);
            this.tbHresInPictures.Submit = this.bSearchInPicture;
            this.tbHresInPictures.TabIndex = 10;
            this.tbHresInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // tbWidthInPictures
            // 
            this.tbWidthInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbWidthInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbWidthInPictures.BannerText = "Width";
            this.tbWidthInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWidthInPictures.Location = new System.Drawing.Point(18, 248);
            this.tbWidthInPictures.Name = "tbWidthInPictures";
            this.tbWidthInPictures.Size = new System.Drawing.Size(70, 21);
            this.tbWidthInPictures.Submit = this.bSearchInPicture;
            this.tbWidthInPictures.TabIndex = 8;
            this.tbWidthInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(186, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "dpi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(186, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "px";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(93, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "&Resolution:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(15, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Di&mension:";
            // 
            // tbFileNameInPictures
            // 
            this.tbFileNameInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileNameInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileNameInPictures.BannerText = "Enter all or part of the file name";
            this.tbFileNameInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameInPictures.Location = new System.Drawing.Point(18, 72);
            this.tbFileNameInPictures.Name = "tbFileNameInPictures";
            this.tbFileNameInPictures.Size = new System.Drawing.Size(206, 21);
            this.tbFileNameInPictures.Submit = this.bSearchInPicture;
            this.tbFileNameInPictures.TabIndex = 0;
            this.tbFileNameInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // dtpToInPictures
            // 
            this.dtpToInPictures.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInPictures.Enabled = false;
            this.dtpToInPictures.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInPictures.Location = new System.Drawing.Point(134, 176);
            this.dtpToInPictures.Name = "dtpToInPictures";
            this.dtpToInPictures.Size = new System.Drawing.Size(90, 21);
            this.dtpToInPictures.TabIndex = 7;
            // 
            // dtpFromInPictures
            // 
            this.dtpFromInPictures.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInPictures.Enabled = false;
            this.dtpFromInPictures.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInPictures.Location = new System.Drawing.Point(18, 176);
            this.dtpFromInPictures.Name = "dtpFromInPictures";
            this.dtpFromInPictures.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInPictures.TabIndex = 6;
            // 
            // cobSizeMetricsInPictures
            // 
            this.cobSizeMetricsInPictures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSizeMetricsInPictures.FormattingEnabled = true;
            this.cobSizeMetricsInPictures.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobSizeMetricsInPictures.Location = new System.Drawing.Point(166, 115);
            this.cobSizeMetricsInPictures.Name = "cobSizeMetricsInPictures";
            this.cobSizeMetricsInPictures.Size = new System.Drawing.Size(58, 21);
            this.cobSizeMetricsInPictures.TabIndex = 3;
            // 
            // tbSizeToInPictures
            // 
            this.tbSizeToInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeToInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeToInPictures.BannerText = "Maximum";
            this.tbSizeToInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeToInPictures.Location = new System.Drawing.Point(89, 115);
            this.tbSizeToInPictures.Name = "tbSizeToInPictures";
            this.tbSizeToInPictures.Size = new System.Drawing.Size(52, 21);
            this.tbSizeToInPictures.Submit = this.bSearchInPicture;
            this.tbSizeToInPictures.TabIndex = 2;
            this.tbSizeToInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
            // 
            // tbSizeFromInPictures
            // 
            this.tbSizeFromInPictures.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeFromInPictures.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeFromInPictures.BannerText = "Minimum";
            this.tbSizeFromInPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeFromInPictures.Location = new System.Drawing.Point(18, 115);
            this.tbSizeFromInPictures.Name = "tbSizeFromInPictures";
            this.tbSizeFromInPictures.Size = new System.Drawing.Size(52, 21);
            this.tbSizeFromInPictures.Submit = this.bSearchInPicture;
            this.tbSizeFromInPictures.TabIndex = 1;
            this.tbSizeFromInPictures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInPictures_KeyPress);
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
            // pResultsInPicture
            // 
            this.pResultsInPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInPicture.Caption = "Results";
            this.pResultsInPicture.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInPicture.CaptionImage")));
            this.pResultsInPicture.Controls.Add(this.bDelete);
            this.pResultsInPicture.Controls.Add(this.lPageNumber);
            this.pResultsInPicture.Controls.Add(this.LLNextPage);
            this.pResultsInPicture.Controls.Add(this.llPrevPage);
            this.pResultsInPicture.Controls.Add(this.lvResultsInPicture);
            this.pResultsInPicture.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInPicture.Location = new System.Drawing.Point(245, 5);
            this.pResultsInPicture.Name = "pResultsInPicture";
            this.pResultsInPicture.Size = new System.Drawing.Size(710, 492);
            this.pResultsInPicture.TabIndex = 3;
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
            this.lPageNumber.TabIndex = 7;
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
            // lvResultsInPicture
            // 
            this.lvResultsInPicture.AllowColumnReorder = true;
            this.lvResultsInPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInPicture.CheckBoxes = true;
            this.lvResultsInPicture.ContextMenuStrip = this.cmsInDocuments;
            this.lvResultsInPicture.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInPicture.FullRowSelect = true;
            this.lvResultsInPicture.GridLines = true;
            this.lvResultsInPicture.Location = new System.Drawing.Point(15, 55);
            this.lvResultsInPicture.Name = "lvResultsInPicture";
            this.lvResultsInPicture.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInPicture.TabIndex = 2;
            
            this.lvResultsInPicture.UseCompatibleStateImageBehavior = false;
            this.lvResultsInPicture.View = System.Windows.Forms.View.Details;
            // 
            // PicturesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PicturePropertiesPanel);
            this.Controls.Add(this.pResultsInPicture);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PicturesUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicturesUserControl_MouseDown);
            this.cmsInDocuments.ResumeLayout(false);
            this.PicturePropertiesPanel.ResumeLayout(false);
            this.PicturePropertiesPanel.PerformLayout();
            this.pResultsInPicture.ResumeLayout(false);
            this.pResultsInPicture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel PicturePropertiesPanel;
        private NumericTextBox tbHeightInPictures;
        private NumericTextBox tbWidthInPictures;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private BannerTextBox tbFileNameInPictures;
        private System.Windows.Forms.DateTimePicker dtpToInPictures;
        private System.Windows.Forms.DateTimePicker dtpFromInPictures;
        private System.Windows.Forms.ComboBox cobSizeMetricsInPictures;
        private NumericTextBox tbSizeToInPictures;
        private NumericTextBox tbSizeFromInPictures;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ListViewEx lvResultsInPicture;
        private GlassButton bSearchInPicture;
        private System.Windows.Forms.Label lClearInputFieldsInPictures;
        private System.Windows.Forms.ToolTip ttInPictures;
        private ResultsPanel pResultsInPicture;
        private System.Windows.Forms.CheckBox cbDateInPictures;
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
        private NumericTextBox tbVResInPictures;
        private NumericTextBox tbHresInPictures;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cobDate;
    }
}
