#!/bin/bash

echo -n "Enter number of seconds:"
read sec



hours=$(($sec/3600))
sec=$(($sec%3600))
mins=$(($sec/60))
sec=$(($sec%60))

echo $hours:$mins:$sec



