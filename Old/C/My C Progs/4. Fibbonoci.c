/*program to generate fibbonaci sequence */
#include<stdio.h>
#include<conio.h>
main()
{
 int n,x,y=0,z=1;                 /* n= endof the series x=term obtained by adding the y,z every time */
 printf("\nenter n");
 scanf("%d",&n);
x=0;                              /* this is used in order to avoid warning statements for x */
for(;x<n;)
 {
  x=y+z;                           /* first the is updated to the  x */
  y=z;                             /* now y is updated by the value of z*/
  z=x;                             /* z is updated by the value of the sum obtained i.e., x */
if(x<=n)printf("%d ",x);
 }
getch();}
