#include<stdio.h>
#include<conio.h>
#include<dos.h>
#include<graphics.h>
union REGS o,i;
void main()
{  int gd=DETECT,gm;
  initgraph(&gd,&gm,"");
  o.x.ax=0;
int86(51,&o,&i);
 o.x.ax=1;
   int86(51,&o,&i);
outtextxy(200,100,"drag using mouse");
while(!kbhit())
{  o.x.ax=3;
   int86(51,&o,&i);
  while((i.x.bx)&1==1)
 {
     o.x.ax=3;
     int86(51,&o,&i);
     putpixel(i.x.cx,i.x.dx,rand(16));

 }
}
getch();
closegraph();
restorecrtmode();
}




