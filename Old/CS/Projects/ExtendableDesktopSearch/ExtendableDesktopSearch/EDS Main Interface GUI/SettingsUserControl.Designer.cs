namespace ExtendableDesktopSearch
{
    partial class SettingsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsUserControl));
            this.resultsPanel1 = new ExtendableDesktopSearch.ResultsPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDisableFSMonitoring = new System.Windows.Forms.CheckBox();
            this.cbDisableFSCrawling = new System.Windows.Forms.CheckBox();
            this.cbEmailIndexing = new System.Windows.Forms.CheckBox();
            this.cbStartup = new System.Windows.Forms.CheckBox();
            this.resultsPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultsPanel1
            // 
            this.resultsPanel1.Caption = "Extendable Desktop Search Settings";
            this.resultsPanel1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("resultsPanel1.CaptionImage")));
            this.resultsPanel1.Controls.Add(this.groupBox1);
            this.resultsPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.resultsPanel1.Location = new System.Drawing.Point(3, 5);
            this.resultsPanel1.Name = "resultsPanel1";
            this.resultsPanel1.Size = new System.Drawing.Size(808, 457);
            this.resultsPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDisableFSMonitoring);
            this.groupBox1.Controls.Add(this.cbDisableFSCrawling);
            this.groupBox1.Controls.Add(this.cbEmailIndexing);
            this.groupBox1.Controls.Add(this.cbStartup);
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // cbDisableFSMonitoring
            // 
            this.cbDisableFSMonitoring.AutoSize = true;
            this.cbDisableFSMonitoring.Location = new System.Drawing.Point(34, 98);
            this.cbDisableFSMonitoring.Name = "cbDisableFSMonitoring";
            this.cbDisableFSMonitoring.Size = new System.Drawing.Size(261, 17);
            this.cbDisableFSMonitoring.TabIndex = 0;
            this.cbDisableFSMonitoring.Text = "Disable automatic file system monitoring (restart)";
            this.cbDisableFSMonitoring.UseVisualStyleBackColor = true;
            // 
            // cbDisableFSCrawling
            // 
            this.cbDisableFSCrawling.AutoSize = true;
            this.cbDisableFSCrawling.Location = new System.Drawing.Point(34, 75);
            this.cbDisableFSCrawling.Name = "cbDisableFSCrawling";
            this.cbDisableFSCrawling.Size = new System.Drawing.Size(250, 17);
            this.cbDisableFSCrawling.TabIndex = 0;
            this.cbDisableFSCrawling.Text = "Disable automatic file system crawling (restart)";
            this.cbDisableFSCrawling.UseVisualStyleBackColor = true;
            // 
            // cbEmailIndexing
            // 
            this.cbEmailIndexing.AutoSize = true;
            this.cbEmailIndexing.Location = new System.Drawing.Point(34, 52);
            this.cbEmailIndexing.Name = "cbEmailIndexing";
            this.cbEmailIndexing.Size = new System.Drawing.Size(128, 17);
            this.cbEmailIndexing.TabIndex = 0;
            this.cbEmailIndexing.Text = "Enable email indexing";
            this.cbEmailIndexing.UseVisualStyleBackColor = true;
            // 
            // cbStartup
            // 
            this.cbStartup.AutoSize = true;
            this.cbStartup.Location = new System.Drawing.Point(34, 29);
            this.cbStartup.Name = "cbStartup";
            this.cbStartup.Size = new System.Drawing.Size(146, 17);
            this.cbStartup.TabIndex = 0;
            this.cbStartup.Text = "Load on windows startup";
            this.cbStartup.UseVisualStyleBackColor = true;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.resultsPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(970, 500);
            this.resultsPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ResultsPanel resultsPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbStartup;
        private System.Windows.Forms.CheckBox cbEmailIndexing;
        private System.Windows.Forms.CheckBox cbDisableFSMonitoring;
        private System.Windows.Forms.CheckBox cbDisableFSCrawling;

    }
}
