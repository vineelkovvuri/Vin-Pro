/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.sorters;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.LinkOption;
import java.nio.file.Path;
import java.nio.file.attribute.FileTime;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
class DateSorter implements IFilesSorter {

    private final OptionSet arguments;
    private Comparator<Path> comparator = null;

    private DateSorter(OptionSet arguments) {
        this.arguments = arguments;

        // TODO: no last change time currently
        if (arguments.has("u"))
            if (arguments.has("r"))
                comparator = this::reverseComparerByAccessTime;
            else
                comparator = this::comparerByAccessTime;
        else if (arguments.has("c"))
            if (arguments.has("r"))
                comparator = this::reverseComparerByCreationTime;
            else
                comparator = this::comparerByCreationTime;
        else// modified time is the default
            if (arguments.has("r"))
                comparator = this::reverseComparerByModificationTime;
            else
                comparator = this::comparerByModificationTime;
    }

    @Override
    public List<Path> sort(List<Path> paths) {
        Collections.sort(paths, comparator);
        return paths;
    }

    public static DateSorter CreateInstance(OptionSet arguments) {
        if (doSortByDate(arguments))
            return new DateSorter(arguments);
        return null;
    }

    private static boolean doSortByDate(OptionSet arguments) {
        boolean sortByDate = false;

        sortByDate = arguments.has("c")
                     || arguments.has("t");

        if (arguments.has("sort"))
            sortByDate |= ((String) arguments.valueOf("sort")).equals("time");

        return sortByDate;
    }

    // atime gets updated when attributes of a file are changed
    public int comparerByAccessTime(Path path1, Path path2) {
        try {
            FileTime path1ATime = (FileTime) Files.getAttribute(
                path1, "lastAccessTime", LinkOption.NOFOLLOW_LINKS);
            FileTime path2ATime = (FileTime) Files.getAttribute(
                path2, "lastAccessTime", LinkOption.NOFOLLOW_LINKS);
            return path1ATime.compareTo(path2ATime);
        }
        catch (IOException ex) {
            ex.printStackTrace();
            return 0;
        }
    }

    public int reverseComparerByAccessTime(Path path1, Path path2) {
        return -comparerByAccessTime(path1, path2);
    }

    // ctime gets updated when attributes of a file are changed
    public int comparerByCreationTime(Path path1, Path path2) {
        try {
            FileTime path1CTime = (FileTime) Files.getAttribute(
                path1, "creationTime", LinkOption.NOFOLLOW_LINKS);
            FileTime path2CTime = (FileTime) Files.getAttribute(
                path2, "creationTime", LinkOption.NOFOLLOW_LINKS);
            return path1CTime.compareTo(path2CTime);
        }
        catch (IOException ex) {
            ex.printStackTrace();
            return 0;
        }
    }

    public int reverseComparerByCreationTime(Path path1, Path path2) {
        return -comparerByCreationTime(path1, path2);
    }

    // mtime gets updated when content of a file are changed
    public int comparerByModificationTime(Path path1, Path path2) {
        try {
            FileTime path1MTime = (FileTime) Files.getAttribute(
                path1, "lastModifiedTime", LinkOption.NOFOLLOW_LINKS);
            FileTime path2MTime = (FileTime) Files.getAttribute(
                path2, "lastModifiedTime", LinkOption.NOFOLLOW_LINKS);
            return path1MTime.compareTo(path2MTime);
        }
        catch (IOException ex) {
            ex.printStackTrace();
            return 0;
        }
    }

    public int reverseComparerByModificationTime(Path path1, Path path2) {
        return -comparerByModificationTime(path1, path2);
    }
}
