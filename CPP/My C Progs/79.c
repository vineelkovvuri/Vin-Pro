/*program to insert an element in to the given matrix*/
#include<stdio.h>
main()
{
int a[25][25],i,j,m,n,b,c,d;
printf("\nEnter the order:");
scanf("%d%d",&m,&n);
printf("\nENTER THE MATRIX ELEMENTS:");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("\nEnter the position of the element your are trying to insert:");
scanf("%d%d",&b,&c);
printf("\nEnter the element:");
scanf("%d",&d);
a[b-1][c-1]=d;
printf("\nTHE REQURIED MATRIX IS :\n");
for(i=0;i<m;i++)
{
for(j=0;j<n;j++)
printf("%d\t",a[i][j]);
printf("\n");
}
getch();
}