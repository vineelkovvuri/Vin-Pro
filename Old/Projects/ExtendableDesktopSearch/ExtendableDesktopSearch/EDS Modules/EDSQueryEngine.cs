using System;
using System.Collections.Generic;
using System.Text;
using Lucene.Net.Search;
using Lucene.Net.Analysis;
using Lucene.Net.QueryParsers;
using System.Collections.Specialized;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Documents;

namespace ExtendableDesktopSearch
{
    class EDSQueryEngine
    {
        #region Code for returning the results based on the posed query
        public List<Hit> GetDocResults(StringDictionary queryDic)
        {
            List<Hit> results = new List<Hit>();
            //Iterate over all the directories present in the %appdata%\EDS\indexes folder
            foreach (string dir in Directory.GetDirectories(GlobalData.IndexRootPath))
            {
                IndexSearcher ids = new IndexSearcher(dir);
                //Iterate over all the properties involved in the query 
                foreach (string property in queryDic.Keys)
                {
                    Query q = null;

                    #region Based on the property to be indexed, Create the necessary Analyser
                    switch (property)
                    {
                        case "content":
                            {
                                string value = queryDic["content"].
                                                Replace(@"\", @"\\").Replace("+", @"\+").Replace("-", @"\-").Replace("&", @"\&").
                                                Replace("|", @"\|").Replace("!", @"\!").Replace("(", @"\(").Replace(")", @"\)").
                                                Replace("{", @"\{").Replace("}", @"\}").Replace("[", @"\[").Replace("]", @"\]").
                                                Replace("^", @"\^").Replace("~", @"\~").Replace("*", @"\*").Replace("?", @"\?").Replace(":", @"\:");
                                q = new QueryParser(property, new KeywordAnalyzer()).Parse(value);
                            }
                            break;
                        case "size":
                            {
                                int idx;
                                string from, to;
                                idx = queryDic[property].IndexOf(' ');
                                from = queryDic[property].Substring(0, idx);
                                to = queryDic[property].Substring(idx + 1);
                                q = new RangeQuery(new Term(property, from.PadLeft(12, '0')), new Term(property, to.PadLeft(12, '0')), true);
                            }
                            break;
                        case "adate":
                        case "cdate":
                        case "mdate":
                        case "length":
                            {
                                int idx;
                                string from, to;
                                idx = queryDic[property].IndexOf(' ');
                                from = queryDic[property].Substring(0, idx);
                                to = queryDic[property].Substring(idx + 1);
                                q = new RangeQuery(new Term(property, from), new Term(property, to), true);
                            }
                            break;
                        case "all":
                            {
                                q = new QueryParser("name", new KeywordAnalyzer()).Parse(queryDic["all"]);
                            }
                            break;
                        default:
                            if (queryDic[property].Contains("*") || queryDic[property].Contains("?"))
                                q = new WildcardQuery(new Term(property, queryDic[property]));
                            else
                            {
                                string value = queryDic[property].
                                               Replace(@"\", @"\\").Replace("+", @"\+").Replace("-", @"\-").Replace("&", @"\&").
                                               Replace("|", @"\|").Replace("!", @"\!").Replace("(", @"\(").Replace(")", @"\)").
                                               Replace("{", @"\{").Replace("}", @"\}").Replace("[", @"\[").Replace("]", @"\]").
                                               Replace("^", @"\^").Replace("~", @"\~").Replace(":", @"\:");
                                q = new QueryParser(property, new KeywordAnalyzer()).Parse(value);
                            }
                            break;
                    }
                    #endregion

#if Log
                    Console.WriteLine("Lucene Query String:" + q.ToString());
#endif
                    //Get the results and sort them based on file name
                    Hits hits = ids.Search(q);//, new Sort("name"));

                    foreach (Hit hit in hits)
                        results.Add(hit); //Add the results to a List
                }
                // ids.Close();
            }
            return results;//Return the list 
        }
        #endregion


        #region Code for returning the results based on the posed query for emails
        public List<Hit> GetEmailResults(StringDictionary queryDic)
        {
            try
            {
                List<Hit> results = new List<Hit>();

                IndexSearcher ids = new IndexSearcher(GlobalData.EmailIndexPath);
                //Iterate over all the properties involved in the query 
                foreach (string property in queryDic.Keys)
                {
                    Query q = null;

                    #region Based on the property to be indexed, Create the necessary Analyser
                    switch (property)
                    {
                        case "body":
                            {
                                q = new QueryParser(property, new KeywordAnalyzer()).Parse(queryDic[property]);
                            }
                            break;

                        case "date":
                            {
                                int idx;
                                string from, to;
                                idx = queryDic[property].IndexOf(' ');
                                from = queryDic[property].Substring(0, idx);
                                to = queryDic[property].Substring(idx + 1);
                                q = new RangeQuery(new Term(property, from), new Term(property, to), true);
                            }
                            break;
                        default:
                            if (queryDic[property].Contains("*") || queryDic[property].Contains("?"))
                                q = new WildcardQuery(new Term(property, queryDic[property]));
                            else
                            {
                                //  PerFieldAnalyzerWrapper pfaw = new PerFieldAnalyzerWrapper();
                                q = new QueryParser(property, new KeywordAnalyzer()).Parse(queryDic[property]);

                            }
                            break;
                    }
                    #endregion

                    //Get the results
                    Hits hits = ids.Search(q);
                    foreach (Hit hit in hits)
                        results.Add(hit); //Add the results to a List
                }
                // ids.Close();
                return results;//Return the list 
            }
            catch { return null; }
        }
        #endregion
    }
}
