/*program to produce the sum of elements of all 2x2 matrices of a given matrix*/
#include<stdio.h>
main()
{
int a[50][50],i,j,k,l,m,s,c=0;
printf("\nEnter the order:");
scanf("%d%d",&m,&m);
printf("\nENTER THE ELEMENTS:");
for(i=0;i<m;i++)
for(j=0;j<m;j++)
scanf("%d",&a[i][j]);
for(k=0;k<m;k+=2)
for(l=0;l<m;l+=2)
{
s=0;
for(i=k;i<k+2;i++)
for(j=l;j<l+2;j++)
s+=a[i][j];
printf("\n%d sum is %d",++c,s);
}
}
