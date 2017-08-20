/*PROGRAM TO PRINT WEATHER THE GIVEN MATRIX IS SYMMETRIC ARE NOT*/
#include<stdio.h>
#include<conio.h>
main()
{
int a[10][10],i,j,m,n,f=0;
printf("Enter the order of the matrix ");
scanf("%d%d",&m,&n);
printf("Enter the matrix elements");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
for(i=1;i<m&&f==0;i++)
for(j=0;j<i;j++)
if(a[i][j]!=a[j][i]){f=1;break;}
if(f==1)printf("THE MATRIX IS NOT SYMMETRIC");
else printf("THE MATRIX IS SYMMETRIC");
getch();
}
