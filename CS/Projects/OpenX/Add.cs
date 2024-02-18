using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Open
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            //ep.SetIconPadding( tbName , 100 );
        }
        ListView lv;
        public Add(ListView lv)
            : this()
        {
            this.lv = lv;
        }
        public Add(string name , string path,ListView lv)
            : this(lv)
        {
            tbName.TextChanged -= tbName_TextChanged;
            tbPath.TextChanged -= tbPath_TextChanged;
            tbName.Text = name;
            tbPath.Text = path;
            bOK.Enabled = true;
            tbName.TextChanged += tbName_TextChanged;
            tbPath.TextChanged += tbPath_TextChanged;

        }

        private string _Name , _Path;
        public new string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }

        private void bFile_Click(object sender , EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "OpenX - Please select a file ....";
            if ( ofd.ShowDialog() == DialogResult.OK ) tbPath.Text = Path = ofd.FileName;
        }

        private void bFolder_Click(object sender , EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "OpenX - Please select a folder ....";
            if ( fbd.ShowDialog() == DialogResult.OK ) tbPath.Text = Path = fbd.SelectedPath;
        }

        private void bCancel_Click(object sender , EventArgs e)
        {
            Path = Name = "";
            this.DialogResult = DialogResult.Cancel;
        }

        private bool CheckName(string str)
        {
            foreach ( ListViewItem lvi in lv.Items )
                if ( lvi.Text.ToLower().Trim() == str.ToLower().Trim() ) return true;
            
            return false;
        }

        private void bOK_Click(object sender , EventArgs e)
        {
            Name = tbName.Text.Trim();
            Path = tbPath.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
        public bool FieldsNotEmpty()
        {
            if ( tbName.Text.Trim() != "" && tbPath.Text.Trim() != "" &&!errorSet ) return true;
            return false;
        }
        bool errorSet = false;
        private void tbName_TextChanged(object sender , EventArgs e)
        {
            if ( CheckName( tbName.Text ) ) {
                ep.SetError( tbName , "Name already exist please choose other name." );
                errorSet = true;
            }
            else {
                ep.Clear();
                errorSet = false;
            }

            bOK.Enabled = FieldsNotEmpty();
        }

        private void tbPath_TextChanged(object sender , EventArgs e)
        {
            bOK.Enabled = FieldsNotEmpty();
        }

        private void bExtra_Click(object sender , EventArgs e)
        {
            cmsExtraBrowse.Show( this , bExtra.Location.X +10, bExtra.Location.Y +10);
        }

        private void tsmiMyComputer_Click(object sender , EventArgs e)
        {
            tbPath.Text = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
        }

        private void tsmiNetworkPlaces_Click(object sender , EventArgs e)
        {
            tbPath.Text = "::{208D2C60-3AEA-1069-A2D7-08002B30309D}";
        }

        private void tsmiNetworkConnections_Click(object sender , EventArgs e)
        {
            tbPath.Text = "::{7007ACC7-3202-11D1-AAD2-00805FC1270E}";
        }

        private void tsmiControlPanel_Click(object sender , EventArgs e)
        {
            tbPath.Text = @"::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{21EC2020-3AEA-1069-A2DD-08002B30309D}";
        }

        private void tsmiRecycleBin_Click(object sender , EventArgs e)
        {
            tbPath.Text = "::{645FF040-5081-101B-9F08-00AA002F954E}";
        }

        private void bHelp_Click( object sender , EventArgs e )
        {
            MessageBox.Show(
@"OpenX <alias>
    - Opens the directory specified in OpenX
    - Example : 'OpenX win' Opens the directory with 'win' as alias.

OpenX <dir path or file path>
    - Opens the directory or file which is not specified in OpenX

OpenX
    - Opens the OpenX main UI window" , "OpenX - Help...!" , MessageBoxButtons.OK , MessageBoxIcon.Information );
        }

        

      }
}