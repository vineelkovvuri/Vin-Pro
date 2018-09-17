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
import org.apache.commons.io.FilenameUtils;

/**
 *
 * @author vineel
 */
class ExtensionSorter implements IFilesSorter {

    private final OptionSet arguments;
    private Comparator<Path> comparator = null;

    private ExtensionSorter(OptionSet arguments) {
        this.arguments = arguments;
        if (arguments.has("r"))
            comparator = this::reverseComparerByExtension;
        else
            comparator = this::comparerByExtension;

    }

    @Override
    public List<Path> sort(List<Path> paths) {
        Collections.sort(paths, comparator);
        return paths;
    }

    public static ExtensionSorter CreateInstance(OptionSet arguments) {
        if (doSortByExtension(arguments))
            return new ExtensionSorter(arguments);
        return null;
    }

    private static boolean doSortByExtension(OptionSet arguments) {
        boolean sortByExtension = arguments.has("X");
        if (arguments.has("sort"))
            sortByExtension |= ((String) arguments.valueOf("sort")).equals("extension");
        return sortByExtension;
    }

    int comparerByExtension(Path path1, Path path2) {
        return FilenameUtils.getExtension(path1.getFileName().toString())
            .compareTo(FilenameUtils.getExtension(path2.getFileName().toString()));
    }

    int reverseComparerByExtension(Path path1, Path path2) {
        return -comparerByExtension(path1, path2);
    }

}
