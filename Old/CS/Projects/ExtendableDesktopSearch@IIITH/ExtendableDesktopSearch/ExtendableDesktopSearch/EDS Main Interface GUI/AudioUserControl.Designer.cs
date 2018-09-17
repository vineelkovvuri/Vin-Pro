namespace ExtendableDesktopSearch
{
    partial class AudioUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioUserControl));
            this.ttInAudio = new System.Windows.Forms.ToolTip(this.components);
            this.lClearInputFieldsInAudio = new System.Windows.Forms.Label();
            this.cmsInDocuments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.cbDateInAudio = new System.Windows.Forms.CheckBox();
            this.bSearchInAudio = new ExtendableDesktopSearch.GlassButton();
            this.cobLengthMetricsInAudio = new System.Windows.Forms.ComboBox();
            this.tbLengthToInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.tbLengthFromInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbYearInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.tbTrackInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.tbGenreInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.tbCommentInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.tbArtistInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.tbAlbumInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.tbTitleInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.tbFileNameInAudio = new ExtendableDesktopSearch.BannerTextBox();
            this.dtpToInAudio = new System.Windows.Forms.DateTimePicker();
            this.dtpFromInAudio = new System.Windows.Forms.DateTimePicker();
            this.cobSizeMetricsInAudio = new System.Windows.Forms.ComboBox();
            this.tbSizeToInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.tbSizeFromInAudio = new ExtendableDesktopSearch.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInAudio = new ExtendableDesktopSearch.ResultsPanel();
            this.bDelete = new ExtendableDesktopSearch.GlassButton();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInAudio = new ExtendableDesktopSearch.ListViewEx();
            this.cmsInDocuments.SuspendLayout();
            this.AudioPropertiesPanel.SuspendLayout();
            this.pResultsInAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lClearInputFieldsInAudio
            // 
            this.lClearInputFieldsInAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInAudio.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInAudio.Image")));
            this.lClearInputFieldsInAudio.Location = new System.Drawing.Point(15, 440);
            this.lClearInputFieldsInAudio.Name = "lClearInputFieldsInAudio";
            this.lClearInputFieldsInAudio.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInAudio.TabIndex = 19;
            this.ttInAudio.SetToolTip(this.lClearInputFieldsInAudio, "Clear all input fields");
            this.lClearInputFieldsInAudio.Click += new System.EventHandler(this.lClearInputFieldsInAudio_Click);
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
            this.tsmiEditProperties,
            this.tsmiProperties});
            this.cmsInDocuments.Name = "cmslvresult";
            this.cmsInDocuments.Size = new System.Drawing.Size(156, 148);
            // 
            // tsmiOpenFolder
            // 
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenFolder.Text = "Open Folder";
            this.tsmiOpenFolder.Click += new System.EventHandler(this.tsmiOpenFolder_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(155, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiCopyTo
            // 
            this.tsmiCopyTo.Name = "tsmiCopyTo";
            this.tsmiCopyTo.Size = new System.Drawing.Size(155, 22);
            this.tsmiCopyTo.Text = "Copy to";
            this.tsmiCopyTo.Click += new System.EventHandler(this.tsmiCopyTo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmiEditProperties
            // 
            this.tsmiEditProperties.Name = "tsmiEditProperties";
            this.tsmiEditProperties.Size = new System.Drawing.Size(155, 22);
            this.tsmiEditProperties.Text = "Edit Properties";
            this.tsmiEditProperties.Click += new System.EventHandler(this.tsmiEditProperties_Click);
            // 
            // tsmiProperties
            // 
            this.tsmiProperties.Name = "tsmiProperties";
            this.tsmiProperties.Size = new System.Drawing.Size(155, 22);
            this.tsmiProperties.Text = "Properties";
            this.tsmiProperties.Click += new System.EventHandler(this.tsmiProperties_Click);
            // 
            // AudioPropertiesPanel
            // 
            this.AudioPropertiesPanel.Caption = "Search for audio files";
            this.AudioPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("AudioPropertiesPanel.CaptionImage")));
            this.AudioPropertiesPanel.Controls.Add(this.cobDate);
            this.AudioPropertiesPanel.Controls.Add(this.cbDateInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.lClearInputFieldsInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.bSearchInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.cobLengthMetricsInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbLengthToInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbLengthFromInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.label2);
            this.AudioPropertiesPanel.Controls.Add(this.label8);
            this.AudioPropertiesPanel.Controls.Add(this.label10);
            this.AudioPropertiesPanel.Controls.Add(this.label9);
            this.AudioPropertiesPanel.Controls.Add(this.tbYearInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbTrackInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbGenreInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbCommentInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbArtistInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbAlbumInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbTitleInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbFileNameInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.dtpToInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.dtpFromInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.cobSizeMetricsInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbSizeToInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.tbSizeFromInAudio);
            this.AudioPropertiesPanel.Controls.Add(this.label5);
            this.AudioPropertiesPanel.Controls.Add(this.label7);
            this.AudioPropertiesPanel.Controls.Add(this.label4);
            this.AudioPropertiesPanel.Controls.Add(this.label3);
            this.AudioPropertiesPanel.Controls.Add(this.label1);
            this.AudioPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioPropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.AudioPropertiesPanel.Name = "AudioPropertiesPanel";
            this.AudioPropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.AudioPropertiesPanel.TabIndex = 0;
            this.AudioPropertiesPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AudioPropertiesPanel_MouseDown);
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
            // cbDateInAudio
            // 
            this.cbDateInAudio.AutoSize = true;
            this.cbDateInAudio.Location = new System.Drawing.Point(18, 149);
            this.cbDateInAudio.Name = "cbDateInAudio";
            this.cbDateInAudio.Size = new System.Drawing.Size(160, 17);
            this.cbDateInAudio.TabIndex = 4;
            this.cbDateInAudio.Text = "                                     &Date";
            this.cbDateInAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInAudio.UseVisualStyleBackColor = true;
            this.cbDateInAudio.CheckedChanged += new System.EventHandler(this.cbDateInAudio_CheckedChanged);
            // 
            // bSearchInAudio
            // 
            this.bSearchInAudio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInAudio.BackgroundImage")));
            this.bSearchInAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInAudio.FlatAppearance.BorderSize = 0;
            this.bSearchInAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInAudio.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInAudio.Image")));
            this.bSearchInAudio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInAudio.Location = new System.Drawing.Point(124, 440);
            this.bSearchInAudio.Name = "bSearchInAudio";
            this.bSearchInAudio.Size = new System.Drawing.Size(100, 32);
            this.bSearchInAudio.TabIndex = 18;
            this.bSearchInAudio.Text = "Search";
            this.bSearchInAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInAudio.UseVisualStyleBackColor = true;
            this.bSearchInAudio.Click += new System.EventHandler(this.bSearchInAudio_Click);
            // 
            // cobLengthMetricsInAudio
            // 
            this.cobLengthMetricsInAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobLengthMetricsInAudio.FormattingEnabled = true;
            this.cobLengthMetricsInAudio.Items.AddRange(new object[] {
            "Sec",
            "Min",
            "Hour"});
            this.cobLengthMetricsInAudio.Location = new System.Drawing.Point(167, 242);
            this.cobLengthMetricsInAudio.Name = "cobLengthMetricsInAudio";
            this.cobLengthMetricsInAudio.Size = new System.Drawing.Size(58, 21);
            this.cobLengthMetricsInAudio.TabIndex = 10;
            // 
            // tbLengthToInAudio
            // 
            this.tbLengthToInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLengthToInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLengthToInAudio.BannerText = "Maximum";
            this.tbLengthToInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLengthToInAudio.Location = new System.Drawing.Point(90, 242);
            this.tbLengthToInAudio.MaxLength = 2;
            this.tbLengthToInAudio.Name = "tbLengthToInAudio";
            this.tbLengthToInAudio.Size = new System.Drawing.Size(52, 21);
            this.tbLengthToInAudio.Submit = this.bSearchInAudio;
            this.tbLengthToInAudio.TabIndex = 9;
            this.tbLengthToInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbLengthFromInAudio
            // 
            this.tbLengthFromInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLengthFromInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLengthFromInAudio.BannerText = "Minimum";
            this.tbLengthFromInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLengthFromInAudio.Location = new System.Drawing.Point(19, 242);
            this.tbLengthFromInAudio.MaxLength = 2;
            this.tbLengthFromInAudio.Name = "tbLengthFromInAudio";
            this.tbLengthFromInAudio.Size = new System.Drawing.Size(52, 21);
            this.tbLengthFromInAudio.Submit = this.bSearchInAudio;
            this.tbLengthFromInAudio.TabIndex = 8;
            this.tbLengthFromInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "in";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(76, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(15, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "--------------------Advanced--------------------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(16, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "&Duration:";
            // 
            // tbYearInAudio
            // 
            this.tbYearInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbYearInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbYearInAudio.BannerText = "Enter the Year";
            this.tbYearInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYearInAudio.Location = new System.Drawing.Point(124, 401);
            this.tbYearInAudio.MaxLength = 4;
            this.tbYearInAudio.Name = "tbYearInAudio";
            this.tbYearInAudio.Size = new System.Drawing.Size(100, 21);
            this.tbYearInAudio.Submit = this.bSearchInAudio;
            this.tbYearInAudio.TabIndex = 17;
            this.tbYearInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbTrackInAudio
            // 
            this.tbTrackInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTrackInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbTrackInAudio.BannerText = "Enter the Track";
            this.tbTrackInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrackInAudio.Location = new System.Drawing.Point(18, 401);
            this.tbTrackInAudio.Name = "tbTrackInAudio";
            this.tbTrackInAudio.Size = new System.Drawing.Size(100, 21);
            this.tbTrackInAudio.Submit = this.bSearchInAudio;
            this.tbTrackInAudio.TabIndex = 16;
            this.tbTrackInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbGenreInAudio
            // 
            this.tbGenreInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbGenreInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbGenreInAudio.BannerText = "Enter the genre of the audio file";
            this.tbGenreInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGenreInAudio.Location = new System.Drawing.Point(18, 375);
            this.tbGenreInAudio.Name = "tbGenreInAudio";
            this.tbGenreInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbGenreInAudio.Submit = this.bSearchInAudio;
            this.tbGenreInAudio.TabIndex = 15;
            this.tbGenreInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbCommentInAudio
            // 
            this.tbCommentInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbCommentInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCommentInAudio.BannerText = "Enter the comment of the audio file";
            this.tbCommentInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommentInAudio.Location = new System.Drawing.Point(18, 349);
            this.tbCommentInAudio.Name = "tbCommentInAudio";
            this.tbCommentInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbCommentInAudio.Submit = this.bSearchInAudio;
            this.tbCommentInAudio.TabIndex = 14;
            this.tbCommentInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbArtistInAudio
            // 
            this.tbArtistInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbArtistInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbArtistInAudio.BannerText = "Enter the artist of the audio file";
            this.tbArtistInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbArtistInAudio.Location = new System.Drawing.Point(18, 323);
            this.tbArtistInAudio.Name = "tbArtistInAudio";
            this.tbArtistInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbArtistInAudio.Submit = this.bSearchInAudio;
            this.tbArtistInAudio.TabIndex = 13;
            this.tbArtistInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbAlbumInAudio
            // 
            this.tbAlbumInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbAlbumInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbAlbumInAudio.BannerText = "Enter the album of the audio file";
            this.tbAlbumInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlbumInAudio.Location = new System.Drawing.Point(18, 297);
            this.tbAlbumInAudio.Name = "tbAlbumInAudio";
            this.tbAlbumInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbAlbumInAudio.Submit = this.bSearchInAudio;
            this.tbAlbumInAudio.TabIndex = 12;
            this.tbAlbumInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbTitleInAudio
            // 
            this.tbTitleInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitleInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbTitleInAudio.BannerText = "Enter the title of the audio file";
            this.tbTitleInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitleInAudio.Location = new System.Drawing.Point(18, 271);
            this.tbTitleInAudio.Name = "tbTitleInAudio";
            this.tbTitleInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbTitleInAudio.Submit = this.bSearchInAudio;
            this.tbTitleInAudio.TabIndex = 11;
            this.tbTitleInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbFileNameInAudio
            // 
            this.tbFileNameInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFileNameInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFileNameInAudio.BannerText = "Enter all or part of the file name";
            this.tbFileNameInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameInAudio.Location = new System.Drawing.Point(18, 72);
            this.tbFileNameInAudio.Name = "tbFileNameInAudio";
            this.tbFileNameInAudio.Size = new System.Drawing.Size(206, 21);
            this.tbFileNameInAudio.Submit = this.bSearchInAudio;
            this.tbFileNameInAudio.TabIndex = 0;
            this.tbFileNameInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // dtpToInAudio
            // 
            this.dtpToInAudio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInAudio.Enabled = false;
            this.dtpToInAudio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInAudio.Location = new System.Drawing.Point(134, 175);
            this.dtpToInAudio.Name = "dtpToInAudio";
            this.dtpToInAudio.Size = new System.Drawing.Size(90, 21);
            this.dtpToInAudio.TabIndex = 7;
            // 
            // dtpFromInAudio
            // 
            this.dtpFromInAudio.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInAudio.Enabled = false;
            this.dtpFromInAudio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInAudio.Location = new System.Drawing.Point(18, 175);
            this.dtpFromInAudio.Name = "dtpFromInAudio";
            this.dtpFromInAudio.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInAudio.TabIndex = 6;
            // 
            // cobSizeMetricsInAudio
            // 
            this.cobSizeMetricsInAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSizeMetricsInAudio.FormattingEnabled = true;
            this.cobSizeMetricsInAudio.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cobSizeMetricsInAudio.Location = new System.Drawing.Point(166, 116);
            this.cobSizeMetricsInAudio.Name = "cobSizeMetricsInAudio";
            this.cobSizeMetricsInAudio.Size = new System.Drawing.Size(58, 21);
            this.cobSizeMetricsInAudio.TabIndex = 3;
            // 
            // tbSizeToInAudio
            // 
            this.tbSizeToInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeToInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeToInAudio.BannerText = "Maximum";
            this.tbSizeToInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeToInAudio.Location = new System.Drawing.Point(89, 116);
            this.tbSizeToInAudio.Name = "tbSizeToInAudio";
            this.tbSizeToInAudio.Size = new System.Drawing.Size(52, 21);
            this.tbSizeToInAudio.Submit = this.bSearchInAudio;
            this.tbSizeToInAudio.TabIndex = 2;
            this.tbSizeToInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
            // 
            // tbSizeFromInAudio
            // 
            this.tbSizeFromInAudio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSizeFromInAudio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSizeFromInAudio.BannerText = "Minimum";
            this.tbSizeFromInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSizeFromInAudio.Location = new System.Drawing.Point(18, 116);
            this.tbSizeFromInAudio.Name = "tbSizeFromInAudio";
            this.tbSizeFromInAudio.Size = new System.Drawing.Size(52, 21);
            this.tbSizeFromInAudio.Submit = this.bSearchInAudio;
            this.tbSizeFromInAudio.TabIndex = 1;
            this.tbSizeFromInAudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFileNameInAudio_KeyPress);
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
            this.label7.Location = new System.Drawing.Point(113, 179);
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
            // pResultsInAudio
            // 
            this.pResultsInAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInAudio.Caption = "Results";
            this.pResultsInAudio.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInAudio.CaptionImage")));
            this.pResultsInAudio.Controls.Add(this.bDelete);
            this.pResultsInAudio.Controls.Add(this.lPageNumber);
            this.pResultsInAudio.Controls.Add(this.LLNextPage);
            this.pResultsInAudio.Controls.Add(this.llPrevPage);
            this.pResultsInAudio.Controls.Add(this.lvResultsInAudio);
            this.pResultsInAudio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInAudio.Location = new System.Drawing.Point(245, 5);
            this.pResultsInAudio.Name = "pResultsInAudio";
            this.pResultsInAudio.Size = new System.Drawing.Size(710, 492);
            this.pResultsInAudio.TabIndex = 2;
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
            this.bDelete.TabIndex = 23;
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
            this.LLNextPage.TabIndex = 7;
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
            this.llPrevPage.TabIndex = 6;
            this.llPrevPage.TabStop = true;
            this.llPrevPage.Text = "<";
            this.llPrevPage.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(151)))), ((int)(((byte)(135)))));
            this.llPrevPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPrevPage_LinkClicked);
            // 
            // lvResultsInAudio
            // 
            this.lvResultsInAudio.AllowColumnReorder = true;
            this.lvResultsInAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInAudio.CheckBoxes = true;
            this.lvResultsInAudio.ContextMenuStrip = this.cmsInDocuments;
            this.lvResultsInAudio.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInAudio.FullRowSelect = true;
            this.lvResultsInAudio.GridLines = true;
            this.lvResultsInAudio.Location = new System.Drawing.Point(15, 55);
            this.lvResultsInAudio.Name = "lvResultsInAudio";
            this.lvResultsInAudio.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInAudio.TabIndex = 1;
            
            this.lvResultsInAudio.UseCompatibleStateImageBehavior = false;
            this.lvResultsInAudio.View = System.Windows.Forms.View.Details;
            // 
            // AudioUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AudioPropertiesPanel);
            this.Controls.Add(this.pResultsInAudio);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AudioUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.cmsInDocuments.ResumeLayout(false);
            this.AudioPropertiesPanel.ResumeLayout(false);
            this.AudioPropertiesPanel.PerformLayout();
            this.pResultsInAudio.ResumeLayout(false);
            this.pResultsInAudio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel AudioPropertiesPanel;
        private BannerTextBox tbFileNameInAudio;
        private System.Windows.Forms.DateTimePicker dtpToInAudio;
        private System.Windows.Forms.DateTimePicker dtpFromInAudio;
        private System.Windows.Forms.ComboBox cobSizeMetricsInAudio;
        private NumericTextBox tbSizeToInAudio;
        private NumericTextBox tbSizeFromInAudio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private BannerTextBox tbCommentInAudio;
        private BannerTextBox tbArtistInAudio;
        private BannerTextBox tbAlbumInAudio;
        private BannerTextBox tbTitleInAudio;
        private BannerTextBox tbGenreInAudio;
        private NumericTextBox tbYearInAudio;
        private NumericTextBox tbTrackInAudio;
        private System.Windows.Forms.ComboBox cobLengthMetricsInAudio;
        private NumericTextBox tbLengthToInAudio;
        private NumericTextBox tbLengthFromInAudio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ListViewEx lvResultsInAudio;
        private GlassButton bSearchInAudio;
        private System.Windows.Forms.Label lClearInputFieldsInAudio;
        private System.Windows.Forms.ToolTip ttInAudio;
        private ResultsPanel pResultsInAudio;
        private System.Windows.Forms.CheckBox cbDateInAudio;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiEditProperties;
        private System.Windows.Forms.ToolStripMenuItem tsmiProperties;
        private System.Windows.Forms.ComboBox cobDate;
    }
}
