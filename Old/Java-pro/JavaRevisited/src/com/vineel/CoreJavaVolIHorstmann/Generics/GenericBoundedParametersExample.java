package com.vineel.CoreJavaVolIHorstmann.Generics;

/**
 * Created by vineel on 1/3/16.
 */
public class GenericBoundedParametersExample {
    public static void main(String[] args) {
        System.out.println(min(1,2,3,4,5));
        System.out.println(min(11.1,2.1,13.1,4.4,5.4));
        System.out.println(min("vineel", "nischala", "rithya", "suneeta", "vinnu"));
    }

    // By restricting the type for T we can make the generic method more useful.
    // here we are restricting it to be any type which implements Comparable
    // and more specifically Comparable<T> just to make sure arg.compareTo(T)
    // expect a T as well instead of object otherwise.
    public static <T extends Comparable<T>> T min(T... args){
        T min = args[0];
        for (T arg : args)
            if (arg.compareTo(min) < 0)
                min = arg;
        return min;
    }
}
