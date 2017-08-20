//                         Simple Calculator
#include<stdio.h>
#include<conio.h>
#include<dos.h>
#include<math.h>
#define m 25
#define n 25
char c='>';
int dot,k=0;float xx,yy;
union REGS o;
void cal()
{
  gotoxy(n,m);
  printf("7");
    gotoxy(n+5 ,m);
    printf("8");
    gotoxy(n+10,m);
    printf("9");
    gotoxy(n,m+4 );
    printf("4");
    gotoxy(n+5,m+4 );
    printf("5");
    gotoxy(n+10,m+4 );
    printf("6");
    gotoxy(n,m+8 );
    printf("1");
    gotoxy(n+5 ,m+8 );
    printf("2");
    gotoxy(n+10 ,m+8 );
    printf("3");
    gotoxy(n,m+12 );
    printf("0");
    gotoxy(n+15 ,m);
    printf("*");
    gotoxy(n+15 ,m+4 );
    printf("/");
    gotoxy(n+15 ,m+8 );
    printf("+");
    gotoxy(n+15 ,m+12 );
    printf("-");
    gotoxy(n+5 ,m+12 );
    printf(".");
    gotoxy(n+10 ,m+12 );
    printf("=");
   gotoxy(n,15 );
   printf(" ");
 }
 void calculator(int x,int y)
 {  int g=0;

  if(dot==1)k++;
  if((x<=203&&x>=184)&&(y>=188&&y<=206))
{if(c=='>'){if(dot==0)xx=10*xx+7;else xx+=7/pow(10,k);}
  else {if(!dot)yy=10*yy+7;else yy+=7/pow(10,k);}
 }
  if((x>=226&&x<=244)&&(y>=188&&y<=206))
 {if(c=='>'){if(!dot)xx=10*xx+8;else xx+=8/pow(10,k);}
  else {if(!dot)yy=10*yy+8;else yy+=8/pow(10,k);}
 }
  if((x>=269&&x<=284)&&(y>=188&&y<=206))
  {if(c=='>'){if(!dot)xx=10*xx+9;else xx+=9/pow(10,k);}
  else {if(!dot)yy=10*yy+9;else yy+=9/pow(10,k);}
  }
  if((x>=303&&x<=328)&&(y>=188&&y<=206))c='*';
  if((x>=184&&x<=205)&&(y>=221&&y<=239))
 {if(c=='>'){if(!dot)xx=10*xx+4;else xx+=4/pow(10,k);}
  else {if(!dot)yy=10*yy+4;else yy+=4/pow(10,k);}
 }
  if((x>=226&&x<=244)&&(y>=221&&y<=239))
 {if(c=='>'){if(!dot)xx=10*xx+5;else xx+=5/pow(10,k);}
  else {if(!dot)yy=10*yy+5;else yy+=5/pow(10,k);}
 }
  if((x>=269&&x<=284)&&(y>=221&&y<=239))
 {if(c=='>'){if(!dot)xx=10*xx+6;else xx+=6/pow(10,k);}
  else {if(!dot)yy=10*yy+6;else yy+=6/pow(10,k);}
 }
  if((x>=303&&x<=328)&&(y>=221&&y<=239))c='/';
  if((x>=184&&x<=205)&&(y>=250&&y<=271))
{if(c=='>'){if(!dot)xx=10*xx+1;else xx+=1/pow(10,k);}
  else {if(!dot)yy=10*yy+1;else yy+=1/pow(10,k);}
 }
  if((x>=226&&x<=244)&&(y>=252&&y<=271))
  {if(c=='>'){if(!dot)xx=10*xx+2;else xx+=2/pow(10,k);}
  else {if(!dot)yy=10*yy+2;else yy+=2/pow(10,k);}
  }
  if((x>=269&&x<=284)&&(y>=250&&y<=271))
  {if(c=='>'){if(!dot)xx=10*xx+3;else xx+=3/pow(10,k);}
  else {if(!dot)yy=10*yy+3;else yy+=3/pow(10,k);}
  }
  if((x>=303&&x<=328)&&(y>=250&&y<=271))c='+';
  if((x>=184&&x<=205)&&(y>=280&&y<=299))
  {if(c=='>'){if(!dot)xx=10*xx+0;else xx+=0;}
  else {if(!dot)yy=10*yy+0;else yy+=0;}
  }
  if((x>=226&&x<=244)&&(y>=280&&y<=301)){dot=1;}
  if((x>=269&&x<=284)&&(y>=280&&y<=299))g=1;
  if((x>=303&&x<=328)&&(y>=280&&y<=299))c='-';
  if(g==1){
	   switch(c)
	  {
	   case '*':{gotoxy(40,18);printf("%g",xx*yy);c='=';break;}
	   case '/':{gotoxy(40,18);printf("%g",xx/yy);c='=';break;}
	   case '+':{gotoxy(40,18);printf("%g",xx+yy);c='=';break;}
	   case '-':{gotoxy(40,18);printf("%g",xx-yy);c='=';break;}
	   }
	  }
gotoxy(40,15);  printf("%g ",xx);
gotoxy(40,16);if(c!='=')printf("%c ",c);
gotoxy(40,17);printf("%g ",yy);
}
void main()
{ int count=0;
 clrscr();
   clrscr();
   cal();
   o.x.ax=0;
   int86(51,&o,&o);
   o.x.ax=1;
   int86(51,&o,&o);
   while(!kbhit())
{
do{
   o.x.ax=3;
   int86(51,&o,&o);
   if((o.x.bx)&1==1){gotoxy(1,1);printf("x=%d y=%d",o.x.cx,o.x.dx);delay(1000);calculator(o.x.cx,o.x.dx);}
   if(count==0)if(c!='>'){dot=0;k=0;count=1;}                         //for prepation of decimal y
  }while(c!='=');
sleep(5);
xx=0;yy=0;c='>';clrscr();cal();count=0;
}
getch();
}