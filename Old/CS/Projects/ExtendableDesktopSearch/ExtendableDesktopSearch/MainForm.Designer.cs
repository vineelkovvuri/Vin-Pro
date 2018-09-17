namespace ExtendableDesktopSearch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pMainButtonPanel = new System.Windows.Forms.Panel();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslDocCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSearchingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lIndexingStatus = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.popupButton1 = new ExtendableDesktopSearch.PopupButton();
            this.pbPictures = new ExtendableDesktopSearch.PopupButton();
            this.pbVideo = new ExtendableDesktopSearch.PopupButton();
            this.pbAudio = new ExtendableDesktopSearch.PopupButton();
            this.pbAllFiles = new ExtendableDesktopSearch.PopupButton();
            this.pbDocuments = new ExtendableDesktopSearch.PopupButton();
            this.tbFilterResults = new ExtendableDesktopSearch.BannerTextBox();
            this.pMainButtonPanel.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            this.cmsTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMainButtonPanel
            // 
            this.pMainButtonPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pMainButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.pMainButtonPanel.Controls.Add(this.popupButton1);
            this.pMainButtonPanel.Controls.Add(this.pbPictures);
            this.pMainButtonPanel.Controls.Add(this.pbVideo);
            this.pMainButtonPanel.Controls.Add(this.pbAudio);
            this.pMainButtonPanel.Controls.Add(this.pbAllFiles);
            this.pMainButtonPanel.Controls.Add(this.pbDocuments);
            this.pMainButtonPanel.Location = new System.Drawing.Point(200, 0);
            this.pMainButtonPanel.Name = "pMainButtonPanel";
            this.pMainButtonPanel.Size = new System.Drawing.Size(535, 88);
            this.pMainButtonPanel.TabIndex = 3;
            // 
            // ssStatusStrip
            // 
            this.ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslDocCount,
            this.tsslSearchingStatus});
            this.ssStatusStrip.Location = new System.Drawing.Point(0, 606);
            this.ssStatusStrip.Name = "ssStatusStrip";
            this.ssStatusStrip.Size = new System.Drawing.Size(972, 25);
            this.ssStatusStrip.SizingGrip = false;
            this.ssStatusStrip.TabIndex = 4;
            this.ssStatusStrip.Text = "statusStrip1";
            // 
            // tsslDocCount
            // 
            this.tsslDocCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslDocCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslDocCount.Name = "tsslDocCount";
            this.tsslDocCount.Size = new System.Drawing.Size(104, 20);
            this.tsslDocCount.Text = "documents indexed";
            // 
            // tsslSearchingStatus
            // 
            this.tsslSearchingStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslSearchingStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslSearchingStatus.Image = global::ExtendableDesktopSearch.Properties.Resources.loading;
            this.tsslSearchingStatus.Name = "tsslSearchingStatus";
            this.tsslSearchingStatus.Size = new System.Drawing.Size(20, 20);
            // 
            // lIndexingStatus
            // 
            this.lIndexingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lIndexingStatus.AutoSize = true;
            this.lIndexingStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lIndexingStatus.Location = new System.Drawing.Point(196, 612);
            this.lIndexingStatus.Name = "lIndexingStatus";
            this.lIndexingStatus.Size = new System.Drawing.Size(56, 13);
            this.lIndexingStatus.TabIndex = 5;
            this.lIndexingStatus.Text = "Indexing: ";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsTrayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.cmsTrayMenu.Name = "cmsTrayMenu";
            this.cmsTrayMenu.Size = new System.Drawing.Size(112, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(111, 22);
            this.tsmiShow.Text = "Show";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(111, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // popupButton1
            // 
            this.popupButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.popupButton1.AutoEllipsis = true;
            this.popupButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.popupButton1.FlatAppearance.BorderSize = 0;
            this.popupButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.popupButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.popupButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.popupButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.popupButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.popupButton1.Image = ((System.Drawing.Image)(resources.GetObject("popupButton1.Image")));
            this.popupButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.popupButton1.Location = new System.Drawing.Point(349, 12);
            this.popupButton1.Name = "popupButton1";
            this.popupButton1.Size = new System.Drawing.Size(80, 62);
            this.popupButton1.TabIndex = 5;
            this.popupButton1.Text = "Emails";
            this.popupButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.popupButton1.UseVisualStyleBackColor = true;
            this.popupButton1.CheckedChanged += new System.EventHandler(this.pbEmails_CheckedChanged);
            // 
            // pbPictures
            // 
            this.pbPictures.Appearance = System.Windows.Forms.Appearance.Button;
            this.pbPictures.AutoEllipsis = true;
            this.pbPictures.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPictures.FlatAppearance.BorderSize = 0;
            this.pbPictures.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.pbPictures.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.pbPictures.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pbPictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pbPictures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pbPictures.Image = ((System.Drawing.Image)(resources.GetObject("pbPictures.Image")));
            this.pbPictures.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pbPictures.Location = new System.Drawing.Point(268, 12);
            this.pbPictures.Name = "pbPictures";
            this.pbPictures.Size = new System.Drawing.Size(80, 62);
            this.pbPictures.TabIndex = 4;
            this.pbPictures.Text = "Pictures";
            this.pbPictures.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pbPictures.UseVisualStyleBackColor = true;
            this.pbPictures.CheckedChanged += new System.EventHandler(this.pbPictures_CheckedChanged);
            // 
            // pbVideo
            // 
            this.pbVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.pbVideo.AutoEllipsis = true;
            this.pbVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVideo.FlatAppearance.BorderSize = 0;
            this.pbVideo.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.pbVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.pbVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pbVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pbVideo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pbVideo.Image = ((System.Drawing.Image)(resources.GetObject("pbVideo.Image")));
            this.pbVideo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pbVideo.Location = new System.Drawing.Point(187, 12);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(80, 62);
            this.pbVideo.TabIndex = 3;
            this.pbVideo.Text = "Video";
            this.pbVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pbVideo.UseVisualStyleBackColor = true;
            this.pbVideo.CheckedChanged += new System.EventHandler(this.pbVideo_CheckedChanged);
            // 
            // pbAudio
            // 
            this.pbAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.pbAudio.AutoEllipsis = true;
            this.pbAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAudio.FlatAppearance.BorderSize = 0;
            this.pbAudio.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.pbAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.pbAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pbAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pbAudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pbAudio.Image = ((System.Drawing.Image)(resources.GetObject("pbAudio.Image")));
            this.pbAudio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pbAudio.Location = new System.Drawing.Point(106, 12);
            this.pbAudio.Name = "pbAudio";
            this.pbAudio.Size = new System.Drawing.Size(80, 62);
            this.pbAudio.TabIndex = 2;
            this.pbAudio.Text = "Audio";
            this.pbAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pbAudio.UseVisualStyleBackColor = true;
            this.pbAudio.CheckedChanged += new System.EventHandler(this.pbAudio_CheckedChanged);
            // 
            // pbAllFiles
            // 
            this.pbAllFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.pbAllFiles.AutoEllipsis = true;
            this.pbAllFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAllFiles.FlatAppearance.BorderSize = 0;
            this.pbAllFiles.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.pbAllFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.pbAllFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pbAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pbAllFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pbAllFiles.Image = ((System.Drawing.Image)(resources.GetObject("pbAllFiles.Image")));
            this.pbAllFiles.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pbAllFiles.Location = new System.Drawing.Point(430, 12);
            this.pbAllFiles.Name = "pbAllFiles";
            this.pbAllFiles.Size = new System.Drawing.Size(80, 62);
            this.pbAllFiles.TabIndex = 0;
            this.pbAllFiles.Text = "Others";
            this.pbAllFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pbAllFiles.UseVisualStyleBackColor = true;
            this.pbAllFiles.CheckedChanged += new System.EventHandler(this.pbAllFiles_CheckedChanged);
            // 
            // pbDocuments
            // 
            this.pbDocuments.Appearance = System.Windows.Forms.Appearance.Button;
            this.pbDocuments.AutoEllipsis = true;
            this.pbDocuments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDocuments.FlatAppearance.BorderSize = 0;
            this.pbDocuments.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.pbDocuments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(219)))));
            this.pbDocuments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.pbDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pbDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pbDocuments.Image = ((System.Drawing.Image)(resources.GetObject("pbDocuments.Image")));
            this.pbDocuments.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pbDocuments.Location = new System.Drawing.Point(25, 12);
            this.pbDocuments.Name = "pbDocuments";
            this.pbDocuments.Size = new System.Drawing.Size(80, 62);
            this.pbDocuments.TabIndex = 1;
            this.pbDocuments.Text = "Documents";
            this.pbDocuments.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pbDocuments.UseVisualStyleBackColor = true;
            this.pbDocuments.CheckedChanged += new System.EventHandler(this.pbDocuments_CheckedChanged);
            // 
            // tbFilterResults
            // 
            this.tbFilterResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilterResults.BannerText = "Filter Results";
            this.tbFilterResults.Location = new System.Drawing.Point(840, 67);
            this.tbFilterResults.Name = "tbFilterResults";
            this.tbFilterResults.Size = new System.Drawing.Size(100, 21);
            this.tbFilterResults.Submit = null;
            this.tbFilterResults.TabIndex = 3;
            this.tbFilterResults.TextChanged += new System.EventHandler(this.tbFilterResults_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(972, 631);
            this.Controls.Add(this.lIndexingStatus);
            this.Controls.Add(this.pMainButtonPanel);
            this.Controls.Add(this.tbFilterResults);
            this.Controls.Add(this.ssStatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 660);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extendable Desktop Search";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pMainButtonPanel.ResumeLayout(false);
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            this.cmsTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pMainButtonPanel;
        private PopupButton pbPictures;
        private PopupButton pbVideo;
        private PopupButton pbAudio;
        private PopupButton pbDocuments;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslDocCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslSearchingStatus;
        private System.Windows.Forms.Label lIndexingStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private BannerTextBox tbFilterResults;
        private PopupButton popupButton1;
        private PopupButton pbAllFiles;








    }
}

