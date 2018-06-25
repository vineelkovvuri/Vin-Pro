#include<stdio.h>
int exchange(int,int);
main()
{
int x,y;
printf("Enter x,y");
scanf("%d%d",&x,&y);
printf("x=%d",exchange(x,y));
//printf("x=%d",exchange(x,y));
}
int exchange(int x,int y)
{
x=x+y;
y=x-y;
x=x-y;
return(x);

}
