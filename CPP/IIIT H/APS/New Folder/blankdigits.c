//Program to find the number of characters,spaces,digits in a file..
#include<stdio.h>
int main()
{
	int digits=0,spaces=0,chars=0,c=0;		
	FILE *fp = fopen("in.txt","r");
	if(fp!=NULL){
		do{
			c = fgetc(fp);
			if(c == ' ' || c == '\t' || c=='\n') spaces++; //Check for spaces...
			else if(c >= '0' && c <= '9')	digits++;	//Check for digits...
			else chars++; //Check for other characters
		}while(!feof(fp));
		printf("\nChars = %d\nSpaces = %d\nDigits = %d",chars,spaces,digits);
	}
}

