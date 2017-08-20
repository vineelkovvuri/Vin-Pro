/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 10/11/2005
 * Time: 14.14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Spring_Button;

namespace Spring_Button
{
		/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private Spring_Button.SpringButton springButton2;
		private Spring_Button.SpringButton springButton3;
		private Spring_Button.SpringButton springButton1;
		private Spring_Button.SpringButton springButton6;
		private Spring_Button.SpringButton springButton7;
		private Spring_Button.SpringButton springButton4;
		private Spring_Button.SpringButton springButton5;
		private Spring_Button.SpringButton springButton8;
		
				[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
	     public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.springButton8 = new Spring_Button.SpringButton();
			this.springButton5 = new Spring_Button.SpringButton();
			this.springButton4 = new Spring_Button.SpringButton();
			this.springButton7 = new Spring_Button.SpringButton();
			this.springButton6 = new Spring_Button.SpringButton();
			this.springButton1 = new Spring_Button.SpringButton();
			this.springButton3 = new Spring_Button.SpringButton();
			this.springButton2 = new Spring_Button.SpringButton();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// springButton8
			// 
			this.springButton8.BackColor = System.Drawing.Color.DeepPink;
			this.springButton8.BackColorEnd = System.Drawing.Color.LightPink;
			this.springButton8.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton8.ForeColor = System.Drawing.Color.Firebrick;
			this.springButton8.Location = new System.Drawing.Point(8, 416);
			this.springButton8.Name = "springButton8";
			this.springButton8.Size = new System.Drawing.Size(208, 56);
			this.springButton8.TabIndex = 9;
			this.springButton8.Text = "Spring Button";
			this.springButton8.Triangle = 30;
			this.springButton8.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton5
			// 
			this.springButton5.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.springButton5.BackColorEnd = System.Drawing.Color.DarkOrchid;
			this.springButton5.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton5.ForeColor = System.Drawing.Color.Blue;
			this.springButton5.Location = new System.Drawing.Point(8, 248);
			this.springButton5.Name = "springButton5";
			this.springButton5.Size = new System.Drawing.Size(208, 56);
			this.springButton5.TabIndex = 6;
			this.springButton5.Text = "Spring Button";
			this.springButton5.Triangle = 30;
			this.springButton5.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton4
			// 
			this.springButton4.BackColor = System.Drawing.Color.BlueViolet;
			this.springButton4.BackColorEnd = System.Drawing.Color.MediumSlateBlue;
			this.springButton4.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton4.ForeColor = System.Drawing.Color.GhostWhite;
			this.springButton4.Location = new System.Drawing.Point(8, 192);
			this.springButton4.Name = "springButton4";
			this.springButton4.Size = new System.Drawing.Size(208, 56);
			this.springButton4.TabIndex = 5;
			this.springButton4.Text = "Spring Button";
			this.springButton4.Triangle = 30;
			this.springButton4.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton7
			// 
			this.springButton7.BackColor = System.Drawing.Color.PaleGreen;
			this.springButton7.BackColorEnd = System.Drawing.Color.DarkGreen;
			this.springButton7.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton7.ForeColor = System.Drawing.Color.Ivory;
			this.springButton7.Location = new System.Drawing.Point(8, 360);
			this.springButton7.Name = "springButton7";
			this.springButton7.Size = new System.Drawing.Size(208, 56);
			this.springButton7.TabIndex = 8;
			this.springButton7.Text = "Spring Button";
			this.springButton7.Triangle = 30;
			this.springButton7.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton6
			// 
			this.springButton6.BackColor = System.Drawing.Color.Fuchsia;
			this.springButton6.BackColorEnd = System.Drawing.Color.Crimson;
			this.springButton6.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton6.ForeColor = System.Drawing.Color.DeepPink;
			this.springButton6.Location = new System.Drawing.Point(8, 304);
			this.springButton6.Name = "springButton6";
			this.springButton6.Size = new System.Drawing.Size(208, 56);
			this.springButton6.TabIndex = 7;
			this.springButton6.Text = "Spring Button";
			this.springButton6.Triangle = 30;
			this.springButton6.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton1
			// 
			this.springButton1.BackColor = System.Drawing.Color.Pink;
			this.springButton1.BackColorEnd = System.Drawing.Color.Thistle;
			this.springButton1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton1.ForeColor = System.Drawing.Color.MediumOrchid;
			this.springButton1.Location = new System.Drawing.Point(8, 8);
			this.springButton1.Name = "springButton1";
			this.springButton1.Size = new System.Drawing.Size(208, 56);
			this.springButton1.TabIndex = 2;
			this.springButton1.Text = "Spring Button";
			this.springButton1.Triangle = 30;
			this.springButton1.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton3
			// 
			this.springButton3.BackColor = System.Drawing.Color.AliceBlue;
			this.springButton3.BackColorEnd = System.Drawing.Color.DeepSkyBlue;
			this.springButton3.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton3.ForeColor = System.Drawing.Color.MediumBlue;
			this.springButton3.Location = new System.Drawing.Point(8, 136);
			this.springButton3.Name = "springButton3";
			this.springButton3.Size = new System.Drawing.Size(208, 56);
			this.springButton3.TabIndex = 4;
			this.springButton3.Text = "Spring Button";
			this.springButton3.Triangle = 30;
			this.springButton3.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// springButton2
			// 
			this.springButton2.BackColor = System.Drawing.Color.PapayaWhip;
			this.springButton2.BackColorEnd = System.Drawing.Color.Goldenrod;
			this.springButton2.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.springButton2.ForeColor = System.Drawing.Color.Olive;
			this.springButton2.Location = new System.Drawing.Point(8, 72);
			this.springButton2.Name = "springButton2";
			this.springButton2.Size = new System.Drawing.Size(208, 56);
			this.springButton2.TabIndex = 3;
			this.springButton2.Text = "Spring Button";
			this.springButton2.Triangle = 30;
			this.springButton2.TriangleClick += new Spring_Button.SpringButton.TriangleClickDelegate(this.SpringButton8TriangleClick);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(224, 8);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.SelectedObject = this.springButton1;
			this.propertyGrid1.Size = new System.Drawing.Size(280, 464);
			this.propertyGrid1.TabIndex = 1;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 478);
			this.Controls.Add(this.springButton8);
			this.Controls.Add(this.springButton7);
			this.Controls.Add(this.springButton6);
			this.Controls.Add(this.springButton5);
			this.Controls.Add(this.springButton4);
			this.Controls.Add(this.springButton3);
			this.Controls.Add(this.springButton2);
			this.Controls.Add(this.springButton1);
			this.Controls.Add(this.propertyGrid1);
			this.Name = "MainForm";
			this.Text = "Sample Spring Form";
			this.ResumeLayout(false);
		}
		#endregion
	
		
		
		
		void SpringButton8TriangleClick(object sender, Spring_Button.TriangleClickEventArgs e)
		{
		if(e.Isleft==true)
				MessageBox.Show("A Click on the LEFT triangle!!");
			else
				MessageBox.Show("A Click on the RIGHT triangle!!");
				
		}
		
	}
}
