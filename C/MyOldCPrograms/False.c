/**************************************************
                  FLASE POSITION 
**************************************************/
#include<stdio.h>
#include<math.h>
float f(float x)
{return cos(x)-x;
}
 main()
{float a,b,x; 
  printf("\nEnter the boundaries:"); 
  scanf("%f%f",&a,&b);
 x=(a*f(b)-b*f(a)) /(f(b)-f(a));
 for(;fabs(f(x))>=1.e-4;)
  {if(f(a)*f(x)<0) x=(a*f(x)-x*f(a)) /(f(x)-f(a));
   else  x=(x*f(b)-b*f(x)) /(f(b)-f(x));
  }
printf("\n%f",x);
}

