#include<stdio.h>
main()
{
int i,j,n;
printf("\nenter n");
scanf("%d",&n);
for(i=1;i<=n;i++)
{
printf("  ");
for(j=1;j<=i;j++)
{
printf("%4d",j);
}
printf("\n");
}
getch();
}
