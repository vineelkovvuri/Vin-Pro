using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Lucene.Net.Search;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis;

namespace ExtendableDesktopSearch
{
    public partial class AllFilesUserControl : UserControl
    {
        public AllFilesUserControl()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBox cobSizeMetricsInFiles = (ComboBox)this.AllFilesPropertiesPanel.Controls["cobSizeMetricsInFiles"];
            cobSizeMetricsInFiles.SelectedIndex = 0;

            ComboBox cobDate = (ComboBox)this.AllFilesPropertiesPanel.Controls["cobDate"];
            cobDate.SelectedIndex = 0;

            ComboBox cobAttributes = (ComboBox)this.AllFilesPropertiesPanel.Controls["cobAttributes"];
            cobAttributes.SelectedIndex = 0;

            PreparePropertiesContextMenu();

            PrepareListViewResultsControl();

        }

        private void PreparePropertiesContextMenu()
        {
            foreach (string property in GlobalData.PropertyList)
            {
                ToolStripItem propertiesMenuItem = cmsProperties.Items.Add(property);
                propertiesMenuItem.Click += new EventHandler(propertiesMenuItem_Click);
            }
        }
        //Advanced Query keys menu
        void propertiesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem property = sender as ToolStripItem;
            tbQuery.Text += " " + property.Text + ":";
        }

        #region Code for creating column headers of the results listview
        private void PrepareListViewResultsControl()
        {
            ListViewEx results = this.lvResultsInAllFiles;

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

            ColumnHeaderEx ch4 = new ColumnHeaderEx("Created Date");
            ch4.Tag = new ColumnState("date", false);
            ch4.Width = 120;
            results.Columns.Add(ch4);

            ColumnHeaderEx ch5 = new ColumnHeaderEx("Modified Date");
            ch5.Tag = new ColumnState("date", false);
            ch5.Width = 120;
            results.Columns.Add(ch5);

            ColumnHeaderEx ch6 = new ColumnHeaderEx("Accessed Date");
            ch6.Tag = new ColumnState("date", false);
            ch6.Width = 120;
            results.Columns.Add(ch6);

            ColumnHeaderEx ch7 = new ColumnHeaderEx("Type");
            results.Columns.Add(ch7);
            ch7.Width = 120;

            ColumnHeaderEx ch8 = new ColumnHeaderEx("Attributes");
            ch8.Width = 80;
            results.Columns.Add(ch8);

        }
        #endregion

        private void cbCreatedDateInAllFiles_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromInFiles.Enabled = dtpToInAllFiles.Enabled = cobDate.Enabled = cbDateInAllFiles.Checked;
        }

        private void cbAttributes_CheckedChanged(object sender, EventArgs e)
        {
            cobAttributes.Enabled = cbAttributes.Checked;
        }

        List<Hit> hits;
        string queryStatistics = null; // string to hold " of about " + hits.Count + " for " + queryStatistics + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
        private void bSearchInAllFiles_Click(object sender, EventArgs e)
        {

            bSearchInAllFiles.Enabled = false;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = true;

            StringDictionary queryTerms = new StringDictionary();

            //Validate the parameters
            if (tbQuery.Text.Trim() != "")
            {
                try
                {
                    new QueryParser("name", new KeywordAnalyzer()).Parse(this.tbQuery.Text.Trim().ToLower());
                    queryTerms.Add("all", this.tbQuery.Text.Trim().ToLower());
                    queryStatistics = this.tbQuery.Text;
                }
                catch { MessageBox.Show("Given query " + tbQuery.Text + " cannot be processed. Check examples on EDS query syntax below \n\n1. 'attr:hidden' searches for file with hidden attribute\n2. 'name:abc.txt' searches for file name with abc.txt\n3. '+attr:hidden +name:abc.txt' searches for hidden files with file name abc.txt ", "Extendable Desktop Search"); }
            }
            else
            {
                //Validate file name
                if (this.tbFileNameInAllFiles.Text.Trim() != "")
                {
                    queryTerms.Add("name", this.tbFileNameInAllFiles.Text.ToLower());
                    queryStatistics = "File name: " + this.tbFileNameInAllFiles.Text;
                }

                //Validate file size
                if (this.tbSizeFromInFiles.Text.Trim() != "" && this.tbSizeToInFiles.Text.Trim() != "")
                {
                    int minSize, maxSize;
                    int.TryParse(this.tbSizeFromInFiles.Text, out minSize);
                    int.TryParse(this.tbSizeToInFiles.Text, out maxSize);
                    if (this.cobSizeMetricsInFiles.SelectedIndex == 1) // if KB is selected
                    {
                        minSize *= 1024;
                        maxSize *= 1024;
                    }
                    else if (this.cobSizeMetricsInFiles.SelectedIndex == 2)// if MB is selected
                    {
                        minSize *= 1024 * 1024;
                        maxSize *= 1024 * 1024;
                    }
                    else if (this.cobSizeMetricsInFiles.SelectedIndex == 3)// if GB is selected
                    {
                        minSize *= 1024 * 1024 * 1024;
                        maxSize *= 1024 * 1024 * 1024;
                    }
                    queryTerms.Add("size", minSize + " " + maxSize);
                    queryStatistics = "Size: " + minSize + " - " + maxSize;
                }

                //Validate file date
                if (cbDateInAllFiles.Checked)
                {
                    string from;
                    DateTime minDate = dtpFromInFiles.Value;
                    from = minDate.Year + "";
                    if (minDate.Month < 10) from += "0" + minDate.Month;
                    else from += minDate.Month;
                    if (minDate.Day < 10) from += "0" + minDate.Day;
                    else from += minDate.Day;

                    string to;
                    DateTime maxDate = dtpToInAllFiles.Value;
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
                //validate attributes
                if (cbAttributes.Checked)
                {
                    queryTerms.Add("attr", "*" + ((string)cobAttributes.SelectedItem).ToLower() + "*");
                    queryStatistics = "Attribute: " + ((string)cobAttributes.SelectedItem);
                }
            }
            if (queryTerms.Count != 0) //if a query is given(prevent from searching for not entering anything in the fields)
            {
                long start = DateTime.Now.Ticks;
                EDSQueryEngine queryEngine = new EDSQueryEngine();
                hits = queryEngine.GetDocResults(queryTerms);
                long end = DateTime.Now.Ticks;
                DateTime dt = new DateTime(end - start);
                if (dt.Second == 0 && dt.Millisecond == 0)
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in 0ms";
                else
                    queryStatistics = " of about " + hits.Count + " for " + GlobalData.AutoEllipsis(queryStatistics) + " in " + (dt.Second != 0 ? dt.Second + "s " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");
                pageNum = 0;
                DisplayPage();    // displays the first page of the results

            }
            bSearchInAllFiles.Enabled = true;
            GlobalData.MainStatusStrip.Items["tsslSearchingStatus"].Visible = false;
        }


        #region Code for displaying the results page by page
        int pageNum = 0;
        int pageSize = 100;
        private void DisplayPage()
        {
            lvResultsInAllFiles.Items.Clear();
            lvResultsInAllFiles.BeginUpdate();

            int index = pageSize + pageSize * pageNum;
            if (index > hits.Count) index = hits.Count;
            for (int i = pageSize * pageNum; i < index; i++)
            {
                try
                {
                    string size = hits[i].Get("size").TrimStart('0');
                    ListViewItemEx item = new ListViewItemEx(new string[] { hits[i].Get("name"), 
                        hits[i].Get("path"), 
                        size == "" ? "0" : size, 
                        DateTime.ParseExact(hits[i].Get("cdate"), "yyyyMMdd", null).ToString("dd/MM/yyyy"), 
                        DateTime.ParseExact(hits[i].Get("mdate"), "yyyyMMdd", null).ToString("dd/MM/yyyy"), 
                        DateTime.ParseExact(hits[i].Get("adate"), "yyyyMMdd", null).ToString("dd/MM/yyyy"), 
                        GlobalData.FileTypes[hits[i].Get("type")],
                        hits[i].Get("attr") });

                    string ext = hits[i].Get("type");
                    if (ext == ".exe" || ext == ".ico" || ext == "") //if exe or ico we must extract the icon
                    {
                        if (Win32Helper.PathExist(hits[i].Get("path")))
                        {
                            Icon ic = Win32Helper.Extract(hits[i].Get("path"));
                            if (ic != null)
                                lvResultsInAllFiles.SmallImageList.Images.Add(ext, ic);
                        }
                        item.ImageIndex = lvResultsInAllFiles.SmallImageList.Images.Count - 1;
                    }
                    else
                    {
                        if (!lvResultsInAllFiles.SmallImageList.Images.ContainsKey(ext)) //if a key with that ext doesn't exist
                        {
                            if (Win32Helper.PathExist(hits[i].Get("path")))
                            {
                                Icon ic = Win32Helper.Extract(hits[i].Get("path"));
                                if (ic != null)
                                    lvResultsInAllFiles.SmallImageList.Images.Add(ext, ic);
                            }
                        }
                        item.ImageKey = ext;
                    }
                    lvResultsInAllFiles.Items.Add(item);
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
            foreach (ListViewItem lvi in lvResultsInAllFiles.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    lvsi.BackColor = (ii & 1) == 0 ? c1 : c2;
                ii++;
            }

            lvResultsInAllFiles.EndUpdate();
            lPageNumber.Text = "Results " + pageSize * pageNum + " - " + index + " " + queryStatistics;
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



        #region Clear Input fields
        private void lClearInputFieldsInAllFiles_Click(object sender, EventArgs e)
        {
            TextBox temp;
            foreach (Control c in ((Control)sender).Parent.Controls)
            {
                if ((temp = c as TextBox) != null)
                    temp.Clear();
            }
        }
        #endregion

        #region Code to handle contextmenu entries
        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(Path.GetDirectoryName(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text));
                    }
                    catch { }
                }
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text))
                {
                    try
                    {
                        Process.Start(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text);
                    }
                    catch { Console.WriteLine("Open Error"); }
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInAllFiles.CheckedItems)
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
            if (lvResultsInAllFiles.SelectedItems.Count == 1)
            {
                string fileSrc = lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text;
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

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.CheckedItems.Count != 0)
            {
                string pFrom = "";
                foreach (ListViewItem lvi in lvResultsInAllFiles.CheckedItems)
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

        private void tsmiProperties_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text))
                {
                    bool ret = Win32Helper.SHObjectProperties(GlobalData.MainForm.Handle, 0x00000002, lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text, null);
                    Console.WriteLine(ret);
                }
            }
        }

        #region code which trigers search button when user hit enter while entering input
        private void tbFileNameInAllFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                bSearchInAllFiles.PerformClick();
        }
        #endregion

        private void bProperties_Click(object sender, EventArgs e)
        {
            cmsProperties.Show(bProperties, 10, 10);
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (lvResultsInAllFiles.SelectedItems.Count == 1)
            {
                if (Win32Helper.PathExist(lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text))
                {
                    Win32Helper.ShellExecute(this.Handle, "edit", lvResultsInAllFiles.SelectedItems[0].SubItems[1].Text, "", "", 5);
                }
            }
        }

    }
}
