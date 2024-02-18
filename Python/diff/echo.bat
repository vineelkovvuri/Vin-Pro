@echo off

if "%1" neq "-c" (
	python diff.py e:\ebooks\  I:\vineel\ebooks\ 
	echo "-------------------------------------------------------------------" 
	python diff.py d:\tools\  I:\vineel\tools\ 
	echo "-------------------------------------------------------------------" 
	python diff.py d:\softs\  I:\vineel\softs\ 
	echo "-------------------------------------------------------------------" 
	python diff.py "d:\USB Softs"  "I:\Vineel\USB Softs"
	echo "-------------------------------------------------------------------" 
) else (
	python diff.py -c e:\ebooks\  I:\vineel\ebooks\ 
	echo "-------------------------------------------------------------------" 
	python diff.py -c d:\tools\  I:\vineel\tools\ 
	echo "-------------------------------------------------------------------" 
	python diff.py -c d:\softs\  I:\vineel\softs\ 
	echo "-------------------------------------------------------------------" 
	python diff.py -c "d:\USB Softs"  "I:\Vineel\USB Softs"
	echo "-------------------------------------------------------------------" 
)


