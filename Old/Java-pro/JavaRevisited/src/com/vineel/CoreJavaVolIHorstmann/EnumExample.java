package com.vineel.CoreJavaVolIHorstmann;

//Unlike C/C++ enums these enums are strongly typed.
//Color.Red implies just a new Object of type Color;
//It cannot be interpreted as integers.

enum Color {
    Red, Blue, Green,;
}
public class EnumExample {

    public static void main(String[] args) {
        System.out.println(Color.Green);
        //Make a reference to an enum object
        Color tempColor = Color.Green;
        //Comparison
        //Single Color.Green is a singleton
        //It can be compared via references
        if (tempColor == Color.Green) {
            System.out.println("Reference equal True");
        }
        //It can also be compared via equals
        if (tempColor.equals(Color.Green)) {
            System.out.println("Object equal True");
        }
        // toString can be used to get the string representation of the enum name
        System.out.println(Color.Green.toString());
        // One can get all the enumerations possible for a enum type using enum.values()
        for (Color c : Color.values())
            System.out.println(c.toString());

        //Also we can create a new Enum object from String name using
        Color red = Enum.valueOf(Color.class, "Red");
        System.out.println(red);
    }
}
