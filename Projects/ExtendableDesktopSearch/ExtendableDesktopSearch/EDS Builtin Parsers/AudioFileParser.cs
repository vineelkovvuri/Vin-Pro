using System;
using System.Collections.Specialized;
using System.Collections;
using IO = System.IO;
using IdSharp.Tagging.ID3v1;
using IdSharp.Tagging.ID3v2;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to extract the metadata attributes of audio formats( .mp3, .mp4, .wma, .ogg)
    /// </summary>
    sealed class AudioFileParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to audio files
        public AudioFileParser()
            : base()
        {
            fileProperties.Add("title", null);
            fileProperties.Add("album", null);
            fileProperties.Add("artist", null);
            fileProperties.Add("year", null);
            fileProperties.Add("track", null);
            fileProperties.Add("genres", null);
            fileProperties.Add("comment", null);
            fileProperties.Add("length", null);
            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.AudioFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from audio files
        /// <summary>
        /// This method sets various audio file properties into a Dictionary
        /// </summary>
        /// <param name="source">source indicates the path to the file whose properties are to be extracted</param>
        /// <returns>Returns a Dictionary object where key => property name and value => property value</returns>
        public override StringDictionary GetProperties(string source)
        {
            if (IO.File.Exists(source))
            {
                try
                {
                    TagLib.File file = TagLib.File.Create(source);
                    TagLib.Tag tags = file.Tag;

                    fileProperties["title"] = tags.Title;
                    fileProperties["album"] = tags.Album;
                    fileProperties["artist"] = string.Join(",", tags.AlbumArtists);
                    fileProperties["year"] = tags.Year.ToString();
                    fileProperties["track"] = tags.Track.ToString();
                    fileProperties["genres"] = string.Join(",", tags.Genres);
                    fileProperties["comment"] = tags.Comment;
                    fileProperties["length"] = TimeSpan.Parse(file.Properties.Duration.Hours + ":" + file.Properties.Duration.Minutes + ":" + file.Properties.Duration.Seconds).ToString();

                }
                catch (Exception ex) //CorruptFileException
                {

                    if (ID3v1Helper.DoesTagExist(source))
                    {
                        IID3v1 id3v1 = ID3v1Helper.CreateID3v1(source);
                        fileProperties["title"] = id3v1.Title;
                        fileProperties["album"] = id3v1.Album;
                        fileProperties["artist"] = id3v1.Artist;
                        fileProperties["year"] = id3v1.Year;
                        fileProperties["track"] = id3v1.TrackNumber.ToString();
                        fileProperties["comment"] = id3v1.Comment;
                    }
                    if (ID3v2Helper.DoesTagExist(source))
                    {
                        IID3v2 id3v2 = ID3v2Helper.CreateID3v2(source);
                        TimeSpan ts = TimeSpan.FromMilliseconds(id3v2.LengthMilliseconds.Value);
                        fileProperties["length"] = TimeSpan.Parse(ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds).ToString();
                        fileProperties["genres"] = id3v2.Genre;
                    }
                    if (!(ID3v1Helper.DoesTagExist(source) && ID3v2Helper.DoesTagExist(source)))
                        RemoveFileSpecificKeys();
                }
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
            fileProperties.Remove("title");
            fileProperties.Remove("album");
            fileProperties.Remove("artist");
            fileProperties.Remove("year");
            fileProperties.Remove("track");
            fileProperties.Remove("genres");
            fileProperties.Remove("comment");
            fileProperties.Remove("length");
        }
        /// <summary>
        /// This method represent the properties(keys) that every audio file contains
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
        string FileTypes = ".asf .au .aiff .aac .amr .aif .ape .ac3 .aa .cda .cdda .dts .flac .gsm .mp3 .mp4 .m4a .m4b .mid .midi .mpc .mpa .m3u .ogg .ofr .ra .wma .wav .wave";
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
            get { return "audio"; }
        }
    }
}


/*
 * asf au aiff aac amr aif ape ac3 aa 
 * cda cdda 
 * dts
 * flac
 * gsm
 * mp3 mp4 m4a m4b mid midi mpc mpa m3u 
 * ogg ofr  
 * ra ram
 * wma wav wave 
 */