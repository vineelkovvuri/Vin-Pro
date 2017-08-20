/* program to produce fermat's numbers */
#include<stdio.h>
#include<math.h>
#include<conio.h>
main()
{
int n,a;
for(n=1;n<=7;n++)
{
a=pow(2,2*n)+1;
printf("\n%d is fermat's number",a);
}
getch();
}
