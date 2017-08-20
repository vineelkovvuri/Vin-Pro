#include<stdio.h>
#include<conio.h>
main()
{
int h,m,s;
//clrscr();
for(h=0;h<=1;h++)
{printf("0%d:",h);
 for(m=0;m<=60;m++)
 {if(m==60)printf("\b");
  else {if(m<10)printf("0%d:",m);
	else {printf("%d",m);printf("\b\b");}
       }
  for(s=0;s<=60;s++)
  {
   if(s==60)printf("\b");
   else{
	if(s<10){printf("0%d",s); delay(1000);printf("\b\b");}
	else {printf("%d",s);delay(1000);printf("\b\b");}
       }
  }
  printf("\b\b");
 }
}
getch();
}
