/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.traversers;

import java.nio.file.Path;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Iterator;

/**
 *
 * @author vineelko
 */
class SelfDirectoryTraverser implements IDirectoryTraverser, Iterable<Path>, Iterator<Path> {

    private final Deque<Path> queue;

    SelfDirectoryTraverser() {
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
        return queue.removeFirst();
    }
}
