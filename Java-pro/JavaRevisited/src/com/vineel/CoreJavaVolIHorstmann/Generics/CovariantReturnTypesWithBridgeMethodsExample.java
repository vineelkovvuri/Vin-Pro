package com.vineel.CoreJavaVolIHorstmann.Generics;

/**
 * Created by vineel on 3/3/16.
 */
public class CovariantReturnTypesWithBridgeMethodsExample implements Cloneable{
    public static void main(String[] args) {

    }

    // This overrides the super class Object.clone() method.
    // This is special because the override a method can have
    // more restrictive return type this is called covariant
    // return type.
    // In order to achieve this the compiler actually populates
    // a normal override method which has the same signature as
    // that of the super class.
    // So to resovle a polymorphic call with base class reference
    // the call will be dispatch to Object clone() method of subclass
    // now this synthesized method will in turn calls the
    // below method.
    //
    // That means this class will contain two clone methods
    // one returning Object and one returning CovariantReturnTypesWithBridgeMethodsExample
    // How is this even possible according to the rules of overloading
    // in a class? Yes, This is possible because the patch up is
    // done by the compiler at the .class level
    public CovariantReturnTypesWithBridgeMethodsExample clone()
    {
        return null;
    }
}

