/* program to generate numbers whose sum of 4th powers of digits equal it */
#include<stdio.h>
#include<conio.h>
main()
{
int s,i,t,d;/*s for updating the sum i for the number t for storing current
 variable d for calculating the 4th power of the digit */
clrscr();
for(i=1;i<=32000;i++) /*this for loop is for running the numbers */
{
t=i;s=0;/* tranfer of the current i value to another variable t */
for(;t!=0;)/*this for loop is used for dividing the number in to its digits
and adding the 4th power of each of it */  /*for loop continues until t=0 */
  {
  d=t%10;
  s+=d*d*d*d;
  t/=10;
  }
if(i==s)printf("%d\n",i); /*ifthe updated sum equals the
number print the number*/
}
getch();
}