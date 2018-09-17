using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
/*
Title:       Mail Checker 1.0
Author:      Matt Watson 
Email:       watsonm2@myrealbox.com
Environment: C# WinXP
Keywords:    mail, IMAP, contextMenu, notifyIcon, Sockets, Timers
Level:       Intermediate
Description: An article on creating a program to check your IMAP mail.  The program will minimize in the system tray and will show the number of new messages.  This program is modeled after MSN Messenger.
Section      Mail
SubSection   Forms
*/
namespace MailChecker
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;
		TcpClient tcpclnt;
		private System.Windows.Forms.RichTextBox richTextBox1;
		string CRLF = "\r\n";
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		int iMessages = 0;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		
		//create an instance of the form to get at the variables
		static Form2 oForm2= new Form2();
		
		public Form1()
		{
			InitializeComponent();
		}

		//must be used to destroy the icon.
		[DllImport("user32.dll", EntryPoint="DestroyIcon")]
		static extern bool DestroyIcon(IntPtr hIcon);

		//Pass in the number of new mail messages
		private void UpdateTaskBar(int i)
		{
			String TaskBarLetter;
			// Create a graphics instance that draws to a bitmap
			Bitmap bitmap = new Bitmap(16, 16);
			SolidBrush brush = new SolidBrush(fontDialog1.Color);
			Graphics graphics = Graphics.FromImage(bitmap);

			// Draw then number of Messages to the bitmap using the user selected font
			if(i != -1)
				 TaskBarLetter= i.ToString();
			else
				TaskBarLetter = "X";
			graphics.DrawString(TaskBarLetter, fontDialog1.Font, brush, 0, 0);

			// Convert the bitmap into an icon and use it for the system tray icon
			IntPtr hIcon = bitmap.GetHicon();
			Icon icon = Icon.FromHandle(hIcon);
			notifyIcon1.Icon = icon;
    
			// unfortunately, GetHicon creates an unmanaged handle which must be manually destroyed
			DestroyIcon(hIcon);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// 
		//Had to overide this in order to make sure the notifyIcon was being destroyed.
		/*protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}*/

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			//this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 64);
			this.label1.TabIndex = 0;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(32, 200);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(248, 104);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "richTextBox1";
			this.richTextBox1.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 30000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 110);
			this.ContextMenu = this.contextMenu1;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBox1,
																		  this.label1});
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
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

		// Hide the window if we're being minimized so it doesn't show in the
		// taskbar (will still show in the system tray).
		protected override void OnResize(EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				this.Hide();
		}

		//shows the config form
		private void showForm2()
		{
			oForm2.MyParentForm = this;
			oForm2.Show();
			oForm2.WindowState = FormWindowState.Normal;
		}

		protected override void OnLoad(EventArgs e)
		{
			UpdateTaskBar(-1);
			oForm2.MyParentForm = this;

			//rect get data from the function returning the working area of the screen
			Rectangle rect=new Rectangle();		
			rect=Screen.GetWorkingArea(this);
			
			//set the window down to the lower right hand corner
			this.Location = new Point(rect.Right - this.Size.Width, rect.Bottom - this.Size.Height);
			if(Connect())
			{
				if(SendToServer("? LOGIN " + oForm2.UserName + " " + oForm2.Password +CRLF,"? NO")!="")
				{
					if(SendToServer("? Select Inbox"+CRLF,"? NO")!="")
					{
						string sMessages = SendToServer("? SEARCH UNSEEN"+CRLF," ");
						if(sMessages != "")
						{
							iMessages = NewMessages(sMessages);
							if(iMessages > 0)
							{
								label1.Text = "You have " + iMessages.ToString() + " new Messages";
							}
							else
							{
								label1.Text = "You have no new mail messages";
							}
							UpdateTaskBar(iMessages);
						}
						else
							label1.Text = "Some Sort of Error on getting messages";
					}
					else
						label1.Text = "Some Sort of Error on Selecting Inbox";
				}
				else
					label1.Text = "Some Sort of Error on Login";

				Disconnect();
			}
			else
				label1.Text = "Error on connect";

		timer1.Enabled = true;
	}

		//parses through the response you get back from the IMAP server
		private int NewMessages(string sMessages)
		{
			int iMessages = -1;
			if(sMessages.StartsWith("* SEARCH"))
			{
				foreach(char c in sMessages)
				{
					if(c == ' ')
						iMessages ++;
					else if(c == 0xd)
						break;
				}
			}
			else
				return 0;
			
			return iMessages;
		}

		//connect to the IMAP Server
		private bool Connect()
		{
			try
			{
				string sResponse="";
				richTextBox1.AppendText("Connecting.....");
				tcpclnt= new TcpClient();
				tcpclnt.Connect(oForm2.Server,143); // use the ipaddress as in the server program
				Stream stm = tcpclnt.GetStream();
				byte[] bb=new byte[4096];
				int k=stm.Read(bb,0,4096);
			
				for (int i=0;i<k;i++)
					sResponse += Convert.ToChar(bb[i]).ToString();
				richTextBox1.AppendText(sResponse);
				return true;
			}
			catch
			{
				return false;
			}
		}

		//sends data to the server and returns the response
		//errString is the error message that we are looking for to see if it worked.
		private string SendToServer(string str, string errString)
		{
			string sResponse="";
			Stream stm = tcpclnt.GetStream();
			ASCIIEncoding asen= new ASCIIEncoding();
			byte[] ba=asen.GetBytes(str);
			richTextBox1.AppendText("Transmitting.....");
			
			stm.Write(ba,0,ba.Length);

			byte[] bb=new byte[4096];
			int k=stm.Read(bb,0,4096);
			
			for (int i=0;i<k;i++)
				sResponse += Convert.ToChar(bb[i]).ToString();
			
			richTextBox1.AppendText(sResponse);
			if(sResponse.StartsWith(errString))
				return "";
				
				return sResponse;
		}

		//send logout message and close the socket
		private bool Disconnect()
		{	
			SendToServer("? LOGOUT"+ CRLF,"");
			tcpclnt.Close();
			return true;
		}

		//Timer to control the loading and unloading of the window in the bottom right corner
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Show();
			this.Hide();
			timer1.Enabled = false;
			timer2.Enabled = true;
		}

		//timer object for checking mail
		private void timer2_Tick(object sender, System.EventArgs e)
		{
			if(Connect())
			{
				if(SendToServer("? LOGIN " + oForm2.UserName + " " + oForm2.Password +CRLF,"? NO")!="")
				{
					if(SendToServer("? Select Inbox"+CRLF,"? NO")!="")
					{
						string sMessages = SendToServer("? SEARCH UNSEEN"+CRLF," ");
						if(sMessages != "")
						{
							int tMessages = NewMessages(sMessages);
							if(iMessages< tMessages)
							{
								iMessages = NewMessages(sMessages);
								label1.Text = "You have " + iMessages + " new mail messages";
								this.Show();
								this.WindowState = FormWindowState.Normal;
								timer1.Enabled = true;
							}
							else if (tMessages < iMessages)
							{
								iMessages = tMessages;
							}
							UpdateTaskBar(iMessages);
						}
						else
							UpdateTaskBar(-1);
					}
					else
						UpdateTaskBar(-1);
					
				}
				else
					UpdateTaskBar(-1);
				Disconnect();
			}
			else
				UpdateTaskBar(-1);
		}

		//override in order to destroy the notify icon
		// still having some problems with this one
		protected override void Dispose( bool disposing ) 
		{ 
			if( disposing ) 
			{ 
				this.notifyIcon1.Dispose(); //we dispose our tray icon here
			}
			base.Dispose( disposing );
		}

		//Had to override the closing so that it does not exit the application when you click on the X
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Hide the form...
			this.Hide();
    
			// Cancel the close...
			e.Cancel = true;
		}

		//Add the menu items to the context menu
		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			// Clear the contents of the context menu.
			contextMenu1.MenuItems.Clear();

			// Add a menu item 
			contextMenu1.MenuItems.Add("Show Config",new System.EventHandler(this.Config_OnClick));
			contextMenu1.MenuItems.Add("Exit",new System.EventHandler(this.Exit_OnClick));
			
		}

		protected void Exit_OnClick(System.Object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		protected void Config_OnClick(System.Object sender, System.EventArgs e)
		{
			showForm2();
		}

	}
}
