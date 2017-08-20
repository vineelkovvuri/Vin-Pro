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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonInTab1 = new System.Windows.Forms.Button();
            this.checkBoxInTab2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Location = new System.Drawing.Point( 12 , 23 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 253 , 188 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.buttonInTab1 );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 245 , 162 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.checkBoxInTab2 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 245 , 162 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonInTab1
            // 
            this.buttonInTab1.Location = new System.Drawing.Point( 71 , 54 );
            this.buttonInTab1.Name = "buttonInTab1";
            this.buttonInTab1.Size = new System.Drawing.Size( 99 , 23 );
            this.buttonInTab1.TabIndex = 0;
            this.buttonInTab1.Text = "buttonInTab1";
            this.buttonInTab1.UseVisualStyleBackColor = true;
            // 
            // checkBoxInTab2
            // 
            this.checkBoxInTab2.AutoSize = true;
            this.checkBoxInTab2.Location = new System.Drawing.Point( 53 , 58 );
            this.checkBoxInTab2.Name = "checkBoxInTab2";
            this.checkBoxInTab2.Size = new System.Drawing.Size( 108 , 17 );
            this.checkBoxInTab2.TabIndex = 0;
            this.checkBoxInTab2.Text = "checkBoxInTab2";
            this.checkBoxInTab2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292 , 266 );
            this.Controls.Add( this.tabControl1 );
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage2.ResumeLayout( false );
            this.tabPage2.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonInTab1;
        private System.Windows.Forms.CheckBox checkBoxInTab2;










    }
}

