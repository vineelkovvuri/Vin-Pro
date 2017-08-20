#include<stdio.h>
float poly(float,int);
main()
{
int n;float x;
printf("\nEnter the degree");
scanf("%d",&n);
printf("\nEnter a value in b/w 0,1");
scanf("%f",&x);
poly(x,n);
}
float poly(float x,int n)
{
if(n==0)return 1;else if(n==1) return x;
else return (((2*n-1)/n)*poly(x,n-1)-((n-1)/n)*poly(x,n-2));
}
