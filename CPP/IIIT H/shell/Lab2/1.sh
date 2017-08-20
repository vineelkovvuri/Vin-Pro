#!/bin/bash

i=$1

while [ $i -le $2 ]
do
	echo -n $i "  "
	i=$(($i+1))
done


