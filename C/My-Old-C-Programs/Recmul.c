/*program to perform multiplication by recursion */
#include<stdio.h>
int mul(int,int);
main()
{
int x,y;
printf("Enter x,y");
scanf("%d%d",&x,&y);
printf("%d",mul(x,y));
}
int mul(int x,int y)
{
if(y==1)return x;
else return (x+mul(x,--y));
}

