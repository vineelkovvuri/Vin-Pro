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
using System.Text.RegularExpressions;


namespace ExtendableDesktopSearch
{
    public partial class EmailUserControl : UserControl
    {
        #region EmailUserControl Constructor
        public EmailUserControl()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PrepareListViewResultsControl();
        }
        #endregion

        #region Code for creating column headers of the results listview
        private void PrepareListViewResultsControl()
        {
            ListViewEx results = this.lvResultsInEmail;

            ColumnHeaderEx ch1 = new ColumnHeaderEx("Subject");
            ch1.Width = 220;
            results.Columns.Add(ch1);

            ColumnHeaderEx ch2 = new ColumnHeaderEx("From");
            ch2.Width = 180;
            results.Columns.Add(ch2);

            ColumnHeaderEx ch3 = new ColumnHeaderEx("To");
            ch3.Width = 180;
            results.Columns.Add(ch3);

            ColumnHeaderEx ch4 = new ColumnHeaderEx("Date");
            ch4.Tag = new ColumnState("date", false);
            ch4.Width = 80;
            results.Columns.Add(ch4);
        }
        #endregion

        #region moving a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void EmailUserControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Parent.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Code for clearing all input fields
        private void lClearInputFieldsInEmails_Click(object sender, EventArgs e)
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
        private void cbDateInEmails_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFromInEmails.Enabled = this.dtpToInEmails.Enabled = cbDateInEmails.Checked;
        }
        #endregion

        #region Code for fetching the results (main code for getting the results)
        List<Hit> hits;
        string queryStatistics = null; // string to hold " of about " + hits.Count + " for " + lStatisticsInDocuments.Text + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
        private void bSearchInEmails_Click(object sender, EventArgs e)
        {
            bSearchInEmails.Enabled = false;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = true;

            StringDictionary queryTerms = new StringDictionary();

            //Validate the parameters

            //Validate subject
            if (this.tbSubjectInEmails.Text.Trim() != "")
            {
                queryTerms.Add("subject", this.tbSubjectInEmails.Text.ToLower());
                queryStatistics = "Subject: " + this.tbSubjectInEmails.Text;
            }

            //Validate from field
            if (this.tbFromAddressInEmails.Text.Trim() != "")
            {
                queryTerms.Add("from", this.tbFromAddressInEmails.Text.ToLower());
                queryStatistics = "From: " + this.tbFromAddressInEmails.Text;
            }

            //Validate to field
            if (this.tbToAddressInEmails.Text.Trim() != "")
            {
                queryTerms.Add("to", this.tbToAddressInEmails.Text.ToLower());
                queryStatistics = "To: " + this.tbToAddressInEmails.Text;
            }

            //Validate body field
            if (this.tbBodyInEmails.Text.Trim() != "")
            {
                queryTerms.Add("body", this.tbBodyInEmails.Text.ToLower());
                queryStatistics = "Body: " + this.tbBodyInEmails.Text;
            }

            //Validate file date
            if (cbDateInEmails.Checked)
            {
                string from;
                DateTime minDate = dtpFromInEmails.Value;
                from = minDate.Year + "";
                if (minDate.Month < 10) from += "0" + minDate.Month;
                else from += minDate.Month;
                if (minDate.Day < 10) from += "0" + minDate.Day;
                else from += minDate.Day;

                string to;
                DateTime maxDate = dtpToInEmails.Value;
                to = maxDate.Year + "";
                if (maxDate.Month < 10) to += "0" + maxDate.Month;
                else to += maxDate.Month;
                if (maxDate.Day < 10) to += "0" + maxDate.Day;
                else to += maxDate.Day;

                queryTerms.Add("date", from + " " + to);
                queryStatistics = "Date: " + minDate.ToShortDateString() + " - " + maxDate.ToShortDateString();
            }

            if (queryTerms.Count != 0) //if a query is given(prevent from searching for not entering anything in the fields)
            {
                long start = DateTime.Now.Ticks;
                EDSQueryEngine queryEngine = new EDSQueryEngine();
                hits = queryEngine.GetEmailResults(queryTerms);
                long end = DateTime.Now.Ticks;
                DateTime dt = new DateTime(end - start);
                if (dt.Second == 0 && dt.Millisecond == 0)
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in 0ms";
                else
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
                pageNum = 0;
                DisplayPage();    // displays the first page of the results

            }
            bSearchInEmails.Enabled = true;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = false;
        }
        #endregion

        #region Code for displaying the results page by page
        int pageNum = 0;
        int pageSize = 100;
        private void DisplayPage()
        {
            if (hits != null)
            {
                lvResultsInEmail.Items.Clear();
                lvResultsInEmail.BeginUpdate();

                int len = pageSize + pageSize * pageNum;
                if (len > hits.Count) len = hits.Count;
                for (int i = pageSize * pageNum; i < len; i++)
                {
                    try
                    {

                        ListViewItemEx item = new ListViewItemEx(new string[] { hits[i].Get("subject"), hits[i].Get("from"), hits[i].Get("to") });// DateTime.ParseExact(hits[i].Get("date"), "yyyyMMdd", null).ToString("dd/MM/yyyy") });
                        lvResultsInEmail.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
#if Log
    Console.WriteLine(ex); 
#endif
                    }
                }

                //set the colors
                Color c1 = Color.FromArgb(247, 247, 247);
                Color c2 = Color.White;
                int ii = 0;
                foreach (ListViewItem lvi in lvResultsInEmail.Items)
                {
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        lvsi.BackColor = (ii & 1) == 0 ? c1 : c2;
                    ii++;
                }

                lvResultsInEmail.EndUpdate();
                lPageNumber.Text = "Results " + pageSize * pageNum + " - " + len + " " + queryStatistics;
            }
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


        //#region Selected (Checked) files deletion logic
        //private void bDelete_Click(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem lvi in lvResultsInEmail.CheckedItems)
        //    {
        //                lvi.Remove();
        //    }
        //}
        //#endregion

        private void tsmiReplyTo_Click(object sender, EventArgs e)
        {
            if (lvResultsInEmail.SelectedItems.Count == 1)
            {
                try
                {
                    Regex r = new Regex("[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}");
                    Match m = r.Match(lvResultsInEmail.SelectedItems[0].SubItems[1].Text);
                    if (m != null) Process.Start("mailto:" + m.Value);
                }
                catch { MessageBox.Show("Outlook is not configured on this computer", "Extendable Desktop Search"); }
            }
        }

        #region code which trigers search button when user hit enter while entering input
        private void tbSubjectInEmails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSearchInEmails.PerformClick();
        }
        #endregion
    }
}
