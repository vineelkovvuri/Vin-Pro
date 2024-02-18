//program to convert binary number to decimal
#include<stdio.h>
int main()
{
	char str[100],*p;
	long dec=0;
	printf("\nEnter the binary string:");
	scanf("%s",str);
	for(p=str; *p != '\0'; p++){
		if(*p >= '0' && *p <= '9') dec = 2*dec + (*p - '0') ;
		else if(*p >= 'a' && *p <= 'f') dec = 2*dec + (10 + (*p - 'a') ) ;
	}
	printf("\nBin: %s => Dec: %ld",str,dec);		
}	

