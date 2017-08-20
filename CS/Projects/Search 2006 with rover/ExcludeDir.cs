using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Search_2006
{
    public partial class ExcludeDir : Form
    {
        public ExcludeDir()
        {
            InitializeComponent();
        }

        public void IntializeListBox()
        {
            if ( excludedir != null )
                lbexcludedir.Items.AddRange( excludedir );
        }

        FolderBrowserDialog fbd = null;
        private void badd_Click( object sender , EventArgs e )
        {
            fbd = new FolderBrowserDialog();
            fbd.Description = "What directories are you willing to exclude from searching";

            if ( fbd.ShowDialog() == DialogResult.OK )
            {
                if ( !lbexcludedir.Items.Contains( fbd.SelectedPath ) )
                    lbexcludedir.Items.Add( fbd.SelectedPath );
                else
                    MessageBox.Show( "This Directory is already listed" );
            }
        }

        private void bremove_Click( object sender , EventArgs e )
        {
            if ( lbexcludedir.SelectedIndex != -1 )
            {
                lbexcludedir.Items.RemoveAt( lbexcludedir.SelectedIndex );
             }
            else
                MessageBox.Show( "First Select an Entry and then Click Remove Button" );
        }
        public string [] excludedir;
        private void bok_Click( object sender , EventArgs e )
        {
            excludedir = new string [lbexcludedir.Items.Count];
            lbexcludedir.Items.CopyTo( excludedir , 0 );
        }
    }
}