#!/bin/bash

i=`date +%H`

if [ $i -ge 4 -a $i -lt 9 ] ; then   echo "Good Morning"
elif [ $i -ge 9 -a $i -lt 16 ] ; then echo "Good Afternoon"
elif [ $i -ge 16 -a $i -lt 19 ] ; then echo "Good Evening" 
  else echo "Good Night"
fi

#use this is ~/.bashrc in mirage 



