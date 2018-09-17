package com.vineel.ExploreJavaThreads;
//1.BasicSynchronization

public class BasicSynchronization {
    static int val = 0;
    /* Same lock is shared among multiple threads */
    static final Object lock = new Object();

    public static void main(String[] args) {
        Thread t1 = new Thread(() -> {
            while (val < 10) {
                synchronized (lock) {
                    System.out.println(Thread.currentThread().getName() + " Before : " + val);
                    val++;
                    try {
                        Thread.sleep(500);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    System.out.println(Thread.currentThread().getName() + " After : " + val);
                }
            }
        }, "T1");
        Thread t2 = new Thread(() -> {
            while (val < 10) {
                synchronized (lock) {
                    System.out.println(Thread.currentThread().getName() + " Before : " + val);
                    val++;
                    try {
                        Thread.sleep(500);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    System.out.println(Thread.currentThread().getName() + " After : " + val);
                }
            }
        }, "T2");

        t1.start();
        t2.start();
    }
}
