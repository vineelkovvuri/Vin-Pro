/*program to perform matrix addition(subtraction)*/
#include<stdio.h>
main()
{
int a[20][20],b[20][20],c[20][20],i,j,m,n;
printf("\n Enter the order of the matrices(i.e.,both orders are equal) ");
scanf("%d%d",&m,&n);
printf("\nEnter the elements of the first matrix ");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("\nEnter the elements of the second matrix ");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&b[i][j]);
printf("\n THE MATRIX ADDITION IS \n");
for(i=0;i<m;i++)
{
for(j=0;j<n;j++)
{
c[i][j]=a[i][j]+b[i][j];
printf("%3d",c[i][j]);
}
printf("\n");
}
getch();
}