
@echo off


rem using for loop
rem General syntax
rem for iterator do (statement)



rem Stepping through a Series of Values
rem for /l %%variable in (start,step,end) do (statement)

rem for /l %%i in (0,1,3) do (
rem		for /l %%j in (0,1,3) do (
rem			echo %%j	 
rem			)
rem		)

rem For used in listing files 
rem for %%variable in (*.dll *.txt *.exe .....) do (statement)
rem for %%f in (c:\windows\system32\*.dll)  do (
rem 		echo %%f
rem 		)

rem For used in listing directories
rem for /D %%variable in (c:\windows\system32\* c:\windows\* .....) do (statement)
rem for /D %%d in (c:\windows\system32\* c:\windows\* ) do (
rem 		echo %%d
rem		)


rem for used in recursive file listing
rem for /R d:\tools %%f in (eula.txt) do (
rem			echo %%f
rem		)

rem for used in recursive directory listing
rem for /D /R c:\a %%f in (*) do (
rem		rmdir  "%%f"
rem		)
set /a 	i=0
for /f "tokens=*" %%A in (6.bat) do (
		echo %i%  %%A
		set /a i=%i%+1
		)

for /F "delims=*"  %%f in ('dir /b /s e:\ebooks\*.pdf')  do (
)