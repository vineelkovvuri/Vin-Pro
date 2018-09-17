package com.vineel.ExploreJavaThreads;

//5.MultipleThreadsWithSingleData
/**
 * Created by vineelkumarr on 17/12/2014.
 * <p>
 * The problem is to increment the a global sum variable by 10 threads.
 * And be able to get the final result of 10 in main.
 * The key to gaurd with synchronized with global lock
 * in places where global data is being read/written
 */
public class MultipleThreadsWithSingleData {
    static int sum = 0;
    static Object lock = new Object(); //To protect global data from multiple threads we need a global lock
    static Thread threads[] = new Thread[10];

    public static void main(String... args) {
        Runnable runnable = () -> {
            synchronized (lock) {
                // This is not an atomic operation simultaneous reads
                // from multiple threads may lead to incorrect results
                // Hence reading/writing the value requires a lock
                sum = sum + 1;
            }
            System.out.println("Thread : " + Thread.currentThread().getName() + " done");
        };
        for (int i = 0; i < threads.length; i++)
            threads[i] = new Thread(runnable, Integer.toString(i)); //passing thread number as thread name

        //start all threads
        for (int i = 0; i < threads.length; i++)
            threads[i].start();

        try {
            for (int i = 0; i < threads.length; i++)
                threads[i].join(); // Here main thread gets blocked until all threads are terminated

            System.out.println("Total Sum : " + sum);

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
