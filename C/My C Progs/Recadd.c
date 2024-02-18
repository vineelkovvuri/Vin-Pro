/* program to perform addition by recursion */
#include<stdio.h>
int add(int,int);
main()
{
int x,y;
printf("Enter x,y");
scanf("%d%d",&x,&y);
printf("%d",add(x,y));
}
int add(int x,int y)
{
if(y==0)return x; 
else return add(++x,--y);
}
