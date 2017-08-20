/*
 * This program extracts the marks of IT(4-2 GVPCOE) from Jtnu.ac.in  
 *
 *	 							 	 By
 *                          K.Vineel Kumar Reddy. B.Tech IV/IV IT
 *                          Gayatri Vidya Parishad College of Engg.
 *                          Vishakapatnam,Andhra Pradesh.
 *	                                  INDIA. 
 */

using System;
using System.Net;
using System.IO;
using System.Diagnostics;
class Student
{
    public string name;
    public string fathName;
    public string roll;
    public string[] inter = new string[3];
    public string[] exter = new string[3];
    public string[] passcode = new string[3];
    public int[] toteach = new int[3];
    public int total = 0;
    public bool exists = true;

}
class India
{
    static string name = "/td><td>";
    //static string stuName = "Name :";
    //static string rollNum = "HTNO :";
    //static string fathName = "Father Name :";
    static StreamReader sr;
    static string[] subj = new string[8];
    static int noStu = 61;
    Student[] stu = new Student[noStu];
    static bool allDataFetched = false;

    public static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Title = "Born 2 Code";
        Console.Clear();
        Console.BufferWidth = 200;
        Console.BufferHeight += 200;
        Console.WindowWidth = 100;
        Console.WindowHeight = 50;
        India ind = new India();
        Console.WriteLine("This program retrieves the marks of IV/IV 2nd Sem IT students of Gayatri College Of Engg.........\n");

