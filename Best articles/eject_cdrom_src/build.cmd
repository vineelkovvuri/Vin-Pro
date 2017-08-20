@echo off

set PATH=c:\PROGRA~1\lcc\bin;

lcc.exe -O main.c
lcclnk.exe -o cdrom.exe -s -subsystem windows main.obj winmm.lib

if exist main.obj del main.obj

pause