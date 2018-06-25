package com.vineel.ExploreJavaThreads;
//2.ThreadJoin
/**
 * Created by vineelkumarr on 17/12/2014.
 *
 * Join method blocks the main thread in which the method is called, Until the join's thread is terminated.
 * if  n threads are already started in main and they are running then calling join on each one of them as
 * shown below will block the main thread on each join call.
 *
 * Example:
 *  Thread t[] = ...
 *  all t threads are in running state.
 *
 *  for (int i = 0; i < t.length; i++)
 *      t[i].join(); // main thread gets blocked until t[0] is terminated,
 *                   // Again, main thread gets blocked until t[1] is terminated,
 *                   // Again, main thread gets blocked until t[2] is terminated,
 *                   // So on
 *
 *
 */
public class ThreadJoin {
    static Thread mainThread;
    public static void main(String ...args) {
        mainThread = Thread.currentThread();
        Thread t1 = new Thread(() -> {
            try {
                int var = 0;
                while (var++ < 25) {
                    Thread.sleep(100);
                    System.out.print(Thread.currentThread().getName() + " " + Thread.currentThread().getState());
                    System.out.println("  " + mainThread.getName() + " " + mainThread.getState());
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }, "t1");
        Thread t2 = new Thread(() -> {
            try {
                int var = 0;
                while (var++ < 25) {
                    Thread.sleep(100);
                    System.out.print(Thread.currentThread().getName() + " " + Thread.currentThread().getState());
                    System.out.println("  " + mainThread.getName() + " " + mainThread.getState());
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }, "t2");

        try {
            System.out.println("Before join ");
            t1.start();
            t1.join(); // Here main thread gets blocked until t1 is terminated
            System.out.println("t1 threads done " + t1.getState());
            t2.start();
            t2.join(); // Here main thread gets blocked until t2 is terminated
            System.out.println("t2 threads done " + t2.getState());
            System.out.println("End");
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
