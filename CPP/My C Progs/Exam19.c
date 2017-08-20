#include<stdio.h>
main()
{
char x[10],y[10],*p,*q;int i,f=0;
printf("\nEnter the 1st string");
scanf("%s",x);
printf("\nEnter the 2nd string");
scanf("%s",y);
p=x;q=y;
for(;*p!='\0'&&*q!='\0'&&f==0;)
{if(*p==*q){p++;q++;}
 else f=1;
}
if(f==0)printf("\nBoth strings are same");
else printf("\nBoth strings are not same");
getch();
return 0;
}


