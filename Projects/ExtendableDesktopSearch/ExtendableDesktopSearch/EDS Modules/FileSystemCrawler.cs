using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security;
using Lucene.Net.Index;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is responsible for sequential scanning of entire harddisc and calling the indexer for indexing the files
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    class FileSystemCrawler
    {
        #region Code to Start the Crawler and Scheduler
        internal void StartCrawler()
        {
            // install the scheduler in a separate thread
            new Thread(delegate()
            {

#if Log
                Console.WriteLine("Initiating Resource Scheduler in file system crawler");
#endif
                Scheduler();
            }).Start();

            //Start the crawler in the current thread
#if Log
            Console.WriteLine("Initiating file system Crawler");
#endif
            long start = DateTime.Now.Ticks;
            foreach (string drive in GlobalData.Drives)
            {
                DriveInfo di = new DriveInfo(drive);
                if (di.IsReady && di.DriveType == DriveType.Fixed && GlobalData.RunCrawler)
                {
                    //check whether the index directory is clean or not. if not delete all files in it
                    if (Directory.Exists(GlobalData.IndexRootPath + drive[0]))
                        Directory.Delete(GlobalData.IndexRootPath + drive[0], true);
                    Directory.CreateDirectory(GlobalData.IndexRootPath + drive[0]);

                    //Initialize the indexer
                    GlobalData.Indexer = new EDSIndexer(GlobalData.IndexRootPath + drive[0]);
                    //Start File System Crawler
                    Crawler(drive);
                    //Optimize the indexes
                    GlobalData.Indexer.Optimize();
                    GlobalData.Indexer.Close();
                }
            }
#if Log
            Console.WriteLine("Completed File System Crawling");
#endif

            if (GlobalData.RunCrawler)  //only when the crawler finished its work do the following stuff.....otherwise if crawler has been terminated by closing the application donot do the following stuff
            {
                GlobalData.IndexingCompleted = true;
                long end = DateTime.Now.Ticks;
                DateTime dt = new DateTime(end - start);
                GlobalData.lIndexingStatus.Text = "Indexing: Completed 100% in " + (dt.Hour != 0 ? dt.Hour + "h:" : "") + (dt.Minute != 0 ? dt.Minute + "m:" : "") + (dt.Second != 0 ? dt.Second + "s: " : "") + (dt.Millisecond != 0 ? dt.Millisecond + "ms" : "");

                //update the statusbar indexed documents count
                int docCount = 0;
                foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
                {
                    IndexReader ir = IndexReader.Open(dir);
                    docCount += ir.NumDocs();
                    ir.Close();
                }

                if (GlobalData.MainStatusStrip != null && GlobalData.MainStatusStrip.Items.Count != 0)
                    GlobalData.MainStatusStrip.Items["tsslDocCount"].Text = docCount + " documents indexed ";

                //Finally start file system monitor for further file system updates
                if (GlobalData.RunMonitor)
                {
#if Log
                    Console.WriteLine("Starting File System Monitor");
#endif
                    FileSystemMonitor fsw = FileSystemMonitor.GetInstance();
                    foreach (string drive in Environment.GetLogicalDrives())
                        fsw.AddMonitor(drive);
                    fsw.StartAllMonitors();
                }
            }
            //after completion of crawling stop the scheduler by setting RunScheduler => false;
            GlobalData.RunScheduler = false;

        }
        #endregion

        #region Code containing the actual File System Crawling Logic (Recursive Tree Traversal)
        /// <summary>
        /// This Method is responsible for Crawling a given Volume or Path recursively.
        /// This method periodically checks the shared state variable 'crawlerState' and 
        /// crawls the given path only when it is set to CrawlerState.Run 
        /// 
        /// Note: The shared variable is modified by the scheduler periodically depending on the 
        ///       availability of system resources   
        /// </summary>
        /// <param name="path">Path to a root volume or a directory whose contents are to be crawled recursively</param>
        private void Crawler(string path)
        {
            if (GlobalData.RunCrawler)  //assume the app is running and user has not exited the application
            {
                try
                {
                    //Process files 
                    foreach (string file in Directory.GetFiles(path))
                    {
                        GlobalData.lIndexingStatus.Text = "Indexing: " + file;
                        if (crawlerState == CrawlerState.Run)  //Is the system in idle state
                        {
                            //Get the respective content handler. If no content handler is present return the default handler
                            IEDSParser parser = GlobalData.Parsers.ContainsKey(Path.GetExtension(file).ToLower()) ?
                                                GlobalData.Parsers[Path.GetExtension(file).ToLower()] : GlobalData.Parsers["*.*"];
                            if (parser != null)  //For some nasty reason the file got deleted or doesnot exist 
                            {
                                StringDictionary properties = parser.GetProperties(file);
                                if (properties != null)
                                {
#if Log
                                    Console.WriteLine("Indexing File:" + file);
#endif
                                    GlobalData.Indexer.Index(properties);
                                }
                            }
                        }
                        else if (crawlerState == CrawlerState.Stop) //If the system is not ready 
                        {
                            while (crawlerState == CrawlerState.Stop && GlobalData.RunScheduler && GlobalData.RunCrawler) //Check the status for every 1 sec 
                                Thread.Sleep(1000);
                        }
                        else if (!GlobalData.RunCrawler) break;    //if app is already close then we should also stop the crawler
                    }

                    //Process Directories
                    foreach (string dir in Directory.GetDirectories(path))
                    {
                        if (Path.GetFileName(dir).ToLower() != "recycler" ||
                            !string.IsNullOrEmpty(Path.GetDirectoryName(Path.GetDirectoryName(dir))))
                        {
                            GenericDirectoryParser parser = GenericDirectoryParser.GetInstance();
                            if (parser != null)
                            {
                                StringDictionary properties = parser.GetProperties(dir);
                                if (properties != null)
                                {
#if Log
                                    Console.WriteLine("Indexing Directory:" + dir);
#endif
                                    GlobalData.Indexer.Index(properties);
                                }
                            }
                            Crawler(dir);
                        }
                    }
                }
                catch (UnauthorizedAccessException uae) { }
            }
        }
        #endregion

        #region Code for Scheduler for calculating System Idle Time

        enum CrawlerState { Run, Stop };
        CrawlerState crawlerState = CrawlerState.Run; //Shared Variable <-- 
        /// <summary>
        /// This method is responsible for monitoring system resource and user activity with the computer
        /// And periodically changes the shared variable 'crawlerState'
        /// </summary>
        public void Scheduler()
        {
            PerformanceCounter pc = new PerformanceCounter("Processor", "% Idle Time", "_Total", true);

            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = Marshal.SizeOf(typeof(LASTINPUTINFO));
            while (GlobalData.RunScheduler)
            {
                if (GetLastInputInfo(ref info))
                {
                    if ((Environment.TickCount - info.dwTime) / 1000 > 5 && (int)pc.NextValue() > 40)
                    {
                        crawlerState = CrawlerState.Run;
                    }
                    else
                    {
                        crawlerState = CrawlerState.Stop;
                        if ((Environment.TickCount - info.dwTime) / 1000 <= 5)
                            GlobalData.lIndexingStatus.Text = string.Format("Indexing is paused and will be resumed in {0} sec of computer inactivity [ CPU Idle : {1:F2}% ]", 5 - (Environment.TickCount - info.dwTime) / 1000, pc.NextValue());
                    }
                }
                Thread.Sleep(1000);
            }
            pc.Close();
        }

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO info);
        internal struct LASTINPUTINFO
        {
            public int cbSize;
            public uint dwTime;
        }
        #endregion
    }
}
