using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace TaskBar_Icon_Change
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int k = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            this.UpdateTaskBar(k++);
        }

        //must be used to destroy the icon.
        [DllImport("user32.dll", EntryPoint = "DestroyIcon")]
        static extern bool DestroyIcon(IntPtr hIcon);

        private void UpdateTaskBar(int i)
        {
            // Create a graphics instance that draws to a bitmap
            Bitmap bitmap = new Bitmap(16, 16);
            SolidBrush brush = new SolidBrush(Color.Black);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawString(i + "", this.Font, brush, 0, 0);

            // Convert the bitmap into an icon and use it for the system tray icon
            IntPtr hIcon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            notifyIcon1.Icon = icon;
            // unfortunately, GetHicon creates an unmanaged handle which must be manually destroyed
            DestroyIcon(hIcon);
        }
    }
}