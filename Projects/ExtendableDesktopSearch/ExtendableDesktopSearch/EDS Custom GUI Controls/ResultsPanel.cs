using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Design;
namespace ExtendableDesktopSearch
{
    class ResultsPanel : Panel
    {
        public ResultsPanel()
        {
            this.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int width = this.Width - 8, height = this.Height - 8;
            int x = 8, y = 8;
            //Draw border rectangle  
            Pen p = new Pen(Color.FromArgb(222, 199, 65), 1);
            GraphicsHelper.DrawRoundRect(g, p, x - 2, y - 2, width - 4, height - 4, 10);
            p.Dispose();
            //Draw inner rectangle  //  
            SolidBrush sb = new SolidBrush(Color.FromArgb(245, 240, 217));
            GraphicsHelper.FillRoundRect(g, sb, x - 1, y - 1, width - 7, height - 7, 10);
            sb.Dispose();

            //Draw Header
            SolidBrush sb2 = new SolidBrush(Color.White);
            GraphicsHelper.FillSemiRoundRect(g, sb2, x - 1, y - 1, width - 7, 40, 10);
            sb2.Dispose();

            //Draw caption 
            TextFormatFlags flags =  TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(g, this.Caption, new Font("Tahoma", 10, FontStyle.Bold),
            new Rectangle(50, 5, this.Width, 35), SystemColors.ControlText, flags);

            //Draw Image
            if (_CaptionImage != null)
            {
                ImageList im = new ImageList();
                im.Images.Add(_CaptionImage);
                g.DrawImage(_CaptionImage, new Rectangle(18, 8, 32, 32));
            }

            base.OnPaint(e);
        }

        private Image _CaptionImage = null;
        [Category("Behavior")]
        [Description("Changes the header display image of the panel")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(BitmapEditor), typeof(UITypeEditor))]
        public Image CaptionImage
        {
            get
            {
                return _CaptionImage;
            }
            set
            {
                if (value != null)
                {
                    _CaptionImage = value;
                    this.Update();
                }
            }
        }
        private string _Caption = "Results";
        [Category("Behavior")]
        [Description("Changes the head caption of the panel")]
        //  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                if (value != null)
                {
                    _Caption = value;
                    this.Update();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Parent.Parent.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            base.OnMouseDown(e);
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    }
}
