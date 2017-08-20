using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace MailChecker
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.TextBox textBox1;
		protected System.Windows.Forms.TextBox textBox2;
		protected System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public Form1 MyParentForm;
		private string mServer;
		private string mPassword;
		private string mUserName;
		string m_strFileName = "c:\\projects\\dotnet\\mailchecker\\parms.xml";
		private System.Windows.Forms.Button button1;

		public string UserName
		{
			get{return mUserName;}
			set{mUserName = value; }
		}
		public string Password
		{
			get{return mPassword;}
			set{mPassword = value; }
		}
		public string Server
		{
			get{return textBox3.Text;}
			set{mServer = value; }
			
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			LoadData();
			textBox3.Text = mServer;
			textBox2.Text = mPassword;
			textBox1.Text = mUserName;
		}
	public void WriteData()
	{
		XmlTextWriter bankWriter = null;
		bankWriter = new XmlTextWriter (m_strFileName, null);

		try
		{
			bankWriter.Formatting = Formatting.Indented;
			bankWriter.Indentation= 6;
			bankWriter.Namespaces = false;

			bankWriter.WriteStartDocument();

			bankWriter.WriteStartElement("", "Parms", "");

			bankWriter.WriteStartElement("", "UserName", "");
			bankWriter.WriteString(mUserName);
			bankWriter.WriteEndElement();
	
			bankWriter.WriteStartElement("", "Password", "");
			bankWriter.WriteString(mPassword);
			bankWriter.WriteEndElement();

			bankWriter.WriteStartElement("", "Server", "");
			bankWriter.WriteString(mServer);
			bankWriter.WriteEndElement();
			
			bankWriter.WriteEndElement();
			bankWriter.Flush();
		}
		catch(Exception e)
		{
			Console.WriteLine("Exception: {0}", e.ToString());
		}
		finally
		{
			if (bankWriter != null)
			{
				bankWriter.Close();
			}
		}
	}


		private void LoadData()
		{
			// Create an isntance of XmlTextReader and call Read method to read the file
			string m_strFileName = "c:\\projects\\dotnet\\mailchecker\\parms.xml";
			XmlTextReader bankReader = null;
			bankReader = new XmlTextReader (m_strFileName);

			while (bankReader.Read())
			{
				if (bankReader.NodeType == XmlNodeType.Element)
				{
					if (bankReader.LocalName.Equals("UserName"))
					{
						mUserName = bankReader.ReadString();
					}

					if (bankReader.LocalName.Equals("Password"))
					{
						mPassword = bankReader.ReadString();
					}

					if (bankReader.LocalName.Equals("Server"))
					{
						mServer = bankReader.ReadString();
					}
				}
			}
			bankReader.Close();

		}
		private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Hide the form...
			this.Hide();
    
			// Cancel the close...
			e.Cancel = true;
			
		}

		protected override void OnResize(EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				this.Hide();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(88, 72);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(88, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "UserName";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "imap server";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 144);
			this.button1.Name = "button1";
			this.button1.TabIndex = 6;
			this.button1.Text = "Update";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 214);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.textBox3,
																		  this.textBox2,
																		  this.textBox1});
			this.Name = "Form2";
			this.Text = "Configuration";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form2_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			mUserName = textBox1.Text;
			mPassword = textBox2.Text;
			mServer = textBox3.Text;
			WriteData();
		}

	}
}
