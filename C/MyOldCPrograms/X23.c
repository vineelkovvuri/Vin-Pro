/*program to create graphs of sum elementry functions*/
#include<stdio.h>
#include<math.h>
#include<conio.h>
main()
{
double x,y,l;
for(x=0;x<=1;x+=.04)
 {
  l=x*(sqrt((1-x)/(x+1)));
  y=l;
  if(y>0)
   {
       for(y=0;y<=l;y+=.01)
       printf(".");
   }
  if(y<0)
   {
       for(y=0;y>=l;y-=.01)
       printf("*");
   }
  if(y==0)
       printf("%lf",x);
 printf("\n");
 }
getch();
}
