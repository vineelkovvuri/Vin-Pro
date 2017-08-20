//Last Modified: Tue Jun 12 2007 11:22:26 PM -- By Vineel
//the NextResult() method of SqlDataReader moves to next Result Set(i.e., result of next Query)


using System;
using System.Data;
using System.Data.SqlClient;
    class Program
    {
        static void Main( string[] args )
        {
            string conStr = @"
                            server=.\sqlexpress;
                            database=northwind;
                            integrated security = true;
                            ";
            string sqlStr = @"SELECT companyname,contactname FROM customers
                              SELECT firstname , lastname FROM employees";

            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection( conStr );
                con.Open();

                SqlCommand command = new SqlCommand( sqlStr , con );
                reader = command.ExecuteReader();

                do
                {
                    while( reader.Read() )
                        Console.WriteLine( "{0,-40} {1}" , reader[0] , reader[1] );

                    Console.WriteLine("".PadLeft(50,'='));
                } while( reader.NextResult() );

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


