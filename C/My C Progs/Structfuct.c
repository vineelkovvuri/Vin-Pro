#include<stdio.h>
struct detail{char name[10];int number;};
main()
{
struct detail n={"vineel",289};
func(n);
}
func(struct detail x)
{
 printf("%s\n%d",x.name,x.number);
}
