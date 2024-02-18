using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Search_2006
{
    public partial class Rename : Form
    {
        String newFileName = "";

        public Rename()
        {
            InitializeComponent();
        }
        public string NewFileName
        {
            get
            {
                return newFileName;
            }
        }
        private void bok_Click( object sender , EventArgs e )
        {
            newFileName = tbnewfile.Text;
        }
    }
}