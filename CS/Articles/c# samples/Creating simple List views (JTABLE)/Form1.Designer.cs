namespace WindowsApplication1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem( new string [] {
            "data00",
            "data01",
            "data02"}, -1 );
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem( new string [] {
            "data10",
            "data11",
            "data12"}, -1 );
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem( new string [] {
            "data20",
            "data21",
            "data22"}, -1 );
            this.listView1 = new System.Windows.Forms.ListView();
            this.column0 = new System.Windows.Forms.ColumnHeader();
            this.column1 = new System.Windows.Forms.ColumnHeader();
            this.column2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader [] {
            this.column0,
            this.column1,
            this.column2} );
            this.listView1.Items.AddRange( new System.Windows.Forms.ListViewItem [] {
            listViewItem1,
            listViewItem2,
            listViewItem3} );
            this.listView1.Location = new System.Drawing.Point( 12 , 12 );
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 268 , 242 );
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column0
            // 
            this.column0.Text = "Column0";
            // 
            // column1
            // 
            this.column1.Text = "Column1";
            // 
            // column2
            // 
            this.column2.Text = "Column2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292 , 266 );
            this.Controls.Add( this.listView1 );
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column0;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;














    }
}

