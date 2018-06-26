#include<stdio.h>
main()
{
int x[10],*p,i,m,s=0;
printf("\nHow many number are you entering?");
scanf("%d",&m);
printf("\nEnter the numbers");
for(i=0;i<m;i++)
scanf("%d",&x[i]);
p=x;
for(i=0;i<m;i++)
s+=*p++;
printf("\n%d",s);
getch();
return 0;
}