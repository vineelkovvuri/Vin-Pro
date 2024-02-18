.386                      ; forces 32 bit assembly 
.model flat,stdcall 
option casemap: none

include c:\masm32\include\windows.inc
include c:\masm32\include\kernel32.inc
include c:\masm32\include\masm32.inc
include c:\masm32\include\debug.inc

includelib c:\masm32\lib\kernel32.lib
includelib c:\masm32\lib\masm32.lib
includelib c:\masm32\lib\debug.lib

DBGWIN_DEBUG_ON = 1 ;turn it off if you don't want to include debug info into the program
DBGWIN_EXT_INFO = 1 ;turn it off if you don't want to include extra debug info into the program

		   

.DATA 					; reserve storage for data
msg BYTE "Enter first number: ", 0

.CODE 					; start of main program code
_start:
 
PrintString msg
ret
END _start ; end of source code

