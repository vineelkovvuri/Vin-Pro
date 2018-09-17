package com.vineel.ExploreJavaThreads;
//3.ThreadJoinUsage
/**
 * Created by vineelkumarr on 17/12/2014.
 *
 * The idea is to increment the individual accounts with balances of 100 at an intervals of 50msec
 * This is done via their corresponding threads.
 * Finally we should be able to print the total amounts in each individual accounts.
 * The key to be able to print the total amounts is the use of join on all the individual threads from main
 *
 */
public class ThreadJoinUsage {
    static int accountsBalances[] = new int[10];
    static Thread accountsThreads[] = new Thread[10];
    public static void main(String ...args) {
        for (int i = 0; i < accountsBalances.length; i++) {
            accountsThreads[i] = new Thread(() -> {
                try {
                    int account = Integer.parseInt(Thread.currentThread().getName()); //I couldn't find a better way to pass the thread number
                    for (int bal = 0; bal < 1000; bal += 1) {
                        accountsBalances[account]++;
                        Thread.sleep(5);
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println("Thread : " + Thread.currentThread().getName() + " done");
            }, Integer.toString(i)); //passing thread number as thread name
        }
        //start all threads
        for (int i = 0; i < accountsBalances.length; i++)
            accountsThreads[i].start();

        try {
            for (int i = 0; i < accountsBalances.length; i++)
                accountsThreads[i].join(); // Here main thread gets blocked until t2 is terminated
            for (int i = 0; i < accountsBalances.length; i++)
                System.out.println(accountsBalances[i]);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
