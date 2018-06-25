namespace ExtendableDesktopSearch
{
    partial class EmailUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailUserControl));
            this.ttInEmail = new System.Windows.Forms.ToolTip(this.components);
            this.lClearInputFieldsInEmails = new System.Windows.Forms.Label();
            this.cmsContextMenuInEmails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiReplyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.EmailPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.cbDateInEmails = new System.Windows.Forms.CheckBox();
            this.bSearchInEmails = new ExtendableDesktopSearch.GlassButton();
            this.tbBodyInEmails = new ExtendableDesktopSearch.BannerTextBox();
            this.tbToAddressInEmails = new ExtendableDesktopSearch.BannerTextBox();
            this.tbFromAddressInEmails = new ExtendableDesktopSearch.BannerTextBox();
            this.tbSubjectInEmails = new ExtendableDesktopSearch.BannerTextBox();
            this.dtpToInEmails = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromInEmails = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pResultsInEmail = new ExtendableDesktopSearch.ResultsPanel();
            this.lPageNumber = new System.Windows.Forms.Label();
            this.LLNextPage = new System.Windows.Forms.LinkLabel();
            this.llPrevPage = new System.Windows.Forms.LinkLabel();
            this.lvResultsInEmail = new ExtendableDesktopSearch.ListViewEx();
            this.cmsContextMenuInEmails.SuspendLayout();
            this.EmailPropertiesPanel.SuspendLayout();
            this.pResultsInEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lClearInputFieldsInEmails
            // 
            this.lClearInputFieldsInEmails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lClearInputFieldsInEmails.Image = ((System.Drawing.Image)(resources.GetObject("lClearInputFieldsInEmails.Image")));
            this.lClearInputFieldsInEmails.Location = new System.Drawing.Point(15, 440);
            this.lClearInputFieldsInEmails.Name = "lClearInputFieldsInEmails";
            this.lClearInputFieldsInEmails.Size = new System.Drawing.Size(43, 33);
            this.lClearInputFieldsInEmails.TabIndex = 8;
            this.ttInEmail.SetToolTip(this.lClearInputFieldsInEmails, "Clear all input fields");
            this.lClearInputFieldsInEmails.Click += new System.EventHandler(this.lClearInputFieldsInEmails_Click);
            // 
            // cmsContextMenuInEmails
            // 
            this.cmsContextMenuInEmails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReplyTo});
            this.cmsContextMenuInEmails.Name = "cmsContextMenuInEmails";
            this.cmsContextMenuInEmails.Size = new System.Drawing.Size(140, 26);
            // 
            // tsmiReplyTo
            // 
            this.tsmiReplyTo.Name = "tsmiReplyTo";
            this.tsmiReplyTo.Size = new System.Drawing.Size(139, 22);
            this.tsmiReplyTo.Text = "Reply To...";
            this.tsmiReplyTo.Click += new System.EventHandler(this.tsmiReplyTo_Click);
            // 
            // EmailPropertiesPanel
            // 
            this.EmailPropertiesPanel.Caption = "Search Inbox";
            this.EmailPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("EmailPropertiesPanel.CaptionImage")));
            this.EmailPropertiesPanel.Controls.Add(this.cbDateInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.lClearInputFieldsInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.bSearchInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.tbBodyInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.tbToAddressInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.tbFromAddressInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.tbSubjectInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.dtpToInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.label4);
            this.EmailPropertiesPanel.Controls.Add(this.dtpFromInEmails);
            this.EmailPropertiesPanel.Controls.Add(this.label3);
            this.EmailPropertiesPanel.Controls.Add(this.label7);
            this.EmailPropertiesPanel.Controls.Add(this.label2);
            this.EmailPropertiesPanel.Controls.Add(this.label1);
            this.EmailPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailPropertiesPanel.Location = new System.Drawing.Point(10, 5);
            this.EmailPropertiesPanel.Name = "EmailPropertiesPanel";
            this.EmailPropertiesPanel.Size = new System.Drawing.Size(243, 490);
            this.EmailPropertiesPanel.TabIndex = 0;
            // 
            // cbDateInEmails
            // 
            this.cbDateInEmails.AutoSize = true;
            this.cbDateInEmails.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDateInEmails.Location = new System.Drawing.Point(19, 255);
            this.cbDateInEmails.Name = "cbDateInEmails";
            this.cbDateInEmails.Size = new System.Drawing.Size(53, 17);
            this.cbDateInEmails.TabIndex = 4;
            this.cbDateInEmails.Text = "&Date:";
            this.cbDateInEmails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDateInEmails.UseVisualStyleBackColor = true;
            this.cbDateInEmails.Visible = false;
            this.cbDateInEmails.CheckedChanged += new System.EventHandler(this.cbDateInEmails_CheckedChanged);
            // 
            // bSearchInEmails
            // 
            this.bSearchInEmails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bSearchInEmails.BackgroundImage")));
            this.bSearchInEmails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSearchInEmails.FlatAppearance.BorderSize = 0;
            this.bSearchInEmails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchInEmails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchInEmails.Image = ((System.Drawing.Image)(resources.GetObject("bSearchInEmails.Image")));
            this.bSearchInEmails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearchInEmails.Location = new System.Drawing.Point(124, 440);
            this.bSearchInEmails.Name = "bSearchInEmails";
            this.bSearchInEmails.Size = new System.Drawing.Size(100, 32);
            this.bSearchInEmails.TabIndex = 7;
            this.bSearchInEmails.Text = "Search";
            this.bSearchInEmails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearchInEmails.UseVisualStyleBackColor = true;
            this.bSearchInEmails.Click += new System.EventHandler(this.bSearchInEmails_Click);
            // 
            // tbBodyInEmails
            // 
            this.tbBodyInEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbBodyInEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbBodyInEmails.BannerText = "Enter a word or phrase of the body";
            this.tbBodyInEmails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBodyInEmails.Location = new System.Drawing.Point(18, 221);
            this.tbBodyInEmails.Name = "tbBodyInEmails";
            this.tbBodyInEmails.Size = new System.Drawing.Size(206, 21);
            this.tbBodyInEmails.Submit = this.bSearchInEmails;
            this.tbBodyInEmails.TabIndex = 3;
            this.tbBodyInEmails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSubjectInEmails_KeyPress);
            // 
            // tbToAddressInEmails
            // 
            this.tbToAddressInEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbToAddressInEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbToAddressInEmails.BannerText = "Enter the to address of the email";
            this.tbToAddressInEmails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbToAddressInEmails.Location = new System.Drawing.Point(18, 169);
            this.tbToAddressInEmails.Name = "tbToAddressInEmails";
            this.tbToAddressInEmails.Size = new System.Drawing.Size(206, 21);
            this.tbToAddressInEmails.Submit = this.bSearchInEmails;
            this.tbToAddressInEmails.TabIndex = 2;
            this.tbToAddressInEmails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSubjectInEmails_KeyPress);
            // 
            // tbFromAddressInEmails
            // 
            this.tbFromAddressInEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFromAddressInEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFromAddressInEmails.BannerText = "Enter the from address of the email";
            this.tbFromAddressInEmails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFromAddressInEmails.Location = new System.Drawing.Point(18, 120);
            this.tbFromAddressInEmails.Name = "tbFromAddressInEmails";
            this.tbFromAddressInEmails.Size = new System.Drawing.Size(206, 21);
            this.tbFromAddressInEmails.Submit = this.bSearchInEmails;
            this.tbFromAddressInEmails.TabIndex = 1;
            this.tbFromAddressInEmails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSubjectInEmails_KeyPress);
            // 
            // tbSubjectInEmails
            // 
            this.tbSubjectInEmails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSubjectInEmails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSubjectInEmails.BannerText = "Enter all or part of the subject of email";
            this.tbSubjectInEmails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubjectInEmails.Location = new System.Drawing.Point(18, 74);
            this.tbSubjectInEmails.Name = "tbSubjectInEmails";
            this.tbSubjectInEmails.Size = new System.Drawing.Size(206, 21);
            this.tbSubjectInEmails.Submit = this.bSearchInEmails;
            this.tbSubjectInEmails.TabIndex = 0;
            this.tbSubjectInEmails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSubjectInEmails_KeyPress);
            // 
            // dtpToInEmails
            // 
            this.dtpToInEmails.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpToInEmails.Enabled = false;
            this.dtpToInEmails.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToInEmails.Location = new System.Drawing.Point(134, 275);
            this.dtpToInEmails.Name = "dtpToInEmails";
            this.dtpToInEmails.Size = new System.Drawing.Size(90, 21);
            this.dtpToInEmails.TabIndex = 6;
            this.dtpToInEmails.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Body:";
            // 
            // dtpFromInEmails
            // 
            this.dtpFromInEmails.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(162)))), ((int)(((byte)(147)))));
            this.dtpFromInEmails.Enabled = false;
            this.dtpFromInEmails.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromInEmails.Location = new System.Drawing.Point(18, 275);
            this.dtpFromInEmails.Name = "dtpFromInEmails";
            this.dtpFromInEmails.Size = new System.Drawing.Size(90, 21);
            this.dtpFromInEmails.TabIndex = 5;
            this.dtpFromInEmails.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&To:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(113, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "to";
            this.label7.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Subject:";
            // 
            // pResultsInEmail
            // 
            this.pResultsInEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultsInEmail.Caption = "Results";
            this.pResultsInEmail.CaptionImage = ((System.Drawing.Image)(resources.GetObject("pResultsInEmail.CaptionImage")));
            this.pResultsInEmail.Controls.Add(this.lPageNumber);
            this.pResultsInEmail.Controls.Add(this.LLNextPage);
            this.pResultsInEmail.Controls.Add(this.llPrevPage);
            this.pResultsInEmail.Controls.Add(this.lvResultsInEmail);
            this.pResultsInEmail.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pResultsInEmail.Location = new System.Drawing.Point(245, 5);
            this.pResultsInEmail.Name = "pResultsInEmail";
            this.pResultsInEmail.Size = new System.Drawing.Size(710, 492);
            this.pResultsInEmail.TabIndex = 2;
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
            // lvResultsInEmail
            // 
            this.lvResultsInEmail.AllowColumnReorder = true;
            this.lvResultsInEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResultsInEmail.CheckBoxes = true;
            this.lvResultsInEmail.ContextMenuStrip = this.cmsContextMenuInEmails;
            this.lvResultsInEmail.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lvResultsInEmail.FullRowSelect = true;
            this.lvResultsInEmail.GridLines = true;
            this.lvResultsInEmail.Location = new System.Drawing.Point(15, 55);
            this.lvResultsInEmail.Name = "lvResultsInEmail";
            this.lvResultsInEmail.Size = new System.Drawing.Size(680, 380);
            this.lvResultsInEmail.TabIndex = 2;
            
            this.lvResultsInEmail.UseCompatibleStateImageBehavior = false;
            this.lvResultsInEmail.View = System.Windows.Forms.View.Details;
            // 
            // EmailUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EmailPropertiesPanel);
            this.Controls.Add(this.pResultsInEmail);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmailUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmailUserControl_MouseDown);
            this.cmsContextMenuInEmails.ResumeLayout(false);
            this.EmailPropertiesPanel.ResumeLayout(false);
            this.EmailPropertiesPanel.PerformLayout();
            this.pResultsInEmail.ResumeLayout(false);
            this.pResultsInEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel EmailPropertiesPanel;
        private BannerTextBox tbSubjectInEmails;
        private System.Windows.Forms.DateTimePicker dtpToInEmails;
        private System.Windows.Forms.DateTimePicker dtpFromInEmails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private BannerTextBox tbToAddressInEmails;
        private BannerTextBox tbFromAddressInEmails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ListViewEx lvResultsInEmail;
        private GlassButton bSearchInEmails;
        private System.Windows.Forms.Label lClearInputFieldsInEmails;
        private System.Windows.Forms.ToolTip ttInEmail;
        private ResultsPanel pResultsInEmail;
        private System.Windows.Forms.CheckBox cbDateInEmails;
        private System.Windows.Forms.LinkLabel LLNextPage;
        private System.Windows.Forms.LinkLabel llPrevPage;
        private System.Windows.Forms.Label lPageNumber;
        private BannerTextBox tbBodyInEmails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenuInEmails;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplyTo;
    }
}
