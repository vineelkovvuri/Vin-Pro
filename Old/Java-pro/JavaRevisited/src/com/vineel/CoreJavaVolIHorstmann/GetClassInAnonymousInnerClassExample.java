package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by vineelko on 28-02-2016.
 */


public class GetClassInAnonymousInnerClassExample {
    public static void main(String[] args) {
        new Object(){
            public void printGetClass()
            {
                System.out.println(getClass());
            }
        }.printGetClass();

        // we can also use object initializer block
        // to directly invoke the System.out.println
        // during object construction
        new Object(){
            {
                System.out.println(getClass());
            }
        };
    }
}
