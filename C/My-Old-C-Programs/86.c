/*program calculate factorial of number by recurence*/
#include<stdio.h>
int fact(int);
main()
{
int n;
printf("\nEnter the number:");
scanf("%d",&n);
printf("\nfactorial of %d is %d",n,fact(n));
getch();
}
int fact(int n)
{
if(n==0)return 1;
else return n*fact(n-1);
}
