/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using IndexFileNameFilter = Lucene.Net.Index.IndexFileNameFilter;

namespace Lucene.Net.Store
{
	
	/// <summary> Straightforward implementation of {@link Directory} as a directory of files.
	/// 
	/// </summary>
	/// <seealso cref="Directory">
	/// </seealso>
	/// <author>  Doug Cutting
	/// </author>
	public class FSDirectory : Directory
	{
		private class AnonymousClassLock : Lock
		{
			public AnonymousClassLock(System.IO.FileInfo lockFile, FSDirectory enclosingInstance)
			{
				InitBlock(lockFile, enclosingInstance);
			}
			private void  InitBlock(System.IO.FileInfo lockFile, FSDirectory enclosingInstance)
			{
				this.lockFile = lockFile;
				this.enclosingInstance = enclosingInstance;
			}
			private System.IO.FileInfo lockFile;
			private FSDirectory enclosingInstance;
            override public bool IsLocked()
            {
                if (Lucene.Net.Store.FSDirectory.disableLocks)
                    return false;
                bool tmpBool;
                if (System.IO.File.Exists(lockFile.FullName))
                    tmpBool = true;
                else
                    tmpBool = System.IO.Directory.Exists(lockFile.FullName);
                return tmpBool;
            }
            public FSDirectory Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			public override bool Obtain()
			{
				if (Lucene.Net.Store.FSDirectory.disableLocks)
					return true;
				
				bool tmpBool;
				if (System.IO.File.Exists(Enclosing_Instance.lockDir.FullName))
					tmpBool = true;
				else
					tmpBool = System.IO.Directory.Exists(Enclosing_Instance.lockDir.FullName);
				if (!tmpBool)
				{
                    try
                    {
					    System.IO.Directory.CreateDirectory(Enclosing_Instance.lockDir.FullName);
                    }
                    catch (Exception)
					{
						throw new System.IO.IOException("Cannot create lock directory: " + Enclosing_Instance.lockDir);
					}
				}
				
                try
                {
                    System.IO.FileStream createdFile = lockFile.Create();
                    createdFile.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
			public override void  Release()
			{
				if (Lucene.Net.Store.FSDirectory.disableLocks)
					return ;
				bool tmpBool;
				if (System.IO.File.Exists(lockFile.FullName))
				{
					System.IO.File.Delete(lockFile.FullName);
					tmpBool = true;
				}
				else if (System.IO.Directory.Exists(lockFile.FullName))
				{
					System.IO.Directory.Delete(lockFile.FullName);
					tmpBool = true;
				}
				else
					tmpBool = false;
				bool generatedAux = tmpBool;
			}
			
			public override System.String ToString()
			{
				return "Lock@" + lockFile;
			}
		}
		
		/// <summary>This cache of directories ensures that there is a unique Directory
		/// instance per path, so that synchronization on the Directory can be used to
		/// synchronize access between readers and writers.
		/// 
		/// This should be a WeakHashMap, so that entries can be GC'd, but that would
		/// require Java 1.2.  Instead we use refcounts...
		/// </summary>
		private static readonly System.Collections.Hashtable DIRECTORIES = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
		
		private static bool disableLocks = false;
		
        /// <summary> Set whether Lucene's use of lock files is disabled. By default, 
        /// lock files are enabled. They should only be disabled if the index
        /// is on a read-only medium like a CD-ROM.
        /// </summary>
        public static void  SetDisableLocks(bool doDisableLocks)
		{
			FSDirectory.disableLocks = doDisableLocks;
		}
		
        /// <summary> Returns whether Lucene's use of lock files is disabled.</summary>
        /// <returns> true if locks are disabled, false if locks are enabled.
        /// </returns>
        public static bool GetDisableLocks()
		{
			return FSDirectory.disableLocks;
		}
		
		/// <summary> Directory specified by <code>Lucene.Net.lockDir</code>
		/// or <code>java.io.tmpdir</code> system property
		/// </summary>
		public static readonly System.String LOCK_DIR = SupportClass.AppSettings.Get("Lucene.Net.lockDir", System.IO.Path.GetTempPath());
		
		/// <summary>The default class which implements filesystem-based directories. </summary>
		private static System.Type IMPL;
		
		private static System.Security.Cryptography.MD5 DIGESTER;
		
		/// <summary>A buffer optionally used in renameTo method </summary>
		private byte[] buffer = null;
		
		/// <summary>Returns the directory instance for the named location.
		/// 
		/// <p>Directories are cached, so that, for a given canonical path, the same
		/// FSDirectory instance will always be returned.  This permits
		/// synchronization on directories.
		/// 
		/// </summary>
		/// <param name="path">the path to the directory.
		/// </param>
		/// <param name="create">if true, create, or erase any existing contents.
		/// </param>
		/// <returns> the FSDirectory for the named file.  
		/// </returns>
		public static FSDirectory GetDirectory(System.String path, bool create)
		{
			return GetDirectory(new System.IO.FileInfo(path), create);
		}
		
		/// <summary>Returns the directory instance for the named location.
		/// 
		/// <p>Directories are cached, so that, for a given canonical path, the same
		/// FSDirectory instance will always be returned.  This permits
		/// synchronization on directories.
		/// 
		/// </summary>
		/// <param name="file">the path to the directory.
		/// </param>
		/// <param name="create">if true, create, or erase any existing contents.
		/// </param>
		/// <returns> the FSDirectory for the named file.  
		/// </returns>
		public static FSDirectory GetDirectory(System.IO.FileInfo file, bool create)
		{
			file = new System.IO.FileInfo(file.FullName);
			FSDirectory dir;
			lock (DIRECTORIES.SyncRoot)
			{
				dir = (FSDirectory) DIRECTORIES[file];
				if (dir == null)
				{
					try
					{
						dir = (FSDirectory) System.Activator.CreateInstance(IMPL);
					}
					catch (System.Exception e)
					{
						throw new System.SystemException("cannot load FSDirectory class: " + e.ToString());
					}
					dir.Init(file, create);
					DIRECTORIES[file] = dir;
				}
				else if (create)
				{
					dir.Create();
				}
			}
			lock (dir)
			{
				dir.refCount++;
			}
			return dir;
		}
		
		private System.IO.FileInfo directory = null;
		private int refCount;
		private System.IO.FileInfo lockDir;
		
		public FSDirectory()
		{
		}
		
		// permit subclassing
		
		private void  Init(System.IO.FileInfo path, bool create)
		{
			directory = path;
			
			if (LOCK_DIR == null)
			{
				lockDir = directory;
			}
			else
			{
				lockDir = new System.IO.FileInfo(LOCK_DIR);
			}
			// Ensure that lockDir exists and is a directory.
			bool tmpBool;
			if (System.IO.File.Exists(lockDir.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(lockDir.FullName);
			if (!tmpBool)
			{
                try
                {
                    System.IO.Directory.CreateDirectory(lockDir.FullName);
                }
                catch (Exception)
                {
                    throw new System.IO.IOException("Cannot create directory: " + lockDir);
                }
			}
			else if (!System.IO.Directory.Exists(lockDir.FullName))
			{
				throw new System.IO.IOException("Found regular file where directory expected: " + lockDir);
			}
			if (create)
			{
				Create();
			}
			
			if (!System.IO.Directory.Exists(directory.FullName))
				throw new System.IO.IOException(path + " not a directory");
		}
		
		private void  Create()
		{
			lock (this)
			{
				bool tmpBool;
				if (System.IO.File.Exists(directory.FullName))
					tmpBool = true;
				else
					tmpBool = System.IO.Directory.Exists(directory.FullName);
				if (!tmpBool)
				{
                    try
                    {
                        System.IO.Directory.CreateDirectory(directory.FullName);
                    }
                    catch (Exception)
                    {
                        throw new System.IO.IOException("Cannot create directory: " + directory);
                    }
				}
				
                try
                {
                    System.IO.Directory.Exists(directory.FullName);
                }
                catch (Exception)
                {
                    throw new System.IO.IOException(directory + " not a directory");
                }
				
                System.String[] files = System.IO.Directory.GetFileSystemEntries(directory.FullName); // clear old files    // {{Aroush-1.9}} we want the line below, not this one; how do we make the line below work in C#?!
                //// System.String[] files = System.IO.Directory.GetFileSystemEntries(new IndexFileNameFilter()); // clear old files 
                //// if (files == null)
                ////    throw new System.IO.IOException("Cannot read directory " + directory.FullName);
                for (int i = 0; i < files.Length; i++)
				{
					System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, files[i]));
					bool tmpBool2;
					if (System.IO.File.Exists(file.FullName))
					{
						System.IO.File.Delete(file.FullName);
						tmpBool2 = true;
					}
					else if (System.IO.Directory.Exists(file.FullName))
					{
						System.IO.Directory.Delete(file.FullName);
						tmpBool2 = true;
					}
					else
						tmpBool2 = false;
					if (!tmpBool2)
						throw new System.IO.IOException("Cannot delete " + files[i]);
				}
				
				System.String lockPrefix = GetLockPrefix().ToString(); // clear old locks
				files = System.IO.Directory.GetFileSystemEntries(lockDir.FullName);
				if (files == null)
					throw new System.IO.IOException("Cannot read lock directory " + lockDir.FullName);
				for (int i = 0; i < files.Length; i++)
				{
					if (!files[i].StartsWith(lockPrefix))
						continue;
					System.IO.FileInfo lockFile = new System.IO.FileInfo(System.IO.Path.Combine(lockDir.FullName, files[i]));
					bool tmpBool3;
					if (System.IO.File.Exists(lockFile.FullName))
					{
						System.IO.File.Delete(lockFile.FullName);
						tmpBool3 = true;
					}
					else if (System.IO.Directory.Exists(lockFile.FullName))
					{
						System.IO.Directory.Delete(lockFile.FullName);
						tmpBool3 = true;
					}
					else
						tmpBool3 = false;
					if (!tmpBool3)
						throw new System.IO.IOException("Cannot delete " + files[i]);
				}
			}
		}
		
		/// <summary>Returns an array of strings, one for each file in the directory. </summary>
		public override System.String[] List()
		{
			return System.IO.Directory.GetFileSystemEntries(directory.FullName);
		}
		
		/// <summary>Returns true iff a file with the given name exists. </summary>
		public override bool FileExists(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			bool tmpBool;
			if (System.IO.File.Exists(file.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(file.FullName);
			return tmpBool;
		}
		
		/// <summary>Returns the time the named file was last modified. </summary>
		public override long FileModified(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			return (file.LastWriteTime.Ticks);
		}
		
		/// <summary>Returns the time the named file was last modified. </summary>
		public static long FileModified(System.IO.FileInfo directory, System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			return (file.LastWriteTime.Ticks);
		}
		
		/// <summary>Set the modified time of an existing file to now. </summary>
		public override void  TouchFile(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
            file.LastWriteTime = System.DateTime.Now;
		}
		
		/// <summary>Returns the length in bytes of a file in the directory. </summary>
		public override long FileLength(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			return file.Exists ? file.Length : 0;
		}
		
		/// <summary>Removes an existing file in the directory. </summary>
		public override void  DeleteFile(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			bool tmpBool;
			if (System.IO.File.Exists(file.FullName))
			{
				System.IO.File.Delete(file.FullName);
				tmpBool = true;
			}
			else if (System.IO.Directory.Exists(file.FullName))
			{
				System.IO.Directory.Delete(file.FullName);
				tmpBool = true;
			}
			else
				tmpBool = false;
			if (!tmpBool)
				throw new System.IO.IOException("Cannot delete " + file);
		}
		
		/// <summary>Renames an existing file in the directory. </summary>
		public override void  RenameFile(System.String from, System.String to)
		{
			lock (this)
			{
				System.IO.FileInfo old = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, from));
				System.IO.FileInfo nu = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, to));
				
				/* This is not atomic.  If the program crashes between the call to
				delete() and the call to renameTo() then we're screwed, but I've
				been unable to figure out how else to do this... */
				
				bool tmpBool;
				if (System.IO.File.Exists(nu.FullName))
					tmpBool = true;
				else
					tmpBool = System.IO.Directory.Exists(nu.FullName);
				if (tmpBool)
				{
					bool tmpBool2;
					if (System.IO.File.Exists(nu.FullName))
					{
						System.IO.File.Delete(nu.FullName);
						tmpBool2 = true;
					}
					else if (System.IO.Directory.Exists(nu.FullName))
					{
						System.IO.Directory.Delete(nu.FullName);
						tmpBool2 = true;
					}
					else
						tmpBool2 = false;
                    //if (!tmpBool2)
                    //    throw new System.IO.IOException("Cannot delete " + nu);
				}
				
				// Rename the old file to the new one. Unfortunately, the renameTo()
				// method does not work reliably under some JVMs.  Therefore, if the
				// rename fails, we manually rename by copying the old file to the new one
                try
                {
                    old.MoveTo(nu.FullName);
                }
                catch (System.Exception)
				{
					System.IO.Stream in_Renamed = null;
					System.IO.Stream out_Renamed = null;
					try
					{
						in_Renamed = new System.IO.FileStream(old.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
						out_Renamed = new System.IO.FileStream(nu.FullName, System.IO.FileMode.Create);
						// see if the buffer needs to be initialized. Initialization is
						// only done on-demand since many VM's will never run into the renameTo
						// bug and hence shouldn't waste 1K of mem for no reason.
						if (buffer == null)
						{
							buffer = new byte[1024];
						}
						int len; 
						while ((len = in_Renamed.Read(buffer, 0, buffer.Length)) > 0) 
						{ 
							out_Renamed.Write(buffer, 0, len); 
						}
						
						// delete the old file.
						bool tmpBool3;
						if (System.IO.File.Exists(old.FullName))
						{
							System.IO.File.Delete(old.FullName);
							tmpBool3 = true;
						}
						else if (System.IO.Directory.Exists(old.FullName))
						{
							System.IO.Directory.Delete(old.FullName);
							tmpBool3 = true;
						}
						else
							tmpBool3 = false;
						bool generatedAux = tmpBool3;
					}
					catch (System.IO.IOException ioe)
					{
                        //System.IO.IOException newExc = new System.IO.IOException("Cannot rename " + old + " to " + nu, ioe);
                        //throw newExc;
                    }
					finally
					{
						if (in_Renamed != null)
						{
							try
							{
								in_Renamed.Close();
							}
							catch (System.IO.IOException e)
							{
								throw new System.SystemException("Cannot close input stream: " + e.ToString());
							}
						}
						if (out_Renamed != null)
						{
							try
							{
								out_Renamed.Close();
							}
							catch (System.IO.IOException e)
							{
								throw new System.SystemException("Cannot close output stream: " + e.ToString());
							}
						}
					}
				}
			}
		}
		
