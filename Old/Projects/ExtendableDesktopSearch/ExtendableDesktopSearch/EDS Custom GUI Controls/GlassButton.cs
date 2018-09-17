using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ExtendableDesktopSearch
{
    class GlassButton:Button
    {
        public GlassButton()
        {
            this.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BackgroundImageLayout = ImageLayout.Center;
            this.BackgroundImage = ExtendableDesktopSearch.Properties.Resources.MouseOut;
            this.Text = "Search";
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            //this.Image = ExtendableDesktopSearch.Properties.Resources.SearchButton_24x24;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackgroundImage = ExtendableDesktopSearch.Properties.Resources.MouseOver;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackgroundImage = ExtendableDesktopSearch.Properties.Resources.MouseOut;
        }
    }
}
