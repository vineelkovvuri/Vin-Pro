using System;
using System.Data;
using System.Data.SqlClient;
namespace SqlServer2005
{
    class Program
    {
        static void Main( string[] args )
        {
            string conStr = @"
					        server=.\sqlexpress;
					        database=northwind;
					        integrated security=true;
					        ";
            string sqlCom = "SELECT * FROM products  ";
            SqlConnection con = new SqlConnection( conStr );
            try
            {
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter( sqlCom , con );

                DataSet ds = new DataSet();
                adap.Fill( ds , "MyQueryTable" );  //Arbitrary name of my retrived results 

                ds.WriteXmlSchema( "test.xsd" );   //Dumping the DataSet to a schema
                ds.WriteXml( "test.xml" );		   //Dumping the DataSet's Data to a XML file
            }
            catch( SqlException ex )
            {
                Console.WriteLine( "{0} {1}" , ex.Message , ex.StackTrace );
            }
            finally
            {
                con.Close();
            }
        }
    }
}


