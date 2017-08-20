
#include<stdio.h>
#include<string.h>
int main (int argc,char *argv[])
{

	int i,j;
	for(i = 0,j=strlen(argv[1])-1;i<j;i++,j--)
		if(argv[1][i]!=argv[1][j])break;
	i==j?printf("Palendrome"):
		 printf("Not a Palendrome");


}

