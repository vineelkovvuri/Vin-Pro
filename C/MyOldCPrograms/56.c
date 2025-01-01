/* program to check weather the given matrix is identity matrix are not */
#include<stdio.h>
main()
{
int a[10][10],i,j,m,n,f=0,g=0;
printf("Enter the order of the matrix");
scanf("%d%d",&m,&n);
printf("Enter the elements of the matrix");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
for(i=0;i<m&&f==0;i++)
{j=i;
if(a[i][j]!=1)f=1;break;}
for(i=1;i<m&&g==0;i++)
for(j=0;j<i;j++)
if(a[i][j]!=0||a[j][i]!=0){g=1;break;}
if(f==0&&g==0)printf("THE MATRIX IS IDENTITY");
else printf("THE MATRIX IS NOT IDENTITY");
getch();
}
