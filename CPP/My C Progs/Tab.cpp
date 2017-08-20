#include<stdio.h>
#include<conio.h>
main()
{  int orig=10000,pass=9625,x=9625,draw;char ch1;
      printf("\nEnter the password:");
   scanf(" %d",&pass);
   if(pass==x)
      {printf("\nEnter the amount to be drawn:");
       scanf(" %d",&draw);
       printf("\nthe amount drawn is=%d",draw);
       printf("\nbalance is=%d",orig-=draw);
      }       
     else printf("\nINVALID PASSWORD:");
                  
getch();
}           
 
