/* program to calculate the radius of sphere given its volume */
#include<stdio.h>
#include<conio.h>
#include<math.h>
#define pi 4*atan(1)
main()
{
float v,r;
printf("\nenter v");
scanf("%f",&v);
r=pow((3*v)/(4*pi), 1.0/3);
printf("%f",r);
getch();
}
