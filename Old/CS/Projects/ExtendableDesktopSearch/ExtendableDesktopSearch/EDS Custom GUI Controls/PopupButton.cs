using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ExtendableDesktopSearch
{
    class PopupButton : RadioButton
    {
        public PopupButton()
        {
            this.Appearance = Appearance.Button;
            this.Cursor = Cursors.Hand;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.White;
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(227, 226, 219);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 245, 241);
            this.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            this.Size = new Size(80, 62);
            this.ImageAlign = ContentAlignment.TopCenter;
            this.TextAlign = ContentAlignment.BottomCenter;
            this.UseVisualStyleBackColor = true;

            this.AutoSize = false;
            this.AutoEllipsis = true;
        }


    }
}
