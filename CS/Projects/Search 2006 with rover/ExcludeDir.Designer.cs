namespace Search_2006
{
    partial class ExcludeDir
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcludeDir));
            this.lbexcludedir = new System.Windows.Forms.ListBox();
            this.bremove = new System.Windows.Forms.Button();
            this.bok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.badd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbexcludedir
            // 
            this.lbexcludedir.FormattingEnabled = true;
            this.lbexcludedir.HorizontalScrollbar = true;
            this.lbexcludedir.Location = new System.Drawing.Point(24, 47);
            this.lbexcludedir.Name = "lbexcludedir";
            this.lbexcludedir.ScrollAlwaysVisible = true;
            this.lbexcludedir.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbexcludedir.Size = new System.Drawing.Size(291, 147);
            this.lbexcludedir.TabIndex = 0;
            // 
            // bremove
            // 
            this.bremove.Location = new System.Drawing.Point(336, 82);
            this.bremove.Name = "bremove";
            this.bremove.Size = new System.Drawing.Size(75, 23);
            this.bremove.TabIndex = 2;
            this.bremove.Text = "&Remove";
            this.bremove.UseVisualStyleBackColor = true;
            this.bremove.Click += new System.EventHandler(this.bremove_Click);
            // 
            // bok
            // 
            this.bok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bok.Location = new System.Drawing.Point(336, 171);
            this.bok.Name = "bok";
            this.bok.Size = new System.Drawing.Size(75, 23);
            this.bok.TabIndex = 3;
            this.bok.Text = "&OK";
            this.bok.UseVisualStyleBackColor = true;
            this.bok.Click += new System.EventHandler(this.bok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Following directories are excluded from searching:";
            // 
            // badd
            // 
            this.badd.Location = new System.Drawing.Point(336, 53);
            this.badd.Name = "badd";
            this.badd.Size = new System.Drawing.Size(75, 23);
            this.badd.TabIndex = 1;
            this.badd.Text = "&Add";
            this.badd.UseVisualStyleBackColor = true;
            this.badd.Click += new System.EventHandler(this.badd_Click);
            // 
            // ExcludeDir
            // 
            this.AcceptButton = this.bok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(452, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bok);
            this.Controls.Add(this.bremove);
            this.Controls.Add(this.badd);
            this.Controls.Add(this.lbexcludedir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcludeDir";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add directories to exclude them in searching";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button badd;
        private System.Windows.Forms.Button bremove;
        private System.Windows.Forms.Button bok;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox lbexcludedir;
    }
}