using System.Drawing;


namespace ImageFormatConverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Panel();
            this.ico = new System.Windows.Forms.CheckBox();
            this.wmf = new System.Windows.Forms.CheckBox();
            this.emf = new System.Windows.Forms.CheckBox();
            this.png = new System.Windows.Forms.CheckBox();
            this.bmp = new System.Windows.Forms.CheckBox();
            this.tif = new System.Windows.Forms.CheckBox();
            this.jpeg = new System.Windows.Forms.CheckBox();
            this.gif = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.vineel = new System.Windows.Forms.NotifyIcon(this.components);
            this.exit = new System.Windows.Forms.Button();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(226, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get The &Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(101, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Browse For Image Files:";
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.Transparent;
            this.p1.Controls.Add(this.ico);
            this.p1.Controls.Add(this.wmf);
            this.p1.Controls.Add(this.emf);
            this.p1.Controls.Add(this.png);
            this.p1.Controls.Add(this.bmp);
            this.p1.Controls.Add(this.tif);
            this.p1.Controls.Add(this.jpeg);
            this.p1.Controls.Add(this.gif);
            this.p1.Location = new System.Drawing.Point(125, 96);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(102, 195);
            this.p1.TabIndex = 2;
            // 
            // ico
            // 
            this.ico.AutoSize = true;
            this.ico.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ico.Location = new System.Drawing.Point(31, 170);
            this.ico.Name = "ico";
            this.ico.Size = new System.Drawing.Size(39, 17);
            this.ico.TabIndex = 7;
            this.ico.Text = "&Ico";
            this.ico.UseVisualStyleBackColor = true;
            // 
            // wmf
            // 
            this.wmf.AutoSize = true;
            this.wmf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wmf.Location = new System.Drawing.Point(31, 147);
            this.wmf.Name = "wmf";
            this.wmf.Size = new System.Drawing.Size(46, 17);
            this.wmf.TabIndex = 6;
            this.wmf.Text = "&Wmf";
            this.wmf.UseVisualStyleBackColor = true;
            // 
            // emf
            // 
            this.emf.AutoSize = true;
            this.emf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.emf.Location = new System.Drawing.Point(31, 124);
            this.emf.Name = "emf";
            this.emf.Size = new System.Drawing.Size(42, 17);
            this.emf.TabIndex = 5;
            this.emf.Text = "&Emf";
            this.emf.UseVisualStyleBackColor = true;
            // 
            // png
            // 
            this.png.AutoSize = true;
            this.png.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.png.Location = new System.Drawing.Point(31, 101);
            this.png.Name = "png";
            this.png.Size = new System.Drawing.Size(43, 17);
            this.png.TabIndex = 4;
            this.png.Text = "&Png";
            this.png.UseVisualStyleBackColor = true;
            // 
            // bmp
            // 
            this.bmp.AutoSize = true;
            this.bmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bmp.Location = new System.Drawing.Point(31, 78);
            this.bmp.Name = "bmp";
            this.bmp.Size = new System.Drawing.Size(45, 17);
            this.bmp.TabIndex = 3;
            this.bmp.Text = "&Bmp";
            this.bmp.UseVisualStyleBackColor = true;
            // 
            // tif
            // 
            this.tif.AutoSize = true;
            this.tif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tif.Location = new System.Drawing.Point(31, 55);
            this.tif.Name = "tif";
            this.tif.Size = new System.Drawing.Size(39, 17);
            this.tif.TabIndex = 2;
            this.tif.Text = "&Tiff";
            this.tif.UseVisualStyleBackColor = true;
            // 
            // jpeg
            // 
            this.jpeg.AutoSize = true;
            this.jpeg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jpeg.Location = new System.Drawing.Point(30, 9);
            this.jpeg.Name = "jpeg";
            this.jpeg.Size = new System.Drawing.Size(47, 17);
            this.jpeg.TabIndex = 0;
            this.jpeg.Text = "&Jpeg";
            this.jpeg.UseVisualStyleBackColor = true;
            // 
            // gif
            // 
            this.gif.AutoSize = true;
            this.gif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gif.Location = new System.Drawing.Point(31, 32);
            this.gif.Name = "gif";
            this.gif.Size = new System.Drawing.Size(37, 17);
            this.gif.TabIndex = 1;
            this.gif.Text = "&Gif";
            this.gif.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.BackColor = System.Drawing.Color.Transparent;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start.Location = new System.Drawing.Point(226, 148);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(95, 23);
            this.start.TabIndex = 5;
            this.start.Text = "&Start Conversion";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(70, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To The Format:";
            // 
            // vineel
            // 
            this.vineel.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.vineel.BalloonTipText = " ImageConverter 1.0  Program is Coded By Vineel";
            this.vineel.Icon = ((System.Drawing.Icon)(resources.GetObject("vineel.Icon")));
            this.vineel.Text = "Vineel";
            this.vineel.Visible = true;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Location = new System.Drawing.Point(433, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "&Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(520, 328);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.start);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageFormat Converter 1.0 It\'s  For GVPITG From Vineel";
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.CheckBox jpeg;
        private System.Windows.Forms.CheckBox wmf;
        private System.Windows.Forms.CheckBox emf;
        private System.Windows.Forms.CheckBox png;
        private System.Windows.Forms.CheckBox bmp;
        private System.Windows.Forms.CheckBox tif;
        private System.Windows.Forms.CheckBox gif;
        private System.Windows.Forms.CheckBox ico;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon vineel;
        private System.Windows.Forms.Button exit;
    }
}

