#include<stdio.h>
#include<conio.h.>
  main()
{
char *p,i,x[10],y[10];
printf("\nEnter the 1st string");
scanf("%s",x);
p=x;
for(i=0;*p!='\0';i++)
  { y[i]=*p;p++;}
printf("\n%s",y);
getch();
return(0);
}
