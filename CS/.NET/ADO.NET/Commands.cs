//Last Modified: Fri Jun 01 2007 4:07:56 PM
//Using CommandText to set SQL COMMAND  

using System;
using System.Data.SqlClient;

class test
{
	static void Main()
	{
		string s = @"server = .\sqlexpress ; database=northwind; integrated security = true;";

		SqlConnection con = null;
		SqlDataReader reader = null;

		try
		{
			con = new SqlConnection(s);
			con.Open();

			SqlCommand cmd = con.CreateCommand();
			cmd.CommandText = "SELECT * FROM employees";
			reader = cmd.ExecuteReader();

			while(reader.Read())
				Console.WriteLine(reader[0]);

		}
		catch(SqlException ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			reader.Close();
			con.Close();
		}
	}
}


