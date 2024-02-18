/*program to produce magic square desired order*/
#include<stdio.h>
main()
{
int x[50][50],i,j,a=1,m;
 printf("enter the order of the square:");
 scanf("%d",&m);
 for(i=0;i<m;i++)
 for(j=0;j<m;j++)
 x[i][j]=0;
 j=(m-1)/2;
 for(i=0;a<=m*m;i--)
 {
 if(i>=0&&j>=0){if(x[i][j]==0)x[i][j]=a;else {i+=2;j+=1;x[i][j]=a;}}
 if(i<0&&j>=0){i=m-1;{if(x[i][j]==0)x[i][j]=a;else {i+=2;j+=1;x[i][j]=a;}}}
 if(i>=0&&j<0){j=m-1;{if(x[i][j]==0)x[i][j]=a;else {i+=2;j+=1;x[i][j]=a;}}}
 if(i<0&&j<0){i+=2;j+=1;{if(x[i][j]==0)x[i][j]=a;else {i+=2;j+=1;x[i][j]=a;}}}
 ++a;j--;
 }
 printf("THE MAGIC SQUARE IS\n");
 for(i=0;i<m;i++)
 {
 for(j=0;j<m;j++)
 printf("%4d",x[i][j]);
 printf("\n");
 }
 getch();
}
