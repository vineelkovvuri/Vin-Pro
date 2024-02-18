#include<stdio.h>
#include<conio.h>
#include<dos.h>
#include<graphics.h>
union REGS o;
void main()
{ int x,y,gd=DETECT,gm;
//clrscr();
initgraph(&gd,&gm,"");
o.x.ax=0;
int86(51,&o,&o);
o.x.ax=1;
int86(51,&o,&o);
outtextxy(200,100,"drag the mouse");
while(!kbhit())
{ o.x.ax=3;
  int86(51,&o,&o);
if(o.x.bx&1==1)x=o.x.cx;y=o.x.dx;
while(o.x.bx&1==1)
{ clearviewport();
outtextxy(200,100,"drag the mouse");
 o.x.ax=3;
int86(51,&o,&o);
rectangle(x,y,o.x.cx,o.x.dx);
delay(25);

}
}
closegraph();
restorecrtmode();
getch();
}