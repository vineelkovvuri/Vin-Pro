using System;
using System.Security;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using IEDSInterface;

namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This class is used to list the files contained in archive formats( .rar, .zip, .tar, .bz2, .gz)
    /// </summary>
    sealed class ArchiveParser : GenericFile, IEDSParser
    {
        #region Constructor for adding properties specific to archive files
        public ArchiveParser()
            : base()
        {
            fileProperties.Add("content", null);  //contained files in the archive
            //GlobalData.DefaultExtensions += this.ParserFileTypes + " ";
            //GlobalData.DocFileTypes += this.ParserFileTypes + " ";
        }
        #endregion

        #region Code to extract metadata properties from archive files
        public override StringDictionary GetProperties(string source)
        {
            if (File.Exists(source))
            {
                string outputFile = GlobalData.OutputFile;//contains the list of files 1 for each line
                switch (Path.GetExtension(source).ToLower())
                {
                    case ".rar":
                        try
                        {
                            Unrar unrar = new Unrar(source);
                            unrar.Open(Unrar.OpenMode.List);
                            StreamWriter sw = new StreamWriter(outputFile); //The outputFile will be Created and opened for writing
                            unrar.WriteFileList(ref sw);
                            sw.Close();
                            unrar.Close();
                            fileProperties["content"] = outputFile;
                        }
                        catch
                        {
                            RemoveFileSpecificKeys();
#if Log
                            Console.WriteLine(source + " => not a valid rar archive"); 
#endif
                        }
                        break;
                    case ".zip":
                        try
                        {
                            FileStream fs = File.OpenRead(source);           //Open the archieve file stream
                            ZipFile zipFile = new ZipFile(fs);                  //Create a zip Object from the opened stream
                            StreamWriter sw = new StreamWriter(outputFile); //The outputFile will be Created and opened for writing
                            foreach (ZipEntry zipEntry in zipFile)
                                if (zipEntry.IsFile) sw.WriteLine(zipEntry.Name);
                            sw.Close();
                            zipFile.Close();
                            fileProperties["content"] = outputFile;
                            fs.Close();
                        }
                        catch
                        {
                            RemoveFileSpecificKeys();
#if Log
                            Console.WriteLine(source + " => not a valid zip archive");
#endif
                        }
                        break;
                    case ".tar":
                        try
                        {
                            FileStream fs = File.OpenRead(source);
                            TarArchive ta = TarArchive.CreateInputTarArchive(fs);
                            StreamWriter sw = new StreamWriter(outputFile); //The outputFile will be Created and opened for writing
                            ta.ProgressMessageEvent += delegate(TarArchive archive, TarEntry entry, string message)
                                                        {
                                                            if (!entry.IsDirectory)
                                                                sw.WriteLine(entry.Name);
                                                        };
                            ta.ListContents();          //List the contents of tar archieve
                            sw.Close();
                            ta.Close();
                            fileProperties["content"] = outputFile;
                            fs.Close();
                        }
                        catch
                        {
                            RemoveFileSpecificKeys();
#if Log
                            Console.WriteLine(source + " => not a valid tar archive"); 
#endif
                        }
                        break;
                    case ".gz":
                        try
                        {
                            FileStream fs = File.OpenRead(source);
                            TarArchive ta = TarArchive.CreateInputTarArchive(new GZipInputStream(fs));
                            StreamWriter sw = new StreamWriter(outputFile); //The outputFile will be Created and opened for writing
                            ta.ProgressMessageEvent += delegate(TarArchive archive, TarEntry entry, string message)
                                                        {
                                                            if (!entry.IsDirectory)
                                                                sw.WriteLine(entry.Name);
                                                        };
                            ta.ListContents();              //List the contents of gz2 archieve
                            sw.Close();
                            ta.Close();
                            fileProperties["content"] = outputFile;
                            fs.Close();
                        }
                        catch
                        {
                            RemoveFileSpecificKeys();
#if Log
                            Console.WriteLine(source + " => not a valid gz archive"); 
#endif
                        }
                        break;
                    case ".bz2":
                        try
                        {
                            FileStream fs = File.OpenRead(source);
                            TarArchive ta = TarArchive.CreateInputTarArchive(new BZip2InputStream(fs));
                            StreamWriter sw = new StreamWriter(outputFile); //The outputFile will be Created and opened for writing
                            ta.ProgressMessageEvent += delegate(TarArchive archive, TarEntry entry, string message)
                                                        {
                                                            if (!entry.IsDirectory)
                                                                sw.WriteLine(entry.Name);
                                                        };
                            ta.ListContents();          //List the contents of bz2 archieve
                            sw.Close();
                            ta.Close();
                            fileProperties["content"] = outputFile;
                            fs.Close();
                        }
                        catch
                        {
                            RemoveFileSpecificKeys();
#if Log
                            Console.WriteLine(source + " => not a valid bz2 archive"); 
#endif
                        }
                        break;
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
            fileProperties.Remove("content");
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
        string FileTypes = ".rar .zip .gz .tar .bz2";
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
            get { return "docs"; }
        }
    }

    #region Rar Wrapper


    /// <summary>
    /// Wrapper class for unrar DLL supplied by RARSoft.  
    /// Calls unrar DLL via pinvoke.
    /// </summary>
    [SuppressUnmanagedCodeSecurity()]
    sealed public class Unrar : IDisposable
    {
        #region Unrar DLL enumerations

        /// <summary>
        /// Mode in which archive is to be opened for processing.
        /// </summary>
        public enum OpenMode
        {
            List = 0,
            Extract = 1
        }

        private enum RarError : uint
        {
            EndOfArchive = 10,
            InsufficientMemory = 11,
            BadData = 12,
            BadArchive = 13,
            UnknownFormat = 14,
            OpenError = 15,
            CreateError = 16,
            CloseError = 17,
            ReadError = 18,
            WriteError = 19,
            BufferTooSmall = 20,
            UnknownError = 21
        }

        private enum Operation : uint
        {
            Skip = 0,
            Test = 1,
            Extract = 2
        }

        #endregion

        #region Unrar DLL structure definitions

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RARHeaderDataEx
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string ArcName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string ArcNameW;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string FileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string FileNameW;
            public uint Flags;
            public uint PackSize;
            public uint PackSizeHigh;
            public uint UnpSize;
            public uint UnpSizeHigh;
            public uint HostOS;
            public uint FileCRC;
            public uint FileTime;
            public uint UnpVer;
            public uint Method;
            public uint FileAttr;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public uint[] Reserved;

            public void Initialize()
            {
                this.CmtBuf = null;
                this.CmtBufSize = 0;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAROpenArchiveDataEx
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string ArcName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ArcNameW;
            public uint OpenMode;
            public uint OpenResult;
            [MarshalAs(UnmanagedType.LPStr)]
            public string CmtBuf;
            public uint CmtBufSize;
            public uint CmtSize;
            public uint CmtState;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public uint[] Reserved;

            public void Initialize()
            {
                this.CmtBuf = null;
                this.CmtBufSize = 0;
                this.Reserved = new uint[32];
            }
        }

        #endregion

        #region Unrar function declarations

        [DllImport("UNRAR.DLL")]
        private static extern IntPtr RAROpenArchiveEx(ref RAROpenArchiveDataEx archiveData);

        [DllImport("unrar.dll")]
        private static extern int RARCloseArchive(IntPtr hArcData);

        [DllImport("unrar.dll")]
        private static extern int RARReadHeaderEx(IntPtr hArcData, ref RARHeaderDataEx headerData);

        [DllImport("unrar.dll")]
        private static extern int RARProcessFile(IntPtr hArcData, int operation,
            [MarshalAs(UnmanagedType.LPStr)] string destPath,
            [MarshalAs(UnmanagedType.LPStr)] string destName);

        #endregion


        #region Private fields

        private string archivePathName = string.Empty;
        private IntPtr archiveHandle = new IntPtr(0);
        private RARHeaderDataEx header = new RARHeaderDataEx();
        private RARFileInfo currentFile;

        #endregion

        #region Object lifetime procedures

        public Unrar(string archivePathName)
        {
            this.archivePathName = archivePathName;
        }

        ~Unrar()
        {
            if (this.archiveHandle != IntPtr.Zero)
            {
                Unrar.RARCloseArchive(this.archiveHandle);
                this.archiveHandle = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            if (this.archiveHandle != IntPtr.Zero)
            {
                Unrar.RARCloseArchive(this.archiveHandle);
                this.archiveHandle = IntPtr.Zero;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Close the currently open archive
        /// </summary>
        /// <returns></returns>
        public void Close()
        {
            // Exit without exception if no archive is open
            if (this.archiveHandle == IntPtr.Zero)
                return;

            // Close archive
            int result = Unrar.RARCloseArchive(this.archiveHandle);

            // Check result
            if (result != 0)
            {
                ProcessFileError(result);
            }
            else
            {
                this.archiveHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Opens archive specified by the ArchivePathName property with a specified mode
        /// </summary>
        /// <param name="openMode">Mode in which archive should be opened</param>
        public void Open(OpenMode openMode)
        {
            if (this.archivePathName.Length == 0)
                throw new IOException("Archive name has not been set.");
            this.Open(this.archivePathName, openMode);
        }

        /// <summary>
        /// Opens specified archive using the specified mode.  
        /// </summary>
        /// <param name="archivePathName">Path of archive to open</param>
        /// <param name="openMode">Mode in which to open archive</param>
        public void Open(string archivePathName, OpenMode openMode)
        {
            IntPtr handle = IntPtr.Zero;

            // Close any previously open archives
            if (this.archiveHandle != IntPtr.Zero)
                this.Close();

            // Prepare extended open archive struct
            this.archivePathName = archivePathName;
            RAROpenArchiveDataEx openStruct = new RAROpenArchiveDataEx();
            openStruct.Initialize();
            openStruct.ArcName = this.archivePathName + "\0";
            openStruct.ArcNameW = this.archivePathName + "\0";
            openStruct.OpenMode = (uint)openMode;

            // Open archive
            handle = Unrar.RAROpenArchiveEx(ref openStruct);

            // Check for success
            if (openStruct.OpenResult != 0)
            {
                switch ((RarError)openStruct.OpenResult)
                {
                    case RarError.InsufficientMemory:
                        throw new OutOfMemoryException("Insufficient memory to perform operation.");

                    case RarError.BadData:
                        throw new IOException("Archive header broken");

                    case RarError.BadArchive:
                        throw new IOException("File is not a valid archive.");

                    case RarError.OpenError:
                        throw new IOException("File could not be opened.");
                }
            }
            // Save handle and flags
            this.archiveHandle = handle;
        }

        /// <summary>
        /// Reads the next archive header and populates CurrentFile property data
        /// </summary>
        /// <returns></returns>
        public bool ReadHeader()
        {
            // Throw exception if archive not open
            if (this.archiveHandle == IntPtr.Zero)
                throw new IOException("Archive is not open.");

            // Initialize header struct
            this.header = new RARHeaderDataEx();
            header.Initialize();

            // Read next entry
            int result = Unrar.RARReadHeaderEx(this.archiveHandle, ref this.header);

            // Check for error or end of archive
            if ((RarError)result == RarError.EndOfArchive)
                return false;
            else if ((RarError)result == RarError.BadData)
                throw new IOException("Archive data is corrupt.");

            // New file, prepare header
            currentFile = new RARFileInfo();
            currentFile.FileName = header.FileNameW.ToString();

            if ((header.Flags & 0xE0) == 0xE0)
                currentFile.IsDirectory = true;

            // Return success
            return true;
        }

        /// <summary>
        /// Writes the files present in rar format to the given file stream
        /// </summary>
        /// <param name="sw">Output text File to write</param>
        public void WriteFileList(ref StreamWriter sw)
        {
            while (this.ReadHeader())
            {
                if (!currentFile.IsDirectory)
                    sw.WriteLine(currentFile.FileName.Replace('\\', '/'));
                this.Skip();
            }
        }

        /// <summary>
        /// Moves the current archive position to the next available header
        /// </summary>
        /// <returns></returns>
        public void Skip()
        {
            int result = Unrar.RARProcessFile(this.archiveHandle, (int)Operation.Skip, string.Empty, string.Empty);

            // Check result
            if (result != 0)
            {
                ProcessFileError(result);
            }
        }

        private void ProcessFileError(int result)
        {
            switch ((RarError)result)
            {
                case RarError.UnknownFormat:
                    throw new OutOfMemoryException("Unknown archive format.");

                case RarError.BadData:
                    throw new IOException("File CRC Error");

                case RarError.BadArchive:
                    throw new IOException("File is not a valid archive.");

                case RarError.OpenError:
                    throw new IOException("File could not be opened.");

                case RarError.CreateError:
                    throw new IOException("File could not be created.");

                case RarError.CloseError:
                    throw new IOException("File close error.");

                case RarError.ReadError:
                    throw new IOException("File read error.");

                case RarError.WriteError:
                    throw new IOException("File write error.");
            }
        }

        #endregion
    }

    #region Event Argument Classes

    public class RARFileInfo
    {
        public string FileName;
        public bool IsDirectory = false;
    }

    #endregion
    #endregion
}
