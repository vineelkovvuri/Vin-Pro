/**************************************************
                  NEWTON-RAPHSON
**************************************************/
#include<stdio.h>
#include<math.h>
float f(float x)
{ return (cos(x)-x);
}
float d(float x)
{float k;
   k=(f(x+.00001)-f(x))/.00001; 

  return k;
}
main()
{
float x;
printf("\nEnter the guess:");
 scanf("%f",&x);
     for(;fabs(f(x))>=1.e-6;)
        x=x-f(x)/d(x);
if(isinf(x)==0)printf("\n%f",x);
else printf("\nGuess point is not converging try again...!\n");
}
