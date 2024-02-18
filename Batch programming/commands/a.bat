

@echo off

rem prints a blank line
echo. 

rem no need to include in qoutes
title Hai I am Vineel from MSDOS ;) 


@echo off

echo.
echo Introduction of command line arguments in batch files
echo.

rem print individual arguments 
echo %1 %2 %3 %4 %5 %6 %7 %8 %9

rem we should use shift to access args > 9 there is no %{10} like unix ${10}



rem the entire string of args are stored in a special variable %*
echo %*



rem use of shift operator . shift with no parameter will shift the arguments by one
shift
rem now we can access 10th arg with %9
echo %9

rem shift with the following syntax will shift the parameters from %3 by one
shift /3
echo %8


@echo off
rem Usage of mathematical expression

rem no floating point operations allowed
set /a x=10+20-(10/3)
echo %x%

rem there is no exponentiation
set /a y=10*10*10
echo %y%
