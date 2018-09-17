package com.vineel.ExploreJavaThreads;

//6.MultipleThreadsWithAtomicSingleData
import java.util.concurrent.atomic.AtomicInteger;

/**
 * Created by vineelkumarr on 17/12/2014.
 * <p>
 * The problem is to increment the a global sum variable by 10 threads.
 * And be able to get the final result of 10 in main.
 * The key to use AtomicInteger without any locks and synchronization
 */
public class MultipleThreadsWithAtomicSingleData {
    static AtomicInteger sum = new AtomicInteger(0);
    static Thread threads[] = new Thread[10];

    public static void main(String... args) {
        Runnable runnable = () -> {
            sum.incrementAndGet();
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
