using System;                   //For EventArgs
using System.Collections;       //For IEnumarator
using System.Windows.Forms;     //For common Window Controls
using System.IO;                //For FileInfo 
using System.Threading;         //For Thread Class
using System.Diagnostics;       //For using Process
using Microsoft.Win32;          //For Registry Manipulations
using System.Text.RegularExpressions; //For Performing Regular expressions job
using System.Runtime.InteropServices; //For SHObjectProperties from shell32.dll
using QuartzTypeLib;
/* meaning of prefixes used for different variables
 * b    = Button
 * l    = Label
 * ep   = ErrorProvider
 * rb   = RadioButton
 * cb   = CheckBox
 * tp   = ToolTip
 * cob  = ComboBox
 * lv   = ListView
 * dtp  = DateTimePicker 
 * clb  = CheckListBox
 * gb   = GroupBox
 * nud  = NumericUpDown
 * tsmi = ToolStripMenuItem
 * ll   = LinkLabel
 */


namespace Search_2006
{
    public struct AdvancedAttributes
    {
        public bool
            CaseSensitive ,  //true if user selects case sensitive checkbox
            Hidden ,         //true if user selects hidden checkbox
            ReadOnly ,       //true if user selects Readonly checkbox
            Archive ,        //true if user selects archive checkbox
       //     CriteriaBased ,  //true if user selects criteria based radiobutton
            PermissionBased;//true if user selects Permission based radiobutton

    }
    public struct DateAttributes
    {
        public bool
            Modified , //true if user selects Modified option in date criteria combo box
            Created ,  //true if user selects Created option in date criteria combo box
            Accessed; //true if user selects Accessed option in date criteria combo box
    }
    public struct SizeAttributes
    {
        public bool
            KB ,//true if user selects KB option in Size criteria combo box
            MB ,//true if user selects MB option in Size criteria combo box
            GB;//true if user selects GB option in Size criteria combo box
    }
    public partial class Form1 : Form
    {
        //Registry Keys Used in this program are
        //HKEY_CLASSES_ROOT\Folder\shell\Search 2006\command for context menu 
        //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Search 2006 for storing the data
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //Getting number drives in the local machine
            this.clbdrives.Items.AddRange( Directory.GetLogicalDrives() );

            //Getting the program setting from Registry 
            IntializeFromRegistry();

            //Check Weather the program is invoked from windows shell's context menu
            CheckForContextMenuInvokation();

            //intialize microsoft agent character named rover
            InitializeRover();

            //intialize  imagelist to lvresult
            lvresults.SmallImageList = Search.img1;

        }

