/* program to count numbers b/w 1 to 1000 not divisible by 2,3 and 5 */
#include<stdio.h>
#include<conio.h>
main()
{
int a,b,c=0;
printf("\nthe numbers between 1 to 1000 is");
for(a=1;a<=1000;a++)
{
   if(a%2!=0&&a%3!=0&&a%5!=0)
{
   
  printf("%d\t",a);
  c++;
  }
  }
 printf("\nthe  no. of numbers between 1 to 1000 is %d",c);
getch();
}
