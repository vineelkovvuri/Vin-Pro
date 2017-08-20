#include<stdio.h>
int fun(int*);
main()
{int i,*p;
printf("\nEnter a number");
scanf("%d",&i);
p=&i;
printf("value at i=%d\naddress of i=%u\n",fun(p),p);
getch();
return 0;
}
int fun(int *q)
{ return(*q);
}