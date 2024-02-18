using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
namespace ExtendableDesktopSearch
{
    class NumericTextBox : BannerTextBox
    {

        public NumericTextBox()
        {
           // this.Font = new Font(this.Font, FontStyle.Italic);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Ignore all non-control and non-numeric key presses.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        //#region NativeMethods

        //private const uint ECM_FIRST = 0x1500;
        //private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
        //private const uint WM_SETFONT = 0x30;

        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, string lParam);

        //#endregion

        //private string _bannerText;


        ///// The banner text associated with the control.
        //[Description("The banner text associated with the control.")]
        //[Category("Appearance")]
        //public string BannerText
        //{
        //    get { return _bannerText; }
        //    set
        //    {
        //        _bannerText = value;

        //        // If supported set the value as banner text.
        //        if (IsSupported)
        //            SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, value);
        //    }
        //}

        //#region Overridden Members

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    base.OnLostFocus(e);

        //    // Notify the text box to change the font to the banner font.
        //    if (this.Text.Length == 0 && IsSupported)
        //    {
        //        SendMessage(this.Handle, WM_SETFONT, base.Font.ToHfont(), null);
        //    }
        //}

        //protected override void OnGotFocus(EventArgs e)
        //{
        //    base.OnGotFocus(e);

        //    // Notify the text box to change the font back.
        //    if (IsSupported)
        //        SendMessage(this.Handle, WM_SETFONT, base.Font.ToHfont(), null);
        //}

        //#endregion

        ///// Returns whether the OS supports banner texts. It is fine if the application
        ///// runs on XP or higher.
        //private bool IsSupported
        //{
        //    get
        //    {
        //        Version v = Environment.OSVersion.Version;
        //        return ((v.Major == 5 && v.Minor == 1) || v.Major > 5);
        //    }
        //}
    }
}