        private void CheckForContextMenuInvokation()
        {
            tsmicontextmenu.CheckState = IsContextMenuSet() ? CheckState.Checked : CheckState.Unchecked;
            if( Program.args != null && Program.args.Length == 1 ) {
                filePath = Program.args[0];
                clbdrives.Enabled = false;
                bbrowse.Enabled = false;
                IsProgramInvokedFromContextMenu = true;
                RegistryKey rk = Registry.ClassesRoot.OpenSubKey( @"Folder\shell\Search 2006\command\" );
                SearchExePath = (string)rk.GetValue( "" );
            }

        }
        private void InitializeRover()
        {
            try {
                System.Resources.ResourceManager resources =
             new System.Resources.ResourceManager( typeof( Form1 ) );
                
                axAgent1.ContainingControl = this;
                axAgent1.Connected = true;
                axAgent1.Characters.Load( "rover" , Environment.ExpandEnvironmentVariables( "%windir%" ) + @"\srchasst\chars\rover.acs" );
                

          
            }
            catch( Exception e ) { MessageBox.Show( e.Source + " " + e.Message + " " + e.StackTrace ); }
        }


        bool IsProgramInvokedFromContextMenu = false;
        string SearchExePath;
        bool BalloonTips = true;

        //Check weather this program is set to shell's context menu from registry
        private bool IsContextMenuSet()
        {
            RegistryKey rk = Registry.ClassesRoot.OpenSubKey( @"Folder\shell\Search 2006\command\" , true );
            if( rk == null ) return false;
            return ( (string)rk.GetValue( "" ) ) != null ? true : false;
            //this is the way to check the value in (Default) Key for empty and (Default) key is denoted with ""
        }
        RegistryKey rk;
        //Initializing the program setting from registry 
        private void IntializeFromRegistry()
        {
            rk = Registry.CurrentUser.OpenSubKey( @"software\microsoft\Search 2006\" , true );
            //if the required registry key is not already present then create one 
            //this happens when the program is first executed
            if( rk == null ) {
                rk = Registry.CurrentUser.OpenSubKey( @"software\microsoft\" , true );
                rk.CreateSubKey( "Search 2006" );
                rk = rk.OpenSubKey( @"Search 2006\" , true );
            }
            //Get the file names that user previously used for searching files based on file names
            if( rk.GetValue( "Name" ) != null && ( (string)rk.GetValue( "Name" ) ).Trim() != "" )
                cobname.Items.AddRange( ( (string)rk.GetValue( "Name" ) ).Split( '#' ) );
            else
                rk.SetValue( "Name" , "" , RegistryValueKind.String );

            //Get the words that user previously used for searching files based on content of  a file
            if( rk.GetValue( "Word" ) != null && ( (string)rk.GetValue( "Word" ) ).Trim() != "" )
                cobword.Items.AddRange( ( (string)rk.GetValue( "Word" ) ).Split( '#' ) );
            else
                rk.SetValue( "Word" , "" , RegistryValueKind.String );

            //Get the list of directories that were previously excluded for searching 
            if( rk.GetValue( "ExcludeDir" ) != null && ( (string)rk.GetValue( "ExcludeDir" ) ).Trim() != "" )
                excludedir = ( (string)rk.GetValue( "ExcludeDir" ) ).Split( '#' );
            else
                rk.SetValue( "ExcludeDir" , "" , RegistryValueKind.String );

            //Check weather BalloonTips are allowed previously by the user or not 
            //if not don't show them this time.
            if( rk.GetValue( "BalloonTips" ) != null && ( (string)rk.GetValue( "BalloonTips" ) ).Trim() != "" ) {
                BalloonTips = true;
                tphelp.Active = true;
                tsmiballoontips.CheckState = CheckState.Checked;
            }
            else {
                BalloonTips = false;
                tphelp.Active = false;
                tsmiballoontips.CheckState = CheckState.Unchecked;
            }
        }

        //occurs when user selects the search by file name criteria radio button
        private void rbname_CheckedChanged( object sender , EventArgs e )
        {
            cobname.Enabled = rbname.Checked ? true : false; //enable cobname
            epname.Clear();  //Clear the Error provider assosiated with cobname
        }
        //occurs when user selects the search by date criteria radio button
        private void rbdate_CheckedChanged( object sender , EventArgs e )
        {
            cobdate.Enabled =
            dtpfrom.Enabled =
            dtpto.Enabled = rbdate.Checked ? true : false;
            cbcase.Enabled = rbdate.Checked ? false : true;
        }
        //occurs when user selects the search by size  criteria radio button
        private void rbsize_CheckedChanged( object sender , EventArgs e )
        {
            cobsize.Enabled =
            nudfrom.Enabled =
            nudto.Enabled = rbsize.Checked ? true : false;
            cbcase.Enabled = rbsize.Checked ? false : true;
        }
        //occurs when user selects the search by word criteria radio button
        private void rbword_CheckedChanged( object sender , EventArgs e )
        {
            cobword.Enabled = rbword.Checked ? true : false;
            epword.Clear();
        }
        private void cbbasedonpermissions_CheckedChanged( object sender , EventArgs e )
        {
            cbarchive.Enabled = cbhidden.Enabled = cbreadonly.Enabled = cbbasedonpermissions.Checked ? true : false;
        }

        //Create the requried structures
        Search_2006.AdvancedAttributes aa;
        Search_2006.DateAttributes da;
        Search_2006.SizeAttributes sa;

        Thread TThread , LargeFileThread;
        private void bstart_Click( object sender , EventArgs e )
        {
            if( tabPage1 == tabControl1.SelectedTab ) {
                //Make AdvancedAttributes structure 
                aa = new Search_2006.AdvancedAttributes();
                aa.CaseSensitive = cbcase.Checked ? true : false;
                aa.Hidden = cbhidden.Checked ? true : false;
                aa.Archive = cbarchive.Checked ? true : false;
                aa.ReadOnly = cbreadonly.Checked ? true : false;
             //   aa.CriteriaBased = rbbasedoncriteria.Checked ? true : false;
                aa.PermissionBased = cbbasedonpermissions.Checked ? true : false;

                //If search is file name  or word
                if( rbname.Checked || rbword.Checked ) {
                    //Fire another Thread to start the search
                    TThread = new Thread( Wrapper );
                    TThread.Priority = ThreadPriority.Highest;
                    TThread.Start();
                }
                //If search is based on date    
                if( rbdate.Checked ) {
                    //first check for dtpfrom value is <= to dtptp value
                    if( dtpfrom.Value.CompareTo( dtpto.Value ) >= 0 ) {
                        //Make DateAttributes Structure
                        da = new Search_2006.DateAttributes();
                        da.Accessed = cobdate.SelectedIndex == 2 ? true : false;
                        da.Created = cobdate.SelectedIndex == 1 ? true : false;
                        da.Modified = cobdate.SelectedIndex == 0 ? true : false;

                        //Fire another Thread to start the search
                        TThread = new Thread( Wrapper );
                        TThread.Priority = ThreadPriority.Highest;
                        TThread.Start();
                    }
                    else MessageBox.Show( "The value entered in From field should be lessthan To field...!" , "Search 2006" );
                }
                //If search is based on size
                if( rbsize.Checked ) {
                    //nudfrom value should be <= nudto value
                    if( nudfrom.Value <= nudto.Value ) {
                        //Make SizeAttributes Structure
                        sa = new Search_2006.SizeAttributes();
                        sa.KB = cobsize.SelectedIndex == 1 ? true : false;
                        sa.MB = cobsize.SelectedIndex == 2 ? true : false;
                        sa.GB = cobsize.SelectedIndex == 3 ? true : false;
                        //Fire another Thread to start the search
                        TThread = new Thread( Wrapper );
                        TThread.Priority = ThreadPriority.Highest;
                        TThread.Start();
                    }
                    else MessageBox.Show( "The value entered in Min field should be lessthan Max field...!" , "Search 2006" );
                }
            }
            if( tabControl1.SelectedTab == tabPage2 ) {
                LargeFileThread = new Thread( Tb2Wrapper );
                LargeFileThread.Priority = ThreadPriority.Highest;
                LargeFileThread.Start();
            }
        }
        private void Tb2Wrapper()
        {
            if( tb2filePath != "" ) {
                lstatus.Text = "Status : Searching in  " + tb2filePath + "  Please Wait...... ";
                rover.StopAll( "play" );
                rover.Play( "Searching" );
                lvresults.Items.Clear();
                max = 0;
                EnableDisable( false );
                StartLargestFileSearch( tb2filePath );
                lvresults.Items.Add( new ListViewItem( new String[] { "" + 1 , maxFile.Name , maxFile.FullName , "" + maxFile.Length } ) );
                lstatus.Text = "Status : Search Completed Sucessfully";
                rover.StopAll( "play" );
                rover.Play( "Pleased" );
                EnableDisable( true );
            }
            else {
                MessageBox.Show( "Please Select a directory......." );
                rover.StopAll( "play" );
                rover.Play( "Congratulate" );
            }
        }
        long max = 0;

        FileInfo f , maxFile;
        private void StartLargestFileSearch( string tb2filePath )
        {
            if( continue_ ) {
                foreach( string s in Directory.GetFiles( tb2filePath ) ) {
                    f = new FileInfo( s );
                    if( max < f.Length ) {
                        max = f.Length;
                        maxFile = f;
                    }
                }
                foreach( string s in Directory.GetDirectories( tb2filePath ) )
                    if( !new FileInfo( s ).Attributes.ToString().Contains( "Hidden, System, Directory" ) )
                        StartLargestFileSearch( s );
            }
        }

        private void Wrapper()
        {
            //disable the controls when search is started
            //this prevent user clicking the start button twice e.t.c
            EnableDisable( false );

            //initializing search class which contain actual searching code
            search = new Search_2006.Search();
            search.listView = lvresults;

            //When ever you start a new search make sure all the 
            //variables are at there defalut values 
            Initials();


            if( rbname.Checked )
                SearchForName();//prepares for name based search 
            //aslo checks weather user have given the
            //file name and selected a drive,
            //directory   or not
            else if( rbdate.Checked )
                SearchForDate();
            else if( rbsize.Checked )
                SearchForSize();
            else if( rbword.Checked )
                SearchForWord();  //prepares for name based search 
            //also checks weather user have given the
            //file name and selected a drive,
            //directory   or not

            //enable controls when search is finished
            EnableDisable( true );
        }
        private string fileName = null;
        private void SearchForName()
        {
            fileName = cobname.Text.Trim();
            //Check for weather invalid file name characters 
            //are present in given file name  or not

            if( !Equals( fileName , null ) && !fileName.Trim().Equals( "" ) &&
                !fileName.Contains( "\\" ) &&
                !fileName.Contains( "/" ) &&
                !fileName.Contains( ":" ) &&
                !fileName.Contains( "<" ) &&
                !fileName.Contains( ">" ) &&
                !fileName.Contains( "\"" )
                )
                //creates the simple regular pattern for the given file name
                fileName = ( "^" + fileName + "$" ).Replace( "." , @"\." ).Replace( "*" , ".*" ).Replace( "?" , "." );
            else {
                MessageBox.Show( "Please Enter a Valid File Name" );
                rover.StopAll( "play" );
                rover.Play( "Congratulate" );
                return;
            }

            if( aa.CaseSensitive )
                search.r = new Regex( fileName , RegexOptions.Compiled );
            else
                search.r = new Regex( fileName , RegexOptions.IgnoreCase | RegexOptions.Compiled );

            //check weather user selected drives are ready or not
            CheckForDrives();

            //adds the entered file name to combobox
            NameHandler();
            return;
        }
        private string word = null;
        private void SearchForWord()
        {
            word = cobword.Text.Trim();
            word = word.Replace( "." , @"\." ).Replace( "*" , ".*" ).Replace( "?" , "." );
            //Check weather the word or not null not empty ("")
            if( !string.IsNullOrEmpty( word ) ) {
                if( aa.CaseSensitive )
                    search.r = new Regex( word , RegexOptions.Compiled );
                else
                    search.r = new Regex( word , RegexOptions.IgnoreCase | RegexOptions.Compiled );

                CheckForDrives();
                WordHandler();
            }
            else {
                MessageBox.Show( "Enter a Valid Word To Search in a File" );
                rover.StopAll( "play" );
                rover.Play( "Congratulate" );
            }
        }

        private void SearchForSize()
        {
            CheckForDrives();
        }

        private void SearchForDate()
        {
            CheckForDrives();
        }

        private string filePath = null;
        private void CheckForDrives()
        {
            //get the selected drives list
            IEnumerator ie = clbdrives.CheckedItems.GetEnumerator();
            //if more than zero drives are selected
            if( clbdrives.CheckedItems.Count != 0 ) {
                try {
                    lstatus.Text = "Status : Search  is in Progress Please Wait......";
                    rover.StopAll( "play" );
                    rover.Play( "Searching" );
                    Thread.Sleep( 1000 );
                    //start traversing each selected drive one by one
                    while( ie.MoveNext() ) {
                        lstatus.Text = "Status : Searching in  " + (String)ie.Current + "  Please Wait...... ";
                        //make sure the selected drive is ready
                        if( new DriveInfo( (String)ie.Current ).IsReady )
                            //actual search process begins here
                            StartSearch( (String)ie.Current );
                        else {
                            MessageBox.Show( (String)ie.Current + " Drive is Not Ready" , "" );
                            rover.StopAll( "play" );
                            rover.Play( "Congratulate" );
                            return;
                        }
                    }
                    lstatus.Text = "Status : Search  Completed Sucessfully";
                    rover.StopAll( "play" );
                    rover.Play( "Pleased" );
                }
                catch //(Exception e)
                {
                    //MessageBox.Show("Exception in SearchForName:" + e.Message + e.StackTrace + "   " + e.GetType().ToString(), "");
                    //lstatus.Text = "Status : Search  Failed Because of " + e.GetType().ToString();
                    //rover.StopAll("play");
                }
            }
            //check weather a directory is selected or not
            //this comes only when not even a single drive is selected    
            else if( !Object.Equals( filePath , null ) ) {
                lstatus.Text = "Status : Searching in " + filePath + " Please Wait......";
                rover.StopAll( "play" );
                rover.Play( "Searching" );
                Thread.Sleep( 1000 );
                StartSearch( filePath );
                lstatus.Text = "Status : Search  Completed Sucessfully";
                rover.StopAll( "play" );
                rover.Play( "Pleased" );
            }
            //if neither drive nor directory is selected in form it to user
            else {
                MessageBox.Show( "Please Select a Drive in Step 2" , "" );
                rover.StopAll( "play" );
                rover.Play( "Congratulate" );
            }
        }
        private void WordHandler()
        {
            if( !cobword.Items.Contains( cobword.Text.Trim() ) )
                cobword.Items.Add( cobword.Text );
        }

        private void NameHandler()
        {
            if( !cobname.Items.Contains( cobname.Text.Trim() ) )
                cobname.Items.Add( cobname.Text );
        }
        Search_2006.Search search = null;
        FileInfo temp;
        int previous = 0;

        private void StartSearch( string filePath )
        {
            try {
                if( continue_ ) {
                    if( rbname.Checked ) {
                        search.SearchInSingleDirByName( filePath , aa );
                    }
                    else if( rbdate.Checked ) {
                        search.SearchInSingleDirByDate( filePath , dtpfrom.Value , dtpto.Value , aa , da );
                    }
                    else if( rbsize.Checked ) {
                        search.SearchInSingleDirBySize( filePath , (long)nudfrom.Value , (long)nudto.Value , aa , sa );
                    }
                    else if( rbword.Checked ) {
                        search.SearchInSingleDirByWord( filePath , aa );
                    }
                    if( cbsubdir.Checked ) {
                        foreach( string ss in Directory.GetDirectories( filePath ) ) {
                            if( !IsSSInExculdeDir( ss ) ) {
                                temp = new FileInfo( ss );
                                if( !temp.Attributes.ToString().Contains( "Hidden, System, Directory" ) ) {
                                    previous = lvresults.Items.Count;
                                    //   MessageBox.Show( ss );
                                    if( !cbhiddendir.Checked && cbsystemfolder.Checked &&
                                        !( temp.Attributes.ToString().Contains( "Hidden" ) ) )
                                        StartSearch( ss );
                                    else if( cbhiddendir.Checked && !cbsystemfolder.Checked &&
                                        !( temp.Attributes.ToString().Contains( "System" ) ) )
                                        StartSearch( ss );
                                    else if( cbhiddendir.Checked && cbsystemfolder.Checked )
                                        StartSearch( ss );
                                    else if( !cbsystemfolder.Checked && !cbhiddendir.Checked &&
                                        !( temp.Attributes.ToString().Contains( "System" ) ) &&
                                        !( temp.Attributes.ToString().Contains( "Hidden" ) ) )
                                        StartSearch( ss );
                                    //if ( lvresults.Items.Count > previous )
                                    //    lvresults.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
                                }
                            }
                        }

                    }

                }
            }
            catch { }
        }
        //Check Wheather the current directory is in exculde directory list or not
        private bool IsSSInExculdeDir( string ss )
        {
            if( excludedir != null ) {
                foreach( string s in excludedir )
                    if( s == ss )
                        return true;
            }
            return false;
        }
        bool continue_ = true;
        private void bstop_Click( object sender , EventArgs e )
        {
            if( tabPage1 == tabControl1.SelectedTab ) {
                continue_ = false;
                EnableDisable( true );
                lstatus.Text = "Status : Search Stop Sucessfully";
                rover.StopAll( "play" );
                rover.Play( "Embarrassed" );
                try {
                    if( TThread.IsAlive ) TThread.Abort();
                }
                catch { }
            }
            if( tabPage2 == tabControl1.SelectedTab ) {
                continue_ = false;
                EnableDisable( true );
                lstatus.Text = "Status : Search Stop Sucessfully";
                rover.StopAll( "play" );
                rover.Play( "Embarrassed" );
                try {
                    if( LargeFileThread.IsAlive ) LargeFileThread.Abort();
                }
                catch { }
            }
        }
        private void EnableDisable( bool b )
        {
            continue_ = !b;
            tabControl1.Enabled = b;
            bstart.Enabled = b;
            bdefault.Enabled = b;
        }


        private void Initials()
        {
            if( !Equals( search , null ) )
                search.k = 1;
            lvresults.Items.Clear();
        }
        private void SoftwareDefaultSetting()
        {
            if( tabPage1 == tabControl1.SelectedTab ) {

                if( !Equals( search , null ) )
                    search.k = 1;
                filePath = null;
                fileName = null;
                search = null;
                continue_ = false;
                rbname.Checked = true;
                rbsize.Checked = false;
                rbdate.Checked = false;
                rbword.Checked = false;
                cbbasedonpermissions.Checked = false;
               // rbbasedonpermissions.Checked = false;
           //     rbbasedoncriteria.Checked = true;
                cbcase.Checked = false;
                cbreadonly.Checked = false;
                cbhidden.Checked = false;
                cbarchive.Checked = true;
                cbsubdir.Checked = true;
                cbhiddendir.Checked = false;
                cbsystemfolder.Checked = true;
                lvresults.Items.Clear();
            }
        }
        FolderBrowserDialog fbd;
        private void bbrowse_Click( object sender , EventArgs e )
        {
            fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Please Select a Folder to search in that directory for the given file";
            if( fbd.ShowDialog() == DialogResult.OK ) {
                filePath = fbd.SelectedPath;
            }
        }

        private void bdefault_Click( object sender , EventArgs e )
        {
            SoftwareDefaultSetting();
        }


        private void tsmiopencontaining_Click( object sender , EventArgs e )
        {
            IEnumerator ie = lvresults.SelectedItems.GetEnumerator();
            while( ie.MoveNext() )
                Process.Start( new FileInfo( ( (ListViewItem)ie.Current ).SubItems[2].Text ).DirectoryName );
        }

        private void tsmiopenit_Click( object sender , EventArgs e )
        {
            IEnumerator ie = lvresults.SelectedItems.GetEnumerator();

            try {
                while( ie.MoveNext() )
                    Process.Start( ( (ListViewItem)ie.Current ).SubItems[2].Text );
            }
            catch( System.ComponentModel.Win32Exception ) {
                Process.Start( "Rundll32.exe" , "Shell32.dll,OpenAs_RunDLL " + ( (ListViewItem)ie.Current ).SubItems[2].Text );
            }
        }

        private void tsmirename_Click( object sender , EventArgs e )
        {
            FileInfo f;
            IEnumerator ie = lvresults.SelectedItems.GetEnumerator();
            Search_2006.Rename r = new Search_2006.Rename();
            while( ie.MoveNext() ) {
                if( r.ShowDialog() == DialogResult.OK ) {
                    f = new FileInfo( ( (ListViewItem)ie.Current ).SubItems[2].Text );
                    if( r.NewFileName != "" ) {
                        if( !File.Exists( f.DirectoryName + r.NewFileName ) ) {
                            f.MoveTo( f.DirectoryName + r.NewFileName );
                            ( (ListViewItem)ie.Current ).SubItems[2].Text = f.DirectoryName + r.NewFileName;
                        }
                        else {
                            MessageBox.Show( "Cannot Rename File:" + f.DirectoryName + r.NewFileName + "  Exists" , "" );
                            rover.StopAll( "play" );
                            rover.Play( "Congratulate" );
                        }
                    }
                }
            }
        }

        private void tsmidelete_Click( object sender , EventArgs e )
        {
            FileInfo f;
            IEnumerator ie = lvresults.SelectedItems.GetEnumerator();
            try {
                while( ie.MoveNext() ) {
                    f = new FileInfo( ( (ListViewItem)ie.Current ).SubItems[2].Text );
                    f.Delete();
                    ( (ListViewItem)ie.Current ).Remove();
                }
            }
            catch {
                MessageBox.Show( "The selected file cannot be deleted it is being used by Windows....!" );
            }

        }

        private void tsmicopyto_Click( object sender , EventArgs e )
        {
            fbd = new FolderBrowserDialog();
            fbd.Description = "Please Select a Folder to copy the Selected File";
            try {
                if( lvresults.SelectedItems.Count != 0 )
                    if( fbd.ShowDialog() == DialogResult.OK ) {
                        IEnumerator ie = lvresults.SelectedItems.GetEnumerator();
                        while( ie.MoveNext() ) {
                            File.Copy( ( (ListViewItem)ie.Current ).SubItems[2].Text , fbd.SelectedPath + "\\" + new FileInfo( ( (ListViewItem)ie.Current ).SubItems[2].Text ).Name );

                        }
                    }
            }
            catch {
                MessageBox.Show( "The selected file  cannot be copied .....!" );
            }
        }

        private void cobname_Validated( object sender , EventArgs e )
        {
            if( cobname.Text.Trim() == "" ||
                cobname.Text.Contains( "\\" ) ||
                cobname.Text.Contains( "/" ) ||
                cobname.Text.Contains( ":" ) ||
                cobname.Text.Contains( "<" ) ||
                cobname.Text.Contains( ">" ) ||
                cobname.Text.Contains( "\"" )
                )
                epname.SetError( cobname , "Search File Name Should Not Be Empty Or It Should Not Contain \\ / : < >\"" );
            else
                epname.SetError( cobname , "" );
        }

        private void cobword_Validated( object sender , EventArgs e )
        {
            if( cobword.Text.Trim() == "" )
                epword.SetError( cobword , "Search Word Should Not Be Empty" );
            else
                epword.SetError( cobword , "" );
        }
        Search_2006.ExcludeDir ed;
        string[] excludedir;
        private void bexclude_Click( object sender , EventArgs e )
        {
            if( ed == null ) {
                ed = new Search_2006.ExcludeDir();
                if( excludedir != null ) {
                    ed.excludedir = excludedir;
                    ed.IntializeListBox();
                }
            }
            if( ed.ShowDialog() == DialogResult.OK ) {
                if( ed.lbexcludedir.Items.Count != 0 ) {
                    excludedir = new string[ed.lbexcludedir.Items.Count];
                    Array.Copy( ed.excludedir , excludedir , ed.excludedir.Length );

                }
                else
                    excludedir = null;
            }
        }
        string temp1 = null;
        private void bpause_Click( object sender , EventArgs e )
        {
            if( tabPage1 == tabControl1.SelectedTab ) {
                if( TThread != null ) {
                    if( TThread.ThreadState == System.Threading.ThreadState.Running ) {
                        TThread.Suspend();
                        temp1 = lstatus.Text;
                        lstatus.Text = "Status : Searching process is currently paused";
                        bpause.Text = "Resume";
                    }
                    else if( TThread.ThreadState == System.Threading.ThreadState.Suspended ) {
                        TThread.Resume();
                        lstatus.Text = temp1;
                        bpause.Text = "Pause";
                    }
                }
            }
            if( tabControl1.SelectedTab == tabPage2 ) {
                if( LargeFileThread != null ) {
                    if( LargeFileThread.ThreadState == System.Threading.ThreadState.Running ) {
                        LargeFileThread.Suspend();
                        temp1 = lstatus.Text;
                        lstatus.Text = "Status : Searching  process is currently paused";
                        bpause.Text = "Resume";
                    }
                    else if( LargeFileThread.ThreadState == System.Threading.ThreadState.Suspended ) {
                        LargeFileThread.Resume();
                        lstatus.Text = temp1;
                        bpause.Text = "Pause";
                    }
                }
            }
        }
        private void Form1_FormClosing( object sender , FormClosingEventArgs e )
        {
            CancelButton.PerformClick();
            if( !this.bstart.Enabled ) this.CancelButton.PerformClick();
            InitializeToRegistry();
            rk.Close();

        }

        private void InitializeToRegistry()
        {
            string[] s = new string[cobname.Items.Count];
            cobname.Items.CopyTo( s , 0 );
            rk.SetValue( "Name" , String.Join( "#" , s ) , RegistryValueKind.String );

            s = new string[cobword.Items.Count];
            cobword.Items.CopyTo( s , 0 );
            rk.SetValue( "Word" , String.Join( "#" , s ) , RegistryValueKind.String );
            if( excludedir != null ) {
                s = new string[excludedir.Length];
                excludedir.CopyTo( s , 0 );
                rk.SetValue( "ExcludeDir" , String.Join( "#" , s ) , RegistryValueKind.String );
            }
            else if( excludedir == null )
                rk.SetValue( "ExcludeDir" , "" , RegistryValueKind.String );
        }
        private void tsmiclearhistory_Click( object sender , EventArgs e )
        {
            if( rk.GetValue( "Name" ) != null )
                rk.DeleteValue( "Name" );
            if( rk.GetValue( "Word" ) != null )
                rk.DeleteValue( "Word" );
            cobname.Items.Clear();
            cobword.Items.Clear();
        }

        private void tsmiexit_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void tsmicontextmenu_Click( object sender , EventArgs e )
        {
            if( tsmicontextmenu.CheckState == CheckState.Checked ) {
                if( MessageBox.Show( "Do you want to add Search 2006 to context menu" , "Search 2006" , MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                    RegistryKey rk = Registry.ClassesRoot.OpenSubKey( @"Folder\shell\Search 2006\command\" , true );
                    if( rk == null ) {
                        rk = Registry.ClassesRoot.OpenSubKey( @"Folder\shell\" , true );
                        rk.CreateSubKey( @"Search 2006\command\" );
                        rk = rk.OpenSubKey( @"Search 2006\command\" , true );
                    }
                    if( IsProgramInvokedFromContextMenu )
                        rk.SetValue( "" , SearchExePath , RegistryValueKind.String );
                    else
                        rk.SetValue( "" , Environment.CurrentDirectory + @"\Search 2006.exe  %1" , RegistryValueKind.String );
                    rk.Close();
                }
                else
                    tsmicontextmenu.CheckState = CheckState.Unchecked;
            }
            else if( tsmicontextmenu.CheckState == CheckState.Unchecked ) {
                if( MessageBox.Show( "Do you want to remove Search 2006 from context menu" , "Search 2006" , MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                    RegistryKey rk = Registry.ClassesRoot.OpenSubKey( @"Folder\shell\" , true );
                    if( rk != null ) {
                        rk.DeleteSubKeyTree( "Search 2006" );
                        rk.Close();
                    }
                }
                else
                    tsmicontextmenu.CheckState = CheckState.Checked;
            }
        }

        private void tsmiballoontips_Click( object sender , EventArgs e )
        {
            if( tsmiballoontips.CheckState == CheckState.Checked ) {
                rk.SetValue( "BalloonTips" , "Yes" , RegistryValueKind.String );
                BalloonTips = true;
                tphelp.Active = true;
            }
            if( tsmiballoontips.CheckState == CheckState.Unchecked ) {
                rk.SetValue( "BalloonTips" , "" , RegistryValueKind.String );
                BalloonTips = false;
                tphelp.Active = false;
            }
        }
        AboutSearch2006 about = new AboutSearch2006();
        private void tsmiabout_Click( object sender , EventArgs e2 )
        {
            rover.Play( "Writing" );
            QuartzTypeLib.FilgraphManager mc = new QuartzTypeLib.FilgraphManager();
            try {
                mc.RenderFile( "about.mp3" );
                
                mc.Run();
                about.ShowDialog();
                mc.Stop();
            }
            catch {
                about.ShowDialog();
                // MessageBox.Show( e.Message + "   " + e.Source + "   " + e.StackTrace );
            }
        }
        string tb2filePath = "";
        private void tb2llselect_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Please Select a Folder to search in that directory for the given file";
            if( fbd.ShowDialog() == DialogResult.OK ) {
                tb2filePath = fbd.SelectedPath;
            }
        }
        private void hideRoverToolStripMenuItem_Click( object sender , EventArgs e )
        {
            if( hideRovertsmi.Checked ) {
                rover.Show( 0 );
                hideRovertsmi.CheckState = CheckState.Unchecked;
            }
            else {
                rover.Hide( 0 );
                hideRovertsmi.CheckState = CheckState.Checked;
            }
        }
        private void lvresults_ColumnClick( object sender , ColumnClickEventArgs e )
        {
            lvresults.ListViewItemSorter = new SortIt( e.Column );
            lvresults.Sort();
        }

        private void tsmiproperties_Click( object sender , EventArgs e )
        {
            if( lvresults.SelectedItems.Count != 0 )
                SHObjectProperties( this.Handle , 0x00000002 , lvresults.SelectedItems[0].SubItems[2].Text , null );
        }

        [DllImport( "shell32.dll" , CharSet = CharSet.Unicode )]
        public extern static bool SHObjectProperties( IntPtr hwnd , uint dwType , String filename , String page );

   

        private void clbdrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbdrives.CheckedItems.Count  == 0) bbrowse.Enabled = true;
            else bbrowse.Enabled = false;
        }

        #region moving a form when dragged in client area

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

     

             
    }
    class SortIt : IComparer
    {
        int coloum;
        public SortIt( int coloum )
        {
            this.coloum = coloum;
        }

        public int Compare( object x , object y )
        {
            ListViewItem xx , yy;
            xx = (ListViewItem)x;
            yy = (ListViewItem)y;
            if( coloum == 1 || coloum == 2 || coloum == 4 )
                return string.Compare( xx.SubItems[coloum].Text , yy.SubItems[coloum].Text );
            else
                return int.Parse( xx.SubItems[coloum].Text ) - int.Parse( yy.SubItems[coloum].Text );

        }
    }
}
