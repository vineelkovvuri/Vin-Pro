/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.traversers;

import java.nio.file.Path;
import joptsimple.OptionSet;

/**
 *
 * @author vineelko
 */
public class DirectoryTraverser implements IDirectoryTraverser {

    private final IDirectoryTraverser traverser;

    public DirectoryTraverser(OptionSet arguments) {
        if (arguments.has("r"))
            traverser = new RecursiveDirectoryTraverser();
        else //if (arguments.has("self"))
            traverser = new SelfDirectoryTraverser();
    }

    @Override
    public Iterable<Path> traverse(Path directory) {
        return traverser.traverse(directory);
    }
}
