package com.vineel.CoreJavaVolIHorstmann.Collections;

import java.util.*;

/**
 * Created by vineel on 5/3/16.
 */
public class ArrayListExample {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<>();
        list.containsAll(list);
        TreeSet<ArrayListExample> tset = new TreeSet<>();
        tset.add(new ArrayListExample());
        tset.add(new ArrayListExample());
        tset.add(new ArrayListExample());
        System.out.println(tset);
    }
}
