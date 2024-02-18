using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Lucene.Net.Index;
using System.Collections.Specialized;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class encapsulates the details of handling and monitoring the file system activites
    /// </summary>
    class FileSystemMonitor
    {
        Dictionary<string, FileSystemWatcher> monitor = new Dictionary<string, FileSystemWatcher>(32);

        #region Construction of FileSystemMonitor (implemented as Singleton Pattern)
        private FileSystemMonitor() { }
        static FileSystemMonitor crawler;
        public static FileSystemMonitor GetInstance()
        {
            if (crawler == null) { crawler = new FileSystemMonitor(); GlobalData.RunMonitor = true; }
            return crawler;
        }
        #endregion

        #region This method starts all the monitors that are currently configured
        Timer fileSystemMonitorScheduler;
        public void StartAllMonitors()
        {
            foreach (string key in monitor.Keys)
                monitor[key].EnableRaisingEvents = true;

            //Create the File System Monitor Scheduler
            fileSystemMonitorScheduler = new Timer(IndexGatheredFiles, null, 0, 10 * 1000);
        }
        #endregion

        #region This method stops all the monitors that are currently configured
        public void StopAllMonitors()
        {
            foreach (string key in monitor.Keys)
                monitor[key].EnableRaisingEvents = true;

            EDSIndexer.OptimizeAllIndexes();  //finally optimize all indexes which have been updated by file system monitor

            //Stop the scheduler Thread
            fileSystemMonitorScheduler.Dispose();
        }
        #endregion

        #region Add a new monitor whose source is specified in 'source' parameter
        public void AddMonitor(string source)//"source" Indicates the source of the monitor
        {
            if (new DriveInfo(source).IsReady)
            {
                try
                {
                    FileSystemWatcher fswatch = new FileSystemWatcher();
                    fswatch.Path = source;
                    fswatch.IncludeSubdirectories = true;
                    fswatch.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime
                                           | NotifyFilters.FileName;
                    fswatch.Changed += new FileSystemEventHandler(fsChanged);
                    fswatch.Created += new FileSystemEventHandler(fsChanged);
                    fswatch.Deleted += new FileSystemEventHandler(fsChanged);
                    fswatch.Renamed += new RenamedEventHandler(fsRenamed);

                    monitor.Add(fswatch.Path, fswatch);
                }
                catch
                {
#if Log
                    Console.WriteLine("A watcher already exists"); 
#endif
                }
            }
        }
        #endregion

        #region Removes an already installed monitor
        public void RemoveMonitor(string source) //"source" Indicates the source of the monitor
        {
            monitor.Remove(source);
        }
        #endregion

        #region Handler responsible for analyzing the file system notifications based on e.ChangeType member of FileSystemEventArgs object
        string rootPath = GlobalData.IndexRootPath.ToLower();
        void fsChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        if (!e.FullPath.ToLower().Contains(@"\recycler") && !e.FullPath.ToLower().Contains(@"\system volume information\") && GlobalData.DefaultExtensions.Contains(Path.GetExtension(e.FullPath).ToLower()) && !e.FullPath.ToLower().StartsWith(rootPath))
                        {
                            if (Win32Helper.PathExist(e.FullPath)) // only include newly created file not directory (as dirs ll be empty initially)
                            {
                                lock (GlobalData.CreatedFiles)
                                    GlobalData.CreatedFiles.Add(e.FullPath);
                                //IndexCreatedFile(e.FullPath);
                                GlobalData.lIndexingStatus.Text = "Created File: " + e.FullPath;
                            }
                        }
                        break;

                    case WatcherChangeTypes.Deleted:
                        if (!e.FullPath.ToLower().Contains(@"\recycler") && !e.FullPath.ToLower().Contains(@"\system volume information\") && GlobalData.DefaultExtensions.Contains(Path.GetExtension(e.FullPath).ToLower()) && !e.FullPath.ToLower().StartsWith(rootPath))
                        {
                            if (Win32Helper.PathExist(e.FullPath))
                            {
                                if (GlobalData.CreatedFiles.Contains(e.FullPath))
                                    lock (GlobalData.CreatedFiles)
                                        GlobalData.CreatedFiles.Remove(e.FullPath);
                                else
                                {
                                    lock (GlobalData.DeletedFiles)
                                        GlobalData.DeletedFiles.Add(e.FullPath);
                                    GlobalData.lIndexingStatus.Text = "Deleted File: " + e.FullPath;
                                }
                            }
                        }
                        break;

                    //case WatcherChangeTypes.Changed:
                    //    if (!e.FullPath.ToLower().Contains(@"\recycler") && !e.FullPath.ToLower().Contains(@"\system volume information\") && GlobalData.DefaultExtensions.Contains(Path.GetExtension(e.FullPath).ToLower()) && !e.FullPath.ToLower().StartsWith(rootPath))
                    //    {
                    //        if (Win32Helper.PathExist(e.FullPath))
                    //            if (!GlobalData.CreatedFiles.Contains(e.FullPath))
                    //            {
                    //                lock (GlobalData.ChangedFiles)
                    //                    GlobalData.ChangedFiles.Add(e.FullPath);
                    //                GlobalData.lIndexingStatus.Text = "Changed File: " + e.FullPath;
                    //            }
                    //    }
                    //    break;
                }
            }
            catch (UnauthorizedAccessException UAE)
            {
#if Log
    Console.WriteLine(UAE.ToString()); 
#endif
            }
        }
        void fsRenamed(object sender, RenamedEventArgs e)
        {
            try
            {
                if (!e.FullPath.ToLower().Contains(@"\recycler") && !e.FullPath.ToLower().Contains(@"\system volume information\") && GlobalData.DefaultExtensions.Contains(Path.GetExtension(e.FullPath).ToLower()) && !e.FullPath.ToLower().StartsWith(rootPath))
                {
                    if (Win32Helper.PathExist(e.FullPath))
                        if (string.Compare(e.OldName, e.Name, true) != 0)  //oldname and new name are not equal
                        {
                            lock (GlobalData.RenamedFiles)
                                GlobalData.RenamedFiles.Add(e);
                            GlobalData.lIndexingStatus.Text = "Renamed File: " + Path.GetDirectoryName(e.FullPath) + @"\[" + Path.GetFileName(e.OldFullPath) + " => " + Path.GetFileName(e.FullPath) + "]";
                        }
                }
            }
            catch (UnauthorizedAccessException UAE)
            {
#if Log
    Console.WriteLine(UAE.ToString()); 
#endif
            }
        }
        #endregion

        #region File System Monitor's Merger logic //if there is any failure in the logic its becoz foreach use for instead
        void IndexGatheredFiles(object state)
        {
            try
            {
                #region Deleting files from the indexes
                //Iterate over all the directories present in the %appdata%\EDS\indexes folder
                if (GlobalData.DeletedFiles.Count > 0)
                {
                    foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                    {
                        //Deletion of files from indexes 
                        IndexReader reader = IndexReader.Open(dir);
                        lock (GlobalData.DeletedFiles)
                        {
                            //foreach (string path in GlobalData.DeletedFiles)
                            while (GlobalData.DeletedFiles.Count != 0)
                            {
                                reader.DeleteDocuments(new Term("path", GlobalData.DeletedFiles[0]));
                                GlobalData.lIndexingStatus.Text = GlobalData.DeletedFiles[0] + " is deleted from indexes";
                                GlobalData.DeletedFiles.RemoveAt(0);
                            }
                        }
                        reader.Close();
                    }
                }
                #endregion

                #region indexing newly created files
                //Indexing of new Files
                if (GlobalData.CreatedFiles.Count > 0)
                {
                    lock (GlobalData.CreatedFiles)
                    {
                        //   foreach (string path in GlobalData.CreatedFiles)
                        while (GlobalData.CreatedFiles.Count != 0)
                        {
                            string path = GlobalData.CreatedFiles[0];
                            //Get the respective content handler. If no content handler is present return the default handler
                            IEDSParser parser = GlobalData.Parsers.ContainsKey(Path.GetExtension(path).ToLower()) ?
                                                GlobalData.Parsers[Path.GetExtension(path).ToLower()] : GlobalData.Parsers["*.*"];
                            if (parser != null)  //For some nasty reason the file got deleted or doesnot exist 
                            {
                                StringDictionary properties = parser.GetProperties(path);
                                if (properties != null)
                                {
                                    //Initialize the indexer
                                    EDSIndexer indexer = new EDSIndexer(GlobalData.IndexRootPath + path[0]);
                                    indexer.Index(properties);
                                    indexer.Close();

                                }
                            }
                            GlobalData.lIndexingStatus.Text = GlobalData.CreatedFiles[0] + " is newly indexed";
                            GlobalData.CreatedFiles.RemoveAt(0);
                        }
                    }
                }
                #endregion

                #region Updating already indexed files

                lock (GlobalData.ChangedFiles)
                {
                    //foreach (string path in GlobalData.ChangedFiles)
                    while (GlobalData.ChangedFiles.Count != 0)
                    {
                        string path = GlobalData.ChangedFiles[0];
                        //first delete that document
                        foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                        {
                            //Deletion of files from indexes 
                            IndexReader reader = IndexReader.Open(dir);
                            reader.DeleteDocuments(new Term("path", path));
                            bool deleted = reader.HasDeletions();
                            reader.Close();
                            if (deleted) break;
                        }
                        //reindex the document
                        //Get the respective content handler. If no content handler is present return the default handler
                        IEDSParser parser = GlobalData.Parsers.ContainsKey(Path.GetExtension(path).ToLower()) ?
                                            GlobalData.Parsers[Path.GetExtension(path).ToLower()] : GlobalData.Parsers["*.*"];
                        if (parser != null)  //For some nasty reason the file got deleted or doesnot exist 
                        {
                            StringDictionary properties = parser.GetProperties(path);
                            if (properties != null)
                            {
                                //Initialize the indexer
                                EDSIndexer indexer = new EDSIndexer(GlobalData.IndexRootPath + path[0]);
                                indexer.Index(properties);
                                indexer.Close();
                            }
                        }
                        GlobalData.lIndexingStatus.Text = path + " is updated in the indexes";
                        GlobalData.ChangedFiles.RemoveAt(0);
                    }
                }

                #endregion

                #region Updating renamed files
                lock (GlobalData.RenamedFiles)
                {
                    //foreach (string path in GlobalData.ChangedFiles)
                    while (GlobalData.RenamedFiles.Count != 0)
                    {
                        string path = GlobalData.RenamedFiles[0].OldFullPath;
                        //first delete the old document
                        foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                        {
                            //Deletion of files from indexes 
                            IndexReader reader = IndexReader.Open(dir);
                            reader.DeleteDocuments(new Term("path", path));
                            bool deleted = reader.HasDeletions();
                            reader.Close();
                            if (deleted) break;
                        }
                        //reindex the new document
                        //Get the respective content handler. If no content handler is present return the default handler
                        path = GlobalData.RenamedFiles[0].FullPath;
                        IEDSParser parser = GlobalData.Parsers.ContainsKey(Path.GetExtension(path).ToLower()) ?
                                            GlobalData.Parsers[Path.GetExtension(path).ToLower()] : GlobalData.Parsers["*.*"];
                        if (parser != null)  //For some nasty reason the file got deleted or doesnot exist 
                        {
                            StringDictionary properties = parser.GetProperties(path);
                            if (properties != null)
                            {
                                //Initialize the indexer
                                EDSIndexer indexer = new EDSIndexer(GlobalData.IndexRootPath + path[0]);
                                indexer.Index(properties);
                                indexer.Close();
                            }
                        }
                        GlobalData.lIndexingStatus.Text = "Renamed file " + path + " is updated in the indexes";
                        GlobalData.RenamedFiles.RemoveAt(0);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
#if Log
    Console.WriteLine(ex); 
#endif
            }
        }
        #endregion
    }
}
