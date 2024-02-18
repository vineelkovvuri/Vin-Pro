using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;

namespace ExtendableDesktopSearch
{
    class GenericDirectoryParser//:IEDSParser
    {
        protected StringDictionary fileProperties = null;

        private static GenericDirectoryParser dirParser;

        public static GenericDirectoryParser GetInstance()
        {
            if (dirParser == null) dirParser = new GenericDirectoryParser();
            return dirParser;
        }

        #region Constructor for adding properties specific to every files
        protected GenericDirectoryParser()
        {
            //Create Dictionary to hold the properties of the file
            fileProperties = new StringDictionary();
            fileProperties.Add("size", null);
            fileProperties.Add("name", null);
            fileProperties.Add("path", null);
            fileProperties.Add("attr", null);
            fileProperties.Add("type", null);
            fileProperties.Add("adate", null);
            fileProperties.Add("cdate", null);
            fileProperties.Add("mdate", null);
        }
        #endregion

        #region Code to extract metadata properties from every files
        /// <summary>
        /// This method sets various basic file properties into a Dictionary
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        /// How to handle PathTooLongException :(( 
        public virtual StringDictionary GetProperties(string source)
        {
            if (Directory.Exists(source))
            {
                DirectoryInfo dir = new DirectoryInfo(source);
                fileProperties["size"] = 0.ToString();
                fileProperties["name"] = dir.Name;
                fileProperties["path"] = dir.FullName;
                fileProperties["attr"] = dir.Attributes.ToString().ToLower();   //File Attributes string
                fileProperties["type"] = dir.Extension;

                string s;
                DateTime dt = dir.LastAccessTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties["adate"] = s;     //Accessed time

                dt = dir.CreationTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties["cdate"] = s;     //Created time

                dt = dir.LastWriteTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties["mdate"] = s;     //Modified time

                return fileProperties;
            }
            //else if (Win32Helper.IsFileExist(source))               //Rock with Win32 api and kick .NET api.....
            //{
            //    fileProperties["size"] = Win32Helper.FileSize(source).ToString();
            //    fileProperties["name"] = Path.GetFileName(source);
            //    fileProperties["path"] = source;
            //    fileProperties["attr"] = Win32Helper.GetAttributes(source);                    //File Attributes string
            //    fileProperties["type"] = Path.GetExtension(source);

            //    string s;
            //    DateTime dt = Win32Helper.LastAccessTime(source);
            //    s = dt.Year + "";
            //    if (dt.Month < 10) s += "0" + dt.Month;
            //    else s += dt.Month;
            //    if (dt.Day < 10) s += "0" + dt.Day;
            //    else s += dt.Day;
            //    fileProperties["adate"] = s;     //Accessed time

            //    dt = Win32Helper.CreatedTime(source);
            //    s = dt.Year + "";
            //    if (dt.Month < 10) s += "0" + dt.Month;
            //    else s += dt.Month;
            //    if (dt.Day < 10) s += "0" + dt.Day;
            //    else s += dt.Day;
            //    fileProperties["cdate"] = s;     //Created time

            //    dt = Win32Helper.LastModifiedTime(source);
            //    s = dt.Year + "";
            //    if (dt.Month < 10) s += "0" + dt.Month;
            //    else s += dt.Month;
            //    if (dt.Day < 10) s += "0" + dt.Day;
            //    else s += dt.Day;
            //    fileProperties["mdate"] = s;     //Modified time

            //    return fileProperties;
            //}
            return null;
        }
        #endregion
    }
}
