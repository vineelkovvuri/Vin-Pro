
//Last Modified: Fri Jun 01 2007 1:25:06 AM
//Retriving data from sql server 2005 using OLEDB Data Provider
using System;
using System.Data.OleDb;

class test
{
	static void Main()
	{
		string conString = @"data source = .\sqlexpress ; initial catalog =northwind ; integrated security = sspi; provider=sqloledb";

		string sqlString = "SELECT * FROM employees";

		OleDbConnection con = null;
		OleDbDataReader reader = null;

		try
		{
			con = new OleDbConnection(conString);
			con.Open();

			OleDbCommand cmd = new OleDbCommand(sqlString,con);
			reader = cmd.ExecuteReader();

			while(reader.Read())
				Console.WriteLine(reader[0]+" "+reader[1]);

		}
		catch(Exception ex)
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


