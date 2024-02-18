/* program to print arrangement of numbers */
#include<stdio.h>
main()
{
int i,j,k,n;
printf("\nenter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
{
for(j=n-i;j>=0;j--)
printf("  ");
for(k=0;k<i;k++)
printf("%4d",i);
printf("\n");
}
getch();
}