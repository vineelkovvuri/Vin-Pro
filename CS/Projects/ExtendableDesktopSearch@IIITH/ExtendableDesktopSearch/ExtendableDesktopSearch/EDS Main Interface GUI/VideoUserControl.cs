using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Lucene.Net.Search;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;

namespace ExtendableDesktopSearch
{
    public partial class VideoUserControl : UserControl
    {
        #region VideoUserControl Constructor
        public VideoUserControl()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBox cobSizeMetricsInVideo = (ComboBox)this.VideoPropertiesPanel.Controls["cobSizeMetricsInVideo"];
            cobSizeMetricsInVideo.SelectedIndex = 0; //Bytes is the default

            ComboBox cobLengthMetricsInVideo = (ComboBox)this.VideoPropertiesPanel.Controls["cobLengthMetricsInVideo"];
            cobLengthMetricsInVideo.SelectedIndex = 1; //minutes the default


            ComboBox cobDate = (ComboBox)this.VideoPropertiesPanel.Controls["cobDate"];
            cobDate.SelectedIndex = 0;

            PrepareListViewResultsControl();
        }
        #endregion

        #region Code for creating column headers of the results listview
        private void PrepareListViewResultsControl()
        {
            ListViewEx results = this.lvResultsInVideo;

            ColumnHeaderEx ch1 = new ColumnHeaderEx("File Name");
            ch1.Width = 120;
            results.Columns.Add(ch1);

            ColumnHeaderEx ch2 = new ColumnHeaderEx("Path");
            ch2.Width = 220;
            results.Columns.Add(ch2);

            ColumnHeaderEx ch3 = new ColumnHeaderEx("Size (bytes)");
            ch3.Tag = new ColumnState("number", false);
            ch3.Width = 120;
            results.Columns.Add(ch3);

            ColumnHeaderEx ch5 = new ColumnHeaderEx("Duration");
            ch5.Width = 80;
            results.Columns.Add(ch5);

            ColumnHeaderEx ch4 = new ColumnHeaderEx("Date");
            ch4.Tag = new ColumnState("date", false);
            ch4.Width = 80;
            results.Columns.Add(ch4);

            ColumnHeaderEx ch6 = new ColumnHeaderEx("Type");
            results.Columns.Add(ch6);
            ch6.Width = 120;

        }
        #endregion

        #region moving a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void VideoUserControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Parent.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Code for clearing all input fields
        private void lClearInputFieldsInVideo_Click(object sender, EventArgs e)
        {
            TextBox temp;
            foreach (Control c in ((Control)sender).Parent.Controls)
            {
                if ((temp = c as TextBox) != null)
                    temp.Clear();
            }
        }
        #endregion

