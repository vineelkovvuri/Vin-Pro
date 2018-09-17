//Last Modified: Sat Jun 16 2007 12:33:37 AM -- By Vineel
//In the following program there is no need to explicitly open the connection
//This will be taken care by Fill method
//The Fill method automatically opens a connection if it is not open when 
//Fill() is called. It then closes the connection after Fill() is called, 
//it uses that filling the dataset. However,if a connection is open when 
//connection and doesnítclose it afterward

using System;
using System.Data;
using System.Data.SqlClient;

class DataSetAndDataAdapter
{
	static void Main()
	{
		string conStr = @"
						server=.\sqlexpress;
						database=northwind;
						integrated security=true;
						";
		string sqlCom = "SELECT productname,unitprice FROM products WHERE unitprice < 20 ";
		SqlConnection con = new SqlConnection(conStr);
		try
		{
			SqlDataAdapter adap = new SqlDataAdapter(sqlCom,con);
			DataSet ds = new DataSet();
			adap.Fill(ds,"MyQueryTable");  //Arbitrary name of my retrived results 
			
			DataTable dt = ds.Tables["MyQueryTable"];

			foreach(DataRow dr in dt.Rows)
			{
				foreach(DataColumn dc in dt.Columns)
					Console.Write("{0,-30}\t",dr[dc]);
				Console.WriteLine();
			}	
		}
		catch(SqlException ex)
		{
			Console.WriteLine("{0} {1}",ex.Message,ex.StackTrace);
		}
	}
}


