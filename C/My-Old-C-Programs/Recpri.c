/* program to print 1 if x is prime and print 0 otherwise */
#include<stdio.h>
int prime(int);
main()
{
int x;
printf("Enter a number");
scanf("%d",&x);
printf("%d",prime(x));
}
int prime(int x)
{
int i,f=0;
for(i=1;i<x/2;i++)
       if(x%i==0)f++;
       if(f==1)return(1);
       else return(0);
}
