namespace Open
{
    partial class Add
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
            if ( disposing && ( components != null ) ) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Add ) );
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.bFile = new System.Windows.Forms.Button();
            this.bFolder = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.ttAdd = new System.Windows.Forms.ToolTip( this.components );
            this.bExtra = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider( this.components );
            this.cmsExtraBrowse = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.tsmiMyComputer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNetworkPlaces = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNetworkConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecycleBin = new System.Windows.Forms.ToolStripMenuItem();
            this.bHelp = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.ep ) ).BeginInit();
            this.cmsExtraBrowse.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 40 , 24 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 38 , 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "&Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 40 , 60 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 32 , 13 );
            this.label2.TabIndex = 0;
            this.label2.Text = "&Path:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point( 84 , 21 );
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size( 236 , 20 );
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler( this.tbName_TextChanged );
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point( 84 , 58 );
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size( 236 , 20 );
            this.tbPath.TabIndex = 1;
            this.tbPath.TextChanged += new System.EventHandler( this.tbPath_TextChanged );
            // 
            // bFile
            // 
            this.bFile.BackColor = System.Drawing.SystemColors.Control;
            this.bFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bFile.Font = new System.Drawing.Font( "Lucida Sans Unicode" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.bFile.Location = new System.Drawing.Point( 327 , 57 );
            this.bFile.Name = "bFile";
            this.bFile.Size = new System.Drawing.Size( 28 , 23 );
            this.bFile.TabIndex = 4;
            this.bFile.Text = "F";
            this.ttAdd.SetToolTip( this.bFile , "Opens file browser dialog to select a file." );
            this.bFile.UseVisualStyleBackColor = false;
            this.bFile.Click += new System.EventHandler( this.bFile_Click );
            // 
            // bFolder
            // 
            this.bFolder.BackColor = System.Drawing.SystemColors.Control;
            this.bFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bFolder.Font = new System.Drawing.Font( "Lucida Sans Unicode" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.bFolder.Location = new System.Drawing.Point( 359 , 57 );
            this.bFolder.Name = "bFolder";
            this.bFolder.Size = new System.Drawing.Size( 28 , 23 );
            this.bFolder.TabIndex = 5;
            this.bFolder.Text = "D";
            this.ttAdd.SetToolTip( this.bFolder , "Opens folder browser dialog to select a folder." );
            this.bFolder.UseVisualStyleBackColor = false;
            this.bFolder.Click += new System.EventHandler( this.bFolder_Click );
            // 
            // bOK
            // 
            this.bOK.Enabled = false;
            this.bOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bOK.Location = new System.Drawing.Point( 114 , 97 );
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size( 75 , 23 );
            this.bOK.TabIndex = 2;
            this.bOK.Text = "&Ok";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler( this.bOK_Click );
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCancel.Location = new System.Drawing.Point( 226 , 97 );
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size( 75 , 23 );
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler( this.bCancel_Click );
            // 
            // bExtra
            // 
            this.bExtra.BackColor = System.Drawing.SystemColors.Control;
            this.bExtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bExtra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExtra.Font = new System.Drawing.Font( "Lucida Sans Unicode" , 9.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.bExtra.Location = new System.Drawing.Point( 391 , 57 );
            this.bExtra.Name = "bExtra";
            this.bExtra.Size = new System.Drawing.Size( 30 , 23 );
            this.bExtra.TabIndex = 6;
            this.bExtra.Text = ">>";
            this.ttAdd.SetToolTip( this.bExtra , "Gives path to system namespaces" );
            this.bExtra.UseVisualStyleBackColor = false;
            this.bExtra.Click += new System.EventHandler( this.bExtra_Click );
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            this.ep.Icon = ( (System.Drawing.Icon)( resources.GetObject( "ep.Icon" ) ) );
            // 
            // cmsExtraBrowse
            // 
            this.cmsExtraBrowse.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMyComputer,
            this.tsmiNetworkPlaces,
            this.tsmiNetworkConnections,
            this.tsmiControlPanel,
            this.tsmiRecycleBin} );
            this.cmsExtraBrowse.Name = "cmsExtraBrowse";
            this.cmsExtraBrowse.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsExtraBrowse.Size = new System.Drawing.Size( 188 , 114 );
            // 
            // tsmiMyComputer
            // 
            this.tsmiMyComputer.Image = ( (System.Drawing.Image)( resources.GetObject( "tsmiMyComputer.Image" ) ) );
            this.tsmiMyComputer.Name = "tsmiMyComputer";
            this.tsmiMyComputer.Size = new System.Drawing.Size( 187 , 22 );
            this.tsmiMyComputer.Text = "My Computer";
            this.tsmiMyComputer.Click += new System.EventHandler( this.tsmiMyComputer_Click );
            // 
            // tsmiNetworkPlaces
            // 
            this.tsmiNetworkPlaces.Image = ( (System.Drawing.Image)( resources.GetObject( "tsmiNetworkPlaces.Image" ) ) );
            this.tsmiNetworkPlaces.Name = "tsmiNetworkPlaces";
            this.tsmiNetworkPlaces.Size = new System.Drawing.Size( 187 , 22 );
            this.tsmiNetworkPlaces.Text = "Network Places";
            this.tsmiNetworkPlaces.Click += new System.EventHandler( this.tsmiNetworkPlaces_Click );
            // 
            // tsmiNetworkConnections
            // 
            this.tsmiNetworkConnections.Image = ( (System.Drawing.Image)( resources.GetObject( "tsmiNetworkConnections.Image" ) ) );
            this.tsmiNetworkConnections.Name = "tsmiNetworkConnections";
            this.tsmiNetworkConnections.Size = new System.Drawing.Size( 187 , 22 );
            this.tsmiNetworkConnections.Text = "Network Connections";
            this.tsmiNetworkConnections.Click += new System.EventHandler( this.tsmiNetworkConnections_Click );
            // 
            // tsmiControlPanel
            // 
            this.tsmiControlPanel.Image = ( (System.Drawing.Image)( resources.GetObject( "tsmiControlPanel.Image" ) ) );
            this.tsmiControlPanel.Name = "tsmiControlPanel";
            this.tsmiControlPanel.Size = new System.Drawing.Size( 187 , 22 );
            this.tsmiControlPanel.Text = "Control Panel";
            this.tsmiControlPanel.Click += new System.EventHandler( this.tsmiControlPanel_Click );
            // 
            // tsmiRecycleBin
            // 
            this.tsmiRecycleBin.Image = ( (System.Drawing.Image)( resources.GetObject( "tsmiRecycleBin.Image" ) ) );
            this.tsmiRecycleBin.Name = "tsmiRecycleBin";
            this.tsmiRecycleBin.Size = new System.Drawing.Size( 187 , 22 );
            this.tsmiRecycleBin.Text = "Recycle Bin";
            this.tsmiRecycleBin.Click += new System.EventHandler( this.tsmiRecycleBin_Click );
            // 
            // bHelp
            // 
            this.bHelp.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.bHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bHelp.Location = new System.Drawing.Point( 414 , 125 );
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size( 17 , 21 );
            this.bHelp.TabIndex = 7;
            this.bHelp.Text = "?";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler( this.bHelp_Click );
            // 
            // Add
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size( 432 , 148 );
            this.Controls.Add( this.bHelp );
            this.Controls.Add( this.bCancel );
            this.Controls.Add( this.bOK );
            this.Controls.Add( this.bExtra );
            this.Controls.Add( this.bFolder );
            this.Controls.Add( this.bFile );
            this.Controls.Add( this.tbPath );
            this.Controls.Add( this.tbName );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.HelpButton = true;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 440 , 175 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 440 , 175 );
            this.Name = "Add";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new alias.... - OpenX";
            ( (System.ComponentModel.ISupportInitialize)( this.ep ) ).EndInit();
            this.cmsExtraBrowse.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button bFile;
        private System.Windows.Forms.Button bFolder;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ToolTip ttAdd;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Button bExtra;
        private System.Windows.Forms.ContextMenuStrip cmsExtraBrowse;
        private System.Windows.Forms.ToolStripMenuItem tsmiMyComputer;
        private System.Windows.Forms.ToolStripMenuItem tsmiNetworkPlaces;
        private System.Windows.Forms.ToolStripMenuItem tsmiNetworkConnections;
        private System.Windows.Forms.ToolStripMenuItem tsmiControlPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecycleBin;
        private System.Windows.Forms.Button bHelp;
    }
}