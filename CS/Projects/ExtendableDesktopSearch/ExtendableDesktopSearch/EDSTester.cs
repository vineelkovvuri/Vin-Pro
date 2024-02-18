using System;
using System.Threading;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis;
namespace ExtendableDesktopSearch
{
    static class EDSTester
    {
        static void Main()
        {
            long start = DateTime.Now.Ticks;
            #region testing code for indexing
            //new FileDispatcher();
            //new FileSystemCrawler().StartCrawler();
            #endregion

            //PerFieldAnalyzerWrapper pfaw = new PerFieldAnalyzerWrapper(new KeywordAnalyzer());
            //pfaw.AddAnalyzer("content", new StopAnalyzer());
            //IndexWriter iw = new IndexWriter(GlobalData.IndexRootPath, pfaw, false);
            //iw.Optimize();
            
            //iw.Close();

            #region Testing Querying logic code
            //EDSQueryEngine queryEngine = new EDSQueryEngine();
            //StringDictionary sd = new StringDictionary();
            ////sd.Add("comment", "*gu");
            ////sd.Add("companyname", "microsoft corporation");
            ////sd.Add("cdate", "20080325 20080330");
            //sd.Add("size", "10000 20000");
            ////sd.Add("name", "kernel32.dll");
            //List<Hit> hits = queryEngine.GetDocResults(sd);
            //foreach (Hit hit in hits)
            //{
            //    try
            //    {
            //        Console.WriteLine(hit.Get("name"));
            //        Console.WriteLine(hit.Get("path"));
            //        Console.WriteLine(hit.Get("size"));
            //        Console.WriteLine(hit.Get("date"));
            //        Console.WriteLine(hit.Get("companyname"));
            //        Console.WriteLine(hit.Get("type"));
            //    }
            //    catch (Exception ex) { Console.WriteLine(ex); }
            //}

            #endregion
            long end = DateTime.Now.Ticks;
            DateTime dt = new DateTime(end - start);
            //Console.WriteLine(dt.Minute + "::" + dt.Second);

            #region Sample testing code for installed plugins
            //string file = @"D:\softs\VCS\eula.1033.txt";
            //new FileDispatcher();
            //IEDSParser parser = GlobalData.Parsers.ContainsKey(Path.GetExtension(file).ToLower()) ?
            //                            GlobalData.Parsers[Path.GetExtension(file).ToLower()] : GlobalData.Parsers["*.*"];
            //StringDictionary sd = parser.GetProperties(file);
            //if (sd != null)    //if the file doesn't exist 
            //{
            //    foreach (string key in sd.Keys)
            //    {
            //        if (key != "content")
            //            Console.WriteLine(key + " => " + sd[key]);
            //        else
            //        {
            //            Console.WriteLine(key + " => " + sd[key]);
            //            StreamReader sr = new StreamReader(sd[key]);
            //            Console.OutputEncoding = Encoding.ASCII;
            //            while (!sr.EndOfStream)
            //                Console.WriteLine(sr.ReadLine());
            //            sr.Close();
            //        }
            //    }
            //}
            #endregion

            //FSMonitor fsw = new FSMonitor();
            //foreach (string drive in Environment.GetLogicalDrives())
            //    fsw.AddMonitor(drive);
            //fsw.StartAllMonitors();

            //while (true)
            //{
            //    Console.Read();
            //    foreach (string file in GlobalData.createdFiles)
            //        Console.WriteLine("C => " + file);
            //    foreach (string file in GlobalData.deletedFiles)
            //        Console.WriteLine("D => "+file);
            //}
            //            Thread.Sleep(Timeout.Infinite);
        }
    }
}
