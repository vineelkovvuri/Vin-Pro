/*progrom to check weather the given matrix is upper triangle matrix or not*/
#include<stdio.h>
main()
{
int x[8][8],i,j,k=0,m,n;
printf("\nEnter the order:");
scanf("%d%d",&m,&n);
printf("\nEnter the elements:");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
{scanf("%d",&x[i][j]);
if(i>j&&x[i][j]!=0)++k;}
if(k==0)printf("\nThe matrix is upper triangle matrix");
else printf("\nThe matrix is not upper triangle matrix");
getch();
}
