namespace ExtendableDesktopSearch
{
    partial class AudioTagEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioTagEditor));
            this.Mp3TagEditorPropertiesPanel = new ExtendableDesktopSearch.PropertiesPanel();
            this.bCancel = new ExtendableDesktopSearch.GlassButton();
            this.bOk = new ExtendableDesktopSearch.GlassButton();
            this.tbTrack = new ExtendableDesktopSearch.NumericTextBox();
            this.tbYear = new ExtendableDesktopSearch.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAlbum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Mp3TagEditorPropertiesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mp3TagEditorPropertiesPanel
            // 
            this.Mp3TagEditorPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Mp3TagEditorPropertiesPanel.BackColor = System.Drawing.Color.Transparent;
            this.Mp3TagEditorPropertiesPanel.Caption = "Audio File Tag Editor";
            this.Mp3TagEditorPropertiesPanel.CaptionImage = ((System.Drawing.Image)(resources.GetObject("Mp3TagEditorPropertiesPanel.CaptionImage")));
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.bCancel);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.bOk);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbTrack);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbYear);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label7);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbGenre);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label6);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label5);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbComment);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label4);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbAlbum);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label3);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbArtist);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label2);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.tbTitle);
            this.Mp3TagEditorPropertiesPanel.Controls.Add(this.label1);
            this.Mp3TagEditorPropertiesPanel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Mp3TagEditorPropertiesPanel.Location = new System.Drawing.Point(11, 17);
            this.Mp3TagEditorPropertiesPanel.Name = "Mp3TagEditorPropertiesPanel";
            this.Mp3TagEditorPropertiesPanel.Size = new System.Drawing.Size(336, 288);
            this.Mp3TagEditorPropertiesPanel.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bCancel.BackgroundImage")));
            this.bCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.Location = new System.Drawing.Point(222, 234);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(80, 30);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOk
            // 
            this.bOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bOk.BackgroundImage")));
            this.bOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOk.Location = new System.Drawing.Point(87, 234);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(80, 30);
            this.bOk.TabIndex = 3;
            this.bOk.Text = "Ok";
            this.bOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // tbTrack
            // 
            this.tbTrack.BannerText = null;
            this.tbTrack.Location = new System.Drawing.Point(222, 197);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Size = new System.Drawing.Size(81, 21);
            this.tbTrack.TabIndex = 2;
            // 
            // tbYear
            // 
            this.tbYear.BannerText = null;
            this.tbYear.Location = new System.Drawing.Point(87, 196);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(81, 21);
            this.tbYear.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Track:";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(87, 169);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(216, 21);
            this.tbGenre.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Year:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Genre:";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(87, 142);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(216, 21);
            this.tbComment.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comment:";
            // 
            // tbAlbum
            // 
            this.tbAlbum.Location = new System.Drawing.Point(87, 115);
            this.tbAlbum.Name = "tbAlbum";
            this.tbAlbum.Size = new System.Drawing.Size(216, 21);
            this.tbAlbum.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Album:";
            // 
            // tbArtist
            // 
            this.tbArtist.Location = new System.Drawing.Point(87, 88);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(216, 21);
            this.tbArtist.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artist:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(87, 61);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(216, 21);
            this.tbTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // AudioTagEditor
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ExtendableDesktopSearch.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(359, 323);
            this.Controls.Add(this.Mp3TagEditorPropertiesPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AudioTagEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MP3 Tag Editor";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mp3TagEditor_MouseDown);
            this.Mp3TagEditorPropertiesPanel.ResumeLayout(false);
            this.Mp3TagEditorPropertiesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesPanel Mp3TagEditorPropertiesPanel;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAlbum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private NumericTextBox tbTrack;
        private NumericTextBox tbYear;
        private System.Windows.Forms.Label label7;
        private GlassButton bOk;
        private GlassButton bCancel;
    }
}