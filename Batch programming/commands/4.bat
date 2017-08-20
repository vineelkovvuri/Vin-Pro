@echo off
rem Usage of mathematical expression

rem no floating point operations allowed
set /a x=10+20-(10/3)
echo %x%

rem there is no exponentiation
set /a y=10*10*10
echo %y%
