#include<stdio.h>
#include<conio.h>
#include<string.h>
main()
{
int i,j,k;char x[]="vineel";
clrscr();
for(i=6;i<50;i++)
for(j=0;j<strlen(x);j++)
{delay(100);
 gotoxy(38+j,i-j);
 printf(" ");
 gotoxy(38+j,i-j+1);
 printf("%c",x[j]);}
 getch();
 return 0;
 }