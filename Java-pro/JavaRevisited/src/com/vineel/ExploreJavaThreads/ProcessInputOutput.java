package com.vineel.ExploreJavaThreads;

import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

/**
 * Created by vineelkumarr on 17/12/2014.
 */

public class ProcessInputOutput {

    public static void main(String[] args) throws Exception {
        Process p = Runtime.getRuntime().exec("C:\\Vin\\Vin-pro\\Java-pro\\2014\\a.exe");
        char cbuf[] = new char[1024];
        OutputStreamWriter osw = new OutputStreamWriter(p.getOutputStream());
        InputStreamReader isr = new InputStreamReader(p.getInputStream());
        //Send Vineel to a.exe
        osw.write("Vineel\n"); //\n is needed to make the input to program happen. its like hitting enter at the scanf input
        osw.flush();
        //Read output from a.exe
        isr.read(cbuf);   // This call is a blocking call, So the order of osw.write and isr.read are important
        System.out.println(cbuf);
        p.waitFor();  //Wait for the process p to be terminated.
    }
}
/*
    //a.exe
    #include<stdio.h>
    int main()
    {
        char x[1024];
        scanf("%s",&x);
        printf("Hello, Mr. %s\n",x);
        return 0;
    }
*/


