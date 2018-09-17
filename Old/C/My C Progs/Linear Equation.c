/* program to solve linear equations */
#include<stdio.h>
main()
{
float a1,b1,c1,a2,b2,c2,x,y,d;
printf("\nenter a1,b1,c1,a2,b2,c2 \nassuming the equation is of the form ax+by=c:");
scanf("%f%f%f%f%f%f",&a1,&b1,&c1,&a2,&b2,&c2);
d=a1*b2-a2*b1;
if(d==0)printf("lines are parallel so no point of intersection");
y=-(c1*a2-a1*c2)/d;
x=-(b1*c2-b2*c1)/d;
printf("x=%f\ny=%f",x,y);
getch();
}