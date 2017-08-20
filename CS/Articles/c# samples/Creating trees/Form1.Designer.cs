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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode( "child1child1" );
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode( "child1" , new System.Windows.Forms.TreeNode [] {
            treeNode1} );
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode( "child2" );
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode( "root" , new System.Windows.Forms.TreeNode [] {
            treeNode2,
            treeNode3} );
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point( 12 , 12 );
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "child1child1";
            treeNode1.Text = "child1child1";
            treeNode2.Name = "child1";
            treeNode2.Text = "child1";
            treeNode3.Name = "child2";
            treeNode3.Text = "child2";
            treeNode4.Name = "root";
            treeNode4.Text = "root";
            this.treeView1.Nodes.AddRange( new System.Windows.Forms.TreeNode [] {
            treeNode4} );
            this.treeView1.Size = new System.Drawing.Size( 121 , 242 );
            this.treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292 , 266 );
            this.Controls.Add( this.treeView1 );
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;









    }
}

