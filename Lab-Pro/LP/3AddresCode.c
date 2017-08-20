//Program to implement '3 Address' Intermediate code generation.....
//Enter expression like a+b*c-d,a*b+c+d e.t.c and they should not contain braces....
#include<stdio.h>
#include<string.h>
main()
{
	char in[30],*p;
	char *op="*/+-",temp='A';

	printf("\nEnter a valid expression : ");
	scanf("%s",in);

	while(*op)
	{
		while(p = strchr(in,*op))
		{
			printf("\n%c=%c%c%c",temp,*(p-1),*p,*(p+1));
			*(p-1) = temp++;
			while(*p = *(p+2))p++;
		}
		op++;
	}
}

/*
INPUT:
	Enter a valid expression : a+b*c-e/f
OUTPUT:	
A=b*c
B=e/f
C=a+A
D=C-B

*/
