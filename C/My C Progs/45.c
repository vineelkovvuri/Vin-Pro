/*program print primes */
#include<stdio.h>
#include<conio.h>
main()
{
int i,j,s,c=0;
clrscr();
for(i=1;i<=3000;i++)
{s=0;
for(j=1;j<=i/2;j++)
if(i%j==0)s++;
if(s==1)c++,printf("%d\t",i);}
printf("number of primes %d",c);
getch();
}