/* program to find integral solution to 6x-9y=29 */
#include<stdio.h>
#include<conio.h>
main()
{
long int x,y,t;
for(x=-214;x<=214;x++)
{
for(y=-214;y<=214;y++)
{
t=6*x-9*y-29;
if(t==0)printf("\n%ld,%ld",x,y);
}
}
getch();
}
