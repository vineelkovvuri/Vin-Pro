using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;
namespace Tree
{
    class Program:Form
    {
        static void Main( string [] args )
        {
            Application.EnableVisualStyles();
            Application.Run( new Program() );
        }

        TreeNode tempnode1,tempnode2;
        DriveInfo d;
        public Program()
        {
            ImageList il = new ImageList();
            il.Images.Add(Image.FromFile("d:\\a\\1.ico"));
            il.Images.Add(Image.FromFile("d:\\a\\2.ico"));
            il.Images.Add(Image.FromFile("d:\\a\\3.ico"));
            il.Images.Add(Image.FromFile("d:\\a\\4.ico"));
            il.Images.Add(Image.FromFile("d:\\a\\5.ico"));



            TreeView tv = new TreeView();
            
            tv.Parent = this;
            tv.Dock = DockStyle.Fill;
            tv.CheckBoxes = true;
            tv.Sort();
            tv.AfterExpand += new TreeViewEventHandler( tv_AfterExpand );
            tv.ImageList = il;
                foreach ( string s in Directory.GetLogicalDrives() )
                {
                    tv.Nodes.Add( tempnode1 = new TreeNode( s ) );
                    d = new DriveInfo(s);
                    if(d.DriveType == DriveType.Removable) tempnode1.ImageIndex = 0;
                else if ( d.DriveType == DriveType.Fixed )
                    tempnode1.ImageIndex = 1;
                else if ( d.DriveType == DriveType.CDRom )
                    tempnode1.ImageIndex = 2;
                else if ( d.DriveType == DriveType.Ram )
                    tempnode1.ImageIndex = 3;
                    if(d.IsReady)
                        foreach ( string ss in Directory.GetDirectories( s ) )
                        {
                            if ( !new FileInfo( ss ).Attributes.ToString().Contains( "System" ) )
                                tempnode1.Nodes.Add( tempnode2 = new TreeNode( new DirectoryInfo( ss ).Name ) );
                            tempnode2.ImageIndex = 4;
                        }
                }
        }
        
        IEnumerator ie;
        void tv_AfterExpand( object sender , TreeViewEventArgs e )
        {
            this.Text = e.Node.FullPath;
                ie = e.Node.Nodes.GetEnumerator();
               while ( ie.MoveNext() )
                {
                    if (((TreeNode)ie.Current).GetNodeCount( false ) == 0 )
                    {
                        foreach ( string s in Directory.GetDirectories( ( ( TreeNode )ie.Current ).FullPath ) )
                        {
                            if ( !new FileInfo( s ).Attributes.ToString().Contains( "System" ) )
                                ( ( TreeNode )ie.Current ).Nodes.Add( tempnode2 =  new TreeNode( new DirectoryInfo( s ).Name ) );
                            tempnode2.ImageIndex = 4;
                        }
                    }
                }
            
        }
    }
}
