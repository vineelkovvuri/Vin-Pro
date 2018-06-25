/*program to calculate the area of a function by simpson 3/8rule*/
#include<stdio.h>
#include<math.h>
main()
{
   float x,y1=0,y2=0,m,n,s;
     printf("Enter the limits of integration:");
     scanf("%f%f",&m,&n);
   for(x=m+.00001;x<n;x+=.00001)
     y1+=sin(x);
   for(x=m+.00003;x<n;x+=.00003)
     y2+=sin(x);
   s=(3*.00001/8)*(sin(m)+sin(n)+3*y1-y2);
   printf("THE AREA IS %f",s);
getch();
}
