/*
  Name: program to calculate factorial of a number 
   copyright: 
  Author:vineel 
  Date: 27/05/05 12:41
  Description: 
*/

#include<stdio.h>
#include<conio.h>
main()
{
 double n,i,f=1;
 printf("\nEnter n:");
 scanf("%lf",&n);
  for(i=1;i<=n;i++)
  f=f*i;
  printf("factorial of%lfis %lf",n,f);
getch();
}
