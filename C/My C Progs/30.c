/*program to produce perfect numbers */
#include<stdio.h>
main()
{
long unsigned s,l,n,x,y;
printf("\nenter n");
scanf("%lu",&n);
for(x=1;x<=n;x++)
{
s=0;
for(y=1;y<x;y++)
{
l= x%y;
if(l==0)s+=y;
}
if(s==x)printf("%lu\n",x);
}
getch();
}

