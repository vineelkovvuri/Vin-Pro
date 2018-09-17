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
using Document = Lucene.Net.Documents.Document;
using Field = Lucene.Net.Documents.Field;
using Similarity = Lucene.Net.Search.Similarity;
using Directory = Lucene.Net.Store.Directory;
using FSDirectory = Lucene.Net.Store.FSDirectory;
using IndexInput = Lucene.Net.Store.IndexInput;
using Lock = Lucene.Net.Store.Lock;

namespace Lucene.Net.Index
{
	
	/// <summary>IndexReader is an abstract class, providing an interface for accessing an
	/// index.  Search of an index is done entirely through this abstract interface,
	/// so that any subclass which implements it is searchable.
	/// <p> Concrete subclasses of IndexReader are usually constructed with a call to
	/// one of the static <code>open()</code> methods, e.g. {@link #Open(String)}.
	/// <p> For efficiency, in this API documents are often referred to via
	/// <i>document numbers</i>, non-negative integers which each name a unique
	/// document in the index.  These document numbers are ephemeral--they may change
	/// as documents are added to and deleted from an index.  Clients should thus not
	/// rely on a given document having the same number between sessions.
	/// </summary>
	/// <summary><p> An IndexReader can be opened on a directory for which an IndexWriter is
	/// opened already, but it cannot be used to delete documents from the index then.
	/// </summary>
	/// <author>  Doug Cutting
	/// </author>
	/// <version>  $Id: IndexReader.java 354917 2005-12-08 00:22:00Z ehatcher $
	/// </version>
	public abstract class IndexReader
	{
		private class AnonymousClassWith : Lock.With
		{
			private void  InitBlock(Lucene.Net.Store.Directory directory, bool closeDirectory)
			{
				this.directory = directory;
				this.closeDirectory = closeDirectory;
			}
			private Lucene.Net.Store.Directory directory;
			private bool closeDirectory;
			internal AnonymousClassWith(Lucene.Net.Store.Directory directory, bool closeDirectory, Lucene.Net.Store.Lock Param1, long Param2):base(Param1, Param2)
			{
				InitBlock(directory, closeDirectory);
			}
			public override System.Object DoBody()
			{
				SegmentInfos infos = new SegmentInfos();
				infos.Read(directory);
				if (infos.Count == 1)
				{
					// index is optimized
					return SegmentReader.Get(infos, infos.Info(0), closeDirectory);
				}
				IndexReader[] readers = new IndexReader[infos.Count];
				for (int i = 0; i < infos.Count; i++)
					readers[i] = SegmentReader.Get(infos.Info(i));
				return new MultiReader(directory, infos, closeDirectory, readers);
			}
		}
		private class AnonymousClassWith1 : Lock.With
		{
			private void  InitBlock(IndexReader enclosingInstance)
			{
				this.enclosingInstance = enclosingInstance;
			}
			private IndexReader enclosingInstance;
			public IndexReader Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			internal AnonymousClassWith1(IndexReader enclosingInstance, Lucene.Net.Store.Lock Param1, long Param2) : base(Param1, Param2)
			{
				InitBlock(enclosingInstance);
			}
			public override System.Object DoBody()
			{
				Enclosing_Instance.DoCommit();
				Enclosing_Instance.segmentInfos.Write(Enclosing_Instance.directory);
				return null;
			}
		}
		
		public sealed class FieldOption
		{
			private System.String option;
			internal FieldOption()
			{
			}
			internal FieldOption(System.String option)
			{
				this.option = option;
			}
			public override System.String ToString()
			{
				return this.option;
			}
			// all fields
			public static readonly FieldOption ALL = new FieldOption("ALL");
			// all indexed fields
			public static readonly FieldOption INDEXED = new FieldOption("INDEXED");
			// all fields which are not indexed
			public static readonly FieldOption UNINDEXED = new FieldOption("UNINDEXED");
			// all fields which are indexed with termvectors enables
			public static readonly FieldOption INDEXED_WITH_TERMVECTOR = new FieldOption("INDEXED_WITH_TERMVECTOR");
			// all fields which are indexed but don't have termvectors enabled
			public static readonly FieldOption INDEXED_NO_TERMVECTOR = new FieldOption("INDEXED_NO_TERMVECTOR");
			// all fields where termvectors are enabled. Please note that only standard termvector fields are returned
			public static readonly FieldOption TERMVECTOR = new FieldOption("TERMVECTOR");
			// all field with termvectors wiht positions enabled
			public static readonly FieldOption TERMVECTOR_WITH_POSITION = new FieldOption("TERMVECTOR_WITH_POSITION");
			// all fields where termvectors with offset position are set
			public static readonly FieldOption TERMVECTOR_WITH_OFFSET = new FieldOption("TERMVECTOR_WITH_OFFSET");
			// all fields where termvectors with offset and position values set
			public static readonly FieldOption TERMVECTOR_WITH_POSITION_OFFSET = new FieldOption("TERMVECTOR_WITH_POSITION_OFFSET");
		}
		
