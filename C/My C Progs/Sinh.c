/* program to generate sinhx up to seven digits accuracy */
#include<stdio.h>
#include<conio.h>
main()
{
 int i;float t,s,x;
 printf("\nenter x");       /* x= the variable */
 scanf("%f",&x);
 s=x;t=x;                /* since first term is x and there fore s=x */
 for(i=1;;i++)
  {
   t=t*(x*x)/(2*i*(2*i+1));
   s+=t;
   if(t<1.0e-7)break;
  }
 printf("the value of sinh%f is %f",x,s);
getch();
}
