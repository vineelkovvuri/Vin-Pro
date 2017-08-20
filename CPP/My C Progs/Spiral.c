#include<stdio.h>
main()
{
int a,i,j,k,x[5][5],m;
printf("\nEnter the order");
scanf("%d",&m,&m);
printf("\nEnter the matrix elements:");
for(i=0;i<m;i++)
for(j=0;j<m;j++)
scanf("%d",&x[i][j]);
printf("\nTHE REURIED ARRAY IS\n");
i=0;j=0;
for(k=m;k>0;k--)
 { if(i==m-k){for(;j<m;){printf("%d ",x[i][j]);j++;}printf("j=%d ",j);}
   else if(j==m){j==m-1;for(;i<m;){++i;printf("%d ",x[i][j]);}printf("i=%d ",i);}
   else if(i==m){i=m-1;for(;j>=m-k;){--j;printf("%d ",x[i][j]);}printf("j=%d ",j);}
   else if(j==m+k-1){j=m-k;for(;i>m-k+1;){--i;printf("%d ",x[i][j]);}printf("i=%d ",i);}
 //  else if(i==m-k+1)a++;
 }
}
