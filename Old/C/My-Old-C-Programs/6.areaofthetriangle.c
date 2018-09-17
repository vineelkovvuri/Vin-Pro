/* program to calculate area ofa triangle */
#include<stdio.h>
#include<conio.h>
#include<math .h>
main()
{
float s,a,b,c,l;
 printf("\nenter a,b,c");
 scanf("%f%f%f",&a,&b,&c);
 s=(a+b+c)/2;
 l=sqrt(s*(s-a)*(s-b)*(s-c));
 printf("\nthe area is %f",l);
getch();
}
