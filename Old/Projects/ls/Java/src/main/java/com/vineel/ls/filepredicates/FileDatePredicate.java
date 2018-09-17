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
class FileDatePredicate implements IFilePredicate {

    private final String datePattern;

    private FileDatePredicate(String datePattern) {
        this.datePattern = datePattern;
    }

    static IFilePredicate CreateDateFilter(String datePattern) {
        // if pattern is null we return a NullFilter which
        // will be true for any given file
        if (datePattern == null)
            return file -> true;
        return new FileDatePredicate(datePattern);
    }

    @Override
    public boolean test(Path path) {
        if (path.getFileName().equals(datePattern))
            return true;
        return false;
    }
}
