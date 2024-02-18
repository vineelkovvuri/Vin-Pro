/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.vineel.ls.formatters;

import com.vineel.ls.CommandLineParser;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.LinkOption;
import java.nio.file.Path;
import java.nio.file.attribute.FileTime;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import joptsimple.OptionSet;

/**
 *
 * @author vineelko
 */
public class FileFormatterUtils {
    private final OptionSet arguments;

    public FileFormatterUtils(OptionSet arguments) {
        this.arguments = arguments;
    }

    public String getFileName(Path path) {
        return path.getFileName().toString();
    }

    public String getFileNameWithQuotes(Path path) {
        return "\"" + path.getFileName().toString() + "\"";
    }

    // Skipped socket, named pipe, http://unix.stackexchange.com/a/82358/38787
    // -F, --classify
    // --file-type
    public String getFileNameClassified(Path path) {

        String symbol = "";
        if (Files.isSymbolicLink(path))
            symbol = "@";
        else if (Files.isDirectory(path))
            symbol = "/";

        //For executable file classification we need to look
        //at the presence of --file-type argument. This is
        //a contradicting option to -F. when both are given
        //only the option appearing later in the command line
        //is choosen
        String argumentStr = " " + String.join(" ", CommandLineParser.getArgs()) + " ";
        //Both -F/--classify and --file-type are present, So verify which ever is last
        if ((arguments.has("F") || arguments.has("classify")) && arguments.has("file-type")) {
            int indexOfClassifyOrF = argumentStr.indexOf(" -F ");
            if (indexOfClassifyOrF == -1)
                indexOfClassifyOrF = argumentStr.indexOf(" --classify ");

            int indexOfFileType = argumentStr.indexOf(" --file-type ");

            if (indexOfClassifyOrF > indexOfFileType) {
                if (Files.isExecutable(path))
                    symbol = "*";
            }
        }
        // --file-type is not present
        else if (!arguments.has("file-type")) {
            if (Files.isExecutable(path))
                symbol = "*";
        }

        return path.getFileName() + symbol;
    }

    public String getCreationDateTime(Path path) {
        return getDateTime(path, "creationTime");
    }

    public String getModificationDateTime(Path path) {
        return getDateTime(path, "lastModifiedTime");
    }

    public String getAccessDateTime(Path path) {
        return getDateTime(path, "lastAccessTime");
    }

    private String getDateTime(Path path, String timeAttribute) {
        try {
            FileTime fileTime = (FileTime) Files.getAttribute(
                path, timeAttribute, LinkOption.NOFOLLOW_LINKS);
            Instant instant = fileTime.toInstant();
            LocalDateTime dateTime = LocalDateTime.ofInstant(instant, ZoneId.systemDefault());
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("+Y-m-d H:M:S.N");
            return dateTime.format(formatter);
        }
        catch (IOException ex) {
            ex.printStackTrace();
            return null;
        }
    }

    private String getLastNChars(String string, int n) {
        if (string.length() <= n)
            return string;
        int len = string.length();
        return string.substring(len - n, len);
    }

    //-s also used when --block-size= is specified // Its a seperate option
    String units1000[] = {"", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB",};
    String units1024[] = {"", "K", "M", "G", "T", "P", "E", "Z", "Y",};

    public String getFileSizeByBlocks(Path path) {
        long fileSize = getFileSize(path);

        if (!arguments.has("block-size"))
            return String.valueOf(fileSize);

        String blockSizeArg = (String) arguments.valueOf("block-size");
        blockSizeArg = blockSizeArg.trim();

        if (blockSizeArg.isEmpty())
            return String.valueOf(fileSize);

        //At this point something is passed to --block-size
        //Split size and unit from blockSizeArg
        String sizeStr = blockSizeArg; //Covers: size with no unit case
        String unitStr = "";
        for (int i = 0; i < blockSizeArg.length(); i++) {
            if (!Character.isDigit(blockSizeArg.charAt(i))) {
                sizeStr = blockSizeArg.substring(0, i);
                unitStr = blockSizeArg.substring(i);
                break;
            }
        }
        int size = sizeStr.length() == 0 ? 1 : Integer.parseInt(sizeStr);

        for (int i = 0; i < units1000.length; i++) {
            if (units1000[i].equals(unitStr)) {
                for (int j = 0; j < i; j++)
                    fileSize /= 1000; // KB MB GB TB ....
                fileSize /= size;
                return fileSize + units1000[i]; // final size followed by unit
            }
        }

        for (int i = 0; i < units1024.length; i++) {
            if (units1024[i].equals(unitStr)) {
                for (int j = 0; j < i; j++)
                    fileSize /= 1024; // K M G T ....
                fileSize /= size;
                return fileSize + units1024[i]; // final size followed by unit
            }
        }
        //Covers: invalid block-size arguments case
        return String.valueOf(fileSize);
    }

    public String getFileSizeInHumanReadableOrSI(Path path) {
        long fileSize = getFileSize(path);

        //These are contradicting options to -F. when both are given
        //only the option appearing later in the command line
        //is choosen
        boolean chooseSI = false;
        String argumentStr = " " + String.join(" ", CommandLineParser.getArgs()) + " ";
        if ((arguments.has("h") || arguments.has("human-readable")) && arguments.has("si")) {

            int indexOfHumanOrH = argumentStr.indexOf(" -h ");
            if (indexOfHumanOrH == -1)
                indexOfHumanOrH = argumentStr.indexOf(" --human-readable ");

            int indexOfSI = argumentStr.indexOf(" --si ");

            chooseSI = indexOfHumanOrH < indexOfSI;
        }
        else if (arguments.has("h") || arguments.has("human-readable"))
            chooseSI = false;
        else if (arguments.has("si"))
            chooseSI = true;

        if (chooseSI) {
            int unitCount = 0; // We start at bytes
            while (fileSize >= 1000) {
                fileSize /= 1000;
                unitCount++; // bump unit by one level
            }
            //Yaa we will return 1024 units weried!!
            return fileSize + units1024[unitCount];
        }
        else if (arguments.has("si")) {

            int unitCount = 0; // We start at bytes
            while (fileSize >= 1024) {
                fileSize /= 1024;
                unitCount++; // bump unit by one level
            }
            return fileSize + units1024[unitCount];
        }
        return String.valueOf(fileSize);
    }

    private long getFileSize(Path path) {
        try {
            return Files.size(path);
        }
        catch (IOException ex) {
            ex.printStackTrace();
            return -1;
        }
    }
}
