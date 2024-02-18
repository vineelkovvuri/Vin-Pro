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
using IndexInput = Lucene.Net.Store.IndexInput;

namespace Lucene.Net.Index
{
	
	sealed class SegmentTermPositions : SegmentTermDocs, TermPositions
	{
		private IndexInput proxStream;
		private int proxCount;
		private int position;
		
		internal SegmentTermPositions(SegmentReader p) : base(p)
		{
			this.proxStream = (IndexInput) parent.proxStream.Clone();
		}
		
		internal override void  Seek(TermInfo ti)
		{
			base.Seek(ti);
			if (ti != null)
				proxStream.Seek(ti.proxPointer);
			proxCount = 0;
		}
		
		public override void  Close()
		{
			base.Close();
			proxStream.Close();
		}
		
		public int NextPosition()
		{
			proxCount--;
			return position += proxStream.ReadVInt();
		}
		
		protected internal override void  SkippingDoc()
		{
			for (int f = freq; f > 0; f--)
			// skip all positions
				proxStream.ReadVInt();
		}
		
		public override bool Next()
		{
			for (int f = proxCount; f > 0; f--)
			// skip unread positions
				proxStream.ReadVInt();
			
			if (base.Next())
			{
				// run super
				proxCount = freq; // note frequency
				position = 0; // reset position
				return true;
			}
			return false;
		}
		
		public override int Read(int[] docs, int[] freqs)
		{
			throw new System.NotSupportedException("TermPositions does not support processing multiple documents in one call. Use TermDocs instead.");
		}
		
		
		/// <summary>Called by super.skipTo(). </summary>
		protected internal override void  SkipProx(long proxPointer)
		{
			proxStream.Seek(proxPointer);
			proxCount = 0;
		}
	}
}