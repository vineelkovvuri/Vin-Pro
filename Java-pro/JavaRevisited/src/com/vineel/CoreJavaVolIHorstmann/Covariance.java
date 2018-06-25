package com.vineel.CoreJavaVolIHorstmann;

/**
 * Created by Vineel on 2/25/2016.
 */

class Employee {
    public Employee getBuddy(){
        return this;
    }
}

class Manager extends Employee
{
    // This method is getting overridden with subtype as return type.
    // We say that two getBuddy methods have covariant return types.
    public Manager getBuddy(){
        return this;
    }
}
public class Covariance {

}
