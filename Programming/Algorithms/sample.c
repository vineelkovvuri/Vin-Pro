#include<stdio.h>


void print(int n)
{
	int i=0;
	
	printf("\n");
	for(i=15;i>0;i--)
		printf("%d",n>>i)&1);
		
}


int main()
{
	
}