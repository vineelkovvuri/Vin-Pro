/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.filepredicates;

import java.nio.file.Path;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
public class FilePredicate implements IFilePredicate {

    private final IFilePredicate dateSingleton;
    private final IFilePredicate nameSingleton;
    private final IFilePredicate typeSingleton;

    public FilePredicate(OptionSet arguments) {
        dateSingleton = FileDatePredicate.CreateDateFilter((String) arguments.valueOf("d"));
        nameSingleton = FileNamePredicate.CreateNameFilter((String) arguments.valueOf("n"));
        typeSingleton = FileTypePredicate.CreateTypeFilter((String) arguments.valueOf("t"));
    }

    @Override
    public boolean test(Path path) {
        return dateSingleton
            .and(nameSingleton)
            .and(typeSingleton)
            .test(path);
    }
}
