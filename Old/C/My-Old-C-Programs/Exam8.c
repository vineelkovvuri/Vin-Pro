#include<stdio.h>
main()
{
int i;char x[10],*p;
printf("\nEnter the string");
scanf("%s",x);
p=x;
for(i=0;*p!='\0';p++,i++);
printf("%d",i);
getch();
return 0;
}