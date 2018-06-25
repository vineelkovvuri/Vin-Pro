/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.sorters;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
class SizeSorter implements IFilesSorter {

    private final OptionSet arguments;
    private Comparator<Path> comparator = null;

    private SizeSorter(OptionSet arguments) {
        this.arguments = arguments;

        if (arguments.has("r"))
            comparator = this::reverseComparerBySize;
        else
            comparator = this::comparerBySize;
    }

    @Override
    public List<Path> sort(List<Path> paths) {
        Collections.sort(paths, comparator);
        return paths;
    }

    public static SizeSorter CreateInstance(OptionSet arguments) {
        if (doSortBySize(arguments))
            return new SizeSorter(arguments);
        return null;
    }

    private static boolean doSortBySize(OptionSet arguments) {
        boolean sortBySize = arguments.has("S");
        if (arguments.has("sort"))
            sortBySize |= ((String) arguments.valueOf("sort")).equals("size");

        return sortBySize;
    }

    int comparerBySize(Path path1, Path path2) {
        try {
            return (int) (Files.size(path1) - Files.size(path2)); //TODO: Date comparision based on type of date from arguments
        }
        catch (IOException ex) {
            return 0;
        }
    }

    int reverseComparerBySize(Path path1, Path path2) {
        return -comparerBySize(path1, path2);
    }
}
