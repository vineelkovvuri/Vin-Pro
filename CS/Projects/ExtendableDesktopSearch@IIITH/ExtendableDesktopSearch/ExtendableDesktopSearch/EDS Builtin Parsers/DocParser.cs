using System;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to extract the text from microsoft word document using antidoc.exe
    /// </summary>
    sealed class DocParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to microsoft doc files
        public DocParser()
            : base()
        {
            fileProperties.Add("content", null);
            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from microsoft doc files
        /// <summary>
        /// This method sets various Doc file properties into a Dictionary 
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                #region extracting the content of Doc file from redirected antiword.exe process output stream

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = GlobalData.AntidocexePath;
                psi.Arguments = "\"" + source + "\"";       // " => accounts for file names containing spaces
                psi.EnvironmentVariables.Add("HOME", Directory.GetParent(GlobalData.AntidocexePath).Parent.FullName);
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                //Start antiword.exe process
                Process doc = Process.Start(psi);
                //doc.WaitForExit();
                string outputFile = GlobalData.OutputFile;
                using (StreamReader sr = doc.StandardOutput)
                using (StreamWriter sw = new StreamWriter(outputFile)) //The outputFile will be Created and opened for writing
                    while (!sr.EndOfStream)
                        sw.WriteLine(sr.ReadLine());
                
                if (doc.ExitCode == 0)
                    fileProperties["content"] = outputFile;
                else
                    RemoveFileSpecificKeys();
                #endregion

                #region basic file properties extraction logic

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
            fileProperties.Remove("content");
        }

        /// <summary>
        /// This method represent the properties(keys) that every doc file contains
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
        string FileTypes = ".doc";
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
