namespace Open
{
    partial class OpenX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OpenX ) );
            this.lvTable = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chPath = new System.Windows.Forms.ColumnHeader();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.llHomeLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bHelp = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // lvTable
            // 
            this.lvTable.AllowColumnReorder = true;
            this.lvTable.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lvTable.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chPath} );
            this.lvTable.FullRowSelect = true;
            this.lvTable.GridLines = true;
            this.lvTable.Location = new System.Drawing.Point( 12 , 12 );
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size( 437 , 221 );
            this.lvTable.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTable.TabIndex = 0;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.DoubleClick += new System.EventHandler( this.lvTable_DoubleClick );
            this.lvTable.SelectedIndexChanged += new System.EventHandler( this.lvTable_SelectedIndexChanged );
            this.lvTable.KeyUp += new System.Windows.Forms.KeyEventHandler( this.lvTable_KeyUp );
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 115;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 302;
            // 
            // bAdd
            // 
            this.bAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bAdd.Location = new System.Drawing.Point( 465 , 28 );
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size( 49 , 23 );
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = "&Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler( this.bAdd_Click );
            // 
            // bDelete
            // 
            this.bDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bDelete.Location = new System.Drawing.Point( 465 , 81 );
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size( 49 , 23 );
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "&Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler( this.bDelete_Click );
            // 
            // bEdit
            // 
            this.bEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bEdit.Location = new System.Drawing.Point( 465 , 134 );
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size( 49 , 23 );
            this.bEdit.TabIndex = 3;
            this.bEdit.Text = "&Edit";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler( this.bEdit_Click );
            // 
            // bExit
            // 
            this.bExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExit.Location = new System.Drawing.Point( 465 , 187 );
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size( 49 , 23 );
            this.bExit.TabIndex = 4;
            this.bExit.Text = "E&xit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler( this.bExit_Click );
            // 
            // llHomeLink
            // 
            this.llHomeLink.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.llHomeLink.AutoSize = true;
            this.llHomeLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llHomeLink.LinkColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 109 ) ) ) ) , ( (int)( ( (byte)( 105 ) ) ) ) , ( (int)( ( (byte)( 105 ) ) ) ) );
            this.llHomeLink.Location = new System.Drawing.Point( 56 , 246 );
            this.llHomeLink.Name = "llHomeLink";
            this.llHomeLink.Size = new System.Drawing.Size( 208 , 13 );
            this.llHomeLink.TabIndex = 2;
            this.llHomeLink.TabStop = true;
            this.llHomeLink.Text = "http://vineelkumarreddy.googlepages.com";
            this.llHomeLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llHomeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llHomeLink_LinkClicked );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.pictureBox1.Image = ( (System.Drawing.Image)( resources.GetObject( "pictureBox1.Image" ) ) );
            this.pictureBox1.Location = new System.Drawing.Point( 10 , 237 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 36 , 33 );
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bHelp
            // 
            this.bHelp.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.bHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bHelp.Location = new System.Drawing.Point( 507 , 254 );
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size( 17 , 21 );
            this.bHelp.TabIndex = 5;
            this.bHelp.Text = "?";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler( this.bHelp_Click );
            // 
            // OpenX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bExit;
            this.ClientSize = new System.Drawing.Size( 524 , 275 );
            this.Controls.Add( this.bHelp );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.llHomeLink );
            this.Controls.Add( this.bExit );
            this.Controls.Add( this.bEdit );
            this.Controls.Add( this.bDelete );
            this.Controls.Add( this.bAdd );
            this.Controls.Add( this.lvTable );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MinimumSize = new System.Drawing.Size( 532 , 309 );
            this.Name = "OpenX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.OpenX_FormClosing );
            this.KeyUp += new System.Windows.Forms.KeyEventHandler( this.OpenX_KeyUp );
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.LinkLabel llHomeLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bHelp;
    }
}

