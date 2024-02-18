/*program to draw the graph of sinx */
#include<stdio.h>
#include<math.h>
#include<conio.h>
float f(float x)
{
      return(sin(x)-x);
      }
main()
{
float x,y,i;
system("cls");
for(x=0;x<=10;x+=.16)
{ y=f(x);
    if(y>=0){
	     printf("\n");
	     for(i=0;i<=38;i++)
	     printf(" ");
	     printf("|");
	     for(y=0;y<=f(x);y+=.04)
	     printf("*");
	    }
     else {
	   printf("\n");
	   for(y=0;y<=38+25*f(x);y+=1)
	   printf(" ");
	   for(y=f(x);y<=0;y+=.04)
	   printf("*");
	   printf("|");
	  }
}
getch();
}
