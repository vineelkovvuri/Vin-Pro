namespace Search_2006
{
    partial class Rename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rename));
            this.label1 = new System.Windows.Forms.Label();
            this.tbnewfile = new System.Windows.Forms.TextBox();
            this.bok = new System.Windows.Forms.Button();
            this.bcancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New File Name:";
            // 
            // tbnewfile
            // 
            this.tbnewfile.Location = new System.Drawing.Point(115, 23);
            this.tbnewfile.Name = "tbnewfile";
            this.tbnewfile.Size = new System.Drawing.Size(194, 20);
            this.tbnewfile.TabIndex = 1;
            // 
            // bok
            // 
            this.bok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bok.Location = new System.Drawing.Point(153, 72);
            this.bok.Name = "bok";
            this.bok.Size = new System.Drawing.Size(75, 23);
            this.bok.TabIndex = 2;
            this.bok.Text = "&OK";
            this.bok.UseVisualStyleBackColor = true;
            this.bok.Click += new System.EventHandler(this.bok_Click);
            // 
            // bcancel
            // 
            this.bcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bcancel.Location = new System.Drawing.Point(234, 72);
            this.bcancel.Name = "bcancel";
            this.bcancel.Size = new System.Drawing.Size(75, 23);
            this.bcancel.TabIndex = 3;
            this.bcancel.Text = "&Cancel";
            this.bcancel.UseVisualStyleBackColor = true;
            // 
            // Rename
            // 
            this.AcceptButton = this.bok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.bcancel;
            this.ClientSize = new System.Drawing.Size(354, 107);
            this.Controls.Add(this.bcancel);
            this.Controls.Add(this.bok);
            this.Controls.Add(this.tbnewfile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rename";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbnewfile;
        private System.Windows.Forms.Button bok;
        private System.Windows.Forms.Button bcancel;
    }
}