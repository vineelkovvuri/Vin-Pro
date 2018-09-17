package com.vineel.CoreJavaVolIHorstmann;

import java.util.*;

/**
 * Created by vineelko on 28-02-2016.
 */
public class DoubleBraceInitializationExample {
    public static void print(ArrayList<String> list){
        list.forEach(System.out::println);
    }
    public static void main(String[] args) {
        // Here the first brace is creating an anonymous sub class of
        // ArrayList and second brace is the object initialization block
        // add(...); is like calling the add of super class ArrayList
        print(new ArrayList<String>(){{add("Vineel"); add("Nischala");}});
    }
}
