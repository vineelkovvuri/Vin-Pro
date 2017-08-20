
using System;
using System.Data;
using System.Data.SqlClient;
class AccessingSQLExpressUsingDataSet
{
	static void Main(string[] args)
	{
		SqlConnection con = new SqlConnection(@"Server = satya\Sqlexpress;Integrated Security=true;" +
				"Database=northwind");
		con.Open();
		SqlDataAdapter sda = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", con);
		DataSet ds = new DataSet();
		sda.Fill(ds,"Customers");
		foreach(DataRow dr in ds.Tables["Customers"].Rows)
			Console.WriteLine(dr["CustomerID"] + "   " + dr["CompanyName"]);
		con.Close();

	}
}


