using System;
using System.Collections.Generic;
using System.Text;
using Lucene;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
//using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using System.IO;
using LStore = Lucene.Net.Store;
namespace LLuceneTest
{
    class Program
    {
        static void Main( string[] args )
        {

            string dir;
            long start = DateTime.Now.Ticks;

            //Indexing
            //foreach( string rootdir in Environment.GetLogicalDrives() )
            //{
            //    Directory.CreateDirectory(dir =  @"H:\index\" + rootdir[0] );
            //    Index.StartIndex( rootdir , dir );
            //}

            foreach( string rootdir in Environment.GetLogicalDrives() )
                Search.StartSearch( @"h:\index\" + rootdir[0] , "SANAT" );
            long end = DateTime.Now.Ticks;
            DateTime dt = new DateTime( end - start );
            Console.WriteLine( dt.Minute + "::" + dt.Second );
        }
    }
    class Index
    {
        static IndexWriter iw;
        public static void StartIndex( string srcPath , string idxPath )
        {
            iw = new IndexWriter( idxPath , new StandardAnalyzer() , true );
            Search( srcPath );
            iw.Optimize();
            iw.Close();

        }
        static Document d = null ;
        static string[ ] fileExt = { "*.txt" , "*.cs" , "*.h" , "*.c" , "*.idl" , "*.htm" , "*.html" , "*.inc" , "*.inf" , "*.java" , "*.cpp" , "*.log" , "*.pas" , "*.xml" , };
        private static void Search( string srcPath )
        {
            try
            {
                foreach( string ext in fileExt )
                {
                    foreach( string file in Directory.GetFiles( srcPath , ext ) )
                    {
                        Console.WriteLine( "Indexing: " + file );
                        d = new Document();
                        d.Add( new Field( "contents" , new StreamReader( file ) ) );
                        d.Add( new Field( "filename" , file , Field.Store.YES , Field.Index.NO ) );
                        iw.AddDocument( d );
                    }
                }
                foreach( string dir in Directory.GetDirectories( srcPath ) )
                    Search( dir );
            }
            catch { Console.WriteLine( "Access Denide" ); }
        }
    }
    class Search
    {
        public static void StartSearch( string idxPath , string query )
        {
            LStore.Directory idxDir = LStore.FSDirectory.GetDirectory( idxPath , false );
            IndexSearcher ids = new IndexSearcher( idxDir );
            Query q = new QueryParser( "contents" , new StandardAnalyzer() ).Parse( query );

            Hits hits = ids.Search( q );

            for( int i = 0 ; i < hits.Length() ; i++ )
            {
                Document d = hits.Doc( i );
                Console.WriteLine( d.Get( "filename" ) );
            }
        }
    }
}
