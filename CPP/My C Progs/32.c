/*program to print arrangement of numbers */
#include<stdio.h>
#include<conio.h>
main()
{
int i,j,k,n;
printf("\nenter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
{
for(j=n-i;j>=0;j--)
printf("  ");
for(k=1;k<=i;k++)
{
printf("%4d",k);
}
printf("\n");
}
getch();
}

