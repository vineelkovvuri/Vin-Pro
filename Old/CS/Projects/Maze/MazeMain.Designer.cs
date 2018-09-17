namespace Maze
{
    partial class MazeMain
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
            if( disposing && ( components != null ) ) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MazeMain ) );
            this.bStart = new System.Windows.Forms.Button();
            this.bRandamize = new System.Windows.Forms.Button();
            this.tbFoodX = new System.Windows.Forms.TextBox();
            this.tbFoodY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ttHomePage = new System.Windows.Forms.ToolTip( this.components );
            this.pbAbout = new System.Windows.Forms.PictureBox();
            this.lBorn2Code = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pbAbout ) ).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.Transparent;
            this.bStart.Location = new System.Drawing.Point( 520 , 156 );
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size( 75 , 23 );
            this.bStart.TabIndex = 0;
            this.bStart.Text = "&Start";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler( this.bStart_Click );
            // 
            // bRandamize
            // 
            this.bRandamize.BackColor = System.Drawing.Color.Transparent;
            this.bRandamize.Location = new System.Drawing.Point( 520 , 189 );
            this.bRandamize.Name = "bRandamize";
            this.bRandamize.Size = new System.Drawing.Size( 75 , 23 );
            this.bRandamize.TabIndex = 1;
            this.bRandamize.Text = "&Randomize";
            this.bRandamize.UseVisualStyleBackColor = false;
            this.bRandamize.Click += new System.EventHandler( this.bRandamize_Click );
            // 
            // tbFoodX
            // 
            this.tbFoodX.Location = new System.Drawing.Point( 453 , 161 );
            this.tbFoodX.Name = "tbFoodX";
            this.tbFoodX.Size = new System.Drawing.Size( 23 , 20 );
            this.tbFoodX.TabIndex = 2;
            this.tbFoodX.Text = "0";
            this.tbFoodX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFoodX.Validated += new System.EventHandler( this.tbFoodX_Validated );
            // 
            // tbFoodY
            // 
            this.tbFoodY.Location = new System.Drawing.Point( 453 , 187 );
            this.tbFoodY.Name = "tbFoodY";
            this.tbFoodY.Size = new System.Drawing.Size( 23 , 20 );
            this.tbFoodY.TabIndex = 3;
            this.tbFoodY.Text = "0";
            this.tbFoodY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFoodY.Validated += new System.EventHandler( this.tbFoodY_Validated );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point( 430 , 164 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 17 , 13 );
            this.label1.TabIndex = 4;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point( 430 , 190 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 17 , 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ( (System.Drawing.Image)( resources.GetObject( "pictureBox1.Image" ) ) );
            this.pictureBox1.Location = new System.Drawing.Point( 6 , 420 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 35 , 37 );
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.ttHomePage.SetToolTip( this.pictureBox1 , "http://vineelkumarreddy.googlepages.com" );
            this.pictureBox1.Click += new System.EventHandler( this.pictureBox1_Click );
            // 
            // pbAbout
            // 
            this.pbAbout.BackColor = System.Drawing.Color.Transparent;
            this.pbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAbout.Image = ( (System.Drawing.Image)( resources.GetObject( "pbAbout.Image" ) ) );
            this.pbAbout.Location = new System.Drawing.Point( 613 , 421 );
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size( 35 , 37 );
            this.pbAbout.TabIndex = 6;
            this.pbAbout.TabStop = false;
            this.ttHomePage.SetToolTip( this.pbAbout , "About" );
            this.pbAbout.Click += new System.EventHandler( this.pbAbout_Click );
            // 
            // lBorn2Code
            // 
            this.lBorn2Code.AutoSize = true;
            this.lBorn2Code.BackColor = System.Drawing.Color.Transparent;
            this.lBorn2Code.Font = new System.Drawing.Font( "Microsoft Sans Serif" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.lBorn2Code.ForeColor = System.Drawing.Color.Firebrick;
            this.lBorn2Code.Location = new System.Drawing.Point( 276 , 426 );
            this.lBorn2Code.Name = "lBorn2Code";
            this.lBorn2Code.Size = new System.Drawing.Size( 0 , 20 );
            this.lBorn2Code.TabIndex = 7;
            // 
            // MazeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size( 652 , 456 );
            this.Controls.Add( this.lBorn2Code );
            this.Controls.Add( this.pbAbout );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.tbFoodY );
            this.Controls.Add( this.tbFoodX );
            this.Controls.Add( this.bRandamize );
            this.Controls.Add( this.bStart );
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 660 , 490 );
            this.MinimumSize = new System.Drawing.Size( 660 , 490 );
            this.Name = "MazeMain";
            this.Opacity = 0.95;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mazer - By K.Vineel Kumar Reddy.";
            this.Paint += new System.Windows.Forms.PaintEventHandler( this.MazeMain_Paint );
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pbAbout ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bRandamize;
        private System.Windows.Forms.TextBox tbFoodX;
        private System.Windows.Forms.TextBox tbFoodY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip ttHomePage;
        private System.Windows.Forms.PictureBox pbAbout;
        private System.Windows.Forms.Label lBorn2Code;



    }
}

