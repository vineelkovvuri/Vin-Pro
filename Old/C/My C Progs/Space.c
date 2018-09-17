/*program to print the required number of spaces in b/w to integers */
#include<stdio.h>
int space(int);
main()
{
int x,y,z;
printf("Enter x,y");
scanf("%d%d",&x,&y);
printf("number of spaces required");
scanf("%d",&z);
printf("%d",x);
space(z);
printf("%d",y);
}
int space(int z)
{int i;
for(i=1;i<=z;i++)
printf(" ");
}
