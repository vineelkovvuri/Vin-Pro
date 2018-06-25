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
class NameSorter implements IFilesSorter {
    private final OptionSet arguments;
    private Comparator<Path> comparator = null;

    private NameSorter(OptionSet arguments) {
        this.arguments = arguments;

        if (arguments.has("r"))
            comparator = this::compareByName;
        else
            comparator = this::reverseCompareByName;

    }

    @Override
    public List<Path> sort(List<Path> paths) {
        Collections.sort(paths, comparator);
        return paths;
    }

    public static NameSorter CreateInstance(OptionSet arguments) {
        return new NameSorter(arguments);
    }

    public int compareByName(Path path1, Path path2) {
        return path1.getFileName().toString()
            .compareTo(path2.getFileName().toString());
    }

    // TODO: natural ordering for now go with default sort
    public int reverseCompareByName(Path path1, Path path2) {
        return -compareByName(path1, path2);
    }
}
