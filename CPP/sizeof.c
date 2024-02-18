#include<stdio.h>

#define sizeof(t) ((t*)0 + 1)

int main()
{
	printf("%d",sizeof(double));
}