		/// <summary>Creates a new, empty file in the directory with the given name.
		/// Returns a stream writing this file. 
		/// </summary>
		public override IndexOutput CreateOutput(System.String name)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name));
			bool tmpBool;
			if (System.IO.File.Exists(file.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(file.FullName);
			bool tmpBool2;
			if (System.IO.File.Exists(file.FullName))
			{
				System.IO.File.Delete(file.FullName);
				tmpBool2 = true;
			}
			else if (System.IO.Directory.Exists(file.FullName))
			{
				System.IO.Directory.Delete(file.FullName);
				tmpBool2 = true;
			}
			else
				tmpBool2 = false;
			if (tmpBool && !tmpBool2)
			// delete existing, if any
				throw new System.IO.IOException("Cannot overwrite: " + file);
			
			return new FSIndexOutput(file);
		}
		
		/// <summary>Returns a stream reading an existing file. </summary>
		public override IndexInput OpenInput(System.String name)
		{
			return new FSIndexInput(new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, name)));
		}
		
		/// <summary> So we can do some byte-to-hexchar conversion below</summary>
		private static readonly char[] HEX_DIGITS = new char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
		
		/// <summary>Constructs a {@link Lock} with the specified name.  Locks are implemented
		/// with {@link File#createNewFile()}.
		/// 
		/// </summary>
		/// <param name="name">the name of the lock file
		/// </param>
		/// <returns> an instance of <code>Lock</code> holding the lock
		/// </returns>
		public override Lock MakeLock(System.String name)
		{
			System.Text.StringBuilder buf = GetLockPrefix();
			buf.Append("-");
			buf.Append(name);
			
			// create a lock file
			System.IO.FileInfo lockFile = new System.IO.FileInfo(System.IO.Path.Combine(lockDir.FullName, buf.ToString()));
			
			return new AnonymousClassLock(lockFile, this);
		}
		
		private System.Text.StringBuilder GetLockPrefix()
		{
			System.String dirName; // name to be hashed
			try
			{
				dirName = directory.FullName;
			}
			catch (System.IO.IOException e)
			{
				throw new System.SystemException(e.ToString());
			}
			
			byte[] digest;
			lock (DIGESTER)
			{
				digest = DIGESTER.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dirName));
			}
			System.Text.StringBuilder buf = new System.Text.StringBuilder();
			buf.Append("lucene-");
			for (int i = 0; i < digest.Length; i++)
			{
				int b = digest[i];
				buf.Append(HEX_DIGITS[(b >> 4) & 0xf]);
				buf.Append(HEX_DIGITS[b & 0xf]);
			}
			
			return buf;
		}
		
		/// <summary>Closes the store to future operations. </summary>
		public override void  Close()
		{
			lock (this)
			{
				if (--refCount <= 0)
				{
					lock (DIRECTORIES.SyncRoot)
					{
						DIRECTORIES.Remove(directory);
					}
				}
			}
		}
		
		public virtual System.IO.FileInfo GetFile()
		{
			return directory;
		}
		
		/// <summary>For debug output. </summary>
		public override System.String ToString()
		{
			return this.GetType().FullName + "@" + directory;
		}

		static FSDirectory()
		{
			{
				try
				{
					System.String name = SupportClass.AppSettings.Get("Lucene.Net.FSDirectory.class", typeof(FSDirectory).FullName);
					IMPL = System.Type.GetType(name);
				}
				catch (System.Security.SecurityException)
				{
					try
					{
						IMPL = System.Type.GetType(typeof(FSDirectory).FullName);
					}
					catch (System.Exception e)
					{
						throw new System.SystemException("cannot load default FSDirectory class: " + e.ToString());
					}
				}
                catch (System.Exception e)
                {
                    throw new System.SystemException("cannot load FSDirectory class: " + e.ToString());
                }
            }
			{
				try
				{
					DIGESTER = System.Security.Cryptography.MD5.Create();
				}
				catch (System.Exception e)
				{
					throw new System.SystemException(e.ToString());
				}
			}
		}
	}
	
	
	public class FSIndexInput : BufferedIndexInput, System.ICloneable
	{
		private class Descriptor : System.IO.BinaryReader
		{
			private void  InitBlock(FSIndexInput enclosingInstance)
			{
				this.enclosingInstance = enclosingInstance;
			}
			private FSIndexInput enclosingInstance;
			public FSIndexInput Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			public long position;
			public Descriptor(FSIndexInput enclosingInstance, System.IO.FileInfo file, System.IO.FileAccess mode) 
                : base(new System.IO.FileStream(file.FullName, System.IO.FileMode.Open, mode, System.IO.FileShare.ReadWrite))
			{
				InitBlock(enclosingInstance);
			}
		}
		
		private Descriptor file = null;
		internal bool isClone;
		private long length;
		
        public bool IsClone
        {
            get { return (isClone); }
        }

		public FSIndexInput(System.IO.FileInfo path)
		{
			file = new Descriptor(this, path, System.IO.FileAccess.Read);
			length = file.BaseStream.Length;
		}
		
		/// <summary>IndexInput methods </summary>
		public override void  ReadInternal(byte[] b, int offset, int len)
		{
			lock (file)
			{
				long position = GetFilePointer();
				if (position != file.position)
				{
					file.BaseStream.Seek(position, System.IO.SeekOrigin.Begin);
					file.position = position;
				}
				int total = 0;
				do 
				{
					int i = file.Read(b, offset + total, len - total);
					if (i <= 0)
						throw new System.IO.IOException("read past EOF");
					file.position += i;
					total += i;
				}
				while (total < len);
			}
		}
		
		public override void  Close()
		{
			if (!isClone && file != null)
				file.Close();
            System.GC.SuppressFinalize(this);
		}
		
		public override void  SeekInternal(long position)
		{
		}
		
		public override long Length()
		{
			return length;
		}
		
		~FSIndexInput()
		{
			Close(); // close the file
		}
		
		public override System.Object Clone()
		{
			FSIndexInput clone = (FSIndexInput) base.Clone();
			clone.isClone = true;
			return clone;
		}
		
		/// <summary>Method used for testing. Returns true if the underlying
		/// file descriptor is valid.
		/// </summary>
		public /*internal*/ virtual bool IsFDValid()
		{
            if (file.BaseStream == null)
                return false;
			return file.BaseStream.CanRead;
		}
	}
	
	
	class FSIndexOutput : BufferedIndexOutput
	{
		internal System.IO.BinaryWriter file = null;
		
		public FSIndexOutput(System.IO.FileInfo path)
		{
			file = new System.IO.BinaryWriter(new System.IO.FileStream(path.FullName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite));
		}
		
		/// <summary>output methods: </summary>
		public override void  FlushBuffer(byte[] b, int size)
		{
			file.Write(b, 0, size);
		}
		public override void  Close()
		{
			base.Close();
			file.Close();
			System.GC.SuppressFinalize(this);
		}
		
		/// <summary>Random-access methods </summary>
		public override void  Seek(long pos)
		{
			base.Seek(pos);
			file.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
		}
		public override long Length()
		{
			return file.BaseStream.Length;
		}
		
		~FSIndexOutput()
		{
			file.Close(); // close the file
		}
	}
}