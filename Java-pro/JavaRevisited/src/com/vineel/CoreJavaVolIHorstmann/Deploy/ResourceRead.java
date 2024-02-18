package com.vineel.CoreJavaVolIHorstmann.Deploy;

import java.io.*;

/**
 * Created by vineel on 6/3/16.
 */
public class ResourceRead {
    public static void main(String[] args) {
        // Intellij automatically copy all the artifacts from the current
        // package to out/<current package>/*
        try (InputStream is = ResourceRead.class.getResourceAsStream("content.txt")) {
            System.out.println((char)is.read());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
