
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.traversers;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.LinkOption;
import java.nio.file.Path;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Iterator;

/**
 *
 * @author vineelko
 */
class RecursiveDirectoryTraverser implements IDirectoryTraverser, Iterable<Path>, Iterator<Path> {

    private final Deque<Path> queue;

    RecursiveDirectoryTraverser() {
        queue = new ArrayDeque<>();
    }

    @Override
    public Iterable<Path> traverse(Path directory) {
        queue.addLast(directory);
        return this;
    }

    @Override
    public Iterator<Path> iterator() {
        return this;
    }

    @Override
    public boolean hasNext() {
        return !queue.isEmpty();
    }

    @Override
    public Path next() {
        Path front = queue.removeFirst();
        try {
            for (Path path : Files.newDirectoryStream(front))
                if (Files.isDirectory(path, LinkOption.NOFOLLOW_LINKS))
                    queue.addLast(path);
        }
        catch (SecurityException | IOException se) {
            se.printStackTrace();
        }
        return front;
    }
}
