package com.vineel.ExploreJavaThreads;

//8.ProducerConsumerWithObjectWaitNotify
/**
 * Created by vineelkumarr on 19/12/2014.
 */
public class ProducerConsumerWithObjectWaitNotify {
    static Thread producer, consumer;
    static int queueCount = 0; //Do not use Integer because queueCount++ will create a new object and hence cannot use it as lock object
    static Object lock = new Object();

    public static void main(String[] args) {
        producer = new Thread(() -> {
            synchronized (lock) {
                for (int i = 0; i < 10; i++)
                    queueCount++;
                System.out.println("Producer: Produced " + queueCount);
                lock.notify();
            }
        }, "Producer");
        consumer = new Thread(() -> {
            synchronized (lock) {
                try {
                    System.out.println("Consumer: Waiting for producer to produce");
                    // Javadoc says 'wait' will release the lock and wait until the
                    // notify on that lock is called by another thread and the other
                    // thread released the lock by finishing its synchronized block
                    // both the above two operations should be done by the other thread
                    // only then wait will resume and reacquires the lock.
                    lock.wait();
                    System.out.println("Consumer: Consuming " + queueCount);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                for (int i = 0; i < 10; i++)
                    queueCount--;
                System.out.println("Consumer: Consumed ");
            }
        }, "Consumer");

        consumer.start();
        producer.start();

        try {
            consumer.join();
            producer.join();

            System.out.println("No of elements in queue " + queueCount);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
