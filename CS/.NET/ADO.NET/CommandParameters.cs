
using System;
using System.Data;
using System.Data.SqlClient;


class test
{
	static void Main()
	{
		string conString = @"server = .\sqlexpress; database=northwind; integrated security=true;";

		string sql = "INSERT into employees(lastname,firstname) values(@lastname,@firstname)";

		SqlConnection con =  new SqlConnection(conString);
		SqlDataReader reader = null;
		try
		{
			con.Open();
			SqlCommand  cmd  = new SqlCommand(sql,con);
			cmd.Parameters.Add("@lastname",SqlDbType.NVarChar,10);
			cmd.Parameters.Add("@firstname",SqlDbType.NVarChar,10);

			cmd.Parameters["@lastname"].Value = "Reddy";
			cmd.Parameters["@firstname"].Value = "Vineel";

			cmd.ExecuteNonQuery();

			cmd.CommandText = "SELECT * FROM employees";

			reader = cmd.ExecuteReader();

			while(reader.Read())
				Console.WriteLine(reader[0]+" "+reader[1]+"  "+reader[2]);
		}
		catch(SqlException sqlEx)
		{
			Console.WriteLine(sqlEx.Message);
		}
		finally
		{
			reader.Close();
			con.Close();
		}
	}

}
