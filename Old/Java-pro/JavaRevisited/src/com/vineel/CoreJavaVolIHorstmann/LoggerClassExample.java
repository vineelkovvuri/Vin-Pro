package com.vineel.CoreJavaVolIHorstmann;

import java.util.logging.*;

/**
 * Created by vineel on 29/2/16.
 */

// we have loggers -> loggerfilters -> handlers(can be console,file,socket) -> handlerfilters -> output
public class LoggerClassExample {
    public static void main(String[] args) {
        Logger logger = Logger.getLogger("com.vineel.CoreJavaVolIHorstmann");
        logger.info("vineel before filter on logger");
        // This will set the filter to be used by logger itself.
        logger.setFilter((lr) -> {
            if (lr.getMessage().contains("vineel"))
                return false;
            return true;
        });
        logger.info("vineel after filter on logger");

        logger.info("nischala before filter on handler");
        // disable the default console handler of logger
        logger.setUseParentHandlers(false);
        // Create new console handler to be used by logger
        ConsoleHandler handler = new ConsoleHandler();
        // This will set the filter to be used by logger's Handler.
        // This is at the handler stage.
        handler.setFilter((lr) -> {
            if (lr.getMessage().contains("nischala"))
                return false;
            return true;
        });
        logger.info("nischala after filter on handler");


    }
}
