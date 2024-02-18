package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by vineel on 28/2/16.
 */
public class LocalInnerClassExample {
    public static void main(String[] args) {
        new LocalInnerClassExample().inc(10);

    }
    public int inc(final int x){
        class Adder {
            public int add(int inc){
                // We are referencing a local variable
                // which before Java 8 need to be marked as final
                // So in the local variable declaration we mark it as final int x
                // in Java 8 the restriction is bit relaxed by making the local variable
                // to be effectively final so now, we don't need the final keyword in front of int x
                return x + inc;
            }
        }
        return new Adder().add(1);
    }
}
