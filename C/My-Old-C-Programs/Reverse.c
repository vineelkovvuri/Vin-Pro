 /*program to calculate reverse of the given number 8-11-2004*/
 #include<stdio.h>
#include<conio.h>
 main()
 {
 int n,s=0,d;
 printf("\n Enter n:");
 scanf("%d",&n);
 while(n!=0)
 {
 d=n%10;
 s=10*s+d;
 n/=10;
 }
 printf("\nThe reverse is %d",s);

getch();
 }
