/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.formatters;

import java.nio.file.Path;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
class AggregateLongListFormatter implements IFilesFormatter {
    private final OptionSet arguments;

    public AggregateLongListFormatter(OptionSet arguments) {
        this.arguments = arguments;
    }

    @Override
    public String format(List<Path> paths) {
        //TODO: implement long listing
        return "Long listing";
    }
}
