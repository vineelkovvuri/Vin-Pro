

using System;
using System.Data.SqlClient;

class test
{
	static void Main()
	{
		string s = @"server = .\sqlexpress ; database=northwind; integrated security = true;";

		SqlConnection con = null;


		try
		{
			con = new SqlConnection(s);
			con.Open();
			Console.WriteLine(con.ConnectionString);
			Console.WriteLine(con.Database);	
			Console.WriteLine(	con.State);
		}
		catch(SqlException ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			con.Close();
		}
	}
}


