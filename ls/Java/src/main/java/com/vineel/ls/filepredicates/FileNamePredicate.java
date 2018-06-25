/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.filepredicates;

import java.nio.file.Path;

/**
 *
 * @author vineel
 */
class FileNamePredicate implements IFilePredicate {

    private final String namePattern;

    private FileNamePredicate(String namePattern) {
        this.namePattern = namePattern;
    }

    static IFilePredicate CreateNameFilter(String namePattern) {
        // if pattern is null we return a NullFilter which
        // will be true for any given file
        if (namePattern == null)
            return file -> true;
        return new FileNamePredicate(namePattern);
    }

    @Override
    public boolean test(Path path) {
        if (path.getFileName().equals(namePattern))
            return true;
        return false;
    }
}
