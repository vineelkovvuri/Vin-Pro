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
using System.IO;
using System.Diagnostics;

namespace ExtendableDesktopSearch
{
    public partial class AudioUserControl : UserControl
    {
        #region AudioUserControl Constructor
        public AudioUserControl()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBox cobSizeMetricsInAudio = (ComboBox)this.AudioPropertiesPanel.Controls["cobSizeMetricsInAudio"];
            cobSizeMetricsInAudio.SelectedIndex = 0; //Bytes is the default

            ComboBox cobLengthMetricsInAudio = (ComboBox)this.AudioPropertiesPanel.Controls["cobLengthMetricsInAudio"];
            cobLengthMetricsInAudio.SelectedIndex = 1; //minutes the default

            ComboBox cobDate = (ComboBox)this.AudioPropertiesPanel.Controls["cobDate"];
            cobDate.SelectedIndex = 0;

            PrepareListViewResultsControl();
        }
        #endregion

        #region Code for creating column headers of the results listview
        private void PrepareListViewResultsControl()
        {
            ListViewEx results = this.lvResultsInAudio;

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

            ColumnHeaderEx ch13 = new ColumnHeaderEx("Duration");
            ch13.Width = 80;
            results.Columns.Add(ch13);

            ColumnHeaderEx ch4 = new ColumnHeaderEx("Date");
            ch4.Tag = new ColumnState("date", false);
            ch4.Width = 80;
            results.Columns.Add(ch4);

            ColumnHeaderEx ch5 = new ColumnHeaderEx("Title");
            ch5.Width = 100;
            results.Columns.Add(ch5);

            ColumnHeaderEx ch6 = new ColumnHeaderEx("Album");
            ch6.Width = 100;
            results.Columns.Add(ch6);

            ColumnHeaderEx ch7 = new ColumnHeaderEx("Artist");
            ch7.Width = 100;
            results.Columns.Add(ch7);

            ColumnHeaderEx ch8 = new ColumnHeaderEx("Comment");
            ch8.Width = 100;
            results.Columns.Add(ch8);

            ColumnHeaderEx ch9 = new ColumnHeaderEx("Track");
            ch9.Width = 100;
            ch9.Tag = new ColumnState("number", false);
            results.Columns.Add(ch9);

            ColumnHeaderEx ch10 = new ColumnHeaderEx("Genre");
            ch10.Width = 100;
            results.Columns.Add(ch10);

            ColumnHeaderEx ch12 = new ColumnHeaderEx("Year");
            ch12.Width = 100;
            ch12.Tag = new ColumnState("number", false);
            results.Columns.Add(ch12);

            ColumnHeaderEx ch11 = new ColumnHeaderEx("Type");
            ch11.Width = 120;
            results.Columns.Add(ch11);
        }
        #endregion

