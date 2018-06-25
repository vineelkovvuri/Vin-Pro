/*program to count the number of odd integers below a number*/ 
#include<stdio.h>
main()
{
int i,k=0,n;
printf("\nEnter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
{
if(i%2!=0)k++;
}
printf("%d",k);
}

