/*
  Name:  program to display the arrangement of numbers 
  Copyright: 
  Author: vineel
  Date: 27/05/05 12:48
  Description: 
*/  
#include<stdio.h>
#include<conio.h>
main()
{
int j,i,n,k=0;
printf("\nenter n:");
scanf("%d",&n);
  for(i=1;i<=n;i++)             /* this is for runing the numbers vertically */
   {
     for(j=1;j<=i;j++)            /* this is for runing the numbers horizantally */
      {
      k++, printf("%3d",k);         /* dispalys the number */
      }
     printf("\n");
   }
getch();
}
