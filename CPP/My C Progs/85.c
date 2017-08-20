#include<stdio.h>
main()
{
int x[10][10],i,j,m,n;
printf("\nEnter the order:");
scanf("%d%d",&m,&n);
printf("\nEnter the elements\n");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&x[i][j]);
printf("\nThe transpose of the given matrix\n");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
if(i>j){x[i][j]=x[i][j]+x[j][i];
 x[j][i]=x[i][j]-x[j][i];
 x[i][j]=x[i][j]-x[j][i];}
/*else if(j>i){x[j][i]=x[i][j];} }*/
for(i=0;i<n;i++)
{ for(j=0;j<m;j++)
  printf("%d\t",x[i][j]);
  printf("\n");
}
getch();
}