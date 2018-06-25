package com.vineel.ExploreJavaThreads;

/**
 * Created by vineelkumarr on 17/12/2014.
 *
 * Assume there are two Synchronized methods, And two threads to invoke each one of
 * them from the respective threads, Because of synchronization on the same
 * class lock, only one method gets executed at a time from each other. Both the methods
 * cannot execute simultaneously
 *
 * In the below example Thread t calls sub and main thread calls add.
 * both sub and add cannot be executed simultaneously because add and sub are
 * synchronized on same class lock.
 *
 * So the output will be always sub done -> add done or add done -> sub done
 * We cannot get interleaved outputs.
 *
 * Sub:Thread-0
 * Sub Done:Thread-0
 * Add:main
 * Add Done:main
 *
 * or
 *
 * Add:main
 * Add Done:main
 * Sub:Thread-0
 * Sub Done:Thread-0
 *
 */

public class SynchronizedOnMultipleMethods {

    public static synchronized int add(int a, int b)
    {
        System.out.println("Add:" + Thread.currentThread().getName());
        try {
            Thread.sleep(300);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("Add Done:" + Thread.currentThread().getName());
        return a + b;
    }
    public static synchronized int sub(int a, int b)
    {
        System.out.println("Sub:" + Thread.currentThread().getName());
        try {
            Thread.sleep(300);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("Sub Done:" + Thread.currentThread().getName());
        return a - b;
    }
    public static void main(String[] args) throws Exception {
        Thread t = new Thread(() -> {
            sub(10, 20);
        });
        t.start();
        add(20, 10);
    }
}
