/*
  Name: program to generate palendromes 
  Copyright: 
  Author: 
  Date: 13/06/05 00:21
  Description: 
*/
 
#include<stdio.h>
#include<conio.h>
main()
{
  int t,s=0,n,i;
printf("\nEnter n:");
scanf("%d",&n);
  for(i=0;i<=n;i++)
   {
    t=i;s=0;
    while(t)   /* here t should be used but not i*/
     {
       s=10*s+t%10;
       t/=10;
     }
    if(i==s)printf("\n%d is palendrome",i);
   }
getch();
}
