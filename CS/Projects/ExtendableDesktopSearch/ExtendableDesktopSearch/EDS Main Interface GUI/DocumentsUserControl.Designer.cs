namespace ExtendableDesktopSearch
{
    partial class DocumentsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentsUserControl));
            this.ttInDocuments = new System.Windows.Forms.ToolTip(this.components);
            this.lClearInputFieldsInDocument = new System.Windows.Forms.Label();
            this.cmsInDocuments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDateInDocuments = new System.Windows.Forms.CheckBox();
            this.bSearchInDocuments = new ExtendableDesktopSearch.GlassButton();
            this.tbVersionInDocuments = new ExtendableDesktopSearch.BannerTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDescriptionInDocuments = new ExtendableDesktopSearch.BannerTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFileCompanyNameInDocuments = new ExtendableDesktopSearch.BannerTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFileContentInDocuments = new ExtendableDesktopSearch.BannerTextBox();
            this.tbFileNameInDocuments = new ExtendableDesktopSearch.BannerTextBox();
            this.dtpToInDocuments = new System.Windows.Forms.DateTimePicker();
            this.dtpFromInDocuments = new System.Windows.Forms.DateTimePicker();
            this.cobSizeMetricsInDocuments = new System.Windows.Forms.ComboBox();
            this.tbSizeToInDocuments = new ExtendableDesktopSearch.NumericTextBox();
            this.tbSizeFromInDocuments = new ExtendableDesktopSearch.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInDocuments = new ExtendableDesktopSearch.ResultsPanel();
            this.bDelete = new ExtendableDesktopSearch.GlassButton();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInDocuments = new ExtendableDesktopSearch.ListViewEx();
            this.cmsInDocuments.SuspendLayout();
            this.DocumentPropertiesPanel.SuspendLayout();
            this.pResultsInDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lClearInputFieldsInDocument
            // 
            this.lClearInputFieldsInDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lClearInputFieldsInDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInDocument.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInDocument.Image")));
            this.lClearInputFieldsInDocument.Location = new System.Drawing.Point(15, 440);
            this.lClearInputFieldsInDocument.Name = "lClearInputFieldsInDocument";
            this.lClearInputFieldsInDocument.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInDocument.TabIndex = 13;
            this.ttInDocuments.SetToolTip(this.lClearInputFieldsInDocument, "Clear all input fields");
            this.lClearInputFieldsInDocument.Click += new System.EventHandler(this.lClearInputFieldsInDocument_Click);
            // 
            // cmsInDocuments
            // 
            this.cmsInDocuments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFolder,
            this.tsmiOpen,
            this.tsmiEdit,
            this.toolStripSeparator1,
            this.tsmiDelete,
            this.tsmiCopyTo,
            this.toolStripSeparator2,
            this.tsmiProperties});
            this.cmsInDocuments.Name = "cmslvresult";
            this.cmsInDocuments.Size = new System.Drawing.Size(145, 148);
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
            // DocumentPropertiesPanel
            // 
            this.DocumentPropertiesPanel.Caption = "Search for documents";
            this.DocumentPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("DocumentPropertiesPanel.CaptionImage")));
            this.DocumentPropertiesPanel.Controls.Add(this.cobDate);
            this.DocumentPropertiesPanel.Controls.Add(this.label10);
            this.DocumentPropertiesPanel.Controls.Add(this.cbDateInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.lClearInputFieldsInDocument);
            this.DocumentPropertiesPanel.Controls.Add(this.bSearchInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.tbVersionInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.label8);
            this.DocumentPropertiesPanel.Controls.Add(this.tbDescriptionInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.label6);
            this.DocumentPropertiesPanel.Controls.Add(this.tbFileCompanyNameInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.label9);
            this.DocumentPropertiesPanel.Controls.Add(this.tbFileContentInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.tbFileNameInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.dtpToInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.dtpFromInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.cobSizeMetricsInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.tbSizeToInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.tbSizeFromInDocuments);
            this.DocumentPropertiesPanel.Controls.Add(this.label5);
            this.DocumentPropertiesPanel.Controls.Add(this.label7);
            this.DocumentPropertiesPanel.Controls.Add(this.label4);
            this.DocumentPropertiesPanel.Controls.Add(this.label3);
            this.DocumentPropertiesPanel.Controls.Add(this.label2);
            this.DocumentPropertiesPanel.Controls.Add(this.label1);
            this.DocumentPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentPropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.DocumentPropertiesPanel.Name = "DocumentPropertiesPanel";
            this.DocumentPropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.DocumentPropertiesPanel.TabIndex = 1;
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
            this.label10.Location = new System.Drawing.Point(16, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "--------------------Advanced--------------------";
            // 
            // cbDateInDocuments
            // 
            this.cbDateInDocuments.AutoSize = true;
            this.cbDateInDocuments.Location = new System.Drawing.Point(18, 147);
            this.cbDateInDocuments.Name = "cbDateInDocuments";
            this.cbDateInDocuments.Size = new System.Drawing.Size(160, 17);
            this.cbDateInDocuments.TabIndex = 4;
            this.cbDateInDocuments.Text = "                                     &Date";
            this.cbDateInDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInDocuments.UseVisualStyleBackColor = true;
            this.cbDateInDocuments.CheckedChanged += new System.EventHandler(this.cbDateInDocuments_CheckedChanged);
            // 
            // bSearchInDocuments
            // 
            this.bSearchInDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSearchInDocuments.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInDocuments.BackgroundImage")));
            this.bSearchInDocuments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInDocuments.FlatAppearance.BorderSize = 0;
            this.bSearchInDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInDocuments.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInDocuments.Image")));
            this.bSearchInDocuments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInDocuments.Location = new System.Drawing.Point(124, 440);
            this.bSearchInDocuments.Name = "bSearchInDocuments";
            this.bSearchInDocuments.Size = new System.Drawing.Size(100, 32);
            this.bSearchInDocuments.TabIndex = 12;
            this.bSearchInDocuments.Text = "Search";
            this.bSearchInDocuments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInDocuments.UseVisualStyleBackColor = true;
            this.bSearchInDocuments.Click += new System.EventHandler(this.bSearchInDocuments_Click);
            // 
            // tbVersionInDocuments
            // 
            this.tbVersionInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbVersionInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbVersionInDocuments.BannerText = "Enter the version of the file";
            this.tbVersionInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionInDocuments.Location = new System.Drawing.Point(18, 381);
            this.tbVersionInDocuments.Name = "tbVersionInDocuments";
            this.tbVersionInDocuments.Size = new System.Drawing.Size(206, 21);
            this.tbVersionInDocuments.Submit = this.bSearchInDocuments;
            this.tbVersionInDocuments.TabIndex = 11;
            this.tbVersionInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(15, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "File &Version:";
            // 
            // tbDescriptionInDocuments
            // 
            this.tbDescriptionInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbDescriptionInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDescriptionInDocuments.BannerText = "Enter a phrase of file\'s description";
            this.tbDescriptionInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescriptionInDocuments.Location = new System.Drawing.Point(18, 337);
            this.tbDescriptionInDocuments.Name = "tbDescriptionInDocuments";
            this.tbDescriptionInDocuments.Size = new System.Drawing.Size(206, 21);
            this.tbDescriptionInDocuments.Submit = this.bSearchInDocuments;
            this.tbDescriptionInDocuments.TabIndex = 10;
            this.tbDescriptionInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "File &Description:";
            // 
            // tbFileCompanyNameInDocuments
            // 
            this.tbFileCompanyNameInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileCompanyNameInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileCompanyNameInDocuments.BannerText = "Enter the company name of the file";
            this.tbFileCompanyNameInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileCompanyNameInDocuments.Location = new System.Drawing.Point(18, 291);
            this.tbFileCompanyNameInDocuments.Name = "tbFileCompanyNameInDocuments";
            this.tbFileCompanyNameInDocuments.Size = new System.Drawing.Size(206, 21);
            this.tbFileCompanyNameInDocuments.Submit = this.bSearchInDocuments;
            this.tbFileCompanyNameInDocuments.TabIndex = 9;
            this.tbFileCompanyNameInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(15, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Co&mpany:";
            // 
            // tbFileContentInDocuments
            // 
            this.tbFileContentInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileContentInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileContentInDocuments.BannerText = "Enter a word  or phrase in the file";
            this.tbFileContentInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileContentInDocuments.Location = new System.Drawing.Point(18, 247);
            this.tbFileContentInDocuments.Name = "tbFileContentInDocuments";
            this.tbFileContentInDocuments.Size = new System.Drawing.Size(206, 21);
            this.tbFileContentInDocuments.Submit = this.bSearchInDocuments;
            this.tbFileContentInDocuments.TabIndex = 8;
            this.tbFileContentInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // tbFileNameInDocuments
            // 
            this.tbFileNameInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileNameInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileNameInDocuments.BannerText = "Enter all or part of the file name";
            this.tbFileNameInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameInDocuments.Location = new System.Drawing.Point(18, 72);
            this.tbFileNameInDocuments.Name = "tbFileNameInDocuments";
            this.tbFileNameInDocuments.Size = new System.Drawing.Size(206, 21);
            this.tbFileNameInDocuments.Submit = this.bSearchInDocuments;
            this.tbFileNameInDocuments.TabIndex = 0;
            this.tbFileNameInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // dtpToInDocuments
            // 
            this.dtpToInDocuments.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInDocuments.Enabled = false;
            this.dtpToInDocuments.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInDocuments.Location = new System.Drawing.Point(134, 180);
            this.dtpToInDocuments.Name = "dtpToInDocuments";
            this.dtpToInDocuments.Size = new System.Drawing.Size(90, 21);
            this.dtpToInDocuments.TabIndex = 7;
            // 
            // dtpFromInDocuments
            // 
            this.dtpFromInDocuments.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInDocuments.Enabled = false;
            this.dtpFromInDocuments.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInDocuments.Location = new System.Drawing.Point(18, 180);
            this.dtpFromInDocuments.Name = "dtpFromInDocuments";
            this.dtpFromInDocuments.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInDocuments.TabIndex = 6;
            // 
            // cobSizeMetricsInDocuments
            // 
            this.cobSizeMetricsInDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSizeMetricsInDocuments.FormattingEnabled = true;
            this.cobSizeMetricsInDocuments.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobSizeMetricsInDocuments.Location = new System.Drawing.Point(166, 116);
            this.cobSizeMetricsInDocuments.Name = "cobSizeMetricsInDocuments";
            this.cobSizeMetricsInDocuments.Size = new System.Drawing.Size(58, 21);
            this.cobSizeMetricsInDocuments.TabIndex = 3;
            // 
            // tbSizeToInDocuments
            // 
            this.tbSizeToInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeToInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeToInDocuments.BannerText = "Maximum";
            this.tbSizeToInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeToInDocuments.Location = new System.Drawing.Point(89, 116);
            this.tbSizeToInDocuments.Name = "tbSizeToInDocuments";
            this.tbSizeToInDocuments.Size = new System.Drawing.Size(52, 21);
            this.tbSizeToInDocuments.Submit = this.bSearchInDocuments;
            this.tbSizeToInDocuments.TabIndex = 2;
            this.tbSizeToInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
            // 
            // tbSizeFromInDocuments
            // 
            this.tbSizeFromInDocuments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeFromInDocuments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeFromInDocuments.BannerText = "Minimum";
            this.tbSizeFromInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeFromInDocuments.Location = new System.Drawing.Point(18, 116);
            this.tbSizeFromInDocuments.Name = "tbSizeFromInDocuments";
            this.tbSizeFromInDocuments.Size = new System.Drawing.Size(52, 21);
            this.tbSizeFromInDocuments.Submit = this.bSearchInDocuments;
            this.tbSizeFromInDocuments.TabIndex = 1;
            this.tbSizeFromInDocuments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInDocuments_KeyPress);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(113, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "to";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File &Content:";
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
            // pResultsInDocuments
            // 
            this.pResultsInDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInDocuments.Caption = "Results";
            this.pResultsInDocuments.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInDocuments.CaptionImage")));
            this.pResultsInDocuments.Controls.Add(this.bDelete);
            this.pResultsInDocuments.Controls.Add(this.lPageNumber);
            this.pResultsInDocuments.Controls.Add(this.LLNextPage);
            this.pResultsInDocuments.Controls.Add(this.llPrevPage);
            this.pResultsInDocuments.Controls.Add(this.lvResultsInDocuments);
            this.pResultsInDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInDocuments.Location = new System.Drawing.Point(245, 5);
            this.pResultsInDocuments.Name = "pResultsInDocuments";
            this.pResultsInDocuments.Size = new System.Drawing.Size(710, 492);
            this.pResultsInDocuments.TabIndex = 3;
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
            // lvResultsInDocuments
            // 
            this.lvResultsInDocuments.AllowColumnReorder = true;
            this.lvResultsInDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInDocuments.CheckBoxes = true;
            this.lvResultsInDocuments.ContextMenuStrip = this.cmsInDocuments;
            this.lvResultsInDocuments.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInDocuments.FullRowSelect = true;
            this.lvResultsInDocuments.GridLines = true;
            this.lvResultsInDocuments.Location = new System.Drawing.Point(14, 54);
            this.lvResultsInDocuments.Name = "lvResultsInDocuments";
            this.lvResultsInDocuments.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInDocuments.TabIndex = 2;
            
            this.lvResultsInDocuments.UseCompatibleStateImageBehavior = false;
            this.lvResultsInDocuments.View = System.Windows.Forms.View.Details;
            // 
            // DocumentsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DocumentPropertiesPanel);
            this.Controls.Add(this.pResultsInDocuments);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DocumentsUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DocumentsUserControl_MouseDown);
            this.cmsInDocuments.ResumeLayout(false);
            this.DocumentPropertiesPanel.ResumeLayout(false);
            this.DocumentPropertiesPanel.PerformLayout();
            this.pResultsInDocuments.ResumeLayout(false);
            this.pResultsInDocuments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel DocumentPropertiesPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BannerTextBox tbFileContentInDocuments;
        private BannerTextBox tbFileNameInDocuments;
        private System.Windows.Forms.DateTimePicker dtpToInDocuments;
        private System.Windows.Forms.DateTimePicker dtpFromInDocuments;
        private System.Windows.Forms.ComboBox cobSizeMetricsInDocuments;
        private NumericTextBox tbSizeToInDocuments;
        private NumericTextBox tbSizeFromInDocuments;
        private BannerTextBox tbFileCompanyNameInDocuments;
        private System.Windows.Forms.Label label9;
        private ListViewEx lvResultsInDocuments;
        private GlassButton bSearchInDocuments;
        private System.Windows.Forms.ToolTip ttInDocuments;
        private System.Windows.Forms.Label lClearInputFieldsInDocument;
        private ResultsPanel pResultsInDocuments;
        private System.Windows.Forms.CheckBox cbDateInDocuments;
        private System.Windows.Forms.LinkLabel llPrevPage;
        private System.Windows.Forms.LinkLabel LLNextPage;
        private System.Windows.Forms.Label lPageNumber;
        private System.Windows.Forms.ContextMenuStrip cmsInDocuments;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiProperties;
        private GlassButton bDelete;
        private System.Windows.Forms.Label label10;
        private BannerTextBox tbVersionInDocuments;
        private System.Windows.Forms.Label label8;
        private BannerTextBox tbDescriptionInDocuments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cobDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
    }
}
