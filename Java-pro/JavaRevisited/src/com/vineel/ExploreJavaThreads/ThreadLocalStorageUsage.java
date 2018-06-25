package com.vineel.ExploreJavaThreads;
//9.ThreadLocalStorageUsage
/**
 * Created by vineelkumarr on 17/12/2014.
 *
 * The beauty of TLS is, when ever tls variable's set/get methods are used in a thread,
 * The value that is stored/retrieved is local to that thread.
 *
 * Suppose if we set 'ABC1' as the value in thread 1 of tls variable.
 * That ABC1 will be associated with thread 1.
 * So always the get method will return 'ABC1' in thread 1 no matter
 * the tls variable is set to some other value in some other thread
 *
 */
public class ThreadLocalStorageUsage {
    static Thread threads[] = new Thread[2];
    // tlsThreadName is a global object but the value set/get by set/get methods
    // is always local to each thread.
    static ThreadLocal<String> tlsThreadName = new ThreadLocal<>();
    public static void main(String ...args) {
        Runnable runnable = () -> {
            System.out.println(Thread.currentThread().getName() + ": started");
            //Here we are just storing the thread's name - it can be anything specific to thread
            tlsThreadName.set(Thread.currentThread().getName());
            System.out.println(Thread.currentThread().getName() + ": setting thread name to TLS done");
            try {
                Thread.sleep(500);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println(Thread.currentThread().getName() + ": its TLS thread name : " + tlsThreadName.get());
            System.out.println(Thread.currentThread().getName() + ": done");
        };
        threads[0] = new Thread(runnable, "Thread0");
        threads[1] = new Thread(runnable, "Thread1");

        threads[0].start();
        threads[1].start();
        try {
            threads[0].join();
            threads[1].join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("Main: Done");
    }
}
