#include<stdio.h>
main()
{
int a[25][25],i,j,m,s=0;
printf("\n Enter the order:");
scanf("%d%d",&m,&m);
printf("\nEnter the elements of the matrix:");
for(i=0;i<=m;i++)
for(j=0;j<=m;j++)
{if(i==m||j==m)a[i][j]=0;
else scanf("%d",&a[i][j]);}
printf("\n The required matrix is:\n");
for(i=0;i<m;i++)
{for(j=0;j<m;j++)
s+=a[i][j];
a[i][j]=s;s=0;}
for(j=0;j<m;j++)
{for(i=0;i<m;i++)
s+=a[i][j];
a[i][j]=s;s=0;}
for(i=0;i<=m;i++)
{for(j=0;j<=m;j++)
printf("%d\t",a[i][j]);
printf("\n");
}
}
