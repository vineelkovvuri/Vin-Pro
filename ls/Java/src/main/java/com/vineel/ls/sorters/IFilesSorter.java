/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.sorters;

import java.nio.file.Path;
import java.util.List;

/**
 *
 * @author vineel
 */
public interface IFilesSorter {
    List<Path> sort(List<Path> paths);
}
