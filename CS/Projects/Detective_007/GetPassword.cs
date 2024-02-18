using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Detective_007
{
    public partial class GetPassword : Form
    {
        public GetPassword()
        {
            InitializeComponent();
        }
        public String password;
        bool firstTime, changePassword;

        public void ShowPasswordDialog(bool firstTime, bool changePassword)
        {
            this.firstTime = firstTime;
            this.changePassword = changePassword;
            tbOldPassword.Text = tbConfirmPassowrd.Text = tbPassword.Text = "";

            if (firstTime)
            {
                this.Text = "Enter your new password.....";
                tbOldPassword.Enabled = false;
                tbConfirmPassowrd.Enabled = true;

            }
            else if (changePassword)
            {
                this.Text = "Change your password.....";
                tbOldPassword.Enabled =
                tbConfirmPassowrd.Enabled = true;
            }
            else
            {
                this.Text = "Enter the password.....";
                tbOldPassword.Enabled = false;
                tbConfirmPassowrd.Enabled = false;
            }

        }

        public DialogResult result = DialogResult.Cancel;
        private void tbConfirmPassowrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (firstTime)
                {
                    if (!string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrEmpty(tbConfirmPassowrd.Text))
                    {
                        if (tbPassword.Text != tbConfirmPassowrd.Text)
                        {
                            this.Text = "Password Mismatch....!";
                            result = DialogResult.Cancel;
                            tbConfirmPassowrd.Text = tbPassword.Text = "";
                        }
                        else
                        {
                            result = DialogResult.OK;
                            password = tbPassword.Text;
                            this.Close();
                        }
                    }
                }
                else if (changePassword)
                {
                    if (!string.IsNullOrEmpty(tbOldPassword.Text) && !string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrEmpty(tbConfirmPassowrd.Text))
                    {
                        if (tbOldPassword.Text == password && tbPassword.Text == tbConfirmPassowrd.Text)
                        {
                            password = tbPassword.Text;
                            result = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            this.Text = "Password Mismatch....!";
                            result = DialogResult.Cancel;
                            tbOldPassword.Text = tbConfirmPassowrd.Text = tbPassword.Text = "";
                        }

                    }
                }
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!firstTime && !changePassword)
            {
                if (e.KeyData == Keys.Enter)
                {

                    if (!string.IsNullOrEmpty(tbPassword.Text))
                    {
                        if (tbPassword.Text == password)
                        {
                            result = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            this.Text = "Password Mismatch....!";
                            result = DialogResult.Cancel;
                            tbConfirmPassowrd.Text = tbPassword.Text = "";
                        }
                    }
                }
            }
        }

        private void GetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!firstTime && !changePassword && tbPassword.Text != password)
                //    e.Cancel = true;
                result = DialogResult.Cancel;
        }

        private void GetPassword_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            {
                int width = this.Width - 30, height = this.Height - 65;
                int x = 10, y = 15;
                //Pen p = new Pen(Color.FromArgb(222, 199, 65), 1);
                //SolidBrush sb = new SolidBrush(Color.FromArgb(255, 251, 236));
                //g.FillRectangle(sb, new Rectangle(x, y, width, height));
                //g.DrawRectangle(p, new Rectangle(x - 1, y - 1, width + 2, height + 2));
                //sb.Dispose();
                //p.Dispose();
                Pen p = new Pen(Color.FromArgb(222, 199, 65), 1);
                Helper.DrawRoundRect(g, p, x - 2, y - 2, width + 4, height + 4, 10);
                p.Dispose();

                SolidBrush sb = new SolidBrush(Color.FromArgb(255, 251, 236));
                Helper.FillRoundRect(g, sb, x - 1, y - 1, width, height + 2, 10);
                sb.Dispose();
            }
        }

        #region moving a form when dragged in client area
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void GetPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

     

        private void GetPassword_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //Translate the screen coordinates to client coordinates..........
            Point p = this.PointToClient(hlpevent.MousePos);
            Control b = FindControl(this, p);
            if (b != null)
            {
                if (b == tbOldPassword || b == label1)
                {
                    ttHelp.Show("previously set password for sealth mode ", b,5000);
                }
                else if (b == tbPassword || b == label2)
                {
                    ttHelp.Show("Enter new password for sealth mode ", b,5000);
                }
                else if (b == tbConfirmPassowrd || b == label3)
                {
                    ttHelp.Show("Confirm newly entered password by reentering here", b,5000);
                }
            }
                
            hlpevent.Handled = true;
        }
        private Control FindControl(Control parent, Point p)
        {
            Control c = parent.GetChildAtPoint(p);
            if (c == null) return parent;
            p = new Point(p.X - c.Location.X, p.Y - c.Location.Y);
            return FindControl(c, p);
        }
    }
}