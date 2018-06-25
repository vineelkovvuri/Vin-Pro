#include<stdio.h>
main()
{ float a[10][10],x[10]={0};
  int i,j,k,n,m;
  printf("\nEnter the order:");
  scanf("%d%d",&n,&m);
  printf("\nEnter the coefficients:");
  for(i=0;i<n;i++)
  for(j=0;j<m;j++)
  scanf("%f",&a[i][j]);
  for(k=0;k<15;k++)
  { printf("\n"); 
  for(i=0;i<n;i++)
   { for(j=0;j<m-1;j++)
      if(j!=i)x[i]+=x[j]*a[i][j];
      x[i]=a[i][m-1]-x[i];
    x[i]/=a[i][i];
  }
 for(i=0;i<n;i++)
 printf("\n%f",x[i]);
 }
}

  
