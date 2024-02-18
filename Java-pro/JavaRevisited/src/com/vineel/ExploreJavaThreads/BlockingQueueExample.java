package com.vineel.ExploreJavaThreads;

import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

class FileCrawler implements Runnable{

    BlockingQueue<String> queue;
    int crawler;
    public FileCrawler(BlockingQueue<String> queue, int crawler) {
        this.queue = queue;
        this.crawler = crawler;
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++)
            try {
                System.out.println("Crawler " + crawler + " put Vineel " + i);
                queue.put("Crawler " + crawler + " put Vineel " + i);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
    }
}

class Indexer implements Runnable{

    BlockingQueue<String> queue;
    int indexer;
    public Indexer(BlockingQueue<String> queue, int indexer) {
        this.queue = queue;
        this.indexer = indexer;
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++)
            try {
                System.out.println("Indexer " + indexer + " take " + queue.take());
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
    }
}

public class BlockingQueueExample {
    public static void main(String[] args) throws Exception {
        LinkedBlockingQueue<String> queue = new LinkedBlockingQueue<>();
        for (int i = 0; i < 10; i++)
            new Thread(new FileCrawler(queue, i)).start();
        for (int i = 0; i < 10; i++)
            new Thread(new Indexer(queue, i)).start();

    }
}
