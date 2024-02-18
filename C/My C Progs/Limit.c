#include<stdio.h>
float f(float);
main()
{
float x,i;int j;
printf("\n Enter the point at which you want to find the limit\n");
scanf("%f",&x);
printf("\nNumber of limit values around %f you want\n",x);
scanf("%d",&j);
printf("\nThe limit values from left neighbourhood are\n");
for(i=x-j*1e-4;i<x;i+=1e-4)
printf("%f\n",f(i));
printf("\nThe limit values from right neighbourhood are\n"); 
for(i=x+j*1e-4;i>x;i-=1e-4)
printf("%f\n",f(i));
}
float f(float x)
{
return((exp(x)-1)/x);
}
