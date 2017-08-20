using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CaptureScreen
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuCaptureScreen;
		private System.Windows.Forms.PictureBox picScreen;
		private System.Windows.Forms.MenuItem mnuExit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuCaptureScreen = new System.Windows.Forms.MenuItem();
			this.picScreen = new System.Windows.Forms.PictureBox();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 8);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 261);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(296, 8);
			this.panel2.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new System.Drawing.Point(288, 8);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(8, 253);
			this.panel4.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 8);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(8, 253);
			this.panel3.TabIndex = 4;
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuCaptureScreen,
																					  this.mnuExit});
			this.menuItem1.Text = "&File";
			// 
			// mnuCaptureScreen
			// 
			this.mnuCaptureScreen.Index = 0;
			this.mnuCaptureScreen.Text = "&Capture Screen";
			this.mnuCaptureScreen.Click += new System.EventHandler(this.mnuCaptureScreen_Click);
			// 
			// picScreen
			// 
			this.picScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picScreen.Location = new System.Drawing.Point(8, 8);
			this.picScreen.Name = "picScreen";
			this.picScreen.Size = new System.Drawing.Size(280, 253);
			this.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picScreen.TabIndex = 5;
			this.picScreen.TabStop = false;
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 1;
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 269);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.picScreen,
																		  this.panel3,
																		  this.panel4,
																		  this.panel2,
																		  this.panel1});
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Capture Screen";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void mnuCaptureScreen_Click(object sender, System.EventArgs e)
		{
			picScreen.Image = CaptureScreen.GetDesktopImage();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
