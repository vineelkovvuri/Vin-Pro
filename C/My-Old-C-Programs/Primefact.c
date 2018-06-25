/*
  Name: prime factors
  Copyright: 
  Author: vineel        
  Date: 26/05/05 22:04
  Description: 
*/
#include<stdio.h>
#include<conio.h>
main()
{
 int n,i;
printf("\nEnter n");
scanf("%d",&n);
for(i=2;i<=n;)
 if(n%i==0){printf("%d ",i); n/=i;i=2;}
 else i++;
getch();
}
