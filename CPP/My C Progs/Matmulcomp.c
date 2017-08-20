/*program to calculate matrix multiplication with complex elements*/
#include<stdio.h>
main()
{ int a,b,c,i,j,k;
  printf("\nEnter the orders of both matrix:");
  scanf("%d%d%d%d",&a,&b,&b,&c);
  struct {int r;int im;}x[a][b],y[b][c],z[a][c];
  printf("\nEnter elements of the first matrix in the form of  a b for a+bi:");
  for(i=0;i<a;i++)
  for(j=0;j<b;j++)
  scanf("%d%d",&x[i][j].r,&x[i][j].im);
  printf("\nEnter elements of the second matrix in the form of a b for a+bi:");
  for(j=0;j<b;j++)
  for(k=0;k<c;k++)
  scanf("%d%d",&y[j][k].r,&y[j][k].im);
  printf("\nTHE MATRIX MULTIPLICATION\n");
  for(i=0;i<a;i++)
  { for(k=0;k<c;k++)
    { z[i][k].r=0;z[i][k].im=0;
      for(j=0;j<b;j++)
      { z[i][k].r+=(x[i][j].r)*(y[i][k].r)-(x[i][j].im)*(y[j][k].im);
        z[i][k].im+=(x[i][j].im)*(y[j][k].r)+(y[j][k].im)*(x[i][j].r);
      }
       printf("%d",z[i][k].r);if(z[i][k].im>=0)printf("+%di\t",z[i][k].im);else printf("%di\t",z[i][k].im);
    }
       printf("\n");
  }
getch();
}

