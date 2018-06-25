/* program to print lower diagonal elements */
#include<stdio.h>
main()
{
int a[10][10],i,j,k,m,n;
printf("Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("Enter the elements of the matrix");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("THE LOWER DIAGONAL ELEMENTS ARE\n");
for(i=1;i<m;i++)
{for(j=0;j<i;j++)
 printf("%d\t",a[i][j]);
 printf("\n");
}
getch();
}