/* program to calculate the area of a given function by simpson's 1/3rule */
#include<stdio.h>
#include<math.h>
main()
{
float x,y1=0,y2=0,m,n,s;
printf("\nEnter the limits of integration:");
scanf("%f%f",&m,&n);
for(x=m+.0001;x<n;x+=.0002)
y1+=sin(x);
for(x=m+.0002;x<n;x+=.0002)
y2+=sin(x);
s=(.0001/3)*(sin(m)+sin(n)+4*y1+2*y2);
printf("THE AREA IS %f",s);
getch();
}
