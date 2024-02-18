using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to extract the version information from PE files
    /// </summary>
    sealed class PEParser : GenericFile, IEDSParser
    {
        public PEParser()
            : base()
        {
            fileProperties.Add("companyname", null);
            fileProperties.Add("filedesc", null);
            fileProperties.Add("filever", null);

            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }

        /// <summary>
        /// This method sets various PE file properties into a Dictionary 
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                #region extracting the content of Doc file from redirected antiword.exe process output stream

                FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(source);
                fileProperties["companyname"] = fileInfo.CompanyName;
                fileProperties["filedesc"] = fileInfo.FileDescription;
                fileProperties["filever"] = fileInfo.FileVersion;

                #endregion

                #region basic file properties extraction logic

                return base.GetProperties(source);

                #endregion
            }
            else if (Win32Helper.PathExist(source)) return base.GetProperties(source);
            return null;
        }

        /// <summary>
        /// This method represent the properties(keys) that every PE file contains
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
        string FileTypes = ".dll .exe .sys";
        public string ParserFileTypes
        {
            get
            {
                return FileTypes;
            }
            set
            {

            }
        }
        public string ParserCategory
        {
            get { return "docs"; }
        }
    }
}
