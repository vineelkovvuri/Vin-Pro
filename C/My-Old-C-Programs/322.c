#include<stdio.h>
main()
{
int i,j,k;
system("clear");
for(i=1;i<9;i++)
{printf("\n");
for(k=1;k<9-i;k++) printf("  ");
for(j=1;j<=i;j++)
printf("%4d",i);
}
}
