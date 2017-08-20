import java.io.*;
import javax.servlet.*;


	public class HelloServlet extends GenericServlet{
		public void service(ServletRequest req,ServletResponse res)
			throws ServletException , IOException{
			res.setContentType("text/html");
			PrintWriter pw = res.getWriter();
			pw.println("<B>Vineel");
			pw.close();
		}
	}