		/// <summary> Constructor used if IndexReader is not owner of its directory. 
		/// This is used for IndexReaders that are used within other IndexReaders that take care or locking directories.
		/// 
		/// </summary>
		/// <param name="directory">Directory where IndexReader files reside.
		/// </param>
		protected internal IndexReader(Directory directory)
		{
			this.directory = directory;
		}
		
		/// <summary> Constructor used if IndexReader is owner of its directory.
		/// If IndexReader is owner of its directory, it locks its directory in case of write operations.
		/// 
		/// </summary>
		/// <param name="directory">Directory where IndexReader files reside.
		/// </param>
		/// <param name="segmentInfos">Used for write-l
		/// </param>
		/// <param name="closeDirectory">
		/// </param>
		internal IndexReader(Directory directory, SegmentInfos segmentInfos, bool closeDirectory)
		{
			Init(directory, segmentInfos, closeDirectory, true);
		}
		
		internal virtual void  Init(Directory directory, SegmentInfos segmentInfos, bool closeDirectory, bool directoryOwner)
		{
			this.directory = directory;
			this.segmentInfos = segmentInfos;
			this.directoryOwner = directoryOwner;
			this.closeDirectory = closeDirectory;
		}
		
		private Directory directory;
		private bool directoryOwner;
		private bool closeDirectory;
		
		private SegmentInfos segmentInfos;
		private Lock writeLock;
		private bool stale;
		private bool hasChanges;
		
		
		/// <summary>Returns an IndexReader reading the index in an FSDirectory in the named
		/// path. 
		/// </summary>
		public static IndexReader Open(System.String path)
		{
			return Open(FSDirectory.GetDirectory(path, false), true);
		}
		
		/// <summary>Returns an IndexReader reading the index in an FSDirectory in the named
		/// path. 
		/// </summary>
		public static IndexReader Open(System.IO.FileInfo path)
		{
			return Open(FSDirectory.GetDirectory(path, false), true);
		}
		
		/// <summary>Returns an IndexReader reading the index in the given Directory. </summary>
		public static IndexReader Open(Directory directory)
		{
			return Open(directory, false);
		}
		
		private static IndexReader Open(Directory directory, bool closeDirectory)
		{
			lock (directory)
			{
				// in- & inter-process sync
				return (IndexReader) new AnonymousClassWith(directory, closeDirectory, directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME), IndexWriter.COMMIT_LOCK_TIMEOUT).Run();
			}
		}
		
		/// <summary>Returns the directory this index resides in. </summary>
		public virtual Directory Directory()
		{
			return directory;
		}
		
		/// <summary> Returns the time the index in the named directory was last modified.
		/// Do not use this to check whether the reader is still up-to-date, use
		/// {@link #IsCurrent()} instead. 
		/// </summary>
		public static long LastModified(System.String directory)
		{
			return LastModified(new System.IO.FileInfo(directory));
		}
		
		/// <summary> Returns the time the index in the named directory was last modified. 
		/// Do not use this to check whether the reader is still up-to-date, use
		/// {@link #IsCurrent()} instead. 
		/// </summary>
		public static long LastModified(System.IO.FileInfo directory)
		{
			return FSDirectory.FileModified(directory, IndexFileNames.SEGMENTS);
		}
		
		/// <summary> Returns the time the index in the named directory was last modified. 
		/// Do not use this to check whether the reader is still up-to-date, use
		/// {@link #IsCurrent()} instead. 
		/// </summary>
		public static long LastModified(Directory directory)
		{
			return directory.FileModified(IndexFileNames.SEGMENTS);
		}
		
