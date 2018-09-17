/* checking weather the given number is prime or not */
#include<stdio.h>
main()
{

int i,n,f=0;                                   /* i for numbers to run from one to given number n=entered number */
printf("\n enter n");
scanf("%d",&n);
 for(i=1;i<=n/2;i++)                           /* i runs from one to the n inorder
			                                   to divide the n by each number up to n */
  if(n%i==0)f++;                               /* if i divieds n f becomes 1 and so on */
  if(f==1)printf("%d is prime",n);             /* if the number is divided by only one
				                               number up to n/2 then it is a prime number */
  else printf("%d is not prime",n);
getch();
}
