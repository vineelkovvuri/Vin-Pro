/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.formatters;

import java.nio.file.Path;
import java.util.List;

/**
 *
 * @author vineel
 */
public interface IFilesFormatter {
    // format is an aggregate operation mainly
    // when we have to display all files in directory
    // by columns. So this method takes all the
    // files and return the aggregated view of
    // the results as single string.
    String format(List<Path> paths);
}
