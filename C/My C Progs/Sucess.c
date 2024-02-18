#include<stdio.h>
#include<math.h>
float f(float x)
{ return (x*x+4*x-12);
}
float g(float x)
{return f(x)+x;}
main()
{
float x;
printf("\nEnter the guess:");
 scanf("%f",&x);
      for(;fabs(f(x))>=1.e-6;)
        x=g(x);
 if(isinf(x)==0)printf("\n%f",x);
 else printf("Guess point is not converging try again....!");
}
