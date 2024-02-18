package com.vineel.CoreJavaVolIHorstmann.Generics;

import java.io.*;

/**
 * Created by vineel on 1/3/16.
 */
public class GenericsMulitpleBoundedParametersExample {
    public static void main(String[] args) {
        min(5, 4, 3, 2, 1);
        max(5, 4, 3, 2, 1);
    }

    // When there are multiple bounded parameters for T
    // The compiler will substitute T with First Interface/Class
    // Here in this case it is Comparable
    public static <T extends Comparable<T> & Serializable> T min(T... args) {
        T min = args[0];
        for (T arg : args)
            if (arg.compareTo(min) < 0)
                min = arg;
        return min;
    }
    /*
      public static <T extends java.lang.Comparable<T> & java.io.Serializable> T min(T...);
    Code:
      ....
      24: aload         5
      26: aload_1
      27: invokeinterface #5,  2            // InterfaceMethod java/lang/Comparable.compareTo:(Ljava/lang/Object;)I
      32: ifge          38
      ....
      44: aload_1
      45: areturn

     */

    // When there are multiple bounded parameters for T
    // The compiler will substitute T with First Interface/Class
    // Here in this case it is Serializable but to make the compareTo
    // work, the compiler also insert a type cast from Serializable to
    // Comparable. Check the Java byte code with javap -c
    // So it is recommended to put marker interfaces to the end of declaration
    public static <T extends Serializable & Comparable<T>> T max(T... args) {
        T max = args[0];
        for (T arg : args)
            if (arg.compareTo(max) > 0)
                max = arg;
        return max;
    }
    /*
      public static <T extends java.io.Serializable & java.lang.Comparable<T>> T max(T...);
    Code:
      ....
      24: aload         5
      26: checkcast     #6                  // class java/lang/Comparable
      29: aload_1
      30: invokeinterface #5,  2            // InterfaceMethod java/lang/Comparable.compareTo:(Ljava/lang/Object;)I
      35: ifle          41
      ....
      47: aload_1
      48: areturn

     */
}
