using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ExtendableDesktopSearch
{
    class ListViewEx : ListView
    {
       // EDSToolTip toolTip;
        public ListViewEx()
        {
            this.View = View.Details;
            this.FullRowSelect = true;
            this.AllowColumnReorder = true;
            this.GridLines = true;
            this.CheckBoxes = true;
            // this.Font = new Font("Tahoma", 8);

            ImageList imagelist = new ImageList();
            imagelist.ColorDepth = ColorDepth.Depth32Bit;
            imagelist.Images.Add(ExtendableDesktopSearch.Properties.Resources.SortDown);
            imagelist.Images.Add(ExtendableDesktopSearch.Properties.Resources.SortUp);
            this.SmallImageList = imagelist;

        }
        //public EDSToolTip ToolTip
        //{
        //    get { return toolTip; }
        //    set
        //    {
        //        toolTip = value;
        //    }
        //}
        //protected override void OnItemMouseHover(ListViewItemMouseHoverEventArgs e)
        //{
        //    if (toolTip != null)
        //    {
        //        string text = "";
        //        int i = 0;
        //        foreach (ListViewItem.ListViewSubItem lvsi in e.Item.SubItems)
        //            text += string.Format("{0,-20} {1,-40}\n", e.Item.ListView.Columns[i++].Text + ":", lvsi.Text);
        //        if (text != "") toolTip.Show(text, this.SmallImageList.Images[e.Item.ImageIndex], this);
        //    }
        //    base.OnItemMouseHover(e);
        //}

        //protected override void OnControlAdded(ControlEventArgs e)
        //{
        //    base.OnControlAdded(e);
        //    Console.WriteLine(e.Control);
        //}

        int previousColumn = -1;
        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            //set the images on the column headers to none
            if (this.SmallImageList != null)
                foreach (ColumnHeader ch in this.Columns)
                    ch.ImageIndex = -1;

            //prepare for sorting the columns
            ListViewItemComparer comparer = new ListViewItemComparer(e.Column);
            ColumnState state = this.Columns[e.Column].Tag as ColumnState;
            if (state != null)
            {
                if (state.type == "number") comparer.Numeric = true;
                else if (state.type == "date") comparer.Date = true;

                state.descending = !state.descending;  //toggle state from acsending to desending and vice versa on very click
                ColumnHeader column = this.Columns[e.Column];
                if (this.SmallImageList != null)
                {
                    if (state.descending) column.ImageIndex = 0;
                    else column.ImageIndex = 1;
                }
                comparer.Descending = state.descending;
            }
            this.ListViewItemSorter = comparer;
            this.Sort();

            //set the colors.

            this.BeginUpdate();
            Color c = Color.FromArgb(247, 247, 247);

            //change the column color
            int idx = 0;
            foreach (ListViewItem lvi in this.Items)
            {
                if (previousColumn != -1) lvi.SubItems[previousColumn].ResetStyle();

                //paint alternate rows
                if ((idx & 1) == 0) //if even
                {
                    lvi.BackColor = c;
                    //Paint subitems
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        lvsi.BackColor = c;
                }
                else                //if odd
                {
                    lvi.BackColor = this.BackColor;
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        lvsi.BackColor = this.BackColor;
                }
                lvi.SubItems[e.Column].BackColor = c;
                idx++;
            }
            previousColumn = e.Column;

            this.EndUpdate();
        }


        public class ListViewItemComparer : IComparer
        {
            private int column;
            public int Column
            {
                get { return column; }
                set { column = value; }
            }

            private bool numeric = false;
            public bool Numeric
            {
                get { return numeric; }
                set { numeric = value; }
            }
            private bool date = false;
            public bool Date
            {
                get { return date; }
                set { date = value; }
            }

            private bool descending = false;
            public bool Descending
            {
                get { return descending; }
                set { descending = value; }
            }

            public ListViewItemComparer(int columnIndex)
            {
                Column = columnIndex;
            }
            public int Compare(object x, object y)
            {
                ListViewItem listX, listY;
                if (descending)
                {
                    listY = (ListViewItem)x;
                    listX = (ListViewItem)y;
                }
                else
                {
                    listX = (ListViewItem)x;
                    listY = (ListViewItem)y;
                }
                if (Numeric)
                {
                    // Convert column text to numbers before comparing.
                    // If the conversion fails, the value defaults to 0.
                    decimal valX, valY;
                    Decimal.TryParse(listX.SubItems[Column].Text, out valX);
                    Decimal.TryParse(listY.SubItems[Column].Text, out valY);
                    // Perform a numeric comparison.
                    return Decimal.Compare(valX, valY);
                }
                else if (Date)
                {
                    DateTime valX = DateTime.ParseExact(listX.SubItems[Column].Text, "dd/MM/yyyy", null);
                    DateTime valY = DateTime.ParseExact(listY.SubItems[Column].Text, "dd/MM/yyyy", null); //DateTime.Parse(listY.SubItems[Column].Text);

                    if (valX.Year != valY.Year) return valX.Year - valY.Year;
                    else if (valX.Month != valX.Month) return valX.Month - valY.Month;
                    else return valX.Day - valY.Day;
                }
                else
                {
                    // Perform an alphabetic comparison.
                    return String.Compare(
                    listX.SubItems[Column].Text, listY.SubItems[Column].Text);
                }
            }
        }

    }
    public class ColumnState
    {
        public string type = "string";
        public bool descending = false;

        public ColumnState(string type, bool descending)
        {
            this.type = type;
            this.descending = descending;
        }
    }
    public class ColumnHeaderEx : ColumnHeader
    {
        public ColumnHeaderEx(string text)
        {
            this.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            ColumnState state = new ColumnState("string", false);
            this.Tag = state;
            this.ImageIndex = -1;
            this.Text = text;
        }
    }
    public class ListViewItemEx : ListViewItem
    {

        Color c = Color.FromArgb(247, 247, 247);
        static int ItemIndex = 0;
        //    static Font font = new Font("Tahoma", 8);
        public ListViewItemEx(string[] items)
            : base(items)
        {
            //this.Font = ListViewItemEx.font;
            this.UseItemStyleForSubItems = false;
            if ((ListViewItemEx.ItemIndex & 1) == 0)
            {
                foreach (ListViewSubItem lvsi in this.SubItems)
                {
                    lvsi.BackColor = c;
                }
            }
            //setting the font to each subitem
            //foreach (ListViewSubItem lvsi in this.SubItems)
            //{
            //    lvsi.Font = font;
            //}

            ListViewItemEx.ItemIndex++;
        }
    }
}
