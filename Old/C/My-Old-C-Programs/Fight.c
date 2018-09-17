#include<stdio.h>
#include"design.h"
#include"design1.h"
main()
{
int i,j,m,t=1;char c,x[]="VINEEL",y[]="CREATED BY VINEEL";
clrscr();
printf("fighting between somaraju and sridhar would you like to continue(y/n)\n");
printf("%c=somaraju\n%c=sridhar\nenter y or n :",2,1);
scanf("%c",&c);
clrscr();
if(c=='y')
for(m=2;m<27;m++)
{
for(i=m;i<80-m+2;i++)
{gotoxy(i,m-1);
 printf(" %c",1);
 delay(t);
 gotoxy(i-1,m-1);
 printf("%c",2);
 delay(t);
 gotoxy(i-1,m-1);
 printf("  ");
 delay(t);
gotoxy(i-2,m-1);
printf(" ");
delay(t);

}
for(j=m+1;j<50-m+2;j++)
{gotoxy(80-m+2,j);
 printf("%c",1);
 delay(t);
 gotoxy(80-m+2,j-1);
 printf(" ");
delay(t);
 gotoxy(80-m+2,j-2);
 printf("%c",2);
 delay(t);
 gotoxy(80-m+2,j-2);
if(j!=49) printf(" ");
 delay(t);
} gotoxy(80-m+2,50-1);printf(" ");
  gotoxy(80-m+2,50-2);printf(" ");
  gotoxy(80-m+2,50-3);printf(" ");
for(i=80-m+2;i>m-1;i--)
{gotoxy(i,49-m+2);
printf("%c",2);
delay(t);
gotoxy(i-1,49-m+2);
printf(" ");
delay(t);
gotoxy(i-2,49-m+2);
printf("%c",1);
delay(t);
gotoxy(i,49-m+2);
printf(" ");
delay(t);
}gotoxy(m-2,49-m+2);printf(" ");
for(j=49-m+1;j>m-1;j--)
{gotoxy(m-1,j);
printf("%c",2);
delay(t);
gotoxy(m-1,j-2);
printf("%c",1);
delay(t);
gotoxy(m-1,j-1);
printf(" ");
delay(t);
gotoxy(m-1,j);
printf(" ");
delay(t);
}gotoxy(m-1,m-2);printf(" ");delay(t);
}
else return 0;
 gotoxy(35,1);
  printf("CREATED BY\n");
  design(x);
  design1(y);
getch();
return 0;
}