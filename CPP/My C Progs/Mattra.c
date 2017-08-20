#include<stdio.h>
main()
{
int a[10][10],i,j,m,n;
printf("\n Enter the matrix order ");
scanf("%d%d",&m,&n);
printf("\nEnter the matrix elements");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("\n THE TRANSPOSE OF THE GIVEN MATRIX IS \n");
for(i=0;i<n;i++)
{for(j=0;j<m;j++)
printf("\t%d",a[j][i]);
printf("\n");}
}

