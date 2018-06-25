#include<stdio.h>
#include<math.h>
main()
{
long int i,x,n1;int d;double n;
printf("\nEnter the number:");
scanf("%lf",&n);
printf("\nEnter the number of decimal places:");
scanf("%d",&d);
n1=(int)(n*pow(10,d));
x=(int)pow(10,d);
for(i=2;i<=n1&&i<=x;)
{if(n1%i==0&&x%i==0){n1/=i;x/=i;i=2;}
 else i++;}
printf("%0.15lf=%ld/%ld",n,n1,x);
}

