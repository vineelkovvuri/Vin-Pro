#include<stdio.h>
main()
{
int a,b,c,i,j,k;
printf("\nEnter the orders of the matrix");
scanf("%d%d%d%d",&a,&b,&b,&c);
struct matrix{int r;int im;} x[a][b],y[b][c],z[a][c];
printf("\nEnter the 1st matrix elements:");
for(i=0;i<a;i++)
for(j=0;j<b;j++)
scanf("%d%d",&x[i][j].r,&x[i][j].im);
printf("\nEnter the 2nd matrix elements:");
for(j=0;j<b;j++)
for(k=0;k<c;k++)
scanf("%d%d",&y[j][k].r,&y[j][k].im);
printf("\nMATRIX MULTIPLICATION IS\n");
for(i=0;i<a;i++)
{ for(k=0;k<c;k++)
  { z[i][k].r=0;z[i][k].im=0;
    for(j=0;j<b;j++)
     {
       z[i][k].r+=x[i][j].r*y[j][k].r-x[i][j].im*y[j][k].im;
       z[i][k].im+=x[i][j].im*y[j][k].r+y[j][k].im*x[i][j].r;
     }
     printf("%d",z[i][k].r);if(z[i][k].im>=0)printf("+%di\t",z[i][k].im);else printf("%di",z[i][k].im);

  }
  printf("\n");
}
}
