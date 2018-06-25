/* program to calculate 1+2+3+4+.......n */
#include<stdio.h>
main()
{
int i,n,t=0;
printf("\n Enter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
t+=i;
printf("%d",t);
}

