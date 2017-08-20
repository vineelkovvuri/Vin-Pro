namespace TempForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbDirectories = new System.Windows.Forms.ListBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.lvResults = new System.Windows.Forms.ListView();
            this.chPath = new System.Windows.Forms.ColumnHeader();
            this.lvResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lFileProcessing = new System.Windows.Forms.Label();
            this.lvResultsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directories to search for duplicate files:";
            // 
            // lbDirectories
            // 
            this.lbDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDirectories.FormattingEnabled = true;
            this.lbDirectories.Location = new System.Drawing.Point(11, 28);
            this.lbDirectories.Name = "lbDirectories";
            this.lbDirectories.Size = new System.Drawing.Size(339, 108);
            this.lbDirectories.TabIndex = 1;
            this.lbDirectories.SelectedIndexChanged += new System.EventHandler(this.lbDirectories_SelectedIndexChanged);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdd.Location = new System.Drawing.Point(370, 49);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(65, 22);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bRemove
            // 
            this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemove.Enabled = false;
            this.bRemove.Location = new System.Drawing.Point(370, 87);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(65, 22);
            this.bRemove.TabIndex = 2;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStart.Location = new System.Drawing.Point(486, 67);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 4;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lvResults
            // 
            this.lvResults.AllowColumnReorder = true;
            this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath});
            this.lvResults.ContextMenuStrip = this.lvResultsContextMenu;
            this.lvResults.FullRowSelect = true;
            this.lvResults.Location = new System.Drawing.Point(12, 155);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(620, 213);
            this.lvResults.TabIndex = 5;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 603;
            // 
            // lvResultsContextMenu
            // 
            this.lvResultsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiOpenFolder,
            this.tsmiDelete});
            this.lvResultsContextMenu.Name = "lvResultsContextMenu";
            this.lvResultsContextMenu.Size = new System.Drawing.Size(145, 70);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(144, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiOpenFolder
            // 
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(144, 22);
            this.tsmiOpenFolder.Text = "Open Folder";
            this.tsmiOpenFolder.Click += new System.EventHandler(this.tsmiOpenFolder_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(144, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(11, 392);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(621, 12);
            this.pbProgress.TabIndex = 6;
            // 
            // lFileProcessing
            // 
            this.lFileProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lFileProcessing.AutoSize = true;
            this.lFileProcessing.Location = new System.Drawing.Point(9, 374);
            this.lFileProcessing.Name = "lFileProcessing";
            this.lFileProcessing.Size = new System.Drawing.Size(0, 13);
            this.lFileProcessing.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 408);
            this.Controls.Add(this.lFileProcessing);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lbDirectories);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicate File Remover";
            this.lvResultsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDirectories;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lFileProcessing;
        private System.Windows.Forms.ContextMenuStrip lvResultsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;

    }
}

