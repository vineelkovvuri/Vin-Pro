/* program to apply switch statement */
#include<stdio.h>
#include<conio.h>
main()
{
	float a,b,c;int ch;
	clrscr();
	printf("\n1.addition");
	printf("\n2.subtraction");
	printf("\n3.division");
	printf("\n4.multiplication");
	printf("\nenter your choice");
	scanf("%d",&ch);
	if(ch>0&ch<5){printf("\nenter a,b");scanf("%f%f",&a,&b);}
	switch(ch)
	{
		case 1:
			c=a+b;
			printf("%f",c);break;
		case 2:
			c=a-b;
			printf("%f",c);break;
		case 3:
			c=a/b;
			printf("%f",c);break;
		case 4:
			c=a*b;
			printf("%f",c);break;
	}
	getch();
}
