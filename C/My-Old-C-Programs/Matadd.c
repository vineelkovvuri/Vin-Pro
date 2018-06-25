#include<stdio.h> 
main()
{ int a[10][10],b[10][10],c[10][10],i,j,m,n;
  printf("\nEnter the orders of the matrix(i.e.,both orders are same) ");
  scanf("%d%d",&m,&n);
  printf("\nEnter the elements of the first matrix ");
  for(i=0;i<m;i++)
  for(j=0;j<n;j++)
  scanf("%d",&a[i][j]);
  printf("\nEnter the elements of the second matrix ");
  for(i=0;i<m;i++)
  for(j=0;j<n;j++)
  scanf("%d",&b[i][j]);
  printf("\n THE MATRIX ADDITION IS\n");
  for(i=0;i<m;i++)
  {for(j=0;j<n;j++)
    { c[i][j]=a[i][j]+b[i][j];
      printf("\t%d",c[i][j]);
    }
    printf("\n");
  }
}
