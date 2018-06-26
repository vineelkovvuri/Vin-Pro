#include<stdio.h>
main()
{
int i,k=0,j;char x[]="vineel";
clrscr();
for(i=1;i<75;i++)
{gotoxy(i,1); delay(5);
printf("vineel");gotoxy(i,1);delay(50);printf(" ");if(i==74)printf("      ");}
for(j=1;j<45;j++)
{for(i=j;i<j+6;i++){gotoxy(80,i);printf("%c",x[k++]);}k=0;delay(100);gotoxy(80,j);if(j!=44)printf(" ");}
for(i=75;i>0;i--)
{gotoxy(i,49);printf("vineel");delay(50);gotoxy(i+5,49);printf(" ");}
getch();
return 0;
}