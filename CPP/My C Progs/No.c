#include<stdio.h>
main()
{
register int i,j,k,l;
for(i=1;i<10;i++)
for(j=1;j<10;j++)
for(k=1;k<10;k++)
for(l=1;l<10;l++)
if(i+j+k==l)printf("%d %d %d %d\n",i,j,k,l);
}
