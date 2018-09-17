package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by vineelko on 26-02-2016.
 */
interface IAccount{
    int x = 10;
    //As of Java 8 we can declare static methods in interfaces
    //This was not allowed before and led to the creation of utility classes like
    // Collection/Collections and Path/Paths where the later used to contain only
    // static methods for the former interfaces.
    // with Java 8 we can simply include all the static methods in the interfaces itself.
    // No need for extra utility classes
    public static int getMinimumBalance()
    {
        return 1000;
    }
}
