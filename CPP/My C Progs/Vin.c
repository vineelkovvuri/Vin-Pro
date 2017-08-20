#include<stdio.h>
main()
{
int s=0,n,d;
int t=n;
for (n=1;n<=1000;n++)
{d=n%10;
s=s+d*d*d;
n=n/10;
if(n==0)break;}
if(t==s)printf("armstrong number %d",t);
else printf("not armstrong %d",t);
}

