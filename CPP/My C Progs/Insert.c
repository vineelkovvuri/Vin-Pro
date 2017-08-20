#include<stdio.h>
main()
{
int a[25][25],i,j,m,n,b,c,d;
printf("\n Enter the order:");
scanf("%d%d",&m,&n);
printf("\n Enter the matrix elements:");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("\nEnter the position of the element:");
scanf("%d%d",&b,&c);
printf("\n Enter the element:");
scanf("%d",&d);
a[b-1][c-1]=d;
printf("\nThe required matrix is:\n");
for(i=0;i<m;i++)
{
for(j=0;j<n;j++)
printf("%d\t",a[i][j]);
printf("\n");
}
}
