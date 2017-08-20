namespace CustomShape
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbexit = new System.Windows.Forms.PictureBox();
            this.lTimeLapsed = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lNetStatus = new System.Windows.Forms.Label();
            this.ni1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.il1 = new System.Windows.Forms.ImageList(this.components);
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.tGC = new System.Windows.Forms.Timer(this.components);
            this.timeLaps = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cmsExit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbexit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.cmsExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbexit
            // 
            this.pbexit.BackColor = System.Drawing.Color.Transparent;
            this.pbexit.ErrorImage = null;
            this.pbexit.Image = ((System.Drawing.Image)(resources.GetObject("pbexit.Image")));
            this.pbexit.InitialImage = null;
            this.pbexit.Location = new System.Drawing.Point(156, 102);
            this.pbexit.Name = "pbexit";
            this.pbexit.Size = new System.Drawing.Size(24, 24);
            this.pbexit.TabIndex = 2;
            this.pbexit.TabStop = false;
            this.pbexit.Click += new System.EventHandler(this.pbexit_Click);
            // 
            // lTimeLapsed
            // 
            this.lTimeLapsed.AutoSize = true;
            this.lTimeLapsed.BackColor = System.Drawing.Color.Transparent;
            this.lTimeLapsed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTimeLapsed.ForeColor = System.Drawing.Color.Black;
            this.lTimeLapsed.Location = new System.Drawing.Point(2, 80);
            this.lTimeLapsed.Name = "lTimeLapsed";
            this.lTimeLapsed.Size = new System.Drawing.Size(81, 13);
            this.lTimeLapsed.TabIndex = 4;
            this.lTimeLapsed.Text = "Time Lapsed:";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.BackColor = System.Drawing.Color.Transparent;
            this.lTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.ForeColor = System.Drawing.Color.Black;
            this.lTime.Location = new System.Drawing.Point(2, 52);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(105, 13);
            this.lTime.TabIndex = 4;
            this.lTime.Text = "Event occured at:";
            // 
            // lNetStatus
            // 
            this.lNetStatus.AutoSize = true;
            this.lNetStatus.BackColor = System.Drawing.Color.Transparent;
            this.lNetStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNetStatus.ForeColor = System.Drawing.Color.Black;
            this.lNetStatus.Location = new System.Drawing.Point(2, 27);
            this.lNetStatus.Name = "lNetStatus";
            this.lNetStatus.Size = new System.Drawing.Size(69, 13);
            this.lNetStatus.TabIndex = 4;
            this.lNetStatus.Text = "Net Status:";
            // 
            // ni1
            // 
            this.ni1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ni1.ContextMenuStrip = this.cmsExit;
            this.ni1.Icon = ((System.Drawing.Icon)(resources.GetObject("ni1.Icon")));
            this.ni1.Text = "Internet Monitor";
            this.ni1.Visible = true;
            this.ni1.DoubleClick += new System.EventHandler(this.ni1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Internet Monitor";
            // 
            // il1
            // 
            this.il1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il1.ImageStream")));
            this.il1.TransparentColor = System.Drawing.Color.Transparent;
            this.il1.Images.SetKeyName(0, "99.ico");
            this.il1.Images.SetKeyName(1, "94.ico");
            // 
            // pbClose
            // 
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(164, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(19, 18);
            this.pbClose.TabIndex = 6;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // tGC
            // 
            this.tGC.Enabled = true;
            this.tGC.Interval = 300000;
            this.tGC.Tick += new System.EventHandler(this.tGC_Tick);
            // 
            // timeLaps
            // 
            this.timeLaps.Enabled = true;
            this.timeLaps.Interval = 1000;
            this.timeLaps.Tick += new System.EventHandler(this.timeLaps_Tick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cmsExit
            // 
            this.cmsExit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.cmsExit.Name = "cmsExit";
            this.cmsExit.Size = new System.Drawing.Size(104, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(181, 128);
            this.ControlBox = false;
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lNetStatus);
            this.Controls.Add(this.lTimeLapsed);
            this.Controls.Add(this.pbexit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Internet Monitor";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)(this.pbexit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.cmsExit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbexit;
        private System.Windows.Forms.Label lTimeLapsed;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lNetStatus;
        private System.Windows.Forms.NotifyIcon ni1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList il1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Timer tGC;
        private System.Windows.Forms.Timer timeLaps;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip cmsExit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;




    }
}

