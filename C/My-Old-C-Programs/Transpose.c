/*program to perform transpose with out using another matrix*/
#include<stdio.h>
main()
{
int x[10][10],i,j,k,m,n;
printf("\nEnter the order of the matrix");
scanf("%d%d",&m,&n);
if(m>n)k=m;else if(m<n)k=n;else k=m;
printf("\nEnter the matrix elements");
for(i=0;i<k;i++)
for(j=0;j<k;j++)
{if(m>n){if(j>=n)x[i][j]=0;else scanf("%d",&x[i][j]);}
  else if(m<n) {if(i>=m)x[i][j]=0;else scanf("%d",&x[i][j]);}
  else scanf("%d",&x[i][j]);}
printf("\nThe transpose of the given matrix is \n");
for(i=0;i<k-1;i++)
for(j=1;j<k;j++)
if(i<j){x[i][j]=x[i][j]+x[j][i];
    x[j][i]=x[i][j]-x[j][i];
    x[i][j]=x[i][j]-x[j][i];}
for(i=0;i<n;i++)
{for(j=0;j<m;j++)
 printf("%d\t",x[i][j]);
 printf("\n");}
getch();}
