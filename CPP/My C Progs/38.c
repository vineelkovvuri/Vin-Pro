/* program to evaluate the following expressions */
#include<stdio.h>
#include<math.h>
#include<conio.h>
#define pi 4*atan(1)
main()
{

float a,x,b,m,y,alpha,sigma,z; int c;
clrscr();
printf("\n1:(ax+b)/(ax-b)");
printf("\n2:2.5logx+cos32*+abs(x*x+y*y)+sqrt(2xy)");
printf("\n3:1/(alpha*sqrt(2*pi)*exp(-(x-m/(sqrt(2sigma)))*(x-m/(sqrt(2sigma)))))");
printf("\nEnter your choice");
scanf("%d",&c);
 if(c>0){printf("\nChoice is incorrect enter once again");
	scanf("%d",&c);}
 if(c==1){printf("\nEnter a,x,b");
	  scanf("%f%f%f",&a,&x,&b);}
 else if(c==2){printf("\nEnter x,y");
	      scanf("%f%f",&x,&y);}
 else if(c==3){printf("\nEnter alpha,sigma,x,m");
	       scanf("%f%f%f%f",&alpha,&sigma,&x,&m);}
switch(c)
{
 case 1:
 z=(a*x+b)/(a*x-b);
 printf("\n%f",z);
 break;
 case 2:
 z=2.5*log10(x)+cos(32*pi/180)+abs(x*x+y*y)+sqrt(2*x*y);
 printf("\n%f",z);
 break;
 case 3:
 z=1/(alpha*sqrt(2*pi)*exp(-(x-m/(sqrt(2*sigma)))*(x-m/(sqrt(2*sigma)))));
 printf("\n%f",z);
 break;
}
getch();
}