package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by vineel on 28/2/16.
 */

public class InnerClassExample {
    public static void main(String[] args) {
        InnerClassExample ice = new InnerClassExample();
        ice.print = true;
    }

    boolean print = false;
    class InnerClass {
        public void print()
        {
            // We are able to access the outer class's fields because the compiler will
            // synthesize a constructor with InnerClassExample as argument and stores
            // that reference in a local final variable.
            //    vineel@Z97X:~/vin-pro/java-pro/JavaRevisited/out/production/JavaRevisited$ javap -c InnerClassExample\$InnerClass.class
            //    Compiled from "InnerClassExample.java"
            //    class InnerClassExample$InnerClass {
            //        final InnerClassExample this$0;
            //
            //        InnerClassExample$InnerClass(InnerClassExample);
            //        Code:
            //        0: aload_0
            //        1: aload_1
            //        2: putfield      #1                  // Field this$0:LInnerClassExample;
            //        5: aload_0
            //        6: invokespecial #2                  // Method java/lang/Object."<init>":()V
            //                9: return
            //
            //        public void print();
            //        Code:
            //        0: aload_0
            //        1: getfield      #1                  // Field this$0:LInnerClassExample;
            //        4: getfield      #3                  // Field InnerClassExample.print:Z
            //        7: ifeq          18
            //        10: getstatic     #4                  // Field java/lang/System.out:Ljava/io/PrintStream;
            //        13: ldc           #5                  // String Inner Class
            //        15: invokevirtual #6                  // Method java/io/PrintStream.println:(Ljava/lang/String;)V
            //        18: return
            //    }

            if (print)
                System.out.println("Inner Class");
        }
    }
}
