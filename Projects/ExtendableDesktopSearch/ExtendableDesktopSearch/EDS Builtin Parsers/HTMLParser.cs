using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to extract the text content from a HTML file excluding all tags
    /// </summary>
    sealed class HTMLParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to HTML files
        public HTMLParser()
            : base()
        {
            fileProperties.Add("content", null);
            GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from html files
        /// <summary>
        /// This method sets various HTML file properties into a Dictionary 
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                #region extracting the content of HTML file using Regular expressions

                string code = File.ReadAllText(source);
                code = Regex.Replace(code, @"<\s*[h|H][e|E][a|A][d|D]\s*>(.|\n|\r)*?<\s*/\s*[h|H][e|E][a|A][d|D]\s*>", " ", RegexOptions.Compiled); //repalce <head> section with single whitespace
                code = Regex.Replace(code, @"<\s*[s|S][c|C][r|R][i|I][p|P][t|T] (.|\n|\r)*?<\s*/\s*[s|S][c|C][r|R][i|I][p|P][t|T]\s*>", " ", RegexOptions.Compiled);//repalce remaining <script> tags from body with single whitespace
                code = Regex.Replace(code, @"<!--(.|\n|\r)*?-->", " ", RegexOptions.Compiled);                      //repalce comments
                code = Regex.Replace(code, @"<(.|\n|\r)*?>", " ", RegexOptions.Compiled);                           //repalce all tags with single whitespace
                code = Regex.Replace(code, @"&.*?;", " ", RegexOptions.Compiled);                                   //replace &gt; e.t.c
                code = Regex.Replace(code, @"\s+", " ", RegexOptions.Compiled);                                     //replace multiple whitespaces characters by single whitespace
                code = Regex.Replace(code, @"\ufffd", " ", RegexOptions.Compiled);                                  //unknown character with 0xfffd value.
                
                string outputFile = GlobalData.OutputFile;
                using (StreamWriter sw = new StreamWriter(outputFile))                 //The outputFile will be Created and opened for writing
                    sw.Write(code);
                fileProperties["content"] = outputFile;
                #endregion

                #region basic file properties extraction logic
                return base.GetProperties(source); 
                #endregion
            }
            else if (Win32Helper.IsFileExist(source)) return base.GetProperties(source);
            return null;
        }
        #endregion

        /// <summary>
        /// This method represent the properties(keys) that every html file contains
        /// </summary>
        /// <returns>Returns a Property Key collection</returns>
        public ICollection Keys
        {
            get
            {
                return fileProperties.Keys;
            }
        }

        /// <summary>
        /// This Property returns the file types handled by this parser
        /// </summary>
        string FileTypes = ".html .htm .xml";
        public string ParserFileTypes
        {
            get
            {
                return FileTypes;
            }
            set
            {
                if (string.Compare(FileTypes, value, true) != 0) FileTypes += " " + value;
            }
        }
    }
}
