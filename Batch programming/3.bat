@echo off

rem Usage of variables


rem initializing variables 
set x=10

rem value of a varible is accessed using %x% syntax
echo %x%

rem uninitializing variables(freeing them)
set x=


set string="asdfasdfaF  asfsfasfd"
echo %string%


rem some standard system variables
echo %path%

rem %errorlevel% gives whether previous command executed successfully or not
echo %errorlevel%

rem we can mark the scope of the variable using setlocal and endlocal

setlocal
set y=10
echo %y%
endlocal

rem y is no more
echo %y%  




