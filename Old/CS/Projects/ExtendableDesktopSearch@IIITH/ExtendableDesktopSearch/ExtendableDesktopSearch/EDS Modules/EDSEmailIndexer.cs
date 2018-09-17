using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Net.Mail;
using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using System.IO;


namespace ExtendableDesktopSearch
{
    class EDSEmailIndexer
    {
        public void StartEmailIndexing()
        {
            if (!Directory.Exists(GlobalData.EmailIndexPath))
                Directory.CreateDirectory(GlobalData.EmailIndexPath);

            IndexWriter index;

            PerFieldAnalyzerWrapper pfaw = new PerFieldAnalyzerWrapper(new KeywordAnalyzer());
            pfaw.AddAnalyzer("body", new StopAnalyzer());
            try
            {
                index = new IndexWriter(GlobalData.EmailIndexPath, pfaw, false);
            }
            catch
            {
                index = new IndexWriter(GlobalData.EmailIndexPath, pfaw, true);
            }

            const string PopServer = "pop.google.in";
            const int PopPort = 995;
            const string User = "extendable.search";
            const string Pass = "vineelreddy";
            using (Pop3Client client = new Pop3Client(PopServer, PopPort, true, User, Pass))
            {
                client.Trace += new Action<string>(Console.WriteLine);
                //connects to Pop3 Server, Executes POP3 USER and PASS
                client.Authenticate();
                client.Stat();
                foreach (Pop3ListItem item in client.List())
                {
                    Document doc = new Document();
                    MailMessageEx message = client.RetrMailMessageEx(item);

                    doc.Add(new Field("subject", message.Subject.ToLower(), Field.Store.YES, Field.Index.NO_NORMS));
                    doc.Add(new Field("from", message.From.ToString().ToLower(), Field.Store.YES, Field.Index.NO_NORMS));
                    doc.Add(new Field("to", message.To.ToString().ToLower(), Field.Store.YES, Field.Index.NO_NORMS));
                    //doc.Add(new Field("date", message.DeliveryDate.ToLower(), Field.Store.YES, Field.Index.NO_NORMS));

                    string code = message.Body;
                    code = Regex.Replace(code, @"<\s*head\s*>(.|\n|\r)*?<\s*/\s*head\s*>", " ", RegexOptions.Compiled); //repalce <head> section with single whitespace
                    code = Regex.Replace(code, @"<\s*script (.|\n|\r)*?<\s*/\s*script\s*>", " ", RegexOptions.Compiled);//repalce remaining <script> tags from body with single whitespace
                    code = Regex.Replace(code, @"<!--(.|\n|\r)*?-->", " ", RegexOptions.Compiled);                      //repalce comments
                    code = Regex.Replace(code, @"<(.|\n|\r)*?>", " ", RegexOptions.Compiled);                           //repalce all tags with single whitespace
                    code = Regex.Replace(code, @"&.*?;", " ", RegexOptions.Compiled);                                   //replace &gt; e.t.c
                    code = Regex.Replace(code, @"\s+", " ", RegexOptions.Compiled);                                     //replace multiple whitespaces characters by single whitespace
                    code = Regex.Replace(code, @"\ufffd", " ", RegexOptions.Compiled);

                    doc.Add(new Field("body", code.ToLower(), Field.Store.YES, Field.Index.NO_NORMS));

                    index.AddDocument(doc);
                }
                client.Noop();
                client.Rset();
                client.Quit();
                index.Optimize();
                index.Close();
            }
        }
    }
}
