/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.filter;

import com.vineel.ls.filepredicates.FilePredicate;
import com.vineel.ls.filepredicates.IFilePredicate;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
public class DirectoryFilter implements IDirectoryFilter {

    private final IFilePredicate predicate;

    public DirectoryFilter(OptionSet arguments) {
        this.predicate = new FilePredicate(arguments);
    }

    public List<Path> filter(Path directory) {
        List<Path> filteredFiles = new ArrayList<>();
        try {
            for (Path file : Files.newDirectoryStream(directory))
                if (predicate.test(file))
                    filteredFiles.add(file);
        }
        catch (SecurityException | IOException se) {
            se.printStackTrace();
        }
        return filteredFiles;
    }

}
