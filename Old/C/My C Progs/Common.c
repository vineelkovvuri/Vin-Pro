#include"stdio.h"
#include<conio.h>
main()
{
int x[5]={1,2,3,4,5},y[4]={2,5,7,8},i,j;
clrscr();
for(i=0;i<4;i++)
for(j=0;j<5;j++)
 if(y[i]==x[j])printf("%d ",y[i]);
 getch();
 return 0;
 }