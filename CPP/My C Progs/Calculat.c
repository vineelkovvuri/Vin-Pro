#include<stdio.h>
#include<conio.h>
main()
{
float x,y;char c,q,a;
//while(1)
{ clrscr();
 printf("Enter the operand:\n");
 scanf("%f",&x);
 printf("Enter the operator:\n");
 scanf("%c",&c);
 printf("Enter the operand:\n");
 scanf("%f",&y);
 switch(c)
 {case '+':printf("%f",x+y);break;
  case '-':printf("%f",x-y);break;
  case '*':printf("%f",x*y);break;
  case '/':printf("%f",x/y);break;
  case 'q':exit(1);
 }
}
getch();
return 0;
}