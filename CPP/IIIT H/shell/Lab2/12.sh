
s=$1

ext=${s##*.}

if [ $ext == "sh" ]
then
	sed 's/#.*//g' $1 
elif [ $ext == "c" -o  $ext == "cpp" ]
then
	sed 's/\/\/.*//g' $1 	
fi


