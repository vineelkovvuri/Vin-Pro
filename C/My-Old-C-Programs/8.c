/* program to generate arrangment of numbers */
#include<stdio.h>
#include<conio.h>
main()
{
 int i,n,j;
 printf("enter n");
 scanf("%d",&n);
for(i=1;i<=n;i++)
 {
   for(j=1;j<=i;j++)
    printf("%3d",i);
   printf("\n");
 }
getch();
}
