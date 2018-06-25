/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.sorters;

import java.nio.file.Path;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
class NullSorter implements IFilesSorter {//, Comparator<Path> {
    private final OptionSet arguments;

    private NullSorter(OptionSet arguments) {
        this.arguments = arguments;
    }

    @Override
    public List<Path> sort(List<Path> paths) {
        //Collections.sort(paths, this);
        return paths;
    }

    public static NullSorter CreateInstance(OptionSet arguments) {
        if (doSortByNothing(arguments))
            return new NullSorter(arguments);
        return null;
    }

    private static boolean doSortByNothing(OptionSet arguments) {
        boolean sortByExtension = arguments.has("U");
        if (arguments.has("sort"))
            sortByExtension |= ((String) arguments.valueOf("sort")).equals("none");
        return sortByExtension;
    }
//    @Override
//    public int compare(Path path1, Path path2) {
//        // TODO: based on arguments assending or desending
//        return 0;//file1.getName().compareTo(file2.getName());
//    }
}
