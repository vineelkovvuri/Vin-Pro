/* program to produce matrix multiplication */
#include<stdio.h>
#include<conio.h>
main()
{
int x[10][10],y[10][10],z[10][10]={0},i,j,k,a,b,c,d;
printf("\n Enter the orders of both the matrices:");
scanf("%d%d%d%d",&a,&b,&c,&d);
printf("\n Enter the elements of the first matrix:");
for(i=0;i<a;i++)
for(j=0;j<b;j++)
scanf("%d",&x[i][j]);
printf("\n Enter the elements of the second matrix:");
for(j=0;j<b;j++)
for(k=0;k<d;k++)
scanf("%d",&y[j][k]);
printf("\n\nTHE MATRIX MULTIPLICATION IS \n\n");
for(i=0;i<a;i++)
{
for(k=0;k<d;k++)
 {
  for(j=0;j<b;j++)
  z[i][k]+=x[i][j]*y[j][k];
  printf("%d\t",z[i][k]);
 }
printf("\n");
}
getch();
}
