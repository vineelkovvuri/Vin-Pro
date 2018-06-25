package com.vineel.CoreJavaVolIHorstmann.Collections;

import java.util.*;

/**
 * Created by vineel on 5/3/16.
 */
public class TreeSetExample {
    public static void main(String[] args) {
        TreeSet<String> set = new TreeSet<>();
        // The objects getting added to TreeSet should
        // implement Comparable interface. If not add
        // will through an exception
        set.add("Vineel");
        set.add("Nischala");
        set.add("Rithya");
        System.out.println(set);

        // will through an exception
        TreeSet<BookComparable> bookComparableSet = new TreeSet<>();
        bookComparableSet.add(new BookComparable(300));
        bookComparableSet.add(new BookComparable(100));
        bookComparableSet.add(new BookComparable(200));

        // will through an exception
//        TreeSet<Book> bookSet = new TreeSet<>();
//        bookSet.add(new Book(300));
//        bookSet.add(new Book(100));
//        bookSet.add(new Book(200));

        // The above exception can be fixed by providing a Comparator
        TreeSet<Book> bookSet = new TreeSet<>((b1, b2) -> b1.cost - b2.cost);
        bookSet.add(new Book(300));
        bookSet.add(new Book(100));
        bookSet.add(new Book(200));


        // TreeSet implements NavigableSet which means
        // it provides range based queries like below
        // Below returns a book whose cost is just less
        // than that of 150
        Book floorBook = bookSet.floor(new Book(150));
        System.out.println(floorBook.cost);
        // Below returns a book whose cost is just greater
        // than that of 150
        Book ceilBook = bookSet.ceiling(new Book(150));
        System.out.println(ceilBook.cost);
        //TreeSet has many more methods implemented from NavigableSet
    }
}

class Book {
    int cost;

    public Book(int cost) {
        this.cost = cost;
    }
}

class BookComparable implements Comparable<BookComparable> {
    int cost;

    public BookComparable(int cost) {
        this.cost = cost;
    }

    @Override
    public int compareTo(BookComparable o) {
        return this.cost - o.cost;
    }
}
