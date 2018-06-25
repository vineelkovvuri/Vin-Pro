package com.vineel.CoreJavaVolIHorstmann;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

/**
 * Created by vineel on 28/2/16.
 */
public class TryWithResourceUsageExample {
    public static void main(String[] args) {

        // try with resource stmt introduced in Java 7
        // you can use all classes which implement AutoClosable interface
        try (Scanner scanner = new Scanner("/home/vineel/.gitconfig")) {

        }

        // try with resource stmt introduced in Java 7 with catch block
        try (FileReader fr = new FileReader("/home/vineel/.gitconfig")) { //FileReader constructor throws checked exceptions

            // The below catch block is necessary for handling exceptions when opening FileReader itself
            // C# using does not have this type of using with catch stmt because in C#
            // we don't have checked exceptions to force us wrap the exceptions in try catch
            // if there occurs a exception in the using(...) then it is simply considered as
            // exception at runtime in C#
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

