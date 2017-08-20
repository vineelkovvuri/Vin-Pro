using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
namespace Search_2006
{

    public class Search
    {
        public ListView listView;
        public Regex r = null;
        /// <summary>
        /// Temparary FileInfo Object used while Searching
        /// </summary>
        FileInfo f = null;
        public int k = 1;
        ListViewItem lvt;
        static public ImageList img1 = new ImageList();
        public Search()
        {
            img1.ColorDepth = ColorDepth.Depth32Bit;
            img1.ImageSize = new Size(16, 16);
        }
        Icon ic;
        public void SearchInSingleDirByName(string filePath, AdvancedAttributes att)
        {
            try
            {
                listView.BeginUpdate();
                foreach (string s in Directory.GetFiles(filePath))
                {
                    f = new FileInfo(s);
                    if (att.PermissionBased)
                    {
                        if ((att.Hidden && (f.Attributes == FileAttributes.Hidden) && r.Match(f.Name).Success) ||
                            (att.ReadOnly && (f.Attributes == FileAttributes.ReadOnly) && r.Match(f.Name).Success) ||
                            (att.Archive && (f.Attributes == FileAttributes.Archive) && r.Match(f.Name).Success) ||
                            (att.ReadOnly && att.Hidden && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden)) && r.Match(f.Name).Success) ||
                            (att.ReadOnly && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Archive)) && r.Match(f.Name).Success) ||
                            (att.Hidden && att.Archive && (f.Attributes == (FileAttributes.Hidden | FileAttributes.Archive)) && r.Match(f.Name).Success) ||
                            (att.ReadOnly && att.Hidden && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive)) && r.Match(f.Name).Success) ||
                            (!att.ReadOnly && !att.Hidden && !att.Archive && (f.Attributes == FileAttributes.Normal) && r.Match(f.Name).Success))
                        {
                            ic = Icon.ExtractAssociatedIcon(f.FullName);

                            if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                            lvt = new ListViewItem("" + k++);
                            lvt.ImageKey = f.Extension;
                            lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                            listView.Items.Add(lvt);
                        }
                    }
                    else
                    {
                        if (r.Match(f.Name).Success)
                        {
                            ic = Icon.ExtractAssociatedIcon(f.FullName);
                            if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                            lvt = new ListViewItem("" + k++);
                            lvt.ImageKey = f.Extension;
                            lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                            listView.Items.Add(lvt);

                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                listView.EndUpdate();
            }
        }

        DateTime t;
        public void SearchInSingleDirByDate(string filePath, DateTime from, DateTime to, AdvancedAttributes att, DateAttributes d)
        {
            listView.BeginUpdate();
            foreach (string s in Directory.GetFiles(filePath))
            {
                f = new FileInfo(s);
                if (d.Modified)
                    t = f.LastWriteTime;
                else if (d.Accessed)
                    t = f.LastAccessTime;
                else if (d.Created)
                    t = f.CreationTime;
                if (att.PermissionBased)
                {
                    if ((att.Hidden && (f.Attributes == FileAttributes.Hidden) && CompareDates(from, t, to)) ||
                         (att.ReadOnly && (f.Attributes == FileAttributes.ReadOnly) && CompareDates(from, t, to)) ||
                         (att.Archive && (f.Attributes == FileAttributes.Archive) && CompareDates(from, t, to)) ||
                         (att.ReadOnly && att.Hidden && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden)) && CompareDates(from, t, to)) ||
                         (att.ReadOnly && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Archive)) && CompareDates(from, t, to)) ||
                         (att.Hidden && att.Archive && (f.Attributes == (FileAttributes.Hidden | FileAttributes.Archive)) && CompareDates(from, t, to)) ||
                         (att.ReadOnly && att.Hidden && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive)) && CompareDates(from, t, to)) ||
                         (!att.ReadOnly && !att.Hidden && !att.Archive && (f.Attributes == FileAttributes.Normal) && CompareDates(from, t, to)))
                    {
                        ic = Icon.ExtractAssociatedIcon(f.FullName);
                        if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                        lvt = new ListViewItem("" + k++);
                        lvt.ImageKey = f.Extension;
                        lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                        listView.Items.Add(lvt);
                    }
                }
                else
                {
                    if (CompareDates(from, t, to))
                    {
                        ic = Icon.ExtractAssociatedIcon(f.FullName);
                        if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                        lvt = new ListViewItem("" + k++);
                        lvt.ImageKey = f.Extension;
                        lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                        listView.Items.Add(lvt);
                    }
                }
            }

            listView.EndUpdate();
        }
        private bool CompareDates(DateTime from, DateTime t, DateTime to)
        {
            if ((from.Year < t.Year && t.Year < to.Year))
                return true;
            else if ((from.Year == t.Year && t.Year == to.Year) && (from.Month < t.Month && t.Month < to.Month))
                return true;
            else if ((from.Year == t.Year && t.Year == to.Year) && (from.Month == t.Month && t.Month == to.Month) && (from.Day <= t.Day && t.Day <= to.Day))
                return true;
            else
                return false;
        }

        long size = 0;
        public void SearchInSingleDirBySize(string filePath, long from, long to, AdvancedAttributes att, SizeAttributes si)
        {

            listView.BeginUpdate();
            foreach (string s in Directory.GetFiles(filePath))
            {
                f = new FileInfo(s);
                size = f.Length;
                if (si.KB)
                    size /= 1000;
                else if (si.MB)
                    size /= 1000 * 1000;
                else if (si.GB)
                    size /= 1000 * 1000 * 1000;
                if (att.PermissionBased)
                {
                    if ((att.Hidden && (f.Attributes == FileAttributes.Hidden) && (size >= from && size <= to)) ||
                        (att.ReadOnly && (f.Attributes == FileAttributes.ReadOnly) && (size >= from && size <= to)) ||
                        (att.Archive && (f.Attributes == FileAttributes.Archive) && (size >= from && size <= to)) ||
                        (att.ReadOnly && att.Hidden && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden)) && (size >= from && size <= to)) ||
                        (att.ReadOnly && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Archive)) && (size >= from && size <= to)) ||
                        (att.Hidden && att.Archive && (f.Attributes == (FileAttributes.Hidden | FileAttributes.Archive)) && (size >= from && size <= to)) ||
                        (att.ReadOnly && att.Hidden && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive)) && (size >= from && size <= to)) ||
                        (!att.ReadOnly && !att.Hidden && !att.Archive && (f.Attributes == FileAttributes.Normal) && (size >= from && size <= to)))
                    {
                        ic = Icon.ExtractAssociatedIcon(f.FullName);
                        if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                        lvt = new ListViewItem("" + k++);
                        lvt.ImageKey = f.Extension;
                        lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                        listView.Items.Add(lvt);
                    }
                }
                else
                {
                    if (size >= from && size <= to)
                    {
                        ic = Icon.ExtractAssociatedIcon(f.FullName);
                        if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                        lvt = new ListViewItem("" + k++);
                        lvt.ImageKey = f.Extension;
                        lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                        listView.Items.Add(lvt);
                    }
                }
            }
            listView.EndUpdate();
        }
        public void SearchInSingleDirByWord(string filePath, AdvancedAttributes att)
        {
            listView.BeginUpdate();
            foreach (string s in Directory.GetFiles(filePath))
            {
                try
                {
                    f = new FileInfo(s);
                    if (IsFileEndingWithPreferredExtension(f))
                    {
                        if (att.PermissionBased)
                        {
                            if ((att.Hidden && (f.Attributes == FileAttributes.Hidden) && CheckForWord(f)) ||
                                (att.ReadOnly && (f.Attributes == FileAttributes.ReadOnly) && CheckForWord(f)) ||
                                (att.Archive && (f.Attributes == FileAttributes.Archive) && CheckForWord(f)) ||
                                (att.ReadOnly && att.Hidden && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden)) && CheckForWord(f)) ||
                                (att.ReadOnly && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Archive)) && CheckForWord(f)) ||
                                (att.Hidden && att.Archive && (f.Attributes == (FileAttributes.Hidden | FileAttributes.Archive)) && CheckForWord(f)) ||
                                (att.ReadOnly && att.Hidden && att.Archive && (f.Attributes == (FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive)) && CheckForWord(f)) ||
                                (!att.ReadOnly && !att.Hidden && !att.Archive && (f.Attributes == FileAttributes.Normal) && CheckForWord(f)))
                            {
                                ic = Icon.ExtractAssociatedIcon(f.FullName);
                                if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                                lvt = new ListViewItem("" + k++);
                                lvt.ImageKey = f.Extension;
                                lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                                listView.Items.Add(lvt);
                            }
                        }
                        else
                        {
                            if (CheckForWord(f))
                            {
                                ic = Icon.ExtractAssociatedIcon(f.FullName);
                                if (!img1.Images.ContainsKey(f.Extension)) img1.Images.Add(f.Extension, ic);
                                lvt = new ListViewItem("" + k++);
                                lvt.ImageKey = f.Extension;
                                lvt.SubItems.AddRange(new String[] { f.Name, f.FullName, "" + f.Length, f.Extension });
                                listView.Items.Add(lvt);
                            }
                        }
                    }
                }
                catch (Exception e) { MessageBox.Show(e.Message + "  " + e.StackTrace); }
            }
            listView.EndUpdate();
        }
        Regex rword = new Regex("^(.c|.h|.x" +
                "|.cc|.cp|.cs|.js|.pl|.rc|.rh|.hh|.vb" +
                "|.asm|.asp|.bat|.cmd|.cpp|.css|.csv|.cxx|.def|.dic|.diz|.eml|.hhc|.hpp|.htm|.htt" +
            "|.htw|.htx|.hxx|.idl|.idq|.inc|.inf|.ini|.inx|.log|.nvr|.nws|.odc|.php|.plg|.reg|.rtf|.sln|.sql|.stm|.sed|.tsv|.txt|.vbs|.wtx|.xml|.xsl" +
            "|.asax|.ascx|.ashx|.asmx|.aspx|.html|.java|.php3|.shtml|.csproj|.config|.datasource)$", RegexOptions.IgnoreCase);
        private bool IsFileEndingWithPreferredExtension(FileInfo f)
        {
            return rword.Match(f.Extension).Success;
        }
        string st;
        private bool CheckForWord(FileInfo f)
        {
            using (StreamReader s = new StreamReader(f.OpenRead()))
            {
                st = s.ReadLine();
                while (st != null)
                {
                    if (r.Match(st).Success)
                    {
                        s.Close();
                        return true;
                    }
                    st = s.ReadLine();
                }
            }
            return false;
        }
    }
}
