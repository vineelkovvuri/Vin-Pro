/*program to print coshx series upto 10 terms */
#include<stdio.h>
main()
{
int i,n;float s,t,x;
printf("enter n,x");
scanf("%d%f",&n,&x);
s=1;t=1;
for(i=1;i<=n;i++)
{
t=t*((x*x)/((2*i)*(2*i-1)));
	s=s+t;

}
	printf("\n the series is %f",s);
}
