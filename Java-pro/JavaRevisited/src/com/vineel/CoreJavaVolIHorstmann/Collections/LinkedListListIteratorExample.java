package com.vineel.CoreJavaVolIHorstmann.Collections;

import java.util.*;

/**
 * Created by vineel on 3/3/16.
 */

public class LinkedListListIteratorExample {
    public static void main(String[] args) {
        LinkedList<String> list = new LinkedList<>();
        list.add("a");
        list.add("b");
        list.add("c");
        ListIterator<String> iterator = list.listIterator();

        // The best way to understand next() and previous() methods
        // is to first understand two important concepts
        // 1. Cursor
        //    Each call to next() makes the cursor move to the next of the current element
        //    |abcd -> next() -> a|bcd -> next() -> ab|cd etc
        //    Each call to previous() makes the cursor move to the before of the current element
        //    abc|d -> previous() -> ab|cd -> previous() -> a|bcd etc
        //
        // 2. Last Returned Element(LRE)
        //    This is the element returned by next() or previous()
        //    in next() case it is the element before the cursor
        //    in previous() case it is the element after the cursor
        //
        //    next() -> LRE  ->  next() ->  LRE  -> next() ->   LRE
        //               v                   v                   v
        //               a|bc               ab|c               abc|
        //              |abc               a|bc               ab|c
        //               ^                   ^                   ^
        //              LRE <- previous()<- LRE <- previous()<- LRE <- previous()
        //
        // from the above, A call to next() followed by previous() only
        // changes the cursor position but returns the same LRE
        System.out.println(iterator.next()); //LRE = 'a' and cursor = a|
        // The below two operations effectively flips the cursor position around 'b'
        System.out.println(iterator.next()); //LRE = 'b' and cursor = ab|
        System.out.println(iterator.previous()); //LRE = 'b' and cursor = a|b

        System.out.println(iterator.next());  //LRE = 'b' and cursor = ab|
        // Remove always removes the LRE element
        iterator.remove();  // remove LRE which is 'b'
        System.out.println(list); // ['a', 'c']
    }
}