        while (true)
        {
            Console.Write("\n1.All student marks\n2.Individual marks\n3.Plot the Graph \n4.Summary\n5.Write all student marks to a file\n6.Exit\nEnter your choice : ");
            int choice = Console.ReadLine()[0] - '0';

            switch (choice)
            {
                case 1:
                    ind.AllStudents();
                    allDataFetched = true;
                    break;
                case 2:
                    Console.Write("\nEnter the roll number (ex: 04131a1256): ");
                    ind.IndividualStudent(Console.ReadLine().ToLower());
                    break;
                case 3:
                    if (!allDataFetched)
                        Console.WriteLine("\nAll Students data hasn't fetched yet...Please select 1st option and then try 3rd option");
                    else
                        ind.Graph();
                    break;
                case 4:
                    if (!allDataFetched)
                        Console.WriteLine("\nAll Students data hasn't fetched yet...Please select 1st option and then try 3rd option");
                    else
                        ind.Summary();
                    break;
                case 5:
                    StreamWriter sw = new StreamWriter("Class Marks 4-2.txt");
                    Console.SetOut(sw);
                    ind.AllStudents();
                    Console.WriteLine("\n\nProgram Written by - K.Vineel Kumar Reddy. In C# \n");
                    sw.Close();
                    Environment.Exit(0);
                    break;
                case 6:
                    goto end;
                default:
                    Console.WriteLine("\nEntered option is Wrong ...Be Cool Bose...!");
                    break;
            }
        }
    end:
        Console.WriteLine("\n\nProgram Written by - K.Vineel Kumar Reddy. In C# \n");
        Console.Read();

    }

    private void Summary()
    {
        int max = 0;
        for (int i = 1; i < noStu; i++)
            if (stu[max].total <= stu[i].total)
                max = i;
        Console.WriteLine("\n\nHighest Marks Scored By \n");
        DisplayDetails(max);
    }

    private void IndividualStudent(string rollno)
    {
        try
        {
            //Extract 56 from 04131a1256
            int i = int.Parse(rollno[8] + "" + rollno[9]);

            Console.WriteLine("Retrieving the details of " + rollno);
        http://jntu.ac.in/results/results.php?htno=04131a1256&ecode=42r04191
            sr = GetStream("http://jntu.ac.in/results/results.php?htno=" + rollno + "&ecode=42r04191");
            stream = sr.ReadToEnd();

            stu[i - 1] = new Student();

            Extract(stu[i - 1], stream);

            DisplayDetails(i - 1);

            Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nInvalid roll number Bose........!!");
            Console.WriteLine(e.StackTrace);
        }
    }
    string stream = null;
    private void AllStudents()
    {
        for (int i = 0; i < noStu; i++)
        {
            Console.WriteLine("Retrieving the marks of 04131a" + (1200 + i + 1));
            sr = GetStream("http://jntu.ac.in/results/results.php?htno=04131a" + (1200 + i + 1) + "&ecode=42r04191");
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
            Console.WriteLine("{0,-25} \n{1,-15} \n{2,-20}", stu[i].name, stu[i].roll, stu[i].fathName);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("{0,-45} {1,-9} {2,-9} {3,-6} {4,-6}",
                    "Subject", "Internal", "External", "Total", "Result");
            Console.WriteLine("-------------------------------------------------------------------------------");
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("{0,-45} {1,-9} {2,-9} {3,-6} {4,-3}"
                        , subj[j], stu[i].inter[j], stu[i].exter[j], stu[i].toteach[j], stu[i].passcode[j]);
            }
            Console.WriteLine("                                                                 ==== =========");
            Console.WriteLine("                                                                 {0}  {1:.00}%", stu[i].total, stu[i].total * (100 / (float)400));
        }
        else
            Console.WriteLine("Roll no 04131a" + (1200 + i + 1) + " is not present\n");
    }
    private void Extract(Student stu, string s)
    {
        int t;
        //for a detained or absent candidate we wont find any subject...... thats is the only clue we have ...... ;)
        if (!s.Contains("PROJECT WORK")) { stu.exists = false; return; }  

        int pos;

        //Extract Student Roll Number
        pos = s.IndexOf("<b>") + "<b>".Length;
        s = s.Substring(pos);
        stu.roll = s.Substring(0, s.IndexOf('<')).Trim();

        //Extract Student Name
        pos = s.IndexOf("<b>") + "<b>".Length;
        s = s.Substring(pos);
        stu.name = s.Substring(0, s.IndexOf('<')).Trim();

        //Extract Father Name
        pos = s.IndexOf("<b>") + "<b>".Length;
        s = s.Substring(pos);
        stu.fathName = s.Substring(0, s.IndexOf('<')).Trim();

        for (int i = 0; i < 3; i++)
        {

            //Move to subject code.........(that is until v get the string.."Result")
            pos = s.IndexOf("Result") + name.Length;
            s = s.Substring(pos);

            //subject name extraction
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            subj[i] = s.Substring(0, s.IndexOf('<')).Trim();

            //internal marks
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            stu.inter[i] = s.Substring(0, s.IndexOf('<')).Trim();

            //external marks
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            stu.exter[i] = s.Substring(0, s.IndexOf('<')).Trim();

            //bypass total marks  in HTML code
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);

            //bypass Pass Fail code present in HTML code
            pos = s.IndexOf(name) + name.Length;
            s = s.Substring(pos);
            stu.passcode[i] = s.Substring(0, s.IndexOf('<')).Trim();

            //total calculation
            int.TryParse(stu.inter[i], out t);
            stu.toteach[i] = t;
            int.TryParse(stu.exter[i], out t);
            stu.toteach[i] += t;

            //calculate total in all subject i.e.,, for 750
            stu.total += stu.toteach[i];
        }
    }

    private void Graph()
    {
        int max, min, temp;
        min = max = (stu[0].total * 100) / 750;

        for (int i = 1; i < noStu; i++)
        {
            temp = (stu[i].total * 100) / 750;
            if (max < temp)
                max = temp;
            if (min > temp)
                min = temp;
        }
        while (max >= min)
        {

            if (max < 80 && max >= 70)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (max < 70 && max >= 60)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (max < 60 && max >= 50)
                Console.ForegroundColor = ConsoleColor.Gray;
            else if (max < 50 && max >= 40)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0,-2}%|", max);

            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < noStu; i++)
                if ((stu[i].total * 100) / 750 >= max)
                    Console.Write("*  ");
                else
                    Console.Write("   ");
            Console.WriteLine();
            max--;
        }
        Console.WriteLine("---|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->");
        Console.Write("   |");
        for (int i = 0; i < noStu; i++)
        {
            temp = (stu[i].total * 100) / 750;
            if (temp < 80 && temp >= 70)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (temp < 70 && temp >= 60)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (temp < 60 && temp >= 50)
                Console.ForegroundColor = ConsoleColor.Gray;
            else if (temp < 50 && temp >= 40)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0,-3}", i + 1);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Green    => [70% , 80% )");
        Console.WriteLine("Blue     => [60% , 70% )");
        Console.WriteLine("Grey     => [50% , 60% )");
        Console.WriteLine("Red      => [40% , 50% )");
        Console.WriteLine("Dark Red => (  < 40%   )");

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


