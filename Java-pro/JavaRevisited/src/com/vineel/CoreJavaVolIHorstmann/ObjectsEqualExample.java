package com.vineel.CoreJavaVolIHorstmann;

import java.util.Objects;

/**
 * Created by Vineel on 2/25/2016.
 */
public class ObjectsEqualExample {
    public static void main(String[] args) {
        String name1 = "Vineel";
        String name2 = "Vineel";
        System.out.println(name1.equals(name2));
        // This will guard us from name1 or name2 being null
        System.out.println(Objects.equals(name1, name2));
    }
}
