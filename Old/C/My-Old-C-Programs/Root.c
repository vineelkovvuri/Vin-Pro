/*program to calculate the roots of a eqution*/
#include<stdio.h>
#include<math.h>
float f(float);
main()
{
float i,a,b,c=1,n;
printf("\nEnter a,b:");
scanf("%f%f",&a,&b);
for(i=a;i<=n&&c!=.00001;i+=c)
if(f(i)*f(i+c)<0){a=i;n=i+1;c=c/10.;}
printf("\n%f",i-1);
}
float f(float x)
{
return((x-2.3)*(x-5.4));
}
