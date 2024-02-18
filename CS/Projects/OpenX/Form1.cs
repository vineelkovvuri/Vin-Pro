using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Open
{
    public partial class OpenX : Form
    {
        public OpenX()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            UpdateFromFile();
            bDelete.Enabled = bEdit.Enabled = ( lvTable.SelectedItems.Count > 0 );
        }

        private void UpdateFromFile()
        {
            if ( File.Exists( "openx.dat" ) ) {
                StreamReader sr = new StreamReader( "openx.dat" );
                string s;
                while ( (s = sr.ReadLine())!=null)
                    lvTable.Items.Add( new ListViewItem( new string [] { s, sr.ReadLine() } ) );
                sr.Close();
            }
        }

        private void bExit_Click(object sender , EventArgs e)
        {
            Application.Exit();
        }

        private void bAdd_Click(object sender , EventArgs e)
        {
            Add addEntry = new Add( lvTable );
            if ( addEntry.ShowDialog() == DialogResult.OK ) {
                if ( addEntry.FieldsNotEmpty() ) {
                    lvTable.Items.Add( new ListViewItem( new string[] { addEntry.Name.ToLower() , addEntry.Path.ToLower() } ) );
                }
            }
        }

        private void lvTable_SelectedIndexChanged(object sender , EventArgs e)
        {
            bDelete.Enabled = ( lvTable.SelectedItems.Count > 0 );
            if ( lvTable.SelectedItems.Count == 1 ) {
                bEdit.Enabled = true;
                selectedIndex = lvTable.SelectedIndices [0];
            }
            else bEdit.Enabled = false;
        }

        private void bDelete_Click(object sender , EventArgs e)
        {
            foreach ( ListViewItem lvi in lvTable.SelectedItems )
                lvi.Remove();
        }

        private void lvTable_KeyUp(object sender , KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Delete ) bDelete_Click( null , null );
            if ( e.KeyCode == Keys.A && e.Control ) {
                foreach ( ListViewItem lvi in lvTable.Items )
                    lvi.Selected = true;
                lvTable.Select();
            }
            if ( e.KeyCode == Keys.F2 && lvTable.SelectedItems.Count == 1 )
                bEdit_Click( null , null );
            if ( e.KeyCode == Keys.F1 ) bHelp.PerformClick();
        }
        int selectedIndex;
        private void bEdit_Click(object sender , EventArgs e)
        {

            Add editEntry = new Add( lvTable.Items [selectedIndex].Text , lvTable.Items [selectedIndex].SubItems [1].Text ,lvTable);
            if ( editEntry.ShowDialog() == DialogResult.OK ) {
                if ( editEntry.FieldsNotEmpty() ) {
                    lvTable.Items.RemoveAt( selectedIndex );
                    lvTable.Items.Insert( selectedIndex , new ListViewItem( new string[] { editEntry.Name.ToLower() , editEntry.Path.ToLower() } ) );
                }
            }
        }

        private void lvTable_DoubleClick(object sender , EventArgs e)
        {
            selectedIndex = lvTable.SelectedIndices [0];
            bEdit_Click( null , null );
        }

        private void OpenX_KeyUp(object sender , KeyEventArgs e)
        {
            lvTable_KeyUp( null , e );
        }

        private void OpenX_FormClosing(object sender , FormClosingEventArgs e)
        {
            UpdateToFile();
        }

        private void UpdateToFile()
        {

            StreamWriter sw = new StreamWriter( "openx.dat",false );
            
            foreach ( ListViewItem lvi in lvTable.Items ) {
                sw.WriteLine( lvi.SubItems [0].Text );
                sw.WriteLine( lvi.SubItems [1].Text );
            }
            sw.Close();
            
        }

        private void llHomeLink_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            try {
                Process.Start( llHomeLink.Text );
            }
            catch { }
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