import java.sql.*;


public class test{
	public static void main(String []args){
		try{
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");

								//Using windows authentication so no username no password
								//and using Database specified in the wizard
			Connection con = DriverManager.getConnection("jdbc:odbc:vineel","","");
			Statement st =  con.createStatement();
			ResultSet rs = st.executeQuery("select * from JournalDetails");

			while(rs.next())
				System.out.println(rs.getString(1));
			con.close();

		}catch(Exception e){
			e.printStackTrace();
		}
	}
}



