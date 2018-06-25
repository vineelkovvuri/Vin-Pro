#include<stdio.h>
main()
{
int x[10][10],m,i,j,k=0,l;
printf("\nEnter the order");
scanf("%d%d",&l,&l);
printf("\nEnter the matirx elements");
for(i=0;i<l;i++)
for(j=0;j<l;j++)
scanf("%d",&x[i][j]);
printf("\nThe requried array is :");
m=l;
//for(m=l;m>=l/2;m--)
{for(j=0;j<m;j++)
 printf(" %d",x[i][j]);
 j--;
 for(i=m-l+1;i<m;i++)
 printf(" %d",x[i][j]);
 i--;
 for(j=m-2;j>=k;j--)
 printf(" %d",x[i][j]);
 j++;
 for(i=m-1;i>k;i--)
 printf(" %d",x[i][j]);
 i++;
k++;
}}
