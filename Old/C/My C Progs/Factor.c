/*program split the given number in to its prime factors*/
#include<stdio.h>
main()
{
int t,n,i;
printf("\nEnter a number");
scanf("%d",&n);
t=n;i=2;
for(;i<=n;i++)
if(t%i==0){printf("%d ",i);t/=i;i=1;}
}
