package com.vineel.CoreJavaVolIHorstmann;

import java.util.Arrays;

/**
 * Created by Vineel on 2/26/2016.
 */
public class ArraysClone {
    public static void main(String[] args) {
        int []a = {1,2,3,4,5};
        //Clone method on Array clones the complete array with all elements
        int []b = a.clone();
        // this only modifies b's elements and a's array is untouched
        b[1] = 20;
        System.out.println(Arrays.toString(a));
        System.out.println(Arrays.toString(b));
    }
}
