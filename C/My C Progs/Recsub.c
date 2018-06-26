/*program to perform subtration by recursion */
#include<stdio.h>
int sub(int,int);
main()
{
int x,y;
printf("Enter x,y");
scanf("%d%d",&x,&y);
printf("%d",sub(x,y));
}
int sub(int x,int y)
{
if(y==0)return x;
else return sub(--x,--y);
}

