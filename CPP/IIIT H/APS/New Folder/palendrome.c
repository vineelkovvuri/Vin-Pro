//program to verify whether the given string is palendrome are not....
#include<stdio.h>
int main()
{
	char str[100];
	int i,j;	
	printf("\nEnter the string:");
	scanf("%s",str);
	
	for(i=0,j=strlen(str) - 1 ; i < j; i++,j--)
		if(str[i] != str[j]) break;
		
	if(i < j)printf("Given string: %s is not palendrome",str);
	else printf("Given string: %s is palendrome",str);
}	
	
