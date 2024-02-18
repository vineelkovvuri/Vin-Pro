#include<stdio.h>
#define Max(a,b)  (a)>(b)?(a):(b)

main()
{
 int a=3,b=4,c=5;
 
   printf("%d is Maximum",Max(Max(a,b),c));
   return 0;
}
