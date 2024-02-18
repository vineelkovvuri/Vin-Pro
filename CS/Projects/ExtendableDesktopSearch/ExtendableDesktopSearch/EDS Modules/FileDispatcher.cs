using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using IEDSInterface;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is responsible for Enumerating the bultin and installed parsers of the software.
    /// </summary>
    class FileDispatcher
    {
        #region Constructor which invokes the creation of parsers dictionary
        internal FileDispatcher()
        {
#if Log
            Console.WriteLine("Executing: FileDispatcher Construtor");
#endif
            CreateParsersDictionary();
            CreatePropertiesList();  // name,album,title,content to used in advanced query popup menu
        }

        #endregion

        #region Code responsible for creating a list of both built-in and 3rd party parsers
        /// <summary>
        /// This method creates a dictionary for each individual file type. 
        /// This makes it easy for the FileSystemCrawler moudle in invoking the necessary parser
        /// based on the file extension as a key
        /// </summary>
        internal void CreateParsersDictionary()
        {
#if Log
            Console.WriteLine("Executing: CreateParsersDictionary");
#endif

            //Get all built in parsers in to dictionary
            foreach (IEDSParser parser in GetBuiltInParsers())
                foreach (string filetype in parser.ParserFileTypes.Split(' '))
                {
                    GlobalData.Parsers.Add(filetype, parser);
#if Log
                    Console.WriteLine("Built-in parser for: " + filetype);
#endif
                }

            //Get all installed parsers in to dictionary
            foreach (IEDSParser parser in GetInstalledParsers())
                foreach (string filetype in parser.ParserFileTypes.Split(' '))
                {
                    GlobalData.Parsers.Add(filetype, parser);
#if Log
                    Console.WriteLine("3rd party parser for: " + filetype);
#endif
                }
        }
        #endregion

        #region  Code for creating a list containing the properties of all files
        private void CreatePropertiesList()
        {
#if Log
            Console.WriteLine("Executing: CreatePropertiesList");
#endif
            //Get all built in parsers in to dictionary
            foreach (IEDSParser parser in GetBuiltInParsers())
                foreach (string key in parser.Keys)
                    if (!GlobalData.PropertyList.Contains(key)) GlobalData.PropertyList.Add(key);

            //Get all installed parsers in to dictionary
            foreach (IEDSParser parser in GetInstalledParsers())
                foreach (string key in parser.Keys)
                    if (!GlobalData.PropertyList.Contains(key)) GlobalData.PropertyList.Add(key);

            GlobalData.PropertyList.Sort();
        }
        #endregion


        #region Code responsible for getting only built-in parser
        /// <summary>
        /// This method will get the parsers(types implementing IEDSParser) present in the current assembly in to a List
        /// </summary>
        /// <returns>List containing the Types that implemented IEDSParser</returns>
        private static List<IEDSParser> GetBuiltInParsers()
        {
            List<IEDSParser> parsers = new List<IEDSParser>(16);
            Assembly curAssembly = Assembly.GetEntryAssembly();
            foreach (Type type in curAssembly.GetTypes()) //Enumerate all the types in the current assembly
                if (type.IsClass && typeof(IEDSParser).IsAssignableFrom(type)) //if type is a class and IEDSParser can be instantiated from type "type"
                {
                    IEDSParser fileparser = (IEDSParser)Activator.CreateInstance(type);
                    GlobalData.DefaultExtensions += fileparser.ParserFileTypes + " ";
                    switch (fileparser.ParserCategory)
                    {
                        case "docs":
                            GlobalData.DocFileTypes += fileparser.ParserFileTypes + " ";
                            break;
                        case "audio":
                            GlobalData.AudioFileTypes += fileparser.ParserFileTypes + " ";
                            break;
                        case "video":
                            GlobalData.VideoFileTypes+=fileparser.ParserFileTypes + " ";
                            break;
                        case "pics":
                            GlobalData.ImageFileTypes += fileparser.ParserFileTypes + " ";
                            break;
                    }
                    parsers.Add(fileparser);
                }
            return parsers;
        }
        #endregion

        #region Code responsible for getting only 3rd party parser
        /// <summary>
        /// This method will get the parsers(types implementing IEDSParser) present in the external parsers in to a List
        /// </summary>
        /// <returns>List containing the Types that implemented IEDSParser</returns>
        private static List<IEDSParser> GetInstalledParsers()
        {
            List<IEDSParser> parsers = new List<IEDSParser>(16);

            foreach (string dll in Directory.GetFiles(GlobalData.ParserFolder, "*.dll"))
            {
                Assembly parser = Assembly.LoadFile(dll);
                foreach (Type type in parser.GetExportedTypes())//Enumerate all the types in the current assembly
                    if (type.IsClass && typeof(IEDSParser).IsAssignableFrom(type)) //if type is a class and IEDSParser can be instantiated from type "type"
                    {
                        IEDSParser fileparser = (IEDSParser)Activator.CreateInstance(type);
                        GlobalData.DefaultExtensions += fileparser.ParserFileTypes + " ";
                        switch (fileparser.ParserCategory)
                        {
                            case "docs":
                                GlobalData.DocFileTypes += fileparser.ParserFileTypes + " ";
                                break;
                            case "audio":
                                GlobalData.AudioFileTypes += fileparser.ParserFileTypes + " ";
                                break;
                            case "video":
                                GlobalData.VideoFileTypes += fileparser.ParserFileTypes + " ";
                                break;
                            case "pics":
                                GlobalData.ImageFileTypes += fileparser.ParserFileTypes + " ";
                                break;
                        }
                        parsers.Add(fileparser);
                    }
            }
            return parsers;
        }
        #endregion
    }
}
