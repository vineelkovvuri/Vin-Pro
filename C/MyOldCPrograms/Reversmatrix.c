#include<stdio.h>
main()
{
int a[20][20],i,j,m,n;
printf("\n Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("\n Enter the elements");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf(" Given matrix is\n");
for(i=m-1;i>=0;i--)
{for(j=m-1;j>=0;j--)
 printf("%d\t",a[i][j]);
 printf("\n");
}
}

