#include<stdio.h>
int redmat(int ,int ,int ,int [][10]);
main()
{
int m,s=0,i,j,x[10][10];
printf("\nEnter the order ");
scanf("%d%d",&m,&m);
printf("\nEnter the elements");
for(i=0;i<m;i++)
for(j=0;j<m;j++)
scanf("%d",&x[i][j]);
for(j=0;j<m;j++)
 s+=x[0][j]*pow(-1,i+j)*redmat(m,1,j+1,x);
printf("%d ",s);
}
int redmat(int m,int a,int b, int x[][10])
{
int i,j,s,l=0,k=0,y[m-1][m-1];
          /*this block redueces the given matrix*/
               for(i=0;i<m;i++)
               {for(j=0;j<m;j++)
                if(i!=a-1){if(j!=b-1){y[l][k]=x[i][j];k++;}}
                if(k==m-1){k=0;l++;}}
        /*upto this*/
if(l==1)return y[0][0];
else{ for(j=0;j<l;j++)
   s+=y[0][j]*pow(-1,i+j)*redmat(l,1,j+1,y);
   return s;}
}

