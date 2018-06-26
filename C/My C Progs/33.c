/* program to calculate ncr */
#include<stdio.h>
#include<conio.h>
main()
{
int i,n,t=1,j;
printf("\nEnter n:");
scanf("%d",&n);
printf("%4d",t);
for(i=1;i<=n;i++)
 {
  t=t*(n-i+1)/i;
  printf("%4d",t);
 }
getch();
}

