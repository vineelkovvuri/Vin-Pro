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
class FileTypePredicate implements IFilePredicate {
    private final String typePattern;

    private FileTypePredicate(String typePattern) {
        this.typePattern = typePattern;
    }

    static IFilePredicate CreateTypeFilter(String typePattern) {
        // if pattern is null we return a NullFilter which
        // will be true for any given file
        if (typePattern == null)
            return file -> true;
        return new FileTypePredicate(typePattern);
    }

    @Override
    public boolean test(Path path) {
        if (path.getFileName().equals(typePattern))
            return true;
        return false;
    }
}
