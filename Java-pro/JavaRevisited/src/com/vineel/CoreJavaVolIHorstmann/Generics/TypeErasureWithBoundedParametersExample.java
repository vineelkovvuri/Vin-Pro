package com.vineel.CoreJavaVolIHorstmann.Generics;

/**
 * Created by vineel on 1/3/16.
 */
public class TypeErasureWithBoundedParametersExample {
    public static void main(String[] args) {
        length(1, 2, 3, 4, 5);
        min(5, 4, 3, 2, 1);
    }

    // In the below method since T is unbounded the compiler
    // replaces type T with object after compilation
    public static <T> int length(T... args) {
        return args.length;
    }

    // In the below method since T is bounded the compiler
    // replaces type T with Comparable, Because that is how
    // the compiler guarantees the existence of compareTo
    // method in Type T
    public static <T extends Comparable<T>> T min(T... args) {
        T min = args[0];
        for (T arg : args)
            if (arg.compareTo(min) < 0)
                min = arg;
        return min;
    }
}
/*
public class com.vineel.CoreJavaVolIHorstmann.Generics.TypeErasureWithBoundedParametersExample {
  public com.vineel.CoreJavaVolIHorstmann.Generics.TypeErasureWithBoundedParametersExample();

  public static <T> int length(T...);
    Code:
       0: aload_0
       1: arraylength
       2: ireturn

  public static <T extends java.lang.Comparable<T>> T min(T...);
    Code:
        .....
      26: aload_1
      27: invokeinterface #6,  2            // InterfaceMethod java/lang/Comparable.compareTo:(Ljava/lang/Object;)I
      32: ifge          38
      35: aload         5
      37: astore_1
      38: iinc          4, 1
      41: goto          12
      44: aload_1
      45: areturn
}
 */