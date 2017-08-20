@echo off
rem Usage of If else statements


set x=11


rem equ neq lss leq gtr geq 
rem 		 |-----> this space is a must	
rem          |
rem          |
if %x% equ 10 (
echo ten
echo tennnnn
)else (
	echo not ten
)


rem u can use == also but equ is better , /I is used for case insensitive comparisions
rem else should occur in the same line as if ends
set y="Vineel"
if %y%  equ "vineel" (
		echo x contains vineel
		)else if /I %y% equ "vineel" (
			echo x contains vineel
			)

rem using not operator
if not %y% equ "vineel" (
echo x does not contain vineel
)



rem if applied to files

if exist 5.bat (
		echo 5.bat file exists
		)else (echo 5.bat does not exits)

if not exist a.txt (
		echo a.txt does not exits
		)else (		
			del a.txt
			echo a.txt file deleted 	
		)

rem if applied to environmental variables(works for normal variables also) 
if defined path (
		echo %path%
		)


