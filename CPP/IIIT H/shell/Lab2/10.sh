#!/bin/bash
#frequency counter 
rm b.txt;rm c.txt;rm d.txt
for n in `cut -f1,3 a.txt` 
do
	echo $n	>> b.txt
	 
done
for n in `sort -u b.txt ` 
do
	echo `grep -c -w $n b.txt`" "$n >> d.txt
done
sort -r d.txt 

