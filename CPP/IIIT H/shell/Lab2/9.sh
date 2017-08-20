#!/bin/bash



if [ -f "$1" ]  
then 
	echo "$1:File already exists" 
	exit
fi

if [ "$#" -ne 1 ]  
then 
	echo "Insufficient number of arguments" 
	exit
fi



for f in `ls`
do
	if [ -f "$f" ] ; then echo $f >> $1; fi
done	



