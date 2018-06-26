/*program to delete an element of the given matrix*/
#include<stdio.h>
main()
{
int a[20][20],i,j,b,c,m,n;
printf("\nEnter the order:");
scanf("%d%d",&m,&n);
printf("\nENTER THE ELEMENTS OF THE MATRIX:");
for(i=0;i<m;i++)
for(j=0;j<n;j++)
scanf("%d",&a[i][j]);
printf("\nEnter the position of the element you are trying to delete:");
scanf("%d%d",&b,&c);
printf("\nTHE REQURIED MATRIX IS:\n");
for(i=0;i<m;i++)
{
for(j=0;j<n;j++)
if(i==b-1&&j==c-1)printf(" \t");
else printf("%d\t",a[i][j]);
printf("\n");
}
getch();
}