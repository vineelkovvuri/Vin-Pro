#include<stdio.h>
void trans(int n,char x,char y,char z)
{ 
	if(n==1)printf("%c to %c\n",x,z);
	else 
	{	
		trans(n-1,x,z,y);
		printf("%c to %c\n",x,z);
		trans(n-1,y,x,z);
	}
	return;
}

int main()
{
	int n;
//printf("\nEnter the no.. of disks:");
	scanf("%d",&n);
	trans(n,'A','B','C');
	return 0;
}

