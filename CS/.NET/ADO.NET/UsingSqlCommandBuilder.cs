//Last Modified: Sat Jun 16 2007 2:26:00 PM -- By Vineel
//

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
				//Connection
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter( sqlCom , con );

				//CommandBuilder used to propagate data with much ease look 
				//With this you need not have to write command strings for updating the data
				//you can avoid using UpdateCommand , InsertCommand , DeleteCommand of 
				//SqlDataAdapter Class
                SqlCommandBuilder cb = new SqlCommandBuilder(adap);

				//Prepare DataSet
                DataSet ds = new DataSet();
                adap.Fill( ds , "MyQueryTable" );  //Arbitrary name of my retrived results 
                
				DataTable dt = ds.Tables["MyQueryTable"];

				//Add a new Row
                DataRow row = dt.NewRow();
                row[0] = 78;
                row["ProductName"] = "Vineel";
                row["Discontinued"] = false;
                dt.Rows.Add( row );

				//Updating the new row . This method will takecare all the new changes 
				//made to the dataset and will finally update the changes to data source.
                adap.Update( ds,"MyQueryTable" );


                foreach( DataRow dr in dt.Rows )
                {
                    foreach( DataColumn dc in dt.Columns )
                        Console.Write( "{0,-30}" , dr[dc] );
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


