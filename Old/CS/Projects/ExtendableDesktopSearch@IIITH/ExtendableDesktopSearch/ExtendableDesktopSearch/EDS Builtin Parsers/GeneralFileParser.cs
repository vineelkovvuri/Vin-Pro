using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is a generic file properties handler => it is a wrapper for the the base class GenericFile and implements IEDSParser
    /// </summary>
   sealed class GeneralFileParser:GenericFile,IEDSParser
   {
       #region Constructor for adding properties specific to all files
       public GeneralFileParser()
            : base()
        {
        }
       #endregion

        #region Code to extract properties from all files
        public override StringDictionary GetProperties(string source)
        {
            if(File.Exists(source)) return base.GetProperties(source);
            else if (Win32Helper.PathExist(source)) return base.GetProperties(source);
            return null;
        }
        #endregion

        public ICollection Keys
        {
            get { return fileProperties.Keys; }
        }
        /// <summary>
        /// This Property returns the file types handled by this parser
        /// </summary>
        string FileTypes = "*.*"; // inital space is required in FileDispatcher Constructor sorting........!!!
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
            get { return "all"; }
        }
    }
}
