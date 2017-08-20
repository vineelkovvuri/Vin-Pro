//Last Modified: Tue Jun 12 2007 9:10:24 PM -- By Vineel
//This program demonstares various SqlDataReader Properties
//1.FieldCount			---> Returns the number of columns(fields) fetched by the query
//2.HasRows				---> Returns true if query returns 1 or more rows, false otherwise
//3.IsClosed			---> Returns true if Data Reader Closed , false otherwise
//4.GetDataTypeName()	---> Returns the Sql Data Type of the specified column
//5.GetFieldType()		---> Returns the .NET Data Type corresponding to the Sql Columns type.
//6.RecordsAffected		---> Returns the number of rows changed, inserted, or deleted by execution of the Transact-SQL statement
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

                Console.WriteLine( "FieldCount = {0}" , reader.FieldCount);
                Console.WriteLine( "HasRows = {0}" , reader.HasRows);
                Console.WriteLine( "Is Data Reader Closed? = {0}" , reader.IsClosed);
				Console.WriteLine( "{0}  {1}" , reader.GetDataTypeName( 0 ) , reader.GetDataTypeName( 1 ) );
                Console.WriteLine( "{0}  {1}" , reader.GetFieldType( 0 ) , reader.GetFieldType( 1 ) ); 

				
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
