using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ExtendableDesktopSearch
{
    public partial class AudioTagEditor : Form
    {
        public AudioTagEditor()
        {
            InitializeComponent();
            Mp3TagEditorPropertiesPanel.Mp3TagEditor = true;
        }

        string _FileName;
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                try
                {
                    TagLib.File file = TagLib.File.Create(_FileName);
                    TagLib.Tag tags = file.Tag;

                    tbTitle.Text = tags.Title;
                    tbAlbum.Text = tags.Album;
                    tbArtist.Text = string.Join(",", tags.AlbumArtists);
                    tbYear.Text = tags.Year.ToString();
                    tbTrack.Text = tags.Track.ToString();
                    tbGenre.Text = string.Join(",", tags.Genres);
                    tbComment.Text = tags.Comment;
                    
                }
                catch
                {
                }
            }
        }

        #region Code to move a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Mp3TagEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        private void bOk_Click(object sender, EventArgs e)
        {
            try
            {
                TagLib.File file = TagLib.File.Create(_FileName);
                TagLib.Tag tags = file.Tag;

                tags.Title = tbTitle.Text;
                tags.AlbumArtists = new string[] { tbArtist.Text };
                tags.Album = tbAlbum.Text;
                tags.Comment = tbComment.Text;
                tags.Genres = new string[] { tbGenre.Text };
                tags.Year = (uint)int.Parse(tbYear.Text);
                tags.Track = (uint)int.Parse(tbTrack.Text);

                file.Save();
            }
            catch (Exception ex) { 
#if Log
Console.WriteLine(ex);
#endif
 }

            this.DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
