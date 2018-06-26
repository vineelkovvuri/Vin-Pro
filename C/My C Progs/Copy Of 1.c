/* program to print the table */
#include<stdio.h>
main()
{
int i,n;
 printf("enter n");
 scanf("%d",&n);
 for(i=1;i<=20;i++)  /* this for loop is for generation*/
 printf("%d*%d=%d\n",n,i,n*i);
getch();
}