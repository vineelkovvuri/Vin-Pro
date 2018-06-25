package com.vineel.CoreJavaVolIHorstmann.Collections;

import java.util.*;

/**
 * Created by vineel on 5/3/16.
 */
public class ViewsAndWrappersExample {
    public static void main(String[] args) {
        String x[] = {"1","2","3","4","5","6","7","8","9"};

        // Arrays.asList is just a view modifying via
        // the view will modify the underlying array.
        List<String> list = Arrays.asList(x);
        // This modifies the actuall array element
        list.set(2, "33");
        System.out.println(Arrays.toString(x));

        // Creates unmodifiable view of same element 10 times
        List<String> lStrings = Collections.nCopies(10, "asdfasdf");
        // Set operation is not supported..
        //lStrings.set(5, "vineel");
        System.out.println(lStrings);

        String name = "Vineel";
        for (String c : Collections.singleton(name))
            System.out.println(c);
    }
}
