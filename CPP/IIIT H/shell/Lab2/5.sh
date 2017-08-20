#!/bin/bash


primecheck(){

n=$(($1/2))

prime=1

for ((i=2; i <= n ; i++))  
do
    if [ $(($1%$i)) -eq 0 ] 
    	then 
    	prime=0
    	break 
    fi
done  

return $prime
	
}

primecheck $1

if [ $? -eq 0 ] ; then echo "Not prime" ; 
else echo "Prime" 
fi



