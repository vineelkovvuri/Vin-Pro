
/*program to find the integral solutions to x^3+y^3+z^3=3 other than (1,1,1),(-5,4,4),(4,-5,4),(4,4,-5)*/
#include<stdio.h>
#include<math.h>
#include<conio.h>
main()
{
long int x,y,z;double t;
for(x=-50;x<=50;x++)
 for(y=-50;y<=50;y++)
   for(z=-50;z<=50;z++)
  {
   t=x*x*x+y*y*y+z*z*z;
   if(t==3)printf("\n%ld,%ld,%ld",x,y,z);
  }
getch();
}
