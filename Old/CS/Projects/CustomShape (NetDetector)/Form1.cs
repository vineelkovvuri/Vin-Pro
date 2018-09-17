using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using QuartzTypeLib;
using System.IO;
using System.Net.NetworkInformation;
namespace CustomShape
{
    public partial class Form1 : Form
    {

        static Ping p = new Ping();
        static PingReply pr;
        static bool c=true;
        static System.Windows.Forms.Timer ti;
        public static bool IsInternetConnected()
        {
            if (c)
            {
                ti.Interval = 5*60*1000;
                c = !c;
            }
            
                pr = p.Send("202.138.96.2");
                return pr.Status == IPStatus.TimedOut ? false : true;
        }

        public Form1()
        {

            InitializeComponent();
            width = Screen.GetWorkingArea(this).Width;
            height = Screen.GetWorkingArea(this).Height;
            fwidth = this.Width;
            fheight = this.Height;
            this.Location = new Point(width - fwidth, height - 0);

            ti = timer;
            
            sw = new StreamWriter(@"d:\Internet_Statstics.txt", true);
            sw.WriteLine("\n");
            sw.Write("System Started At : ");
            sw.WriteLine(DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToLongDateString());
            sw.WriteLine("===========================================================");
            sw.WriteLine("\n");
            sw.Close();
        }
        int k = 0, t = 0, sec = 0;
        StreamWriter sw;
        void timer_Tick(object sender, EventArgs e)
        {

            try
            {

                if (!IsInternetConnected())
                {
                    if (k == 0)
                    {
                        lNetStatus.Text = "Net Status:  Disconnected ";
                        lTime.Text = "Event occured at:  " + DateTime.Now.ToLongTimeString();
                        tt = new Thread(show);
                        tt.Start();
                        Play();
                        sw = new StreamWriter(@"d:\Internet_Statstics.txt", true);
                        sw.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        sw.WriteLine("{0,-20} {1} {2} ", "Disconnected :  ", DateTime.Now.ToLongTimeString(),
                                     DateTime.Now.ToLongDateString());
                        sw.Close();
                        k = 1;
                        t = 0;
                        sec = 0;
                        lTimeLapsed.Text = "Duration:  ";
                    }

                    il1.Draw(this.CreateGraphics(), new Point(163, 27), 1);

                }
                else
                {
                    if (t == 0)
                    {
                        lNetStatus.Text = "Net Status:  Connected ";
                        lTime.Text = "Event occured at:  " + DateTime.Now.ToLongTimeString();

                        tt = new Thread(show);
                        tt.Start();
                        Play();
                        sw = new StreamWriter(@"d:\Internet_Statstics.txt", true);
                        sw.WriteLine("{0,-20} {1} {2} ", "Reconnected :  ", DateTime.Now.ToLongTimeString(),
                                     DateTime.Now.ToLongDateString());
                        sw.WriteLine("                           ================================");
                        sw.WriteLine("                           Total Disconnected Time : " + GetTime(sec));
                        sw.WriteLine("                           ================================");
                        sw.Close();
                        t = 1;
                        k = 0;
                        sec = 0;
                        lTimeLapsed.Text = "Duration:  ";
                    }
                    il1.Draw(this.CreateGraphics(), new Point(163, 27), 0);
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message + "   " + e1.Source + "  " + e1.StackTrace);
            }
        }
        private void Play()
        {
            QuartzTypeLib.FilgraphManager mc = new QuartzTypeLib.FilgraphManager();
            try
            {
                mc.RenderFile("pow.wav");
                mc.Run();
            }
            catch { }
        }


        private string GetTime(long p)
        {
            long h = 0, m = 0, s = 0;
            h = p / 3600;
            m = (p % 3600) / 60;
            s = ((p % 3600) % 60);

            return h + ":" + m + ":" + s;

        }
        Thread tt;
        int width, height, fwidth, fheight;
        private void show()
        {
            lock (this)
            {
                for (int i = 0; i <= fheight; i += 3)
                {
                    this.Location = new Point(width - fwidth, height - i);
                    this.Opacity = i / (double)fheight;
                }
            }
        }


        private void exit()
        {
            lock (this)
            {
                for (int i = 0; i <= 180; i += 3)
                {
                    this.Location = new Point(width - fwidth + i, height - fheight);
                    this.Opacity = (180 - i) / (double)180;
                    Thread.Sleep(10);
                }
            }
        }

        private void pbexit_Click(object sender, EventArgs e)
        {
            tt = new Thread(exit);
            tt.Start();
        }

        private void ni1_DoubleClick(object sender, EventArgs e)
        {
            tt = new Thread(show);
            tt.Start();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tGC_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void timeLaps_Tick(object sender, EventArgs e)
        {
            lTimeLapsed.Text = "Duration:  " + GetTime(sec++);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}