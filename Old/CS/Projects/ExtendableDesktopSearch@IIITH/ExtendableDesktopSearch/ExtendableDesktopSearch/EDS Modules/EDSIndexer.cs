using System;
using System.Collections.Specialized;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using System.Windows.Forms;
using Lucene.Net.Analysis.Standard;
namespace ExtendableDesktopSearch
{
    class EDSIndexer
    {
        #region Overloaded constructors for EDSIndexer
        IndexWriter index;
        public EDSIndexer(string desIndexPath)
            : this(desIndexPath, new KeywordAnalyzer(), false)
        {
        }
        public EDSIndexer()
            : this(GlobalData.IndexRootPath, new KeywordAnalyzer(), false)
        {

        }
        /// <summary>
        /// This constructor is responsible for setting the parameters for starting the indexer
        /// </summary>
        /// <param name="desIndexPath">Destination path where the indexes are stored</param>
        /// <param name="analyser">Default analyser used to index the content</param>
        /// <param name="overwriteIndexDir">This parameter if set to true overwites the content present in the desIndexPath Directory</param>
        /// keyword analyser is used for all properties becoz it stores the data as it is
        /// Stop analyzer is used for content to get rid of unneccessary words
        /// Standard analyzer is used for content of archive files to get rid of path separators
        PerFieldAnalyzerWrapper pfaw;
        Analyzer keywordAnalyzer;
        StopAnalyzer stopAnalyzer = new StopAnalyzer();
        StandardAnalyzer standardAnalyzer = new StandardAnalyzer();
        public EDSIndexer(string desIndexPath, Analyzer analyser, bool overwriteIndexDir)
        {
            keywordAnalyzer = analyser;
            pfaw = new PerFieldAnalyzerWrapper(analyser);
            pfaw.AddAnalyzer("content", stopAnalyzer);          //generally for content v use stop analyser
            try
            {
                index = new IndexWriter(desIndexPath, pfaw, overwriteIndexDir);
            }
            catch
            {
                index = new IndexWriter(desIndexPath, pfaw, true);
            }
        }
        #endregion

        #region Code for indexing a single document
        /// <summary>
        /// This method will index the contents present in the dictionary 
        /// </summary>
        /// <param name="keyValueDic">Dictionary object holding the key value pairs </param>
        public void Index(StringDictionary keyValueDic)
        {
            Document doc = new Document();
            foreach (string key in keyValueDic.Keys)
            {
                if (keyValueDic[key] != null)
                {
                    if (key == "content")
                    {
                        try
                        {
                            if (keyValueDic["type"] == ".rar" || keyValueDic["type"] == ".zip" || keyValueDic["type"] == ".gz" || keyValueDic["type"] == ".bz2" || keyValueDic["type"] == ".tar")
                                pfaw.AddAnalyzer("content", standardAnalyzer);  //for archive files v use standard analyzer
                            else pfaw.AddAnalyzer("content", stopAnalyzer);
                            doc.Add(new Field(key, new StreamReader(keyValueDic[key])));
                        }
                        catch { }
                    }
                    //else if (key == "path") doc.Add(new Field(key, keyValueDic[key], Field.Store.YES, Field.Index.NO));
                    else if (key == "size") doc.Add(new Field(key, keyValueDic[key].PadLeft(12, '0'), Field.Store.YES, Field.Index.NO_NORMS));
                    else doc.Add(new Field(key, keyValueDic[key].ToLower(), Field.Store.YES, Field.Index.NO_NORMS));
                }
            }
            try
            {
                if (keyValueDic["attr"].ToLower().Contains("hidden")) doc.SetBoost(.5f);  //setting the ranking or boosting factor of the document
                index.AddDocument(doc);
            }
            catch (Exception ex) {/* Console.WriteLine(keyValueDic["path"] + e.Message + " == " + e.StackTrace + "  " + e.Source); */}
        }
        #endregion

        #region Cleanup code once the indexer is used
        public void Optimize()
        {
            index.Optimize();
        }
        public void Close()
        {
            index.Close();
        }
        #endregion

        #region Optimize all indexes
        internal static void OptimizeAllIndexes()
        {
            PerFieldAnalyzerWrapper pfaw = new PerFieldAnalyzerWrapper(new KeywordAnalyzer());
            pfaw.AddAnalyzer("content", new StopAnalyzer());
            foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
            {
                IndexWriter writer = new IndexWriter(dir, pfaw, false);
                writer.Optimize();
                writer.Close();
            }

        }
        #endregion
    }
}
