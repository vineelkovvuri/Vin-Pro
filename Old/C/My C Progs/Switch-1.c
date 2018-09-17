#include<stdio.h>
#include<math.h>
#define pi 4*atan(1)
#define al 7.92e-3
#define si 5.67e-8
main()
{
double p,a,b,x,y,z,m;
int c;
printf("\n1:(ax+b)/(ax-b)");
printf("\n2:2.5logx+cos(32)+abs(x*x-y*y)+sqrt(2xy)");
printf("\n3:1/(al*sqrt(2*pi)*exp(p*p)");
printf("\nEnter your choice");
scanf("%d",&c);
switch(c)
{
case 1:
printf("\nEnter a,b,x");
scanf("%lf%lf%lf",&a,&b,&x);
z=(a*x+b)/(a*x-b);
printf("%lf",z);
break;
case 2:
printf("\nEnter x,y");
scanf("%lf%lf",&x,&y);
z=2.5*log10(x)+cos(32*pi/180)+abs(x*x-y*y)+sqrt(2*x*y);
printf("%lf",z);
break;
case 3:
printf("\nEnter x,m");
scanf("%lf%lf",&x,&m);
p=x-(m/(sqrt(2*si)));
z=1/(al*sqrt(2*pi)*exp(-p*p));
printf("%lf",z);
break;
}
}
