#include<stdio.h>
#include<math.h>
//int redmat(int ,int[][10],int);
main()
{
int s=0,x[10][10],i,j,m;
printf("\nEnter the order:");
scanf("%d%d",&m,&m);
printf("\nEnter the elements:");
for(i=0;i<m;i++)
for(j=0;j<m;j++)
 scanf("%d",&x[i][j]);
for(j=0;j<m;j++)
 s+=x[0][j]*(int)pow(-1,j)*redmat(j,x,m);
printf("%d",s);
}
redmat(int a,int x[][10],int m)
{
  int i=0,j,s=0,l=0,k=0,y[5][5]; 
   for(i=1;i<m;i++)
   {for(j=0;j<m;j++)
    if(j!=a){y[l][k]=x[i][j];++k;}
    k=0;++l;}--l;
 if(l==0)return y[0][0];
for(j=0;j<=l;j++)
s+=y[0][j]*(int)pow(-1,j)*redmat(j,y[5],l+1);
return s;
}