        #region Stub
        private void cbDateInVideo_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFromInVideo.Enabled = this.dtpToInVideo.Enabled = cobDate.Enabled = cbDateInVideo.Checked;
        }
        #endregion

        #region Code for fetching the results (main code for getting the results)
        List<Hit> hits;
        string queryStatistics = null; // string to hold " of about " + hits.Count + " for " + lStatisticsInDocuments.Text + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
        private void bSearchInVideo_Click(object sender, EventArgs e)
        {
            bSearchInVideo.Enabled = false;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = true;

            StringDictionary queryTerms = new StringDictionary();

            //Validate the parameters

            //Validate file name
            if (this.tbFileNameInVideo.Text.Trim()!="")
            {
                queryTerms.Add("name", this.tbFileNameInVideo.Text.ToLower());
                queryStatistics = "File name: " + this.tbFileNameInVideo.Text;
            }

            //Validate file size
            if (this.tbSizeFromInVideo.Text.Trim()!="" && this.tbSizeToInVideo.Text.Trim()!="")
            {
                int minSize, maxSize;
                int.TryParse(this.tbSizeFromInVideo.Text, out minSize);
                int.TryParse(this.tbSizeToInVideo.Text, out maxSize);
                if (this.cobSizeMetricsInVideo.SelectedIndex == 1) // if KB is selected
                {
                    minSize *= 1024;
                    maxSize *= 1024;
                }
                else if (this.cobSizeMetricsInVideo.SelectedIndex == 2)// if MB is selected
                {
                    minSize *= 1024 * 1024;
                    maxSize *= 1024 * 1024;
                }
                else if (this.cobSizeMetricsInVideo.SelectedIndex == 3)// if GB is selected
                {
                    minSize *= 1024 * 1024 * 1024;
                    maxSize *= 1024 * 1024 * 1024;
                }
                queryTerms.Add("size", minSize + " " + maxSize);
                queryStatistics = "Size: " + minSize + " - " + maxSize;
            }

            //Validate file date
            if (cbDateInVideo.Checked)
            {
                string from;
                DateTime minDate = dtpFromInVideo.Value;
                from = minDate.Year + "";
                if (minDate.Month < 10) from += "0" + minDate.Month;
                else from += minDate.Month;
                if (minDate.Day < 10) from += "0" + minDate.Day;
                else from += minDate.Day;

                string to;
                DateTime maxDate = dtpToInVideo.Value;
                to = maxDate.Year + "";
                if (maxDate.Month < 10) to += "0" + maxDate.Month;
                else to += maxDate.Month;
                if (maxDate.Day < 10) to += "0" + maxDate.Day;
                else to += maxDate.Day;

                if (cobDate.SelectedIndex == 0)
                {
                    queryTerms.Add("cdate", from + " " + to);
                    queryStatistics = "Created Date: " + minDate.ToShortDateString() + " - " + maxDate.ToShortDateString();
                }
                else if (cobDate.SelectedIndex == 1)
                {
                    queryTerms.Add("mdate", from + " " + to);
                    queryStatistics = "Modified Date: " + minDate.ToShortDateString() + " - " + maxDate.ToShortDateString();
                }
                else if (cobDate.SelectedIndex == 2)
                {
                    queryTerms.Add("adate", from + " " + to);
                    queryStatistics = "Accessed Date: " + minDate.ToShortDateString() + " - " + maxDate.ToShortDateString();
                }
            }

            //Validate duration
            if (this.tbLengthFromInVideo.Text.Trim()!="" && this.tbLengthToInVideo.Text.Trim()!="")
            {
                string from="", to="";

                if (this.cobLengthMetricsInVideo.SelectedIndex == 0) // if Sec is selected
                {
                    from = tbLengthFromInVideo.Text;
                    if (from.Length < 2) from = "0" + from;
                    from = "00:00:" + from;

                    to = tbLengthToInVideo.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = "00:00:" + to;
                }
                else if (this.cobLengthMetricsInVideo.SelectedIndex == 1)// if Min is selected
                {
                    from = tbLengthFromInVideo.Text;
                    if (from.Length < 2) from = "0" + from;
                    from = "00:" + from + ":00";

                    to = tbLengthToInVideo.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = "00:" + to + ":00";
                }
                else if (this.cobLengthMetricsInVideo.SelectedIndex == 2)// if Hour is selected
                {
                    from = tbLengthFromInVideo.Text;
                    if (from.Length < 2) from = "0" + from;
                    from = from + ":00:00";

                    to = tbLengthToInVideo.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = to + ":00:00";
                }
                queryTerms.Add("length", from + " " + to);
                queryStatistics = "Duration: " + from + " - " + to;
            }

            if (queryTerms.Count != 0) //if a query is given(prevent from searching for not entering anything in the fields)
            {
                //Start Searching........
                long start = DateTime.Now.Ticks;
                EDSQueryEngine queryEngine = new EDSQueryEngine();
                hits = queryEngine.GetDocResults(queryTerms);
                //filter Video files from the results
                string ext;
                List<Hit> temp = new List<Hit>();
                foreach (Hit hit in hits)
                {
                    ext = hit.Get("type");
                    if (GlobalData.VideoFileTypes.Contains(ext + " ") && ext != "") temp.Add(hit);
                }
                hits = temp;
                long end = DateTime.Now.Ticks;
                DateTime dt = new DateTime(end - start);
                if (dt.Second == 0 && dt.Millisecond == 0)
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in 0ms";
                else
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
                pageNum = 0;
                DisplayPage();    // displays the first page of the results

            }
            bSearchInVideo.Enabled = true;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = false;
        }
        #endregion

        #region Code for displaying the results page by page
        int pageNum = 0;
        int pageSize = 100;
        private void DisplayPage()
        {
            lvResultsInVideo.Items.Clear();
            lvResultsInVideo.BeginUpdate();

            //foreach (Hit hit in hits)
            int len = pageSize + pageSize * pageNum;
            if (len > hits.Count) len = hits.Count;
            for (int i = pageSize * pageNum; i < len; i++)
            {
                try
                {
                    string size = hits[i].Get("size").TrimStart('0');
                    ListViewItemEx item = new ListViewItemEx(new string[] { hits[i].Get("name"), hits[i].Get("path"), size == "" ? "0" : size, hits[i].Get("length"), DateTime.ParseExact(hits[i].Get("cdate"), "yyyyMMdd", null).ToString("dd/MM/yyyy"), GlobalData.FileTypes[hits[i].Get("type")] });

                    string ext = hits[i].Get("type");
                    if (ext == ".exe" || ext == ".ico" || ext == "") //if exe or ico we must extract the icon
                    {
                        if (Win32Helper.PathExist(hits[i].Get("path")))
                        {
                            Icon ic = Win32Helper.Extract(hits[i].Get("path"));
                            if (ic != null)
                                lvResultsInVideo.SmallImageList.Images.Add(ext, ic);
                        }
                        item.ImageIndex = lvResultsInVideo.SmallImageList.Images.Count - 1;
                    }
                    else
                    {
                        if (!lvResultsInVideo.SmallImageList.Images.ContainsKey(ext)) //if a key with that ext doesn't exist
                        {
                            if (Win32Helper.PathExist(hits[i].Get("path")))
                            {
                                Icon ic = Win32Helper.Extract(hits[i].Get("path"));
                                if (ic != null)
                                    lvResultsInVideo.SmallImageList.Images.Add(ext, ic);
                            }
                        }
                        item.ImageKey = ext;
                    }

                    lvResultsInVideo.Items.Add(item);
                }
                catch (Exception ex) { 
                    #if Log
Console.WriteLine(ex); 
#endif
                }
            }
            //set the colors
            Color c1 = Color.FromArgb(247, 247, 247);
            Color c2 = Color.White;
            int ii = 0;
            foreach (ListViewItem lvi in lvResultsInVideo.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    lvsi.BackColor = (ii & 1) == 0 ? c1 : c2;
                ii++;
            }

            lvResultsInVideo.EndUpdate();
            lPageNumber.Text = "Results " + pageSize * pageNum + " - " + len + " " + queryStatistics;
        }

        private void llPrevPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (hits != null)
            {
                if (pageNum > 0)
                {
                    pageNum--;
                    DisplayPage();
                }
            }
        }

        private void LLNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (hits != null)
            {
                pageNum++;
                if (pageNum * pageSize > hits.Count) pageNum--;
                else DisplayPage();
            }
        }
        #endregion

        #region Handling keypress events to restrict the inputs for duration fields
        private void tbLengthFromInVideo_KeyPress(object sender, KeyPressEventArgs e)//also handled for tbLengthToInVideo
        {
            TextBox tb = sender as TextBox;
            int data;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chars other than digit and control chars are handled by us
            {
                e.Handled = true;
            }
            else if (int.TryParse(tb.Text + e.KeyChar, out data)) //even digits which doesnot fall in the range of sec,min,hours are handled by us
            {
                if (cobLengthMetricsInVideo.SelectedIndex == 0)
                {
                    int sec = data;
                    if (sec >= 0 && sec <= 60) e.Handled = false;
                    else e.Handled = true;
                }
                else if (cobLengthMetricsInVideo.SelectedIndex == 1)
                {
                    int min = data;
                    if (min >= 0 && min <= 60) e.Handled = false;
                    else e.Handled = true;
                }
                else if (cobLengthMetricsInVideo.SelectedIndex == 2)
                {
                    int hour = data;
                    if (hour >= 0 && hour <= 23) e.Handled = false;
                    else e.Handled = true;
                }
            }
        }
        #endregion

        #region Selected (Checked) files deletion logic
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInVideo.CheckedItems)
                {
                    if (Win32Helper.PathExist(lvi.SubItems[1].Text))
                    {
                        pFrom += lvi.SubItems[1].Text + '\0';
                        lvi.Remove();
                    }
                }
                pFrom += '\0';
                Win32Helper.SHFileDelete(pFrom);//delete files to recycle bin
            }
        }
        #endregion

        #region Code to Handle contextmenu entries
        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInVideo.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(Path.GetDirectoryName(lvResultsInVideo.SelectedItems[0].SubItems[1].Text));
                    }
                    catch { }
                }
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInVideo.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(lvResultsInVideo.SelectedItems[0].SubItems[1].Text);
                    }
                    catch { }
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInVideo.CheckedItems)
                {
                    if (Win32Helper.PathExist(lvi.SubItems[1].Text))
                    {

                        pFrom += lvi.SubItems[1].Text + '\0';
                        lvi.Remove();
                    }
                }
                pFrom += '\0';

                Win32Helper.SHFileDelete(pFrom);//delete files to recycle bin
            }
        }

        private void tsmiCopyTo_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.SelectedItems.Count == 1)
            {
                string fileSrc = lvResultsInVideo.SelectedItems[0].SubItems[1].Text;
                if (Win32Helper.PathExist(fileSrc))
                {
                    FolderBrowserDialog desFolder = new FolderBrowserDialog();
                    desFolder.Description = "Select a folder to copy the file";
                    desFolder.ShowNewFolderButton = true;
                    if (desFolder.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Win32Helper.SHFileCopy(fileSrc + '\0' + '\0', desFolder.SelectedPath + '\0' + '\0');
                        }
                        catch { }
                    }
                    desFolder.Dispose();
                }
            }
        }

        private void tsmiProperties_Click(object sender, EventArgs e)
        {
            if (lvResultsInVideo.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInVideo.SelectedItems[0].SubItems[1].Text))
                {
                    bool ret = Win32Helper.SHObjectProperties(GlobalData.MainForm.Handle, 0x00000002, lvResultsInVideo.SelectedItems[0].SubItems[1].Text, null);
#if Log
Console.WriteLine("File properties Window Result: "+ret);
#endif
                }
            }
        }

        #endregion

        #region code which trigers search button when user hit enter while entering input
        private void tbFileNameInVideo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSearchInVideo.PerformClick();
        }
        #endregion
    }
}
