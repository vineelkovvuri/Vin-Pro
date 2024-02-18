/*program to find the greatest and the least elements of the given matrix*/
#include<stdio.h>
main()
{
int a[20][20],i,j,m,n,x,y;
printf("\nEnter the order:");
scanf("%d%d",&m,&n);
printf("\nEnter the elements:\n");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
x=a[0][0];y=a[0][0];
for(i=0;i<m;i++)
for(j=0;j<n;j++)
{if(x<a[i][j]){x=a[i][j];}
 if(y>a[i][j]){y=a[i][j];}}
printf("The greatest element is %d\n",x);
printf("The least element is %d",y);
getch();
}
