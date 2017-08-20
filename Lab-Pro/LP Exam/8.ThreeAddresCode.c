//Program to implement '3 Address' Intermediate code generation.....
//Enter expression like a+b*c-d,a*b+c+d e.t.c and they should not contain parentheses....
#include<stdio.h>
#include<string.h>
#include<conio.h>
main()
{
	char in[30],*p,*op="*/-+";
	int temp=0;
	clrscr();
	printf("\nEnter a valid expression : ");
	scanf("%s",in);

	printf("\nno. operand op1   op2   result");
	printf("\n------------------------------");
	while(*op)
	{
		while(p = strchr(in,*op))
		{
			printf("\n%-5d %-5c %-5c %-5c %-5c",temp,*p,*(p-1),*(p+1),'A'+temp);
			*(p-1) = 'A'+temp;
			temp++;
			while(*p = *(p+2))p++;
		}
		op++;
	}
	getch();
}

/*
INPUT:
Enter a valid expression : a+b*c-e/f
OUTPUT:
no. operand op1   op2   result
------------------------------
0     *     b     c     A    
1     /     e     f     B    
2     -     A     B     C    
3     +     a     C     D    

*/



