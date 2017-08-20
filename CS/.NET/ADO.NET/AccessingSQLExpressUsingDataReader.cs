using System;
using System.Data;
using System.Data.SqlClient;
class AccessingSQLExpress
{
	static void Main(string[] args)
	{
		SqlConnection con = new SqlConnection(@"Server = satya\Sqlexpress;Integrated Security=true;" +
				"Database=northwind");
		con.Open();
		SqlCommand command = con.CreateCommand();
		command.CommandText = "Select CustomerID, CompanyName from customers";
		SqlDataReader sdr =  command.ExecuteReader();
		while (sdr.Read())
			Console.WriteLine(sdr["CustomerID"] + "   " + sdr["CompanyName"]);
		sdr.Close();
		con.Close();

	}
}