        #region moving a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void AudioPropertiesPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Parent.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Code for clearing all input fields
        private void lClearInputFieldsInAudio_Click(object sender, EventArgs e)
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
        private void cbDateInAudio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFromInAudio.Enabled = this.dtpToInAudio.Enabled = cobDate.Enabled = cbDateInAudio.Checked;
        }
        #endregion

        #region Code for fetching the results (main code for getting the results)
        List<Hit> hits;
        string queryStatistics = null; // string to hold " of about " + hits.Count + " for " + lStatisticsInDocuments.Text + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
        private void bSearchInAudio_Click(object sender, EventArgs e)
        {
            bSearchInAudio.Enabled = false;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = true;

            StringDictionary queryTerms = new StringDictionary();

            //Validate the parameters

            //Validate file name
            if (this.tbFileNameInAudio.Text.Trim() != "")
            {
                queryTerms.Add("name", this.tbFileNameInAudio.Text.ToLower());
                queryStatistics = "File name: " + this.tbFileNameInAudio.Text;
            }

            //Validate file size
            if (this.tbSizeFromInAudio.Text.Trim() != "" && this.tbSizeToInAudio.Text.Trim() != "")
            {
                int minSize, maxSize;
                int.TryParse(this.tbSizeFromInAudio.Text, out minSize);
                int.TryParse(this.tbSizeToInAudio.Text, out maxSize);
                if (this.cobSizeMetricsInAudio.SelectedIndex == 1) // if KB is selected
                {
                    minSize *= 1024;
                    maxSize *= 1024;
                }
                else if (this.cobSizeMetricsInAudio.SelectedIndex == 2)// if MB is selected
                {
                    minSize *= 1024 * 1024;
                    maxSize *= 1024 * 1024;
                }
                else if (this.cobSizeMetricsInAudio.SelectedIndex == 3)// if GB is selected
                {
                    minSize *= 1024 * 1024 * 1024;
                    maxSize *= 1024 * 1024 * 1024;
                }
                queryTerms.Add("size", minSize + " " + maxSize);
                queryStatistics = "Size: " + minSize + " - " + maxSize;
            }

            //Validate file date
            if (cbDateInAudio.Checked)
            {
                string from;
                DateTime minDate = dtpFromInAudio.Value;
                from = minDate.Year + "";
                if (minDate.Month < 10) from += "0" + minDate.Month;
                else from += minDate.Month;
                if (minDate.Day < 10) from += "0" + minDate.Day;
                else from += minDate.Day;

                string to;
                DateTime maxDate = dtpToInAudio.Value;
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
            if (this.tbLengthFromInAudio.Text.Trim() != "" && this.tbLengthToInAudio.Text.Trim() != "")
            {
                string from = "", to = "";

                if (this.cobLengthMetricsInAudio.SelectedIndex == 0) // if Sec is selected
                {
                    from = tbLengthFromInAudio.Text;
                    if (from.Length < 2) from = "0" + from; //from = from.PadLeft(2, '0');
                    from = "00:00:" + from;

                    to = tbLengthToInAudio.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = "00:00:" + to;
                }
                else if (this.cobLengthMetricsInAudio.SelectedIndex == 1)// if Min is selected
                {
                    from = tbLengthFromInAudio.Text;
                    if (from.Length < 2) from = "0" + from;
                    from = "00:" + from + ":00";

                    to = tbLengthToInAudio.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = "00:" + to + ":00";
                }
                else if (this.cobLengthMetricsInAudio.SelectedIndex == 2)// if Hour is selected
                {
                    from = tbLengthFromInAudio.Text;
                    if (from.Length < 2) from = "0" + from;
                    from = from + ":00:00";

                    to = tbLengthToInAudio.Text;
                    if (to.Length < 2) to = "0" + to;
                    to = to + ":00:00";
                }
                queryTerms.Add("length", from + " " + to);
                queryStatistics = "Duration: " + from + " - " + to;
            }

            //Validate title
            if (this.tbTitleInAudio.Text.Trim() != "")
            {
                queryTerms.Add("title", this.tbTitleInAudio.Text.ToLower());
                queryStatistics = "Title: " + this.tbTitleInAudio.Text;
            }
            //Validate album
            if (this.tbAlbumInAudio.Text.Trim() != "")
            {
                queryTerms.Add("album", this.tbAlbumInAudio.Text.ToLower());
                queryStatistics = "Album: " + this.tbAlbumInAudio.Text;
            }
            //Validate artist
            if (this.tbArtistInAudio.Text.Trim() != "")
            {
                queryTerms.Add("artist", this.tbArtistInAudio.Text.ToLower());
                queryStatistics = "artist: " + this.tbArtistInAudio.Text;
            }
            //Validate comment
            if (this.tbCommentInAudio.Text.Trim() != "")
            {
                queryTerms.Add("comment", this.tbCommentInAudio.Text.ToLower());
                queryStatistics = "Comment: " + this.tbCommentInAudio.Text;
            }
            //Validate genre
            if (this.tbGenreInAudio.Text.Trim() != "")
            {
                queryTerms.Add("genre", this.tbGenreInAudio.Text.ToLower());
                queryStatistics = "Genre: " + this.tbGenreInAudio.Text;
            }
            //Validate track
            if (this.tbTrackInAudio.Text.Trim() != "")
            {
                queryTerms.Add("track", this.tbTrackInAudio.Text);
                queryStatistics = "Track: " + this.tbGenreInAudio.Text;
            }
            //Validate year
            if (this.tbYearInAudio.Text.Trim() != "")
            {
                queryTerms.Add("year", this.tbYearInAudio.Text);
                queryStatistics = "Year: " + this.tbYearInAudio.Text;
            }

            if (queryTerms.Count != 0) //if a query is given(prevent from searching for not entering anything in the fields)
            {
                //Start searching..........
                long start = DateTime.Now.Ticks;

                EDSQueryEngine queryEngine = new EDSQueryEngine();
                hits = queryEngine.GetDocResults(queryTerms);

                //filter music files from the results
                string ext;
                List<Hit> temp = new List<Hit>();
                foreach (Hit hit in hits)
                {
                    ext = hit.Get("type");
                    if (GlobalData.AudioFileTypes.Contains(ext + " ") && ext != "")
                        temp.Add(hit);
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
            bSearchInAudio.Enabled = true;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = false;
        }
        #endregion

        #region Code for displaying the results page by page
        int pageNum = 0;
        int pageSize = 100;
        private void DisplayPage()
        {
            lvResultsInAudio.Items.Clear();
            lvResultsInAudio.BeginUpdate();

            //foreach (Hit hit in hits)
            int len = pageSize + pageSize * pageNum;
            if (len > hits.Count) len = hits.Count;
            for (int i = pageSize * pageNum; i < len; i++)
            {
                try
                {
                    string ext = hits[i].Get("type");
                    if (!lvResultsInAudio.SmallImageList.Images.ContainsKey(ext)) //if a key with that ext doesn't exist
                    {
                        if (Win32Helper.PathExist(hits[i].Get("path")))
                        {
                            Icon ic = Win32Helper.Extract(hits[i].Get("path"));
                            if (ic != null)
                                lvResultsInAudio.SmallImageList.Images.Add(ext, ic);
                        }
                    }
                    string size = hits[i].Get("size").TrimStart('0');
                    ListViewItemEx item = new ListViewItemEx(new string[] { hits[i].Get("name"), hits[i].Get("path"), size == "" ? "0" : size, hits[i].Get("length"), DateTime.ParseExact(hits[i].Get("cdate"), "yyyyMMdd", null).ToString("dd/MM/yyyy"), hits[i].Get("title"), hits[i].Get("album"), hits[i].Get("artist"), hits[i].Get("comment"), hits[i].Get("track"), hits[i].Get("genre"), hits[i].Get("year"), GlobalData.FileTypes[hits[i].Get("type")] });
                    // PaintListViewItem(ref item, i);
                    item.ImageKey = ext;
                    lvResultsInAudio.Items.Add(item);
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
            foreach (ListViewItem lvi in lvResultsInAudio.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    lvsi.BackColor = (ii & 1) == 0 ? c1 : c2;
                ii++;
            }

            lvResultsInAudio.EndUpdate();
            lPageNumber.Text = "Results " + pageSize * pageNum + " - " + len + " " + queryStatistics;

        }

        private void llPrevPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (hits != null) //if results are ready
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
            if (hits != null) //if results are ready
            {
                pageNum++;
                if (pageNum * pageSize > hits.Count) pageNum--;
                else DisplayPage();
            }
        }
        #endregion

    

        #region Handling keypress events to restrict the inputs for duration fields
        private void tbLengthFromInAudio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int data;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chars other than digit and control chars are handled by us
            {
                e.Handled = true;
            }
            else if (int.TryParse(tb.Text + e.KeyChar, out data)) //even digits which doesnot fall in the range of sec,min,hours are handled by us
            {
                if (cobLengthMetricsInAudio.SelectedIndex == 0)
                {
                    int sec = data;
                    if (sec >= 0 && sec <= 59) e.Handled = false;
                    else e.Handled = true;
                }
                else if (cobLengthMetricsInAudio.SelectedIndex == 1)
                {
                    int min = data;
                    if (min >= 0 && min <= 59) e.Handled = false;
                    else e.Handled = true;
                }
                else if (cobLengthMetricsInAudio.SelectedIndex == 2)
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
            if (lvResultsInAudio.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInAudio.CheckedItems)
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
            if (lvResultsInAudio.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAudio.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(Path.GetDirectoryName(lvResultsInAudio.SelectedItems[0].SubItems[1].Text));
                    }
                    catch { }
                }
            }
        }



        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (lvResultsInAudio.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAudio.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(lvResultsInAudio.SelectedItems[0].SubItems[1].Text);
                    }
                    catch { }
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvResultsInAudio.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInAudio.CheckedItems)
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
            if (lvResultsInAudio.SelectedItems.Count == 1)
            {
                string fileSrc = lvResultsInAudio.SelectedItems[0].SubItems[1].Text;
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


        private void tsmiEditProperties_Click(object sender, EventArgs e)
        {
            if (lvResultsInAudio.SelectedItems.Count == 1)
            {
                string fileSrc = lvResultsInAudio.SelectedItems[0].SubItems[1].Text;
                if (Win32Helper.PathExist(fileSrc))
                {
                    AudioTagEditor mp3TagEditor = new AudioTagEditor();
                    mp3TagEditor.FileName = fileSrc;
                    mp3TagEditor.ShowDialog();
                    mp3TagEditor.Dispose();
                }
            }
        }
        #endregion

        private void tsmiProperties_Click(object sender, EventArgs e)
        {
            if (lvResultsInAudio.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAudio.SelectedItems[0].SubItems[1].Text))
                {
                    bool ret = Win32Helper.SHObjectProperties(GlobalData.MainForm.Handle, 0x00000002, lvResultsInAudio.SelectedItems[0].SubItems[1].Text, null);
                    
                    #if Log
Console.WriteLine("File properties Window Result: "+ret);
#endif
                }
            }
        }

        #region code which trigers search button when user hit enter while entering input
        private void tbFileNameInAudio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSearchInAudio.PerformClick();
        }
        #endregion
    }
}
