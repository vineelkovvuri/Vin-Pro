/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.sorters;

import java.nio.file.Path;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
class VersionSorter implements IFilesSorter {

    private final OptionSet arguments;
    private Comparator<Path> comparator = null;

    private VersionSorter(OptionSet arguments) {
        this.arguments = arguments;
        if (arguments.has("r"))
            comparator = this::reverseComparerByVersion;
        else
            comparator = this::comparerByVersion;
    }

    @Override
    public List<Path> sort(List<Path> paths) {
        Collections.sort(paths, comparator);
        return paths;
    }

    public static VersionSorter CreateInstance(OptionSet arguments) {
        if (doSortByVersion(arguments))
            return new VersionSorter(arguments);
        return null;
    }

    private static boolean doSortByVersion(OptionSet arguments) {
        boolean sortByExtension = arguments.has("v");
        if (arguments.has("sort"))
            sortByExtension |= ((String) arguments.valueOf("sort")).equals("version");
        return sortByExtension;
    }

    //TODO: For now instead of version we are just doing normal file name compare
    int comparerByVersion(Path path1, Path path2) {
        return path1.getFileName()
            .compareTo(path2.getFileName());
    }

    int reverseComparerByVersion(Path path1, Path path2) {
        return -comparerByVersion(path1, path2);
    }
}
