/*
 * This program extracts the marks of IT(3-1 GVPCOE) from IndiaResults.com  
 *
 *	 							 	 By
 *                          K.Vineel Kumar Reddy. B.Tech III/IV IT
 *                          Gayatri Vidya Parishad College of Engg.
 *                          Vishakapatnam,Andhra Pradesh.
 *	                                  INDIA. 
 */




using System;
using System.Net;
using System.IO;

namespace MyConsole
{
    class Student
    {
        public string name;
        public string roll;
        public string[] inter = new string[8];
        public string[] exter = new string[8];
        public int[] toteach = new int[8];
        public int total = 0;
        public bool exists = true;
    }
    class India
    {
        static string subName = "%><font face=Arial size=2><p style=\"margin-left: 5\">";
        static string name = "t><td width=50% bgcolor=\"#F3F3F3\" class=\"IndiaResults12\"><p style=\"margin-left: 5\"><font face=Arial size=2><b> ";
        static string intext = "<td width=25%  align=center><font face='verdana' size='2'>";
        static StreamReader sr;
        static string[] subj = new string[8];
        static int noStu = 61;
        Student[] stu = new Student[noStu];
        public static void Main()
        {
            while (true)
            {
                Console.Write("\n1.All student marks\n2.Individual marks\n3.Exit\n5.Enter your choice : ");
                int choice = Console.ReadLine()[0] - '0';
                India ind = new India();
                switch (choice)
                {
                    case 1:
                        ind.AllStudents();
                        break;
                    case 2:
                        Console.Write("\nEnter the roll number (ex: 04131a1256): ");
                        ind.IndividualStudent(Console.ReadLine().ToLower());
                        break;
                    case 3:
                        goto end;
                    default:
                        Console.WriteLine("\nEntered option is Wrong ...Be Cool Boss...!");
                        break;
                }
            }
        end:;
        }
        private void IndividualStudent(string rollno)
        {
            try
            {
                //Extract 56 from 04131a1256
                int i = int.Parse(rollno[8] + "" + rollno[9]);

                Console.WriteLine("Retriveing the details of " + rollno);
                sr = GetStream("http://www.indiaresults.com/Andhra_Pradesh/jntubt/RollResult.aspx?id=910078&Rollno=" + rollno);
                stream = sr.ReadToEnd();

                stu[i - 1] = new Student();
                Extract(stu[i - 1], stream);

                DisplayDetails(i - 1);

                Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("\nInvalid roll number Boss........!!");
                Console.WriteLine(e.StackTrace);
            }
        }
        string stream = null;
        private void AllStudents()
        {
            for (int i = 0; i < noStu; i++)
            {
                Console.WriteLine("Retriveing the details of 04131a" + (1200 + i + 1));
                sr = GetStream("http://www.indiaresults.com/Andhra_Pradesh/jntubt/RollResult.aspx?id=910078&Rollno=04131a" + (1200 + i + 1));
                stream = sr.ReadToEnd();

                stu[i] = new Student();
                Extract(stu[i], stream);
                DisplayDetails(i);
                Close();
            }
        }
        private void DisplayDetails(int i)
        {
            //Print retrived Details
            if (stu[i].exists)
            {
                Console.WriteLine("{0,-25} {1,-15}", stu[i].name, stu[i].roll);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("{0,-45} {1,-9} {2,-9} {3,-6} {4,-6}",
                                   "Subject", "Internal", "External", "Total", "Result");
                Console.WriteLine("-------------------------------------------------------------------------------");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-45} {1,-9} {2,-9} {3,-6} "
                           , subj[j], stu[i].inter[j], stu[i].exter[j], stu[i].toteach[j]);
                    Console.WriteLine("{0,-6}", (stu[i].toteach[j] >= 40) ? "PASS" : "FAIL");
                }
                Console.WriteLine("                                                                 ==== =========");
                Console.WriteLine("                                                                 {0}  {1:.00}%", stu[i].total, stu[i].total * (100 / (float)750));
            }
            else Console.WriteLine("Roll no 04131a" + (1200 + i + 1) + " is not present");
        }
        private void Extract(Student stu, string s)
        {
            int t;
            if (s.Contains("Roll No Not Exist")) { stu.exists = false; return; }
            //roll number extraction
            int pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            stu.roll = s.Substring(0, 10);

            //name extraction
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            stu.name = s.Substring(0, s.IndexOf('<'));

            for (int i = 0; i < 8; i++)
            {
                //subject name extraction
                pos = s.IndexOf(subName) + subName.Length;
                s = s.Substring(pos);
                subj[i] = s.Substring(0, s.IndexOf('&'));

                //internal marks
                pos = s.IndexOf(intext) + intext.Length;
                s = s.Substring(pos);
                stu.inter[i] = s.Substring(0, s.IndexOf('<'));

                //external marks
                pos = s.IndexOf(intext) + intext.Length;
                s = s.Substring(pos);
                stu.exter[i] = s.Substring(0, s.IndexOf('<'));

                //bypass total marks present in HTML code
                pos = s.IndexOf(intext) + intext.Length;
                s = s.Substring(pos);

                //total calculation
				int.TryParse(stu.inter[i], out t);
                stu.toteach[i] = t;
				int.TryParse(stu.exter[i], out t);
				stu.toteach[i] += t;

                //calculate total in all subject i.e.,, for 750
                stu.total += stu.toteach[i];
            }
        }
        private void Close()
        {
            res.Close();
        }
        HttpWebResponse res;
        public StreamReader GetStream(String url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                res = (HttpWebResponse)req.GetResponse();
            }
            catch
            {
                Console.WriteLine("ERROR : Check your internet connection or the URL...!!");
            }
            return new StreamReader(res.GetResponseStream());
        }
    }
}
