#include<stdio.h>
#include<dos.h>
main()
{
int s,m,h;
for(h=0;h<=24;h++)
{printf("%d:",h);
 /*if(h<=9)printf("\b");else printf("\b\b");*/
   for(m=0;m<=60;m++)
    {printf("%d:",m);
     /*if(m<=9)printf("\b");else printf("\b\b");*/
      for(s=0;s<=60;s++)
      {printf("%d",s);
       if(s<=9)printf("\b");else printf("\b\b");
       sleep(1);
      }
      if(m<=9)printf("\b\b\b\b");else printf("\b\b\b\b\b");
  }
   if(h<=9)printf("\b\b\b\b\b");else printf("\b\b\b\b\b\b");
}
getch();
}