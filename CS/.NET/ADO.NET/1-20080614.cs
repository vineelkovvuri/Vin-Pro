
using System;
using System.Data.SqlClient;


class test
{
	static void Main()
	{

		string conString = @"
			server=.\sqlexpress;
		database=bioinfo;
		integrated security = true;
		";
		string sql = "SELECT * FROM titles";

		SqlConnection con = null;
		SqlDataReader reader = null;

		try{
			con = new SqlConnection(conString);
			con.Open();
			SqlCommand cmd = new SqlCommand(sql,con);
			reader = cmd.ExecuteReader();
			while(reader.Read())
			{
				Console.WriteLine(reader[0]+"  "+reader[1]);
			}

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

