using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ExtendableDesktopSearch
{
    class EDSToolTip : ToolTip
    {
        public EDSToolTip()
        {
            this.InitialDelay = 1000;
            this.OwnerDraw = true;
            this.Draw += new DrawToolTipEventHandler(EDSToolTip_Draw);
        }

        private Image image;

        public void Show(string text, Image image, IWin32Window window)
        {
            this.image = image;
            base.Show(text, window);
        }
        void EDSToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (e.ToolTipText.Trim() != "")
            {
                //e.DrawBackground();
                Graphics g = e.Graphics;

                //draw background
                LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(Point.Empty, e.Bounds.Size), Color.FromArgb(250, 252, 253), Color.FromArgb(206, 220, 240), LinearGradientMode.Vertical);
                g.FillRectangle(lgb, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                lgb.Dispose();

                //Console.WriteLine(e.ToolTipText);

                //draw border
                ControlPaint.DrawBorder(g, e.Bounds, SystemColors.GrayText, ButtonBorderStyle.Dashed);
                //draw Image
                g.DrawImage(image, new Point(5, 5));


                // Draw the custom text.
                // The using block will dispose the StringFormat automatically.
                using (StringFormat sf = new StringFormat())
                {
                    using (Font f = new Font("Tahoma", 8))
                    {
                        e.Graphics.DrawString(e.ToolTipText, f,
                            Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 30, StringFormat.GenericTypographic);
                    }
                }
            }
        }
    }
}
