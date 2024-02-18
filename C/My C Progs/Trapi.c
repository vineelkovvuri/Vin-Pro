/**************************************************
                    TRAPEZOIDAL
**************************************************/
#include<stdio.h>
#include<math.h>
 float f(float x)
 {return x*x;}
main()
{ float i,x1,x2,h,s=0;
  printf("\nEnter the boundaries:");
  scanf("%f%f",&x1,&x2);
  printf("\nEnter the length of the interval:");
  scanf("%f",&h);
  for(i=x1+h;i<x2;i+=h)
  s+=f(i);
  s=2*s+f(x1)+f(x2); 
printf("\nThe area is %f",h*s/2.);
} 
 
