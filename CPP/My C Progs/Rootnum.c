/* program to calculate the root of a given number */
#include<stdio.h>
main()
{
float n,i=1,j;
printf("\nEnter n");
scanf("%f",&n);
for(j=0;j<15;j++)
 i=(2*n)/(i+(n/i));
printf("\nthe square root of %f is %f",n,i);
}
