/* program to cheak weather the given matrix is unit matrix or not */
#include<stdio.h>
main()
{
int a[10][10],i,j,m,n,f=0;
printf("Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("Enter the matrix elements ");
for(i=0;i<m;i++)
{for(j=0;j<n;j++)
{scanf("%d",&a[i][j]);
 if(a[i][j]!=1)f=1;}}
if(f==0) printf("THE MATRIX IS UNIT MATRIX");
else printf("THE MATRIX IS NOT UNIT MATRIX");
getch();
}