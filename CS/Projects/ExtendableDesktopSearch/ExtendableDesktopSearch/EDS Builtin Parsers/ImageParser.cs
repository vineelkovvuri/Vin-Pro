using System;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Drawing;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    sealed class ImageParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to image files
        public ImageParser()
            : base()
        {
            fileProperties.Add("width", null);
            fileProperties.Add("height", null);
            fileProperties.Add("hres", null);
            fileProperties.Add("vres", null);

            GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            GlobalData.ImageFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from Image files
        /// <summary>
        /// This method sets various image file properties into a Dictionary 
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                try
                {
                    Image image = Image.FromFile(source);
                    fileProperties["width"] = image.Width.ToString();
                    fileProperties["height"] = image.Height.ToString();
                    fileProperties["hres"] = (int)image.HorizontalResolution + "";
                    fileProperties["vres"] = (int)image.VerticalResolution + "";
                    image.Dispose();
                }
                catch { RemoveFileSpecificKeys(); }

                return base.GetProperties(source);
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
            fileProperties.Remove("width");
            fileProperties.Remove("height");
            //GlobalData.ImageFileTypes += this.ParserFileTypes + " ";
        }
        /// <summary>
        /// This method represent the properties(keys) that every image file contains
        /// </summary>
        /// <returns>Returns a Property Key collection</returns>
        public ICollection Keys
        {
            get { return fileProperties.Keys; }
        }

        /// <summary>
        /// This Property returns the file types handled by this parser
        /// </summary>
        string FileTypes = ".bmp .emf .jpeg .jpg .png .gif .tiff .wmf";
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
            get { return "pics"; }
        }
    }
}
