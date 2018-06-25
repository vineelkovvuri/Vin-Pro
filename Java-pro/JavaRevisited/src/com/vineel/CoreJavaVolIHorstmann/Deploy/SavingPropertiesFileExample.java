package com.vineel.CoreJavaVolIHorstmann.Deploy;

import java.io.*;
import java.util.*;

/**
 * Created by vineel on 6/3/16.
 */
public class SavingPropertiesFileExample {
    public static void main(String[] args) {
        Properties settings = new Properties();
        settings.setProperty("name", "Vineel");
        settings.setProperty("age", "29");
        try {
            settings.store(System.out, "asdfa");
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
