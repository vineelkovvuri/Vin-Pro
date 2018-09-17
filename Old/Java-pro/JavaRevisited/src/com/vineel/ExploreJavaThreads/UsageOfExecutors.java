package com.vineel.ExploreJavaThreads;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class UsageOfExecutors {

	public static long fibbonaci(int n) {
		if (n < 0) return 0;
		if (n == 2 || n == 1) return 1;
		return fibbonaci(n - 1) + fibbonaci(n - 2); 
	}
	public static void main(String[] args) throws Exception {
		int n = Runtime.getRuntime().availableProcessors();
		/* Create n Threadpool */
		final ExecutorService exec = Executors.newFixedThreadPool(n);
		System.out.println(n);
		for (int i = 0; i < n; i++) {
			exec.execute(() -> { //Spawn this Runnable to the freely available Threads
				System.out.println("Fibb(45) = " + fibbonaci(45));
			});
		}
		exec.shutdown(); // mark the ExecutorService to shutdown gracefully
		exec.awaitTermination(10, TimeUnit.SECONDS);//wait for the unfinished tasks or for a timeout
	}
}
