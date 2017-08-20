#include<stdio.h>
#include<conio.h>
main()
{
int i=10,*p;
p=&i;
printf("p=%u,&i=%u,*p=%d,i=%d,ap=%u",p,&i,*p,i,&p);
getch();
return(0);
}