/*program to produce n fibonacci numbers*/
#include<stdio.h>
int fibb(int);
main()
{
int n;
printf("\nEnter n");
scanf("%d",&n);
fibb(n);
}
int fibb(int n)
{
static int f1,f2=1;
if(n==0)return 0;
else if(n==1)return 1;
else {);
      printf("%d\t",fibb(n-1)+fibb(n-2)); }
}
