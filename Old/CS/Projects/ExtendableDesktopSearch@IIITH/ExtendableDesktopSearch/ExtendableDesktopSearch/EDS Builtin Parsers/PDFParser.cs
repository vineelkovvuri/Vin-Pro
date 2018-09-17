using System;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to extract the text and metadata attribute from a pdf file.
    /// </summary>
    sealed class PDFParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to pdf files
        public PDFParser()
            : base()
        {
            fileProperties.Add("title", null);
            fileProperties.Add("subject", null);
            fileProperties.Add("keywords", null);
            fileProperties.Add("author", null);
            fileProperties.Add("content", null);

            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from pdf files
        /// <summary>
        /// This method sets various PDF file properties into a Dictionary 
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                #region Pdf Specific Metadata extraction logic
                //Set the process attributes of pdfinfo.exe
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = GlobalData.PdfinfoexePath;
                psi.Arguments = "\"" + source + "\"";       // " => accounts for file names containing spaces
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;             //psi.WindowStyle = ProcessWindowStyle.Hidden;

                //Start pdfinfo.exe process
                Process p = Process.Start(psi);
                StreamReader sr = p.StandardOutput;
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    //populate the field,value pairs into the dictionary
                    if (line.StartsWith("Title:")) fileProperties["title"] = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Subject:")) fileProperties["subject"] = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Keywords:")) fileProperties["keywords"] = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Author:")) fileProperties["author"] = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Error:")) {RemoveFileSpecificKeys(); sr.Close(); return null; }    //pdf is password protected => u have no access to read its attributes
                }
                sr.Close();
                #endregion

                #region basic file properties,pdf content extraction logic

                string outputFile = GlobalData.OutputFile;
                psi.FileName = GlobalData.PdftotextexePath;
                psi.Arguments = " -l 20 " + "\"" + source + "\"" + " " + "\"" + outputFile + "\""; //assuming first 20 pages contain relevant data......shame on ur part ;)

                Process pdf = Process.Start(psi);
                pdf.WaitForExit();

                if (pdf.ExitCode == 0)
                    fileProperties["content"] = outputFile;
                else
                    RemoveFileSpecificKeys();
                return base.GetProperties(source);

                #endregion
            }
            else if (Win32Helper.PathExist(source)) { RemoveFileSpecificKeys(); return base.GetProperties(source); }
            return null;
        }
        #endregion

        /// <summary>
        /// This method removes the extra specific properties of the file.
        /// This is method is called when there is an exception while parsing the file( this could happen because of corrupted file format )
        /// By removing file specific keys we effectively make the 'specific file' a normal 'general file' (containing only basic properties) 
        /// </summary>
        private void RemoveFileSpecificKeys()
        {
            fileProperties.Remove("title");
            fileProperties.Remove("subject");
            fileProperties.Remove("keywords");
            fileProperties.Remove("author");
            fileProperties.Remove("content");
        }

        /// <summary>
        /// This method represent the properties(keys) that every pdf file contains
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
        string FileTypes = ".pdf";
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
