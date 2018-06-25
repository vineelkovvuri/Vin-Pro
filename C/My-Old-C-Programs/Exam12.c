#include<stdio.h>
void swap(int*,int*);
main()
{
int m,n;
printf("\nEnter two numbers");
scanf("%d%d",&m,&n);
swap(&m,&n);
return 0;
}
void swap(int*p,int *q)
{
 *p=*p+*q;
 *q=*p-*q;
 *p=*p-*q;
printf("%d %d",*p,*q);
getch();
}
