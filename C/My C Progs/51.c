/*program to calculate the sum of antidiagonal elements*/
#include<stdio.h>
main()
{
int a[10][10],i,j,m,n,s=0;
printf("Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("Enter the elements of the matrix");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("THE REQUIRED SUM IS:");
for(i=0;i<m;i++)
{j=m-i-1;
s+=a[i][j];}
printf("%d",s);
getch();
}
