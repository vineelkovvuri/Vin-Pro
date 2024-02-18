//Last Modified: Fri Jun 01 2007 1:36:27 AM
//retrieving Data from sql server 2005 using ODBC data provider

using System;
using System.Data.Odbc;


class test
{
	static void Main()
	{
		string conString = "dsn=vineel";//will not allow blanks or new lines
		string sql = "SELECT * FROM employees";


		OdbcConnection con = null;
		OdbcDataReader reader = null;

		try
		{
			con = new OdbcConnection(conString);
			con.Open();

			OdbcCommand cmd = new OdbcCommand(sql,con);

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

