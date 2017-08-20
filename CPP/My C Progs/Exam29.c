#include<stdio.h>
#include<string.h>
main()
{
int i,k;
char x[25],y[10],*p;
printf("\nEnter the 1st string:");
scanf("%s",x);
printf("\nEnter the 2nd string:");
scanf("%s",y);
k=strlen(x);
p=y;
for(i=0;*p!='\0';i++,p++)
x[k+i]=*p;
printf("%s",x);
getch();
return 0;
}