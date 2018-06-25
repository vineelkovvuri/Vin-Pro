/* program to generate lucky number */
#include<stdio.h>
#include<conio.h>
main()
{
int s=0,n;
  printf("enter n"); /* takes the value of n*/
  scanf("%d",&n);
for(;;)
 {
  s+=n%10;
  n/=10;
  if(n==0){n=s,s=0;}
  if(s==1||s==2||s==3||s==4||s==5||s==6||s==7||s==8||s==9)printf("%d",s);
 }
getch();
}
