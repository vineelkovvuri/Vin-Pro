using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox editBox ;
		int itemSelected = -1 ;

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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox1.ItemHeight = 16;
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(296, 164);
			this.listBox1.TabIndex = 0;
			this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
			this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 173);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1});
			this.Name = "Form1";
			this.Text = "Editable ListBox";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			CreateEditBox(sender);
		}
	
		private void CreateEditBox(object sender)
		{
			listBox1= (ListBox)sender ; 
			itemSelected = listBox1.SelectedIndex ;
			Rectangle r = listBox1.GetItemRectangle(itemSelected);
			string itemText = (string)listBox1.Items[itemSelected];
            editBox.Location = new System.Drawing.Point(r.X , r.Y );
            editBox.Size = new System.Drawing.Size(r.Width , r.Height );
			editBox.Show();
			listBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.editBox});			
			editBox.Text = itemText ;
			editBox.Focus();
			editBox.SelectAll(); 
			editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
			editBox.LostFocus += new System.EventHandler(this.FocusOver);
		}

		private void FocusOver(object sender, System.EventArgs e)
		{
			listBox1.Items[itemSelected] = editBox.Text ;
			editBox.Hide();
		}

		private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( e.KeyChar == 13 ) 
			{
				listBox1.Items[itemSelected] = editBox.Text ;
				editBox.Hide();
			}

			if ( e.KeyChar == 27 ) 
				editBox.Hide();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			editBox = new System.Windows.Forms.TextBox();
			editBox.Location = new System.Drawing.Point(0,0);
			editBox.Size = new System.Drawing.Size(0,0);
			editBox.Hide();
			listBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.editBox});			
			editBox.Text = "";
			editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
			editBox.LostFocus += new System.EventHandler(this.FocusOver);
			editBox.BorderStyle = BorderStyle.None;

			listBox1.Items.Add("USA");
			listBox1.Items.Add("FRANCE");
			listBox1.Items.Add("ITALY");
			listBox1.Items.Add("ARGENTINA");
			listBox1.Items.Add("INDIA");
			listBox1.Items.Add("SINGAPORE");
			listBox1.Items.Add("JAPAN");

			listBox1.SelectedIndex = 0 ; 
		}

		private void listBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( e.KeyChar == 13 ) 		
				CreateEditBox(sender);
		}

		private void listBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyData == Keys.F2 ) 
				CreateEditBox(sender);
		}
	}
}
