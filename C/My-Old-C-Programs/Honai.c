#include<stdio.h>
trans(int ,char,char,char);
main()
{
	int n;
	printf("\nEnter the no.. of disks:");
	scanf("%d",&n);
	trans(n,'a','b','c');
	return 0;
}
void trans(int n,char x,char y,char z)
{ 
	if(n==1)printf("\nMove disc %d from %c to %c ",n,x,z);
	else 
	{	
		trans(n-1,x,z,y);
		printf("\nMove disc %d from %c to %c ",n,x,z);
		trans(n-1,y,x,z);
	}
	return  ;
}
