using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
namespace ImageFormatConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i <= 100; i += 3)
            {
                Opacity = i * 0.01;
                Update();

            }
        }

        string[] files = new string[1000];
        string SaveDir = "";
        bool open = false;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();

            od.Filter = "Jpeg(*.jpg) |*.jpg" + "|PNG (*.png)|*.png"
                          + "|BMP (*.bmp)|*bmp" + "|Icon (*.ico)|*.ico"
                          + "|GIF (*.gif)|*.gif" + "|Tiff (*.tif)|*.tif"
                          + "|EMF (*.emf)|*.emf " + "|WMF (*.wmf)|*.wmf"
                          + "|All Picture Files(*.jpg;*.png;*.bmp;*.ico;*.gif;*.tif;*.emf;*.wmf)|"
                          + "*.jpg;*.png;*.bmp;*.ico;*.gif;*.tif;*.emf;*.wmf";
            od.InitialDirectory=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            od.RestoreDirectory = false;    
            od.Multiselect = true;
            if (od.ShowDialog() == DialogResult.OK)
            {files = od.FileNames; open = true;}
        }
      

        private void start_Click(object sender, EventArgs e)
        {
            if (open)
            {
                if (!bmp.Checked && !gif.Checked && !ico.Checked && !jpeg.Checked && !png.Checked && !tif.Checked && !emf.Checked && !wmf.Checked)
                    MessageBox.Show("Select a Picture Format yar....!", "From My Bose");
                else
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.RootFolder = Environment.SpecialFolder.Desktop;
                    fbd.Description = "Tell Me Where To Save The Converted Files";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        if (fbd.SelectedPath.Equals(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
                            SaveDir = fbd.SelectedPath + "\\";
                        else SaveDir = fbd.SelectedPath;


                        Thread t1 = new Thread(new ThreadStart(ImageConvert));
                        t1.Start();
                        Thread t2 = new Thread(new ThreadStart(icon));
                        t2.Start();
                    }
                }
            }
            else MessageBox.Show("First select the Images for Convertion","********");
            
        }
        public void ImageConvert()
        {
            Image i;
            string save;
            DirectoryInfo dir;
            
            foreach (string s in files)
            {
                i = Image.FromFile(s);
                dir = new DirectoryInfo(s);
                save = dir.Name;
                if (bmp.Checked&&!s.EndsWith("bmp")) i.Save(SaveDir+save.Remove(save.Length - 3, 3) + "bmp", ImageFormat.Bmp);
                if (gif.Checked && !s.EndsWith("gif")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "gif", ImageFormat.Gif);
                if (ico.Checked && !s.EndsWith("ico")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "ico", ImageFormat.Icon);
                if (jpeg.Checked && !s.EndsWith("jpg")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "jpg", ImageFormat.Jpeg);
                if (png.Checked && !s.EndsWith("png")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "png", ImageFormat.Png);
                if (tif.Checked && !s.EndsWith("tif")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "tif", ImageFormat.Tiff);
                if (emf.Checked && !s.EndsWith("emf")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "emf", ImageFormat.Emf);
                if (wmf.Checked && !s.EndsWith("wmf")) i.Save(SaveDir + save.Remove(save.Length - 3, 3) + "wmf", ImageFormat.Wmf);
            }

        }

        public  void icon()
        {
            
            vineel.ShowBalloonTip(15);
            
        }


        private void exit_Click(object sender, EventArgs e)
        {

            for (int i = 100; i >=0; i-=3)
            {
                Opacity = i * .01;
                Update();
                
            }
            vineel.Visible = false;
            Close();
        }



    }
}