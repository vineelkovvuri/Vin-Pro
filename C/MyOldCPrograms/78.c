/*program to produce a matrix who's Mth row and coloum is the sum of the respective coloum or row of a given matrix*/
#include<stdio.h>
main()
{
int a[25][25],i,j,m,s=0;
printf("\n Enter the order:");
scanf("%d%d",&m,&m);
printf("ENTER THE ELEMENTS OF THE MATRIX:");
for(i=0;i<=m;i++)
for(j=0;j<=m;j++)
{if(i==m||j==m)a[i][j]=0;
else scanf("%d",&a[i][j]);}
printf("\nTHE REQURIED MATRIX IS:\n");
 for(i=0;i<m;i++)
 {
  for(j=0;j<m;j++)
  s+=a[i][j];
  a[i][j]=s;
  s=0;
 }
 for(j=0;j<m;j++)
 {
  for(i=0;i<m;i++)
  s+=a[i][j];
  a[i][j]=s;
  s=0;
 }
 for(i=0;i<=m;i++)
 {
  for(j=0;j<=m;j++)
  printf("%d\t",a[i][j]);
  printf("\n");
 }
getch();
}