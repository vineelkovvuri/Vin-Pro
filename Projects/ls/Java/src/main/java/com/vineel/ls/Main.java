/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls;

import joptsimple.OptionException;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
public class Main {
    public static void main(String... args) {

        final CommandLineParser parser = new CommandLineParser();
        OptionSet arguments = null;
        parser.buildOptions();
        try {
            arguments = parser.parseOptions(args);
        }
        catch (OptionException oe) {
            System.out.println(oe.getMessage());
            System.out.println(oe.options());
            return;
        }
        if (arguments.has("help")) {
            parser.printHelp();
            return;
        }
        else if (arguments.has("version")) {
            parser.printVersion();
            return;
        }

        Driver driver = new Driver();
        driver.drive(arguments);
    }
}
