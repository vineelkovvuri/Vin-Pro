using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    sealed class VideoParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to video files
        public VideoParser()
            : base()
        {
            fileProperties.Add("length", null);
            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.VideoFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from video files
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                try
                {
                    TagLib.File file = TagLib.File.Create(source);
                    TagLib.Tag tags = file.Tag;
                    fileProperties["length"] = TimeSpan.Parse(file.Properties.Duration.Hours + ":" + file.Properties.Duration.Minutes + ":" + file.Properties.Duration.Seconds).ToString();
                }
                catch { RemoveFileSpecificKeys(); }
                return base.GetProperties(source);
            }
            else if (Win32Helper.PathExist(source)) return base.GetProperties(source);
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
            fileProperties.Remove("length");
        }
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
        string parserFileTypes = ".3g2 .3gp .3gp2 .amc .asx .avi .dv .ivf .m1v .m2v .m4e .mkv .mov .mod .mp2 .mp2v .mpe .mpeg .mpg .mps .mpv .mpv2 .mswmm .ogm .qt .ram .rm .rv .wm .wmp .wmv .wmx .wvx";
        public string ParserFileTypes
        {
            get
            {
                return parserFileTypes;
            }
            set
            {
                if (string.Compare(parserFileTypes, value, true) != 0) parserFileTypes += " " + value;
            }
        }
        public string ParserCategory
        {
            get { return "video"; }
        }
    }
}

/*
 * 3g2 3gp 3gp2 amc asf asx avi dv ivf m1v m2v m4e mkv mov mod mp2 mp2v mp4 mpa mpe mpeg mpg mps mpv mpv2 mswmm ogm qt ram rm rv 
 * wm wmp wmv wmx wvx
 */

