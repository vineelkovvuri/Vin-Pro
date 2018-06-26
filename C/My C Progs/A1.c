#include<stdio.h>
#include<conio.h>
main()
{
int i,k=0,j;char x[]="vineel";
clrscr();
for(i=35;i<80;i++)
{gotoxy(i,1); delay(50);
printf("vineel");gotoxy(i,1);delay(50);if(i!=79)printf(" ");}
for(j=1;j<45;j++)
{for(i=j;i<j+6;i++){gotoxy(80,i+1);printf("%c",x[k++]);}k=0;delay(50);gotoxy(80,j);printf(" ");}
return 0;
}