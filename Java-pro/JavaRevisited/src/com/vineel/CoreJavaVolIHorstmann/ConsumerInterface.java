package com.vineel.CoreJavaVolIHorstmann;

import java.util.function.IntConsumer;

/**
 * Created by vineel on 27/2/16.
 */


public class ConsumerInterface {

    public static void printElements(int args[], IntConsumer consumer) {
        for (int i = 0; i < args.length; i++) {
            consumer.accept(args[i]);
        }
    }

    public static void main(String[] args) {
        int arr[] = {1, 2, 3, 4, 5};
        printElements(arr, System.out::print);
    }
}
