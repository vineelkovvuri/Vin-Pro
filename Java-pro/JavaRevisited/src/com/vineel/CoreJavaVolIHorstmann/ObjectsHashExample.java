package com.vineel.CoreJavaVolIHorstmann;

import java.util.Objects;

/**
 * Created by Vineel on 2/25/2016.
 */
public class ObjectsHashExample {
    public static void main(String[] args) {
        String abc = "ABC";
        String def = "DEF";
        // Objects.hash can be used to compute hash from mulitple objects.
        // useful when implement hashcode of a user defined object from its fields
        System.out.printf("%x", Objects.hash(abc, def));
    }
}
