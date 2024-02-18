#include<stdio.h>
main()
{
int i,j,k;char x[80];
printf("\nEnter the line:\n");
for(i=0;i<5;i++)
{   scanf("%c",&x[i]);
    for(j=1;j<=125;j++)
       printf(" ");
    printf("%c",x[i]);
    //for(k=1;k<=125;k++)
      // printf("\b");
}
}
