package com.vineel.CoreJavaVolIHorstmann;

import java.util.Arrays;

/**
 * Created by Vineel on 2/25/2016.
 */
public class ArraystoStringdeepToString {
    public static void main(String[] args) {
        // use toString to print single dimensional arrays
        int []num = {1,2,3,4,5,6};
        System.out.println(Arrays.toString(num));
        // use deepToString to print multidimensional arrays
        int [][]num2 = {{1,2},{3,4},{5,6}};
        System.out.println(Arrays.deepToString(num2));
    }
}

/*
[1, 2, 3, 4, 5, 6]
[[1, 2], [3, 4], [5, 6]]
 */
