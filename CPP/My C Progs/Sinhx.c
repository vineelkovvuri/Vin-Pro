/*program to print sinhx with given accuracy */
#include<stdio.h>
main()
{
int i;float t,s,x;
printf("enter x");
scanf("%f",&x);
s=x;t=x;
for(i=1;;i++)
{
t=t*(x*x)/((2*i)*(2*i+1));
s=s+t;
if(t<.0000001)break;
}
printf("the series is %f",s);
}
