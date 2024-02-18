#!/bin/bash

awk '
BEGIN {
l=0; 
}
{
   if (l >= start && l < ending) print $0;  
   l++;
}' start=$1 ending=$(($1+$2)) $3


