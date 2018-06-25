/*
  Name: program to give lucky number
  Copyright: 
  Author: 
  Date: 31/05/05 15:37
  Description: 
*/
#include<stdio.h>
#include<conio.h>
main()
{
int t,s=0,n;
printf("\nEnter n:");
scanf("%d",&n);
  for(;n;)
   {
    s+=n%10;n/=10;
    if(n==0&s<=9){printf("the lucky number is %d",s);break;}
    else if(n==0&s>9){ n=s;s=0;}
       }
getch();
}
