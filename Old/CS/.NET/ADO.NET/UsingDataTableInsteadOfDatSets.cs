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
                //SqlCommandBuilder cb = new SqlCommandBuilder(adap);
                DataTable dt = new DataTable();
                adap.Fill( dt);  //Arbitrary name of my retrived results 
                
                foreach( DataRow dr in dt.Rows ) {
                    foreach( DataColumn dc in dt.Columns )
                        Console.Write( "{0}" , dr[dc] );
                    Console.WriteLine();
                }
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


