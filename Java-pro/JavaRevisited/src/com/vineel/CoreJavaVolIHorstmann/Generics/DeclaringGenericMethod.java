package com.vineel.CoreJavaVolIHorstmann.Generics;

/**
 * Created by vineel on 29/2/16.
 */
public class DeclaringGenericMethod {
    public static void main(String[] args) {
        // implicit type deduction
        int strcount = count(new String[]{"asfasf", "asdfasdf", "asfasfd"});
        System.out.println(strcount);
        // explicit about the type
        int strcount2 = DeclaringGenericMethod.<String>count(new String[]{"asfasf", "asdfasdf", "asfasfd"});
        System.out.println(strcount2);

    }

    public static <T> int count(T args[]) {
        return args.length;
    }

}
