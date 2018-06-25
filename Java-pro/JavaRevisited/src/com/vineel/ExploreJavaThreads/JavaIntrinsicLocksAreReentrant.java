package com.vineel.ExploreJavaThreads;

/**
 * Created by vineelkumarr on 17/12/2014.
 *
 * intrinsic locks => locking doing using synchronized methods, or synchronized blocks.
 * The idea here is acquiring of intrinsic locks is per thread basis not per invocation basic
 * because of this a thread can invoke the same lock again when the lock is already held by it.
 * This is called reentrant locking
 */

public class JavaIntrinsicLocksAreReentrant {
    static Object lock = new Object();
    public static int sub(int a, int b) {
        int res = 0;
        synchronized (lock) {
            res = a - b;
            System.out.println("Subtracting");
        }
        return res;
    }
    public static int add(int a, int b) {
        int res = 0;
        synchronized (lock) {
            System.out.println("adding");
            res = sub(a, b);
        }
        return res + 2 * b;
    }
    public static void main(String[] args) throws Exception {
        System.out.println(add(1, 2));
    }
}
