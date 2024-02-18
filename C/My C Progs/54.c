/* program to print upper diagonal elements */
#include<stdio.h>
main()
{
int a[10][10],i,j,k,m,n,s;
printf("Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("Enter the elements of the matrix ");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("UPPER DIAGONAL ELEMENTS ARE\n");
for(i=0;i<m;i++)
{ for(k=i;k>0;k--)
  printf("\t");
  for(j=i+1;j<n;j++)
  printf("%d\t",a[i][j]);
  printf("\n");
}
getch();
}