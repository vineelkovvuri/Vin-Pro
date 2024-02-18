/* program to perform mean, variance,standard deviation*/
#include<stdio.h>
#include<math.h>
main()
{
float x[50],a=0,s=0;int i,n;
printf("\nEnter the number of elements:");
scanf("%d",&n);
printf("\nEnter the elments:\n");
for(i=0;i<n;i++)
scanf("%f",&x[i]);
for(i=0;i<n;i++)
a+=x[i];
a=a/n; printf("The mean is %f\n",a);
for(i=0;i<n;i++)
s+=(a-x[i])*(a-x[i]);
s=s/n;printf("The variance is %f\n",s);
s=sqrt(s);
printf("The standard deviation is %f",s);
getch();
}
