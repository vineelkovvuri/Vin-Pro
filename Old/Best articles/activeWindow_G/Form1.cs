using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace activeWindow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		
		[ DllImport("user32.dll") ]
		static extern int GetForegroundWindow();
			
		[ DllImport("user32.dll") ]
		static extern int GetWindowText(int hWnd, StringBuilder text, int count);

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label captionWindowLabel;
		private System.Windows.Forms.Label IDWindowLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		//
		// GetForegroundWindow API 
		//
		private void GetActiveWindow()
		{
			
			const int nChars = 256;
			int handle = 0;
			StringBuilder Buff = new StringBuilder(nChars);
   			
			handle = GetForegroundWindow();

			if ( GetWindowText(handle, Buff, nChars) > 0 )
			{
				this.captionWindowLabel.Text = Buff.ToString();
				this.IDWindowLabel.Text = handle.ToString();
			}

		}


		public Form1()
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.captionWindowLabel = new System.Windows.Forms.Label();
			this.IDWindowLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(136, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Active Window Detail";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Window Caption : ";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Window Handle :";
			// 
			// captionWindowLabel
			// 
			this.captionWindowLabel.Location = new System.Drawing.Point(112, 40);
			this.captionWindowLabel.Name = "captionWindowLabel";
			this.captionWindowLabel.Size = new System.Drawing.Size(224, 40);
			this.captionWindowLabel.TabIndex = 3;
			// 
			// IDWindowLabel
			// 
			this.IDWindowLabel.Location = new System.Drawing.Point(112, 88);
			this.IDWindowLabel.Name = "IDWindowLabel";
			this.IDWindowLabel.Size = new System.Drawing.Size(100, 16);
			this.IDWindowLabel.TabIndex = 4;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 24);
			this.button1.TabIndex = 5;
			this.button1.Text = "EXIT";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 173);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.IDWindowLabel,
																		  this.captionWindowLabel,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Window Information";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			GetActiveWindow();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
