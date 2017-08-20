/*sum of all even numbers below a number*/
#include<stdio.h>
main()
{
int i,s=0,n;
printf("\nEnter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
{
if(i%2==0)s+=i;
}
printf("%d",s);
}

