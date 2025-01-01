/* program to generate coshx series */
#include<stdio.h>
main()
{
 int i,n;float s,t,x;
 printf("\nenter n x");/* n= number of terms x= variable value */
 scanf("%d%f",&n,&x);
s=1;t=1;/* since for first term the sum is 1 here t=1,s=1 */
 for(i=1;i<=n;i++) /* i for evaluating the factorial in the denominaters */
  {
   t=t*(x*x)/(2*i*(2*i-1)); /* each term */
   s+=t;     /* updating the sum */
  }
 printf("the value of cosh%f is %f",x,s);
getch();
}