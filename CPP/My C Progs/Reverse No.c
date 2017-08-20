/*
  Name: program to generate reverse of the given number  
  Author:vineel 
  Date: 28/05/05 14:19
*/
#include<stdio.h>
#include<conio.h>
main()
{int n,s=0;
 printf("\nEnter n:");
 scanf("%d",&n);
for(;n;)
 {s=10*s+n%10;n/=10;}
printf("\nthe reverse of the given number is  %d",s);
getch();
 }
