using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class Handles all kind of plain text file types like .txt, .log, .c, .h, .cpp e.t.c
    /// </summary>
    sealed class TextFileParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to text files
        public TextFileParser()
            : base()
        {
            fileProperties.Add("content", null);
            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract the properties from text files
        /// <summary>
        /// This method sets various text file properties into a Dictionary
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                fileProperties["content"] = source;
                return base.GetProperties(source);
            }
            else if (Win32Helper.PathExist(source)) return base.GetProperties(source);
            return null;
        }
        #endregion

        /// <summary>
        /// This method represent the properties(keys) that every text file contains
        /// </summary>
        /// <returns>Returns a Property Key collection</returns>
        public ICollection Keys
        {
            get { return fileProperties.Keys; }
        }

        /// <summary>
        /// This Property returns the file types handled by this parser
        /// </summary>
        string FileTypes = ".txt .c .h .cpp .cs .java .bat .cmd .nt .pl .py .asm .js .vbs .vb"; //.log
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
        public string ParserCategory
        {
            get { return "docs"; }
        }
    }
}
