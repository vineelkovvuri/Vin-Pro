/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls;

import com.vineel.ls.filter.DirectoryFilter;
import com.vineel.ls.filter.IDirectoryFilter;
import com.vineel.ls.formatters.FilesFormatter;
import com.vineel.ls.sorters.FilesSorter;
import com.vineel.ls.sorters.IFilesSorter;
import com.vineel.ls.traversers.DirectoryTraverser;
import com.vineel.ls.traversers.IDirectoryTraverser;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import joptsimple.OptionSet;
import com.vineel.ls.formatters.IFilesFormatter;

/**
 *
 * @author vineel
 */
public class Driver {
    public void drive(OptionSet arguments) {
        IDirectoryTraverser traverser = new DirectoryTraverser(arguments);
        IDirectoryFilter directoryFilter = new DirectoryFilter(arguments);
        IFilesSorter filesSorter = new FilesSorter(arguments);
        IFilesFormatter filesFormater = new FilesFormatter(arguments);

        // Directory Traverser
        for (Path directory : traverser.traverse(Paths.get("/home/vineel"))) {
            List<Path> unsortedFiles = directoryFilter.filter(directory);
            List<Path> sortedFiles = filesSorter.sort(unsortedFiles);
            String view = filesFormater.format(sortedFiles);

            System.out.println(view);
        }
    }
}
