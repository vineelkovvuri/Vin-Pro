#include<stdio.h>
#include<conio.h>
#include<math.h>
main()
{
int i;float x,y;
clrscr();
for(i=.1;i<5;i+=.1)
{ if((cos(i)-i)*(cos(i+.1)-i-.1)<0)
  { x=i;
     for(;;)
      {  y=x-(cos(x)-x)/(-sin(x)-1);
	 x=y;
	 if(cos(x)-x<=.000001)break;
      }
  }
}
printf("\n%f,%d",y,i);
getch();
}