		/// <summary> Reads version number from segments files. The version number is
		/// initialized with a timestamp and then increased by one for each change of
		/// the index.
		/// 
		/// </summary>
		/// <param name="directory">where the index resides.
		/// </param>
		/// <returns> version number.
		/// </returns>
		/// <throws>  IOException if segments file cannot be read </throws>
		public static long GetCurrentVersion(System.String directory)
		{
			return GetCurrentVersion(new System.IO.FileInfo(directory));
		}
		
		/// <summary> Reads version number from segments files. The version number is
		/// initialized with a timestamp and then increased by one for each change of
		/// the index.
		/// 
		/// </summary>
		/// <param name="directory">where the index resides.
		/// </param>
		/// <returns> version number.
		/// </returns>
		/// <throws>  IOException if segments file cannot be read </throws>
		public static long GetCurrentVersion(System.IO.FileInfo directory)
		{
			Directory dir = FSDirectory.GetDirectory(directory, false);
			long version = GetCurrentVersion(dir);
			dir.Close();
			return version;
		}
		
		/// <summary> Reads version number from segments files. The version number is
		/// initialized with a timestamp and then increased by one for each change of
		/// the index.
		/// 
		/// </summary>
		/// <param name="directory">where the index resides.
		/// </param>
		/// <returns> version number.
		/// </returns>
		/// <throws>  IOException if segments file cannot be read. </throws>
		public static long GetCurrentVersion(Directory directory)
		{
            lock (directory)
            {
                // in- & inter-process sync
                Lock commitLock = directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME);
				
                bool locked = false;
				
                try
                {
                    locked = commitLock.Obtain(IndexWriter.COMMIT_LOCK_TIMEOUT);
					
                    return SegmentInfos.ReadCurrentVersion(directory);
                }
                finally
                {
                    if (locked)
                    {
                        commitLock.Release();
                    }
                }
            }
        }
		
		/// <summary> Version number when this IndexReader was opened.</summary>
		public virtual long GetVersion()
		{
			return segmentInfos.GetVersion();
		}
		
		/// <summary> Check whether this IndexReader still works on a current version of the index.
		/// If this is not the case you will need to re-open the IndexReader to
		/// make sure you see the latest changes made to the index.
		/// 
		/// </summary>
		/// <throws>  IOException </throws>
		public virtual bool IsCurrent()
		{
            lock (directory)
            {
                // in- & inter-process sync
                Lock commitLock = directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME);
				
                bool locked = false;
				
                try
                {
                    locked = commitLock.Obtain(IndexWriter.COMMIT_LOCK_TIMEOUT);
					
                    return SegmentInfos.ReadCurrentVersion(directory) == segmentInfos.GetVersion();
                }
                finally
                {
                    if (locked)
                    {
                        commitLock.Release();
                    }
                }
            }
        }
		
		/// <summary>  Return an array of term frequency vectors for the specified document.
		/// The array contains a vector for each vectorized field in the document.
		/// Each vector contains terms and frequencies for all terms in a given vectorized field.
		/// If no such fields existed, the method returns null. The term vectors that are
		/// returned my either be of type TermFreqVector or of type TermPositionsVector if
		/// positions or offsets have been stored.
		/// 
		/// </summary>
		/// <param name="docNumber">document for which term frequency vectors are returned
		/// </param>
		/// <returns> array of term frequency vectors. May be null if no term vectors have been
		/// stored for the specified document.
		/// </returns>
		/// <throws>  IOException if index cannot be accessed </throws>
		/// <seealso cref="Lucene.Net.document.Field.TermVector">
		/// </seealso>
		abstract public TermFreqVector[] GetTermFreqVectors(int docNumber);
		
		
		/// <summary>  Return a term frequency vector for the specified document and field. The
		/// returned vector contains terms and frequencies for the terms in
		/// the specified field of this document, if the field had the storeTermVector
		/// flag set. If termvectors had been stored with positions or offsets, a 
		/// TermPositionsVector is returned.
		/// 
		/// </summary>
		/// <param name="docNumber">document for which the term frequency vector is returned
		/// </param>
		/// <param name="field">field for which the term frequency vector is returned.
		/// </param>
		/// <returns> term frequency vector May be null if field does not exist in the specified
		/// document or term vector was not stored.
		/// </returns>
		/// <throws>  IOException if index cannot be accessed </throws>
		/// <seealso cref="Lucene.Net.document.Field.TermVector">
		/// </seealso>
		abstract public TermFreqVector GetTermFreqVector(int docNumber, System.String field);
		
		/// <summary> Returns <code>true</code> if an index exists at the specified directory.
		/// If the directory does not exist or if there is no index in it.
		/// <code>false</code> is returned.
		/// </summary>
		/// <param name="directory">the directory to check for an index
		/// </param>
		/// <returns> <code>true</code> if an index exists; <code>false</code> otherwise
		/// </returns>
		public static bool IndexExists(System.String directory)
		{
			bool tmpBool;
            if (System.IO.File.Exists((new System.IO.FileInfo(System.IO.Path.Combine(directory, IndexFileNames.SEGMENTS))).FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists((new System.IO.FileInfo(System.IO.Path.Combine(directory, IndexFileNames.SEGMENTS))).FullName);
			return tmpBool;
		}
		
		/// <summary> Returns <code>true</code> if an index exists at the specified directory.
		/// If the directory does not exist or if there is no index in it.
		/// </summary>
		/// <param name="directory">the directory to check for an index
		/// </param>
		/// <returns> <code>true</code> if an index exists; <code>false</code> otherwise
		/// </returns>
		public static bool IndexExists(System.IO.FileInfo directory)
		{
			bool tmpBool;
			if (System.IO.File.Exists((new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, IndexFileNames.SEGMENTS))).FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists((new System.IO.FileInfo(System.IO.Path.Combine(directory.FullName, IndexFileNames.SEGMENTS))).FullName);
			return tmpBool;
		}
		
		/// <summary> Returns <code>true</code> if an index exists at the specified directory.
		/// If the directory does not exist or if there is no index in it.
		/// </summary>
		/// <param name="directory">the directory to check for an index
		/// </param>
		/// <returns> <code>true</code> if an index exists; <code>false</code> otherwise
		/// </returns>
		/// <throws>  IOException if there is a problem with accessing the index </throws>
		public static bool IndexExists(Directory directory)
		{
			return directory.FileExists(IndexFileNames.SEGMENTS);
		}
		
		/// <summary>Returns the number of documents in this index. </summary>
		public abstract int NumDocs();
		
		/// <summary>Returns one greater than the largest possible document number.
		/// This may be used to, e.g., determine how big to allocate an array which
		/// will have an element for every document number in an index.
		/// </summary>
		public abstract int MaxDoc();
		
		/// <summary>Returns the stored fields of the <code>n</code><sup>th</sup>
		/// <code>Document</code> in this index. 
		/// </summary>
		public abstract Document Document(int n);
		
		/// <summary>Returns true if document <i>n</i> has been deleted </summary>
		public abstract bool IsDeleted(int n);
		
		/// <summary>Returns true if any documents have been deleted </summary>
		public abstract bool HasDeletions();
		
		/// <summary>Returns true if there are norms stored for this field. </summary>
		public virtual bool HasNorms(System.String field)
		{
			// backward compatible implementation.
			// SegmentReader has an efficient implementation.
			return Norms(field) != null;
		}
		
		/// <summary>Returns the byte-encoded normalization factor for the named field of
		/// every document.  This is used by the search code to score documents.
		/// 
		/// </summary>
		/// <seealso cref="Field.SetBoost(float)">
		/// </seealso>
		public abstract byte[] Norms(System.String field);
		
		/// <summary>Reads the byte-encoded normalization factor for the named field of every
		/// document.  This is used by the search code to score documents.
		/// 
		/// </summary>
		/// <seealso cref="Field.SetBoost(float)">
		/// </seealso>
		public abstract void  Norms(System.String field, byte[] bytes, int offset);
		
		/// <summary>Expert: Resets the normalization factor for the named field of the named
		/// document.  The norm represents the product of the field's {@link
		/// Field#SetBoost(float) boost} and its {@link Similarity#LengthNorm(String,
		/// int) length normalization}.  Thus, to preserve the length normalization
		/// values when resetting this, one should base the new value upon the old.
		/// 
		/// </summary>
		/// <seealso cref="Norms(String)">
		/// </seealso>
		/// <seealso cref="Similarity.DecodeNorm(byte)">
		/// </seealso>
		public void  SetNorm(int doc, System.String field, byte value_Renamed)
		{
			lock (this)
			{
				if (directoryOwner)
					AquireWriteLock();
				DoSetNorm(doc, field, value_Renamed);
				hasChanges = true;
			}
		}
		
		/// <summary>Implements setNorm in subclass.</summary>
		protected internal abstract void  DoSetNorm(int doc, System.String field, byte value_Renamed);
		
		/// <summary>Expert: Resets the normalization factor for the named field of the named
		/// document.
		/// 
		/// </summary>
		/// <seealso cref="Norms(String)">
		/// </seealso>
		/// <seealso cref="Similarity.DecodeNorm(byte)">
		/// </seealso>
		public virtual void  SetNorm(int doc, System.String field, float value_Renamed)
		{
			SetNorm(doc, field, Similarity.EncodeNorm(value_Renamed));
		}
		
		/// <summary>Returns an enumeration of all the terms in the index.
		/// The enumeration is ordered by Term.compareTo().  Each term
		/// is greater than all that precede it in the enumeration.
		/// </summary>
		public abstract TermEnum Terms();
		
		/// <summary>Returns an enumeration of all terms after a given term.
		/// The enumeration is ordered by Term.compareTo().  Each term
		/// is greater than all that precede it in the enumeration.
		/// </summary>
		public abstract TermEnum Terms(Term t);
		
		/// <summary>Returns the number of documents containing the term <code>t</code>. </summary>
		public abstract int DocFreq(Term t);
		
		/// <summary>Returns an enumeration of all the documents which contain
		/// <code>term</code>. For each document, the document number, the frequency of
		/// the term in that document is also provided, for use in search scoring.
		/// Thus, this method implements the mapping:
		/// <p><ul>
		/// Term &nbsp;&nbsp; =&gt; &nbsp;&nbsp; &lt;docNum, freq&gt;<sup>*</sup>
		/// </ul>
		/// <p>The enumeration is ordered by document number.  Each document number
		/// is greater than all that precede it in the enumeration.
		/// </summary>
		public virtual TermDocs TermDocs(Term term)
		{
			TermDocs termDocs = TermDocs();
			termDocs.Seek(term);
			return termDocs;
		}
		
		/// <summary>Returns an unpositioned {@link TermDocs} enumerator. </summary>
		public abstract TermDocs TermDocs();
		
		/// <summary>Returns an enumeration of all the documents which contain
		/// <code>term</code>.  For each document, in addition to the document number
		/// and frequency of the term in that document, a list of all of the ordinal
		/// positions of the term in the document is available.  Thus, this method
		/// implements the mapping:
		/// 
		/// <p><ul>
		/// Term &nbsp;&nbsp; =&gt; &nbsp;&nbsp; &lt;docNum, freq,
		/// &lt;pos<sub>1</sub>, pos<sub>2</sub>, ...
		/// pos<sub>freq-1</sub>&gt;
		/// &gt;<sup>*</sup>
		/// </ul>
		/// <p> This positional information faciliates phrase and proximity searching.
		/// <p>The enumeration is ordered by document number.  Each document number is
		/// greater than all that precede it in the enumeration.
		/// </summary>
		public virtual TermPositions TermPositions(Term term)
		{
			TermPositions termPositions = TermPositions();
			termPositions.Seek(term);
			return termPositions;
		}
		
		/// <summary>Returns an unpositioned {@link TermPositions} enumerator. </summary>
		public abstract TermPositions TermPositions();
		
		/// <summary> Tries to acquire the WriteLock on this directory.
		/// this method is only valid if this IndexReader is directory owner.
		/// 
		/// </summary>
		/// <throws>  IOException If WriteLock cannot be acquired. </throws>
		private void  AquireWriteLock()
		{
			if (stale)
				throw new System.IO.IOException("IndexReader out of date and no longer valid for delete, undelete, or setNorm operations");
			
			if (this.writeLock == null)
			{
				Lock writeLock = directory.MakeLock(IndexWriter.WRITE_LOCK_NAME);
				if (!writeLock.Obtain(IndexWriter.WRITE_LOCK_TIMEOUT))
				// obtain write lock
				{
					throw new System.IO.IOException("Index locked for write: " + writeLock);
				}
				this.writeLock = writeLock;
				
				// we have to check whether index has changed since this reader was opened.
				// if so, this reader is no longer valid for deletion
				if (SegmentInfos.ReadCurrentVersion(directory) > segmentInfos.GetVersion())
				{
					stale = true;
					this.writeLock.Release();
					this.writeLock = null;
					throw new System.IO.IOException("IndexReader out of date and no longer valid for delete, undelete, or setNorm operations");
				}
			}
		}
		
		
        /// <summary>Deletes the document numbered <code>docNum</code>.  Once a document is
		/// deleted it will not appear in TermDocs or TermPostitions enumerations.
		/// Attempts to read its field with the {@link #document}
		/// method will result in an error.  The presence of this document may still be
		/// reflected in the {@link #docFreq} statistic, though
		/// this will be corrected eventually as the index is further modified.
		/// </summary>
		public void  DeleteDocument(int docNum)
		{
			lock (this)
			{
				if (directoryOwner)
					AquireWriteLock();
				DoDelete(docNum);
				hasChanges = true;
			}
		}
		
		
		/// <summary>Implements deletion of the document numbered <code>docNum</code>.
		/// Applications should call {@link #DeleteDocument(int)} or {@link #DeleteDocuments(Term)}.
		/// </summary>
		protected internal abstract void  DoDelete(int docNum);
		
		
        /// <summary>Deletes all documents containing <code>term</code>.
		/// This is useful if one uses a document field to hold a unique ID string for
		/// the document.  Then to delete such a document, one merely constructs a
		/// term with the appropriate field and the unique ID string as its text and
		/// passes it to this method.
		/// See {@link #Delete(int)} for information about when this deletion will 
		/// become effective.
		/// </summary>
		/// <returns> the number of documents deleted
		/// </returns>
		public int DeleteDocuments(Term term)
		{
			TermDocs docs = TermDocs(term);
			if (docs == null)
				return 0;
			int n = 0;
			try
			{
				while (docs.Next())
				{
					DeleteDocument(docs.Doc());
					n++;
				}
			}
			finally
			{
				docs.Close();
			}
			return n;
		}
		
		/// <summary>Undeletes all documents currently marked as deleted in this index.</summary>
		public void  UndeleteAll()
		{
			lock (this)
			{
				if (directoryOwner)
					AquireWriteLock();
				DoUndeleteAll();
				hasChanges = true;
			}
		}
		
		/// <summary>Implements actual undeleteAll() in subclass. </summary>
		protected internal abstract void  DoUndeleteAll();
		
		/// <summary> Commit changes resulting from delete, undeleteAll, or setNorm operations
		/// 
		/// </summary>
		/// <throws>  IOException </throws>
		protected internal void  Commit()
		{
			lock (this)
			{
				if (hasChanges)
				{
					if (directoryOwner)
					{
						lock (directory)
						{
							// in- & inter-process sync
							new AnonymousClassWith1(this, directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME), IndexWriter.COMMIT_LOCK_TIMEOUT).Run();
						}
						if (writeLock != null)
						{
							writeLock.Release(); // release write lock
							writeLock = null;
						}
					}
					else
						DoCommit();
				}
				hasChanges = false;
			}
		}
		
		/// <summary>Implements commit. </summary>
		protected internal abstract void  DoCommit();
		
		/// <summary> Closes files associated with this index.
		/// Also saves any new deletions to disk.
		/// No other methods should be called after this has been called.
		/// </summary>
		public void  Close()
		{
			lock (this)
			{
				Commit();
				DoClose();
				if (closeDirectory)
					directory.Close();
                System.GC.SuppressFinalize(this);
			}
		}
		
		/// <summary>Implements close. </summary>
		protected internal abstract void  DoClose();
		
		/// <summary>Release the write lock, if needed. </summary>
		~IndexReader()
		{
			if (writeLock != null)
			{
				writeLock.Release(); // release write lock
				writeLock = null;
			}
		}
		
		
        /// <summary> Get a list of unique field names that exist in this index and have the specified
		/// field option information.
		/// </summary>
		/// <param name="fldOption">specifies which field option should be available for the returned fields
		/// </param>
		/// <returns> Collection of Strings indicating the names of the fields.
		/// </returns>
		/// <seealso cref="IndexReader.FieldOption">
		/// </seealso>
		public abstract System.Collections.ICollection GetFieldNames(FieldOption fldOption);
		
		/// <summary> Returns <code>true</code> iff the index in the named directory is
		/// currently locked.
		/// </summary>
		/// <param name="directory">the directory to check for a lock
		/// </param>
		/// <throws>  IOException if there is a problem with accessing the index </throws>
		public static bool IsLocked(Directory directory)
		{
			return directory.MakeLock(IndexWriter.WRITE_LOCK_NAME).IsLocked() || directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME).IsLocked();
		}
		
		/// <summary> Returns <code>true</code> iff the index in the named directory is
		/// currently locked.
		/// </summary>
		/// <param name="directory">the directory to check for a lock
		/// </param>
		/// <throws>  IOException if there is a problem with accessing the index </throws>
		public static bool IsLocked(System.String directory)
		{
			Directory dir = FSDirectory.GetDirectory(directory, false);
			bool result = IsLocked(dir);
			dir.Close();
			return result;
		}
		
		/// <summary> Forcibly unlocks the index in the named directory.
		/// <P>
		/// Caution: this should only be used by failure recovery code,
		/// when it is known that no other process nor thread is in fact
		/// currently accessing this index.
		/// </summary>
		public static void  Unlock(Directory directory)
		{
			directory.MakeLock(IndexWriter.WRITE_LOCK_NAME).Release();
			directory.MakeLock(IndexWriter.COMMIT_LOCK_NAME).Release();
		}
		
		/// <summary> Prints the filename and size of each file within a given compound file.
		/// Add the -extract flag to extract files to the current working directory.
		/// In order to make the extracted version of the index work, you have to copy
		/// the segments file from the compound index into the directory where the extracted files are stored.
		/// </summary>
		/// <param name="args">Usage: Lucene.Net.index.IndexReader [-extract] &lt;cfsfile&gt;
		/// </param>
		[STAThread]
		public static void  Main(System.String[] args)
		{
			System.String filename = null;
			bool extract = false;
			
			for (int i = 0; i < args.Length; ++i)
			{
				if (args[i].Equals("-extract"))
				{
					extract = true;
				}
				else if (filename == null)
				{
					filename = args[i];
				}
			}
			
			if (filename == null)
			{
				System.Console.Out.WriteLine("Usage: Lucene.Net.index.IndexReader [-extract] <cfsfile>");
				return ;
			}
			
			Directory dir = null;
			CompoundFileReader cfr = null;
			
			try
			{
				System.IO.FileInfo file = new System.IO.FileInfo(filename);
				System.String dirname = new System.IO.FileInfo(file.FullName).DirectoryName;
				filename = file.Name;
				dir = FSDirectory.GetDirectory(dirname, false);
				cfr = new CompoundFileReader(dir, filename);
				
				System.String[] files = cfr.List();
				System.Array.Sort(files); // sort the array of filename so that the output is more readable
				
				for (int i = 0; i < files.Length; ++i)
				{
					long len = cfr.FileLength(files[i]);
					
					if (extract)
					{
						System.Console.Out.WriteLine("extract " + files[i] + " with " + len + " bytes to local directory...");
						IndexInput ii = cfr.OpenInput(files[i]);
						
						System.IO.FileStream f = new System.IO.FileStream(files[i], System.IO.FileMode.Create);
						
						// read and write with a small buffer, which is more effectiv than reading byte by byte
						byte[] buffer = new byte[1024];
						int chunk = buffer.Length;
						while (len > 0)
						{
							int bufLen = (int) System.Math.Min(chunk, len);
							ii.ReadBytes(buffer, 0, bufLen);

                            byte[] byteArray = new byte[buffer.Length];
                            for (int index=0; index < buffer.Length; index++)
                                byteArray[index] = (byte) buffer[index];

                            f.Write(byteArray, 0, bufLen);

                            len -= bufLen;
						}
						
						f.Close();
						ii.Close();
					}
					else
						System.Console.Out.WriteLine(files[i] + ": " + len + " bytes");
				}
			}
			catch (System.IO.IOException ioe)
			{
				System.Console.Error.WriteLine(ioe.StackTrace);
			}
			finally
			{
				try
				{
					if (dir != null)
						dir.Close();
					if (cfr != null)
						cfr.Close();
				}
				catch (System.IO.IOException ioe)
				{
					System.Console.Error.WriteLine(ioe.StackTrace);
				}
			}
		}
	}
}