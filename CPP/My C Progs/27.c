/* program to generate a design*/
#include<stdio.h>
#include<math.h>
#include<conio.h>
main()
{
int i,j,n;
printf("Enter n");
scanf("%d",&n);
for(i=0;i<=n;i++)
{
  for(j=n-i;j>=0;j--)
  {
   printf("%3d",j);
  }
 printf("\n");
}
getch();
} 
