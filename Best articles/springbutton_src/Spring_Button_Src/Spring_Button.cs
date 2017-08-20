/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 10/11/2005
 * Time: 14.15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Spring_Button
{
	/// <summary>
	/// A simple example about
	/// how to  create a c# control
	/// and 
	/// how to manage a delegate with
	/// embedded Eventargs
	/// </summary>
	/// 
	
	//This is the Embedded eventargs...
	//it just say if the clicked items
	//is right or left triangle
	
		 public class TriangleClickEventArgs
        {
            public bool Isleft = true;

            public TriangleClickEventArgs(bool TriangleIsleft)
            {

                Isleft = TriangleIsleft;

            }

        }
		 
	//and this is the code for the button:	 
	public class SpringButton : Control
	{
	
			
		//Whe user click on the triangle(left o right)
		//the control  run a new event called "TriangleClick"
		//and say what triangle has been clicked.
	
		
		public event TriangleClickDelegate TriangleClick;

        public delegate void TriangleClickDelegate(Object sender,TriangleClickEventArgs e);

        //this variable say if the
        //mouse is over the contol
        private bool Sel = false;
        private Color BackColor2= Color.Gray;
        
        public Color BackColorEnd
        {
        	get{return BackColor2; }
        	set{BackColor2=value; 
        		this.Invalidate();  }
        
        }
        
        int _triangle =25;
        //I add a proprety
        //that's the lenght of
        //a triangle rectangle (45°)
        
        public int Triangle
        {
        	get{return _triangle;}
        	set{ 
        		_triangle=value;
        		//if lenght change I update 
        		//the control
        		this.Invalidate(true);
        	}
        }
			
		
		public SpringButton()
		{
			//First of all i set the style 
			
			this.SetStyle(ControlStyles.AllPaintingInWmPaint  |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint
                 | ControlStyles.UserMouse, true);
			
			
			this.Invalidate();
			
		}
		
		//I override the default event " Onclick"
		//adding the detection of "triangle click"
		
		protected override void OnMouseDown(MouseEventArgs e)
		{ 
			base.OnClick(e);
			// if the user use this delegate...
			if (this.TriangleClick != null)
			{
			//check if the user click on the left triangle
			//or in the right with some geometrics  rules...
			//(is't possible to click all triangle at the same time )
			
			int x= e.X;
			int y= e.Y;
			
			if((x<_triangle)&&(y<=(_triangle-x))||
			   (x>this.ClientRectangle.Width-_triangle)&&(y>=(this.ClientRectangle.Height-_triangle-x)) )
			{
				
			
				//try with right...
				TriangleClickEventArgs te= new TriangleClickEventArgs(false);
				//if not...
				if((x<_triangle)&&(y<=(_triangle-x)))
				    te= new TriangleClickEventArgs(true);
				   
                    this.TriangleClick(this,te);


                }
			}
		}
	//set the button as "selected" on mouse entering
	//and as not selected on mouse leaving
        protected override void OnMouseEnter(EventArgs e)
        {
            Sel = true;

            this.Invalidate();

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Sel = false;

            this.Invalidate();

        }
        
        //i overide the default paint
        //and do my special routine...
		 protected override void OnPaint( PaintEventArgs e)
		 {
		 	//base.OnPaint(e);
            this.PaintBut(e);            
         }
		 
		//If  this component is resized i update him
		  protected override void OnResize( EventArgs e)
		 {
		 	base.OnResize(e);
		 	this.Invalidate(true);            
         }
		  
		  
		  //The Core of this control...
		  protected void PaintBut(PaintEventArgs e)
		  {
		  	//I select the rights color 
		  	//To paint the button...
              Color FColor = this.BackColorEnd;
              Color BColor = this.BackColor;
              if (Sel == true)
              {
                  FColor = this.BackColor;

                  BColor = this.BackColorEnd;
              }
           //I daw the central rectangle


		  	e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control),this.ClientRectangle);
		  	
		  	Rectangle rect=new Rectangle(5,5,this.ClientRectangle.Width-10,this.ClientRectangle.Height-10);
            
            e.Graphics.FillRectangle(new LinearGradientBrush(rect, BColor, Color.FromArgb(10, BColor), 45, true), rect);
		  	e.Graphics.DrawRectangle(new Pen(FColor),rect);
		  	
		  	//I define the triangle's coordinate...
		  	Point[] tringleleft= new Point[4];
		  	tringleleft[0]= new Point(0,0);
		  	tringleleft[1]= new Point(_triangle,0);
		  	tringleleft[2]= new Point(0,_triangle);
		  	tringleleft[3]= new Point(0,0);
		  	
		  	Point[] tringleright= new Point[4];
		  	tringleright[0]= new Point(this.Width-1,this.Height-1);
		  	tringleright[1]= new Point(this.Width-_triangle-1,this.Height-1);
		  	tringleright[2]= new Point(this.Width-1,this.Height-_triangle-1);
		  	tringleright[3]= new Point(this.Width-1,this.Height-1);
		  	
		  
		  	
		  	
		    //..and paint the triangle on the control 
		  	e.Graphics.FillPolygon(new SolidBrush(BColor),tringleleft);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleleft);

		  	
		  	e.Graphics.FillPolygon(new SolidBrush(BColor),tringleright);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleright);
		  	
            //At last i write the text with
            //some allignament...
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;

            sf.Trimming = StringTrimming.Character;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            
		  	e.Graphics.DrawString(this.Text,this.Font,new SolidBrush(this.ForeColor),this.ClientRectangle,sf);
		  
		  }
        		
		
		  
	}
	

}
