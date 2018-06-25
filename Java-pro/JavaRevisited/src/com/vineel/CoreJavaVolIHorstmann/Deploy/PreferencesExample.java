package com.vineel.CoreJavaVolIHorstmann.Deploy;

import java.util.*;
import java.util.prefs.*;

/**
 * Created by vineel on 6/3/16.
 */
public class PreferencesExample {
    public static void main(String[] args) {
        // Preferences is different from Property files.
        // the actual values will be saved in a central repo
        // like Windows Registry in case of Windows
        //      ~/.java/.userPref in case of Linux
        // More over the data can be organized in the form
        // of hierarchical structure like windows registry
        // Node in Preference API can be thought of as
        // Registry folder under which key/value pairs exist

        // This is like getting HKCU in windows registry
        Preferences preferences = Preferences.userRoot();
        preferences.put("name", "Vineel");
        preferences.put("age", "29");
        try {
            System.out.println(Arrays.toString(preferences.keys()));
        } catch (BackingStoreException e) {
            e.printStackTrace();
        }
        System.out.println(preferences.absolutePath());

        // This is like getting HKLM in windows registry
        preferences = Preferences.systemRoot();
        System.out.println(preferences.absolutePath());
    }
}
