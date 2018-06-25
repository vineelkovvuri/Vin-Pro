/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.formatters;

import com.vineel.ls.CommandLineParser;
import java.nio.file.Path;
import java.util.List;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
enum FormattersEnum {
    OnePerLineListing, //-1
    AggregateLongListing, //-l //-o //-g //-n //--full-time
    CommaListing, //-m
    ColumnListing, //-C //Default formatter
}

public class FilesFormatter implements IFilesFormatter {

    private IFilesFormatter formatter;

    public FilesFormatter(OptionSet arguments) {

        switch (chooseFormatter()) {
            case OnePerLineListing:
                formatter = new OnePerLineFormatter(arguments);
            case AggregateLongListing:
                formatter = new AggregateLongListFormatter(arguments);
            case CommaListing:
                formatter = new CommaSeperatedFormatter(arguments);
            case ColumnListing:
            default:
                formatter = new ColumnListFormatter(arguments);
        }
    }

    @Override
    public String format(List<Path> paths) {
        return formatter.format(paths);
    }

    // This method is needed because we need to get
    // the last formatting option of the ls command.
    // formatting options here include all options
    // specified in FormattersEnum
    // ls picks the last formatting option
    // for example: ls -l -m -C     it picks -C
    // for example: ls -l -1        it picks -1
    // This rule does not applies among mulitple
    // options of aggregate enum, like between -o and -g
    // for example: ls -o -g is same as ls -g -o
    // and they essentially fall into broader aggregate
    // filter. -g and -o option is treated as logical
    // AND so ls -o -g will output the list format
    // by excluding group info (for -o) AND owner(for -g)
    private FormattersEnum chooseFormatter() {
        String args[] = CommandLineParser.getArgs();
        FormattersEnum formatterEnum = FormattersEnum.ColumnListing; //Default
        int maxIndex = -1;
        for (int i = 0; i < args.length; i++) {
            String arg = args[i].trim();
            if (arg.equals("-1")) {
                if (maxIndex < i) {
                    formatterEnum = FormattersEnum.OnePerLineListing;
                    maxIndex = i;
                }
            }
            else if (arg.equals("-l") // all these options basically
                     || arg.equals("-o") // format as list with slight
                     || arg.equals("-g") // variations
                     || arg.equals("-n")
                     || arg.equals("--full-time")) {
                if (maxIndex < i) {
                    formatterEnum = FormattersEnum.AggregateLongListing;
                    maxIndex = i;
                }
            }
            else if (arg.equals("-m"))
                if (maxIndex < i) {
                    formatterEnum = FormattersEnum.CommaListing;
                    maxIndex = i;
                }
        }
        return formatterEnum;
    }

}
