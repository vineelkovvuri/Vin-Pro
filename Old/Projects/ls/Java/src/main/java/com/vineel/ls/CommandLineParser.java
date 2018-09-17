/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls;

import java.io.IOException;
import java.util.Arrays;
import joptsimple.OptionParser;
import joptsimple.OptionSet;

/**
 *
 * @author vineel
 */
public class CommandLineParser {

    private final OptionParser parser;
    private static String args[];

    public static String[] getArgs() {
        return args;
    }

    public CommandLineParser() {
        parser = new OptionParser();
    }

    public OptionSet parseOptions(String... args) {
        //Store a copy of args to be accessed for arugments order
        //Formaters module
        this.args = Arrays.copyOf(args, args.length);
        return parser.parse(args);
    }

    public void buildOptions() {
        // http://man7.org/linux/man-pages/man1/ls.1.html

        // -a, --all //Filter
        parser.acceptsAll(Arrays.asList("a", "all"));

        // -A, --almost-all //Filtering
        parser.acceptsAll(Arrays.asList("A", "almost-all"));

        // --author //Formatting
        parser.accepts("author");

        // -b, --escape //Formatting
        parser.acceptsAll(Arrays.asList("b", "escape"));

        //
        // --block-size=SIZE //Formatting
        parser.accepts("block-size").withRequiredArg();

        // -B, --ignore-backups //Filtering
        parser.acceptsAll(Arrays.asList("B", "ignore-backups"));

        //
        // -c with -lt display ctime and sort by ctime //Sorting && Formatting
        //    with -l display ctime //Formatting
        // http://www.linux-faqs.info/general/difference-between-mtime-ctime-and-atime
        parser.accepts("c");

        // -C //Formatting
        parser.accepts("C");

        // --color=WHEN //Formatting
        parser.accepts("color").withRequiredArg();

        // -d, --directory //TODO: list directories themselves, not their contents //Filtering
        parser.acceptsAll(Arrays.asList("d", "directory"));

        // -D, --dired //INVESTIGATE:
        //
        // -f //INVESTIGATE:
        // -F, --classify //Formatting
        parser.acceptsAll(Arrays.asList("F", "classify"));

        // --file-type //Formatting
        parser.accepts("file-type");

        // --format=WORD //Formatting
        parser.accepts("format").withRequiredArg();

        // --full-time //Formatting
        parser.accepts("full-time");

        // -g //Formatting
        parser.accepts("g");

        // --group-directories-first //Sorting
        parser.accepts("group-directories-first");

        // -G, --no-group //Formatting
        parser.acceptsAll(Arrays.asList("G", "no-group"));

        // -h, --human-readable //Formatting
        parser.acceptsAll(Arrays.asList("h", "human-readable"));

        // --si likewise, //Formatting
        parser.accepts("si");

        // -H, --dereference-command-line //Formatting
        parser.acceptsAll(Arrays.asList("H", "dereference-command-line"));

        // --dereference-command-line-symlink-to-dir //INVESTIGATE:
        //
        // --hide=PATTERN //Filtering
        parser.accepts("hide").withRequiredArg();

        // --indicator-style=WORD //Formatting
        parser.accepts("indicator-style").withRequiredArg();

        // -i, --inode //Formatting
        parser.acceptsAll(Arrays.asList("i", "inode"));

        // -k, --kibibytes //Formatting
        parser.acceptsAll(Arrays.asList("k", "kibibytes"));

        // -l //Formatting
        parser.accepts("l");

        // -L, --dereference //Formatting
        parser.acceptsAll(Arrays.asList("L", "dereference"));

        // -m //Formatting
        parser.accepts("m");

        // -n, --numeric-uid-gid //Formatting
        parser.acceptsAll(Arrays.asList("n", "numeric-uid-gid"));

        // -N, --literal //Formatting
        parser.acceptsAll(Arrays.asList("N", "literal"));

        // -o //Formatting
        parser.accepts("o");

        // -p, --indicator-style=slash //Formatting //FIX: =slash cannot be parsed by jopt
        parser.acceptsAll(Arrays.asList("p", "indicator-style"));

        // -q, --hide-control-chars //Formatting
        parser.acceptsAll(Arrays.asList("q", "hide-control-chars"));

        // --show-control-chars //Formatting
        parser.accepts("show-control-chars");

        // -Q, --quote-name //Formatting
        parser.acceptsAll(Arrays.asList("Q", "quote-name"));

        // --quoting-style=WORD //Formatting
        parser.accepts("quoting-style").withRequiredArg();

        // -r, --reverse // Sorting
        parser.acceptsAll(Arrays.asList("r", "reverse"));

        // -R, --recursive //Traversal
        parser.acceptsAll(Arrays.asList("R", "recursive"));

        // -s, --size //Formatting
        parser.acceptsAll(Arrays.asList("s", "size"));

        // -S //Sorting
        parser.accepts("S");

        // --sort=WORD //Sorting
        parser.accepts("sort").withRequiredArg();

        // --time=WORD //Formatting
        parser.accepts("time").withRequiredArg();

        // --time-style=STYLE //Formatting
        parser.accepts("time-style").withRequiredArg();

        // -t //Sorting
        parser.accepts("t");

        // -T, --tabsize=COLS //Formatting
        parser.acceptsAll(Arrays.asList("T", "tabsize")).withRequiredArg();

        // -u //Sorting && Formatting
        parser.accepts("u");

        // -U //Sorting
        parser.accepts("U");

        // -v //Sorting
        parser.accepts("v");

        // -w, --width=COLS //Formatting
        parser.acceptsAll(Arrays.asList("w", "width")).withRequiredArg();

        // -x //Formatting
        parser.accepts("x");

        // -X //Sorting
        parser.accepts("X");

        // -Z, --context  //Formatting
        parser.acceptsAll(Arrays.asList("Z", "context"));

        // -1 //Formatting
        parser.accepts("1");

        // --help
        parser.accepts("help").forHelp();

        // --version
        parser.accepts("version");
    }

    public void printHelp() {
        try {
            parser.printHelpOn(System.out);
        }
        catch (IOException ex) {
            System.out.println("Exception in printHelp");
        }
    }

    void printVersion() {
        System.out.println("ls 1.0");
    }

}
