/**********************************************************************************
Shared Source License for Cropper in C#
Copyright 2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#region Using Directives

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Fusion8Design.Win32;

#endregion

namespace Fusion8Design.Cropper
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			this.Visible = false;
            InitializeComponent();
			LoadConfiguration();
			SetUpForm();
			SetUpMenu(); 
			this.Visible = true;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(null != _feedbackFont)
					_feedbackFont.Dispose();
				if(null != _menu)
					_menu.Dispose();
				if(null != _tabBrush)
					_tabBrush.Dispose();
				if(null != _areaBrush)
					_areaBrush.Dispose();
				if(null != _textBrush)
					_textBrush.Dispose();
				if(null != _recordTimer)
					_recordTimer.Dispose();
				if(null != notifyIcon)
					notifyIcon.Dispose();

				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "Cropper";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Magenta;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cropper";
			this.TransparencyKey = System.Drawing.Color.Magenta;

		}
		[STAThread]
		static void Main() 
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.UnhandledException += new UnhandledExceptionEventHandler(TopLevelErrorHandler);
			Application.Run(new MainForm());
		}

		static void TopLevelErrorHandler(object sender, UnhandledExceptionEventArgs args) 
		{
			//TODO: Add error Handling code
		}


		#endregion

        #region ResizeRegion enum

        private enum ResizeRegion
        {
            None, N, NE, E, SE, S, SW, W, NW
        }

        #endregion

        #region Private Property Accessors

        private int VisibleWidth
        {
            get
            {
                return this.Width - (TRANS_BORDER_WIDTH * 2);
            }
            set
            {
                this.Width = value + (TRANS_BORDER_WIDTH * 2);
            }
        }

        private int VisibleHeight
        {
            get
            {
                return this.Height - (TRANS_BORDER_WIDTH * 2);
            }
            set
            {
                this.Height = value + (TRANS_BORDER_WIDTH * 2);
            }
        }

		private int VisibleLeft
		{
			get
			{
				return this.Left + (TRANS_BORDER_WIDTH);
			}
			set
			{
				this.Left = value - (TRANS_BORDER_WIDTH);
			}

		}

		private int VisibleTop
		{
			get
			{
				return this.Top + (TRANS_BORDER_WIDTH);
			}
			set
			{
				this.Top = value - (TRANS_BORDER_WIDTH);
			}
		}

		private Size VisibleClientSize
		{
			set
			{
				Width = value.Width + (TRANS_BORDER_WIDTH * 2);
				Height = value.Height + (TRANS_BORDER_WIDTH * 2);
			}
		}
		private Rectangle VisibleClientRectangle
		{
			get
			{
				Rectangle visibleClient = new Rectangle(TRANS_BORDER_WIDTH, 
					TRANS_BORDER_WIDTH, 
					VisibleWidth - 1, 
					VisibleHeight - 1);
				return visibleClient;
			}
		}

        #endregion

        #region Member Variables

        private int				_middleX;
        private int				_middleY;
		private int				_thumbnailWidth		= 80;
		private int				_thumbnailHeight	= 80;
		private string			_imageFormat		= "Bmp";
		private double			_userOpacity		= .40;
		private double			_maxThumbSize		= 80;
		private bool            _isRecording		= false;
		private bool			_isThumbnailed		= false;
        private Font            _feedbackFont		= new Font("Verdana", 8f);
        private Point			_offset;
        private Point			_mouseDownPoint;
		private Point			_point1				= new Point(TRANS_BORDER_WIDTH - TAB_HEIGHT, TRANS_BORDER_WIDTH - TAB_HEIGHT);
		private Point			_point2				= new Point(TRANS_BORDER_WIDTH + TAB_TOP_WIDTH, TRANS_BORDER_WIDTH - TAB_HEIGHT);
		private Point			_point3				= new Point(TRANS_BORDER_WIDTH + TAB_BOTTOM_WIDTH, TRANS_BORDER_WIDTH);
		private Point			_point4				= new Point(TRANS_BORDER_WIDTH, TRANS_BORDER_WIDTH);
		private Point			_point5				= new Point(TRANS_BORDER_WIDTH, TRANS_BORDER_WIDTH + TAB_BOTTOM_WIDTH);
		private Point			_point6				= new Point(TRANS_BORDER_WIDTH - TAB_HEIGHT , TRANS_BORDER_WIDTH + TAB_TOP_WIDTH);
		private Rectangle		_mouseDownRect;
		private Rectangle       _closeRectangle;
		private Rectangle		_thumbRectangle;
		private Size[]			_userSizes;
        private ContextMenu		_menu				= new ContextMenu();
		private SolidBrush		_tabBrush			= new SolidBrush(Color.LightSteelBlue);
		private SolidBrush		_areaBrush			= new SolidBrush(Color.White);
		private SolidBrush		_textBrush			= new SolidBrush(Color.Black);
		private ResizeRegion	_resizeRegion		= ResizeRegion.None;
		private Timer           _recordTimer;
		private	MenuItem		_outputMenuItem;
        private const int		RESIZE_BORDER_WIDTH	= 10;
        private const int       TRANS_BORDER_WIDTH	= 60;
        private const int       TAB_HEIGHT			= 15;
        private const int       TAB_TOP_WIDTH		= 45;        
        private const int       TAB_BOTTOM_WIDTH	= 60;
		
		private System.Windows.Forms.NotifyIcon notifyIcon;

        #endregion

        #region Helper Methods

		private bool IsInThumbnailResizeArea()
		{
			Point clientCursorPos = PointToClient(MousePosition);

			Rectangle resizeInnerRect = _thumbRectangle;
			resizeInnerRect.Inflate(-RESIZE_BORDER_WIDTH, -RESIZE_BORDER_WIDTH);

			return (_thumbRectangle.Contains(clientCursorPos) && !resizeInnerRect.Contains(clientCursorPos));
		}

        private bool IsInResizeArea()
        {
            Point clientCursorPos = PointToClient(MousePosition);

            Rectangle clientVisibleRect = ClientRectangle;
            clientVisibleRect.Inflate(-TRANS_BORDER_WIDTH, -TRANS_BORDER_WIDTH);

            Rectangle resizeInnerRect = clientVisibleRect;
            resizeInnerRect.Inflate(-RESIZE_BORDER_WIDTH, -RESIZE_BORDER_WIDTH);

            return (clientVisibleRect.Contains(clientCursorPos) && !resizeInnerRect.Contains(clientCursorPos));
        }

        private bool IsMouseInRectangle(Rectangle rectangle)
        {
            Point clientCursorPos = PointToClient(MousePosition);
            return (rectangle.Contains(clientCursorPos));
        }      

        private ResizeRegion GetResizeRegion()
        {
            Point clientCursorPos = PointToClient(MousePosition);
            if ((clientCursorPos.X >= (Width - (TRANS_BORDER_WIDTH + RESIZE_BORDER_WIDTH))) & (clientCursorPos.Y >= (Height - (TRANS_BORDER_WIDTH + RESIZE_BORDER_WIDTH))))
                return ResizeRegion.SE;
            else if (clientCursorPos.X >= (Width - (TRANS_BORDER_WIDTH + RESIZE_BORDER_WIDTH)))
                return ResizeRegion.E;
            else if (clientCursorPos.Y >= (Height - (TRANS_BORDER_WIDTH + RESIZE_BORDER_WIDTH)))
                return ResizeRegion.S;
            else
                return ResizeRegion.None;
        }

		private ResizeRegion GetThumbnailResizeRegion()
		{
			Point clientCursorPos = PointToClient(MousePosition);
			if (clientCursorPos.X >= _thumbRectangle.Right - RESIZE_BORDER_WIDTH & clientCursorPos.Y >= _thumbRectangle.Bottom - RESIZE_BORDER_WIDTH)
				return ResizeRegion.SE;
			else if (clientCursorPos.X >= _thumbRectangle.Right - RESIZE_BORDER_WIDTH)
				return ResizeRegion.E;
			else if (clientCursorPos.Y >= _thumbRectangle.Bottom - RESIZE_BORDER_WIDTH)
				return ResizeRegion.S;
			else
				return ResizeRegion.None;
		}

        private void SetUpForm()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserMouse, true);
			_recordTimer = new Timer();
			this.ContextMenu = _menu;
			this.notifyIcon.ContextMenu = _menu;
			this.notifyIcon.Icon = this.Icon;
        }

		private void LoadConfiguration()
		{
			Configuration config = new Configuration().Load();
			_userOpacity = config.UserOpacity;
			_userSizes = config.UserSizes;
			_imageFormat = config.ImageFormat;
			_maxThumbSize = config.MaxThumbnailSize;
			this.Opacity = _userOpacity;
			this.ClientSize = _userSizes[0];
			this.Location = config.Location;
		}

		private void InvertColors()
		{
			Opacity = _userOpacity;
			if(this._areaBrush.Color == Color.White)
			{
				this._areaBrush.Color = Color.DimGray;
				this._tabBrush.Color = Color.Firebrick;
				this._textBrush.Color = Color.White;
			}
			else
			{
				this._areaBrush.Color = Color.White;
				this._tabBrush.Color = Color.LightSteelBlue;
				this._textBrush.Color = Color.Black;				
			}
			this.Invalidate();
		}

		private void CheckForDialogClosing()
		{
			if(IsMouseInRectangle(_closeRectangle))
			{
				Opacity = _userOpacity;
				ClientSize = _userSizes[0];
				_closeRectangle.Inflate(-_closeRectangle.Size.Width, -_closeRectangle.Size.Height);
				this.Invalidate();
			}
		}


        #endregion

        #region Form Manipulation

		private void ResizeThumbnail(int interval)
		{
			_maxThumbSize = _maxThumbSize + interval;
			if(_maxThumbSize < 20)
				_maxThumbSize = 20;
			Invalidate();
		}

		private void CenterSize(int interval)
		{
			if(interval > 100)
				throw new ArgumentOutOfRangeException("interval", interval, "the interval must not be greater that 100");
            
			if(VisibleWidth > interval & VisibleHeight > interval)
			{
				int interval2 = interval * 2;
				Width = Width - interval2;
				Height = Height - interval2;
				Left = Left + interval;
				Top = Top + interval;
			}
		}

        private void HandleResize()
        {
            int diffX = MousePosition.X - _mouseDownPoint.X;
            int diffY = MousePosition.Y - _mouseDownPoint.Y;
            switch (_resizeRegion)
            {
                case ResizeRegion.E:
                    Width = _mouseDownRect.Width + diffX;
                    break;
                case ResizeRegion.S:                    
                    Height = _mouseDownRect.Height + diffY;
                    break;
                case ResizeRegion.SE:
                    Width = _mouseDownRect.Width + diffX;
                    Height = _mouseDownRect.Height + diffY;
                    break;
            }
        }

		private void HandleThumbnailResize()
		{
			int diffX = MousePosition.X - _mouseDownPoint.X;
			int diffY = MousePosition.Y - _mouseDownPoint.Y;
			switch (_resizeRegion)
			{
				case ResizeRegion.E:
					_thumbRectangle.Width = _mouseDownRect.Width + diffX;
					break;
				case ResizeRegion.S:                    
					_thumbRectangle.Height = _mouseDownRect.Height + diffY;
					break;
				case ResizeRegion.SE:
					_thumbRectangle.Width = _mouseDownRect.Width + diffX;
					_thumbRectangle.Height = _mouseDownRect.Height + diffY;
					break;
			}
			Invalidate();
		}

        private void SetResizeCursor(ResizeRegion region)
        {
            switch (region)
            {
                case ResizeRegion.N:
                case ResizeRegion.S:
                    Cursor = Cursors.SizeNS;
                    break;

                case ResizeRegion.E:
                    Cursor = Cursors.SizeWE;
                    break;
                case ResizeRegion.W:

                case ResizeRegion.NW:
                case ResizeRegion.SE:
                    Cursor = Cursors.SizeNWSE;
                    break;

                default:
                    Cursor = Cursors.Default;
                    break;
            }
        }

        private void AdjustPosition(int interval, Keys keys)
        {
            switch(keys)
            {
                case Keys.Left:
                    Left = Left - interval;
                    break;
                case Keys.Right:
                    Left = Left + interval;
                    break;
                case Keys.Up:
                    Top = Top - interval;
                    break;
                case Keys.Down:
                    Top = Top + interval;
                    break;
            }
        }

        private void AdjustSize(int interval, Keys keys)
        {
            switch(keys)
            {
                case Keys.Left:
                    Width = Width - interval;
                    break;
                case Keys.Right:
                    Width = Width + interval;
                    break;
                case Keys.Up:
                    Height = Height - interval;
                    break;
                case Keys.Down:
                    Height = Height + interval;
                    break;
            }
        }


        #endregion

        #region Event Overrides

        protected override void OnResize(EventArgs e)
        {            
            _middleX = (VisibleWidth / 2) + TRANS_BORDER_WIDTH;
            _middleY = (VisibleHeight / 2) + TRANS_BORDER_WIDTH;

            if(VisibleWidth <= 1)
                VisibleWidth = 1;
            if(VisibleHeight <= 1)
                VisibleHeight = 1;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
			CheckForDialogClosing();
            HandleMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            HandleMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            HandleMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintUI(e.Graphics, e);
        }

		protected override void OnKeyDown(KeyEventArgs e)
		{
			HandleKeyDown(e);
		}
		protected override void OnDoubleClick(EventArgs e)
		{
			TakeScreenShot();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Configuration config = new Configuration(_imageFormat, _userOpacity, _maxThumbSize, this.Location, ClientSize);
			config.Save();
			base.OnClosing (e);
		}

		private void HandleKeyDown(KeyEventArgs e)
		{

			int interval;
			if(e.Control) 
				interval = 10;
			else
				interval = 1;
			
			switch(e.KeyCode)
			{
				case Keys.Enter:
					TakeScreenShot();
					e.Handled = true;
					break;
				case Keys.Escape:
					this.Close();
					e.Handled = true;
					break;
				case Keys.Tab:
					InvertColors();
					e.Handled = true;
					break;
				case Keys.OemOpenBrackets:
					if(e.Alt)
						ResizeThumbnail(interval);
					else
						CenterSize(10);
					e.Handled = true;
					break;
				case Keys.OemCloseBrackets:
					if(e.Alt)
						ResizeThumbnail(-interval);
					else
						CenterSize(-10);
					e.Handled = true;
					break;
			}

			if(e.Alt)
				AdjustSize(interval, e.KeyCode);
			else
				AdjustPosition(interval, e.KeyCode);
		}
        private void HandleMouseUp(MouseEventArgs e)
        {
            _resizeRegion = ResizeRegion.None;
        }

        private void HandleMouseDown(MouseEventArgs e)
        {
			_offset = new Point(MousePosition.X - Location.X, MousePosition.Y - Location.Y);
			_mouseDownRect = ClientRectangle;
            _mouseDownPoint = MousePosition;

			if(IsInResizeArea())
			{
				_resizeRegion = GetResizeRegion();
				SetResizeCursor(_resizeRegion);
			}
        }

        private void HandleMouseMove(MouseEventArgs e)
        {
            if (_resizeRegion != ResizeRegion.None)
            {
				HandleResize();
            }
            else
            {
				if (e.Button == MouseButtons.Left)
					Location = new Point(MousePosition.X - _offset.X, MousePosition.Y - _offset.Y);
			
                if(IsInResizeArea() && e.Button != MouseButtons.Left)
                    SetResizeCursor(GetResizeRegion());
                else if (_resizeRegion == ResizeRegion.None)
                    Cursor = Cursors.Default;
            }            
        }


        #endregion

        #region Painting

        private void PaintUI(Graphics graphics, PaintEventArgs e)
        {         
            Point[] points = {_point1, _point2, _point3, _point4, _point5, _point6};
            graphics.FillPolygon(this._tabBrush, points); 

            Rectangle form = e.ClipRectangle;
            Rectangle area = VisibleClientRectangle;

            Region formRegion = new Region(form);
            Region areaRegion = new Region(area);

            formRegion.Complement(areaRegion);

            //Main Area
            //
            graphics.FillRegion(this._areaBrush, areaRegion);
			formRegion.Dispose();
			areaRegion.Dispose();

			Pen linePen = new Pen(this._textBrush);
            graphics.DrawRectangle(
                linePen, area);
 
			if(_isThumbnailed)
			{
				double thumbRatio;
				if(VisibleHeight > VisibleWidth)
					thumbRatio = VisibleHeight / _maxThumbSize;
				else
					thumbRatio = VisibleWidth / _maxThumbSize;
				_thumbnailWidth = Convert.ToInt32(VisibleWidth/thumbRatio);
				_thumbnailHeight = Convert.ToInt32(VisibleHeight/thumbRatio);

				if(VisibleWidth > (_thumbnailWidth + 30) && VisibleHeight > (_thumbnailHeight + 30))
				{
					string size = _thumbnailWidth + "x" + _thumbnailHeight;
					string max = _maxThumbSize + " px max";
					SizeF dimensionSize = graphics.MeasureString(size, _feedbackFont);
					SizeF maxSize = graphics.MeasureString(max, _feedbackFont);
				
					graphics.DrawString(
						max, 
						_feedbackFont, 
						_textBrush, 
						_middleX - (maxSize.Width / 2), 
						_middleY - (_thumbnailHeight / 2) - maxSize.Height);

					graphics.DrawString(
						size, 
						_feedbackFont, 
						_textBrush, 
						_middleX - (dimensionSize.Width / 2), 
						_middleY + (_thumbnailHeight / 2));

					_thumbRectangle = new Rectangle(
						_middleX - (_thumbnailWidth / 2),
						_middleY - (_thumbnailHeight / 2), 
						_thumbnailWidth,
						_thumbnailHeight);

					graphics.DrawRectangle(
						linePen, _thumbRectangle);
				}
			}

            if(VisibleWidth > 30 & VisibleHeight > 30)
            {
                graphics.DrawLine(
                    linePen, 
                    _middleX, 
                    (_middleY) + 10, 
                    _middleX, 
                    (_middleY) - 10 );

                graphics.DrawLine(
                    linePen, 
                    (_middleX) + 10, 
                    _middleY, 
                    (_middleX) - 10, 
                    _middleY );
            }
			linePen.Dispose();

            // Width String
            //
            graphics.DrawString(
                VisibleWidth + " px", 
                _feedbackFont, 
                _textBrush, 
                TRANS_BORDER_WIDTH, 
                TRANS_BORDER_WIDTH - 15);

            // Height String
            //
            graphics.RotateTransform(90);
            graphics.DrawString( 
                VisibleHeight + " px",  
                _feedbackFont, 
                _textBrush,  
                TRANS_BORDER_WIDTH, 
                -TRANS_BORDER_WIDTH);
        }

		private void DrawAbout()
		{
			DrawDialog("About Cropper v" + Application.ProductVersion, 
				"Copyright © 2004\nBrian Scott\nblogs.geekdojo.net/Brian\n\n" +
				"GUI  inspired by Ruler\nCopyright © 2004, Jeff Key\nwww.sliver.com");
		}

		private void DrawHelp()
		{
			DrawDialog("Help", 
				"Screenshot: DblClick or Enter\nMove: Arrow Keys\nResize: Alt + Arrow Keys\n" + 
				"Move/Resize 10px: +Ctrl\n\nRecord: Saves continous images\nImages: In Desktop/Cropper");
		}

		private void DrawDialog(string title, string text)
		{
			_userSizes[0] = ClientSize;
			if(VisibleWidth < 230 | VisibleHeight < 180)
			{
				VisibleClientSize = new Size(230, 180);
			}

			Application.DoEvents();

			Opacity = .9;
			Graphics g = this.CreateGraphics();

			StringFormat format = new StringFormat(StringFormatFlags.NoClip);
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;            
            
			Rectangle aboutRectangle = new Rectangle((Width/2) - 90, (Height/2) - 60, 180, 120);
            
			// Box
			//
			g.FillRectangle(Brushes.SteelBlue, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			//Contents
			//
			aboutRectangle.Inflate(-5, -5);
			aboutRectangle.Y = aboutRectangle.Y + 5;

			Font textFont = new Font("Tahoma", 8f);
			//Draw text
			//
			g.DrawString(text, 
				textFont, 
				Brushes.White, 
				aboutRectangle,
				format);

			//Title
			//
			aboutRectangle.Inflate(5, -47);
			aboutRectangle.Y = (Height/2) - 60;
			g.FillRectangle(Brushes.Black, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			aboutRectangle.Inflate(-5, 0);
			g.DrawString(title, 
				textFont, 
				Brushes.White, 
				aboutRectangle,
				format);

			//Close
			//
			aboutRectangle.Inflate(-78, 0);
			aboutRectangle.X = (Width/2) + 76;
			g.FillRectangle(Brushes.Red, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			StringFormat closeFormat = new StringFormat(StringFormatFlags.NoClip|StringFormatFlags.DirectionVertical);
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;
       
			Font closeFont = new Font("Verdana", 10.5f, FontStyle.Bold);
			aboutRectangle.Inflate(3, -1);
			g.DrawString("X", 
				closeFont, 
				Brushes.White, 
				aboutRectangle,
				closeFormat);

			_closeRectangle = aboutRectangle;
			format.Dispose();
			closeFormat.Dispose();
			textFont.Dispose();
			closeFont.Dispose();
		}


        #endregion

		#region Screenshot Methods

		private void TakeScreenShot()
		{
			Image image = null;
			CaptureOutput captureOutput = null;
			try
			{      
				image = Desktop.GetBitmap(VisibleLeft, VisibleTop, VisibleWidth, VisibleHeight);
				captureOutput = new CaptureOutput(image);
				switch(_imageFormat)
				{
					case "Clipboard":
						captureOutput.SaveToClipboard();
						break;
					case "Printer":
						captureOutput.Print();
						break;
					default:
						bool thumbnail = _isThumbnailed;
						if(VisibleWidth < (_thumbnailWidth + 31) || VisibleHeight < (_thumbnailHeight + 31))
							thumbnail = false;
						captureOutput.SaveToFile(_imageFormat, _maxThumbSize, thumbnail);
						break;
				}
			}
			finally
			{
				if(null != image)
					image.Dispose();
				if(null != captureOutput)
					captureOutput.Dispose();
			}                 
		}

		private void Recording(bool record)
		{
			if(record)
			{
				_recordTimer.Interval = 15;
				_recordTimer.Tick +=new EventHandler(_recordTimer_Tick);
				_recordTimer.Start();
			}
			else
			{
				_recordTimer.Stop();
			}
		}

		#endregion

		#region Event Handlers

		private void _recordTimer_Tick(object sender, EventArgs e)
		{
			TakeScreenShot();
		}

		private void NotifyIcon_MouseUp(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				ContextMenu.MenuItems[1].Visible = true;
				ContextMenu.MenuItems[2].Visible = false;
				Visible = true;
				Activate();
			}
		}
		

		#endregion

		#region Menu Handling

		/// <summary>
		/// Setup the main context menu
		/// </summary>
		private void SetUpMenu()
		{
			AddMenuItem("Always On Top");
			AddMenuItem("Hide");
			AddMenuItem("Show").Visible = false;            
			AddMenuItem("Reset");
			AddMenuItem("-");
			MenuItem opacityMenuItem = AddMenuItem("Opacity");            
			_outputMenuItem = AddMenuItem("Output");
			AddMenuItem("Thumbnail");
			AddMenuItem("Invert");
			AddMenuItem("-");
			AddMenuItem("Record");
			AddMenuItem("-");
			AddMenuItem("Help");
			AddMenuItem("About");
			AddMenuItem("-");
			AddMenuItem("Exit");

			MenuItem subMenu;
			for (int i = 10; i <= 100; i += 10)
			{
				subMenu = new MenuItem(i + "%");
				subMenu.RadioCheck = true;
				subMenu.Click += new EventHandler(OpacityMenuHandler);
				opacityMenuItem.MenuItems.Add(subMenu);
				if(i == _userOpacity * 100)
					subMenu.Checked = true;
			}			

			AddImageMenuItem("Bmp", _outputMenuItem);
			MenuItem jpegMenuItem = AddImageMenuItem("Jpeg", _outputMenuItem);
			AddImageMenuItem("Png", _outputMenuItem);
			AddImageMenuItem("Clipboard", _outputMenuItem);
			AddImageMenuItem("Printer", _outputMenuItem);

			subMenu = new MenuItem("Quality");
			subMenu.RadioCheck = false;
			subMenu.Enabled = false;
			jpegMenuItem.MenuItems.Add(subMenu);
			AddImageMenuItem("-", jpegMenuItem);
			for (int j = 10; j <= 100; j += 10)
			{
				AddImageMenuItem(j.ToString(), jpegMenuItem);
			}
		}

        private MenuItem AddImageMenuItem(string text, MenuItem parent)
		{
			MenuItem subMenu = new MenuItem(text);
			subMenu.RadioCheck = true;
			if(text == _imageFormat)
				subMenu.Checked = true;
			subMenu.Click +=new EventHandler(ImageMenuHandler);
			parent.MenuItems.Add(subMenu);
			return subMenu;
		}

		private MenuItem AddMenuItem(string text)
		{
			MenuItem mi = new MenuItem(text);
			mi.Click += new EventHandler(MainMenuHandler);
			_menu.MenuItems.Add(mi);

			return mi;
		}

		private void MainMenuHandler(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;

			switch (mi.Text)
			{
				case "Exit":
					Close();
					break;
				case "Always On Top":					
					TopMost = mi.Checked = !mi.Checked;
					break;
				case "Hide":
					ContextMenu.MenuItems[1].Visible = false;
					ContextMenu.MenuItems[2].Visible = true;
					Visible = false;
					break;
				case "Show":
					ContextMenu.MenuItems[1].Visible = true;
					ContextMenu.MenuItems[2].Visible = false;
					Visible = true;
					break;
				case "Invert":
					InvertColors();
					break;
				case "Thumbnail":
					_isThumbnailed = mi.Checked = !mi.Checked;
					Invalidate();
					break;
				case "Reset":
					ResetForm();
					break;
				case "Record": 
					mi.Checked = _isRecording = !_isRecording;
					Recording(_isRecording);
					break;
				case "Help":                    
					DrawHelp();
					break;
				case "About":                    
					DrawAbout();
					break;
				default:
					MessageBox.Show("Unknown menu item.");
					break;
			}
		}

		private void ResetForm()
		{
			VisibleWidth = 180;
			VisibleHeight = 180;
			VisibleLeft = 100;
			VisibleTop = 100;
			Opacity = 0.45;
		}

		private void OpacityMenuHandler(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;
			foreach(MenuItem item in mi.Parent.MenuItems)
				item.Checked = false;
			mi.Checked = true;

			Opacity = double.Parse(mi.Text.Replace("%", "")) / 100;
			_userOpacity = this.Opacity;
		}

		private void ImageMenuHandler(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;
			foreach(MenuItem sibling in _outputMenuItem.MenuItems)
				if(sibling.IsParent)
					foreach(MenuItem subSibling in sibling.MenuItems)
						subSibling.Checked = false;
				else
					sibling.Checked = false;

			mi.Checked = true;
			_imageFormat = mi.Text;
		}

		private void ThumbnailMenuHandler(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;
			foreach(MenuItem sibling in mi.Parent.MenuItems)
				sibling.Checked = false;
			mi.Checked = true;
			_imageFormat = mi.Text;     
		}


		#endregion
	}
}
