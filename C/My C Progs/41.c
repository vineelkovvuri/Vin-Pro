/*program to display a matrix*/
#include<stdio.h>
main()
{
int a[20][20],i,j,m,n;
printf("\n Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("\n Enter the matrix elements");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("the given matrix is\n");
for(i=0;i<n;i++)
{
for(j=0;j<m;j++)
printf("\t%d",a[i][j]);
printf("\n");
}
getch();
}
