#include<stdio.h>
#include<conio.>
main()
{
int x=24,*y;
 y=&x;
 printf("\nx=%d",x);
 printf("\n&x=%u",&x);
 printf("\ny=%u",y);
 printf("\n&y=%d",&y);
 printf("\n&y=%u",&y);
 printf("\n*(&y)=%u",*(&y));
 printf("\n*(&x)=%d",*(&x));
}
