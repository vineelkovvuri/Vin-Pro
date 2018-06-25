#include<stdio.h>
int redmat(int ,int ,int ,int [][]);
main()
{
int m,a,b,i,j,x[10][10],y[10][10];
printf("\nEnter the order ");
scanf("%d%d",&m,&m);
printf("\nEnter the elements");
for(i=0;i<m;i++)
for(j=0;j<m;j++)
scanf("%d",&x[i][j]);
printf("\nEnter the row,colum");
scanf("%d%d",&a,&b);
// for(i=0;i<m-1;i++)
  // {for(j=0;j<m-1;j++)
    // {y[i][j]=redmat(m,a,b,x);
   /*printf("%d ",y[i][j]);}}*/
  redmat(m,a,b,x);
}
int redmat(int m,int a,int b, int x[10][10])
{
int i,j,l=0,k=0,y[6][6];
  for(i=0;i<m;i++)
   {for(j=0;j<m;j++)
     if(i!=a-1){if(j!=b-1){y[l][k]=x[i][j];k++;}}
     if(k==m-1){k=0;l++;}
   }
  //for(i=0;i<m-1;i++)
   //{for(j=0;j<m-1;j++)
     //printf("%d\t",y[i][j]);
     //printf("\n");
   //}
}

