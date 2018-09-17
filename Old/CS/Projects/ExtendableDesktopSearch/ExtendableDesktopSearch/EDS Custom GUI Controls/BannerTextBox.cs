using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ExtendableDesktopSearch
{
    class BannerTextBox:TextBox
    {
        private Button _Submit; //this button ll be called when enter key is pressed
        public BannerTextBox()
        {
            this.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public Button Submit
        {
            get { return _Submit; }
            set
            {
                _Submit = value;
            }
        }

        //To override the Enter Key behaviour when autocomplete is enabled
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.Text.Trim() != "" && !this.AutoCompleteCustomSource.Contains(this.Text.Trim()))
                    this.AutoCompleteCustomSource.Add(this.Text.Trim());
                if (Submit != null)
                {
                    Submit.PerformClick();
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        #region NativeMethods

        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
        private const uint WM_SETFONT = 0x30;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, string lParam);

        #endregion

        private string _bannerText;

        /// The banner text associated with the control.
        [Description("The banner text associated with the control.")]
        [Category("Appearance")]
        public string BannerText
        {
            get { return _bannerText; }
            set
            {
                _bannerText = value;

                // If supported set the value as banner text.
                if (IsSupported)
                    SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, value);
            }
        }

        #region Overridden Members
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            // Notify the text box to change the font to the banner font.
            if (this.Text.Length == 0 && IsSupported)
            {
                // SendMessage(this.Handle, WM_SETFONT, base.Font.ToHfont(), null);
                SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, BannerText);
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            // Notify the text box to change the font back.
            if (IsSupported)
                //  SendMessage(this.Handle, WM_SETFONT, base.Font.ToHfont(), null);
                SendMessage(this.Handle, EM_SETCUEBANNER, IntPtr.Zero, null);
        }
        #endregion

        /// Returns whether the OS supports banner texts. It is fine if the application
        /// runs on XP or higher.
        private bool IsSupported
        {
            get
            {
                Version v = Environment.OSVersion.Version;
                return ((v.Major == 5 && v.Minor == 1) || v.Major > 5);
            }
        }
    }
}
