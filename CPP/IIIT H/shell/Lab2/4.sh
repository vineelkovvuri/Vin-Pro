#!/bin/bash

arr=( a b c d e f g h i j k l m n o p q r s t )
echo -n "Enter k:"
read k

n=${#arr[@]}

echo $n
t=0
a=0
b=$k
c=$(($b+$k))
d=$b
while [ $t -lt $n ]
do
if [ $(($t%2)) -eq 0 ] 
then 
	for((j=a;j<b;j++))
	do
		echo -n "${arr[$j]} "
	done
	
c=$(($b+$k-1))
d=$b

else
	for((i=c;i>=d;i--))
	do
		echo -n "${arr[$i]} "
	done
a=$(($c+1))
b=$(($c+$k+1))
fi
t=$(($t+1))

echo ""


done

