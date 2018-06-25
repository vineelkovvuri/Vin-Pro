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
public class FilesSorter implements IFilesSorter {

    private IFilesSorter sorter;

    public FilesSorter(OptionSet arguments) {
        if (sorter == null) // -c or -t
            sorter = DateSorter.CreateInstance(arguments);
        if (sorter == null) // -s
            sorter = SizeSorter.CreateInstance(arguments);
        if (sorter == null) // -v
            sorter = ExtensionSorter.CreateInstance(arguments);
        if (sorter == null) // -U
            sorter = NullSorter.CreateInstance(arguments);
        if (sorter == null) // This is default - no option is specified
            sorter = NameSorter.CreateInstance(arguments);
    }

    @Override
    public List<Path> sort(List<Path> paths) {
        return sorter.sort(paths);
    }
}
