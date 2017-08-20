/* program to convert co-ordinate systems */
#include<stdio.h>
#include<math.h>
main()
{
float x,y,r,t;int c;
printf("\n1.conversion from retangle to polar.\n2.conversion from polar to rectangle.\nenter the appropriate choice:");
scanf("%d",&c);
switch(c)
	{
	case 1:
	printf("\nenter the value of x,y");
	scanf("%f%f",&x,&y);
	r=(x*x)+(y*y);
	r=sqrt(r);
	t=atan2(y,x);
	printf("\nthe r,theta values are %f %f",r,t);
	break;
	case 2:
	printf("\nenter the values of r,theta in radians");
	scanf("%f%f",&r,&t);
	x=r*cos(t);
	y=r*sin(t);
	printf("\nthe x,y values are %f %f",x,y);
	break;
	}
getch();
}