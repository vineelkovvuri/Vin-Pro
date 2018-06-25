#include<stdio.h>
main()
{
int a[10][10],i,j,m,f=0;
printf("\nEnter the order of the matrix ");
scanf("%d",&m);
printf("\nEnter the matrix elements ");
 for(i=0;i<m;i++)
 for(j=0;j<m;j++)
 scanf("%d",&a[i][j]);
 for(i=0;i<m&&f==0;i++)
 {for(j=0;j<i;j++)
 if(a[i][j]!=a[j][i])f=1;break;}
 if(f==1)printf("THE MATRIX IS NOT SYMETRIC");
 else printf("THE MATRIX IS SYMETRIC");
}
