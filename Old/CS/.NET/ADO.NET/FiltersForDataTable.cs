//Last Modified: Sat Jun 16 2007 12:25:14 AM -- By Vineel
//This program demonstrated the use of Select method of DataTable
//This Method takes a filter expression for selecting rows out of the
//retrieved Table 
//ms-help://MS.VSExpressCC.v80/MS.NETFramework.v20.en/cpref4/html/P_System_Data_DataColumn_Expression.htm
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
            string sqlCom = "SELECT productname,unitprice FROM products  ";
            SqlConnection con = new SqlConnection( conStr );
            try
            {
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter( sqlCom , con );
                DataSet ds = new DataSet();
                adap.Fill( ds , "MyQueryTable" );  //Arbitrary name of my retrived results 

                DataTable dt = ds.Tables["MyQueryTable"];

                foreach( DataRow dr in dt.Select( "unitprice > 20 and unitprice < 40" ) )
                {
                    foreach( DataColumn dc in dt.Columns )
                        Console.Write( "{0,-30}\t" , dr[dc] );
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

