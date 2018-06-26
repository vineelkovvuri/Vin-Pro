/* program to produce transpose of a given matrix */
#include<stdio.h>
main()
{
int a[20][20],b[20][20],i,j,m,n;
printf("\nEnter the order of the matrix ");
scanf("%d%d",&m,&n);
printf("\nEnter the matrix elements ");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("the transpose of the given matrix is\n");
for(i=0;i<n;i++)
{
for(j=0;j<m;j++)
{
b[i][j]=a[j][i];
printf("%3d",b[i][j]);
}
printf("\n");
}
getch();
}
