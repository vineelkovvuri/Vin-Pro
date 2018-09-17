//Last Modified: Tue Jun 12 2007 8:20:17 PM
//
//This program demonstrates the use of SqlDataReader object in various forms
//reader.GetInt32(0) returns the zeroth coloum in int form where as reader[0] 
//returns object 

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
                            integrated security = true;
                            ";
            string sqlStr = "SELECT productid , productname FROM products";

            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection( conStr );
                con.Open();

                SqlCommand command = new SqlCommand( sqlStr , con );
                reader = command.ExecuteReader();

                while( reader.Read() )
                    Console.WriteLine( "{0} {1}" , reader.GetInt32(0) , reader[1] );
            }
            catch( Exception ex )
            {
                Console.WriteLine( "{0}{1}" , ex.Message , ex.Source );
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
    }
}

