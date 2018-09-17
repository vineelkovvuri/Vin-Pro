using System;
using System.Collections.Generic;
using System.Text;
using IEDSInterface;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
namespace ABCFileParser
{
    public class ABCParser : IEDSParser
    {

        public ABCParser()
        {

        }

        #region IEDSParser Members
        StringDictionary fileProperties = new StringDictionary();
        public StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                
                FileInfo file = new FileInfo(source);

                fileProperties.Add("name", file.Name);
                fileProperties.Add("path", file.FullName);
                fileProperties.Add("size", file.Length.ToString());
                fileProperties.Add("attr", file.Attributes.ToString().ToLower());
                fileProperties.Add("type", file.Extension);

                string s;
                DateTime dt = file.LastAccessTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties.Add("adate", s);     //Accessed time

                dt = file.CreationTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties.Add("cdate", s);   //Created time

                dt = file.LastWriteTime;
                s = dt.Year + "";
                if (dt.Month < 10) s += "0" + dt.Month;
                else s += dt.Month;
                if (dt.Day < 10) s += "0" + dt.Day;
                else s += dt.Day;
                fileProperties.Add("mdate", s);     //Modified time


                fileProperties.Add("content", source);
                return fileProperties;

            }
            else return null;

        }

        public ICollection Keys
        {
            get { return fileProperties.Keys; }
        }

        string FileType = ".abc";
        public string ParserFileTypes
        {
            get
            {
                return FileType;
            }
            set
            {
                FileType = value;
            }
        }

        public string ParserCategory
        {
            get { return "docs"; }
        }
        #endregion
    }
}
