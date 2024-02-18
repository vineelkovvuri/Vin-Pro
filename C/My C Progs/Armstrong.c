/* program to generate armstrong number */
#include<stdio.h>
#include<conio.h>
main()
{
int s,n,t,d;
clrscr();
for(n=1;n<=32000;n++)
 {
   t=n;s=0;       /*for the next for loop t should be used but not n for
		  evalution because if we use n then for every change in the
		  value of n will also change t so we can not campare at
		  the last*/
   for(;;)
  {
   d=t%10;
   s+=d*d*d;
   t/=10;
   if(t==0)break;
  }
 if(n==s)printf("\narmstrong number %d",n);
 }
getch();
}
