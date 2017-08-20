#include<stdio.h>
#include<conio.h>
main()
{
int x,y,m;char a[]="K.VINEEL KUMAR REDDY";
clrscr();
for(m=0;m<25;m++)
{
 for(x=m;x<=80-m;x++)
 {delay(2);gotoxy(x,m);printf(".");}
 for(y=m;y<50-m;y++)
 {delay(2);gotoxy(80-m,y);printf(".");}
 for(x=80-m;x>m;x--)
 {delay(2);gotoxy(x,49-m);printf(".");}
 for(y=49-m;y>=m;y--)
 {delay(2);gotoxy(m+1,y);printf(".");}
}
gotoxy(30,25);
for(x=0;x<20;x++)
{delay(35);printf("%c",a[x]);}
delay(10);
getch();
return 0;
}