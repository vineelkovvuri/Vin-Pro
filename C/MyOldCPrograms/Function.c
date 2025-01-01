/*program to use functions*/
#include<stdio.h>
#include<math.h>
#define pi 3.14159
float area(float,float);
float circle(float);
main()
{
float x,y,r;
printf("enter the values of the x,y");
scanf("%f%f",&x,&y);
printf("%f\n",area(x,y));
printf("area of the circle is %f",circle(r));
}
float area(float a,float b)
{
return(.5*a*b);
}
float circle(float r)
{
printf("enter the value of r");
scanf("%f",&r);
return(pi*r*r);
} 
