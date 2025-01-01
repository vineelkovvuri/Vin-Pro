/* editor program */
#include<stdio.h>
#include<conio.h>
#include<dos.h>
#include<stdlib.h>
void setcursor(int,int);
void cursor();
union REGS i,o;
int x=1,y=1;
void setcursor(int a,int b)
{ cursor();
i.h.ah=2;
if(a==-1&&b==-1)
{
  i.h.dl=1;
  i.h.dh=45;
}
else if(a==1&&b==1)
{ i.h.dl=1;
  i.h.dh=y+1;
}
else{
i.h.dl=x+a;
i.h.dh=y+b;
    }
int86(0x10,&i,&o);
 }
void cursor()
{i.h.ah=3;
int86(0x10,&i,&o);
x=o.h.dl;y=o.h.dh;
}
void main(int argc,char *argv[])
{
  FILE *fp=fopen(argv[1],"w");
clrscr();
setcursor(1,1);
do
{
i.h.ah=0;
int86(0x16,&i,&o);
if(o.h.al<127&&o.h.al>31){fprintf(fp,"%c",o.h.al);printf("%c",o.h.al);}
if(o.h.al==8){fprintf(fp,"\b \b");printf("\b \b");}
if(o.h.ah==72){cursor();if(y!=0){fseek(fp,-28,1);setcursor(0,-1);}}
else if(o.h.ah==80){cursor();fseek(fp,28,1);setcursor(0,1); }
else if(o.h.ah==75){cursor();if(x!=0){fseek(fp,-1,1);setcursor(-1,0);}}
else if(o.h.ah==77){cursor();fseek(fp,1,1);setcursor(1,0);}
else if(o.h.al==13){cursor();fprintf(fp,"\n");setcursor(1,1);}
}while(o.h.al!=27);
setcursor(-1,-1);
do
{i.h.ah=0;
int86(0x16,&i,&o);
printf("%c",o.h.al);
}while(o.h.al!=13);
fclose(fp);
}