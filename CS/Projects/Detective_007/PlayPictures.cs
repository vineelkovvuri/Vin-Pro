using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Detective_007
{
    public partial class PlayPictures : Form
    {
        public PlayPictures()
        {
            InitializeComponent();
            
        }
        public void ShowScreenCaptures(String path) {
            int i = 0;
            Thread t = new Thread(delegate() {
                this.Text = "Start of Captured Images...!";
                DirectoryInfo d = new DirectoryInfo(path);
                foreach (FileInfo f in d.GetFiles("*.bmp")) {
                    this.Text = "Captured Image "+(++i) ;
                    pb1.Image = Bitmap.FromFile(f.FullName);
                    Thread.Sleep(3000);

                }
                
                this.Text = "End of Captured Images...!";
                pb1.Image = null;
                GC.Collect();
            });
            t.Start();
        }
    }
}