#!/bin/bash



if [ $# -lt 4 ] 
then 
	echo "Need enough arguments" 
	exit
fi

if [[ $1 == *[!0-9]* ]] 
then		
	echo "value $1 is not an integer"
	exit
elif [[ $2 == *[!0-9]* ]] 
then		
	echo "value $2 is not an integer"
	exit
elif [[ $3 == *[!0-9]* ]] 
then		
	echo "value $3 is not an integer"
	exit
elif [[ $4 == *[!0-9]* ]] 
then		
	echo "value $4 is not an integer"
	exit
else
	echo $(( $1*20-$2*2+$3/$4 ))	
fi	





