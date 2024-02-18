

//Last Modified: Fri Jun 01 2007 4:19:07 PM
//The Sql command returns only single value so it is efficient to use ExecuteScalar
//than ExecuteReader and using a while loop to iterate over the result
using System;
using System.Data.SqlClient;


class test
{
	static void Main()
	{
		string conString = @"server = .\sqlexpress; database = northwind; integrated security=true;";

		SqlConnection con = null;
		
		try
		{
			con = new SqlConnection(conString);
			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT count(*) FROM employees",con);

			Console.WriteLine("Number of Employees are : "+cmd.ExecuteScalar());
		}
		catch(SqlException sqlEx)
		{
			Console.WriteLine(sqlEx.Message);
		}
		finally
		{
			con.Close();
		}
	}
}


