#include<stdio.h>
#include<conio.h>
main()
{
int i,j,m=6,n,k=1,a[7][7];
clrscr();
for(i=0;i<7;i++)
{
for(j=0;j<7;j++)
{
a[i][j]=k++;
printf("%5d",a[i][j]);
}
printf("\n\n");
}
printf("\n\n");
i=m/2;j=m/2;
while(i<=6)
{
 if(j<=m/2&&i==j)

 {if(j==m/2)printf("%d",a[i][j]);/*middle element print avva danaki*/
  i++;/*repeate avva kunda chuda danaki*/
  for( ;i<=m-j+1;i++)
  {
  if(i<=6) /*last lo i=7ki guda print cheya kunda*/
  printf("%3d",a[i][j]);
  }i--;
 }
 else  if(j<=m/2)
 {
 j++;/*repeate avva kunda chuda danaki*/
 for( ;j<=i;j++)
 {printf("%3d",a[i][j]);}
 j--;
 }
 if(j>m/2&&i==j)
 {i--;/*repeate avva kunda chuda danaki*/
 for( ;i>=m-j;i--)
 {
 printf("%3d",a[i][j]);
 }i++;
 }
 else if(j>m/2)
 {
 j--;/*repeate avva kunda chuda danaki*/
 for( ;j>=i;j--)
 {printf("%3d",a[i][j]);}
 j++;
 }
}
getch();
return 0;
}