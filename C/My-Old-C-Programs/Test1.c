#include<stdio.h>
#include<conio.h>
main()
{
 int i,j,k=65;char x[10][10];
 clrscr();
 for(i=0;i<5;i++)
 {for(j=0;j<5;j++)
  {x[i][j]=k++;
   printf("%c\t",x[i][j]);}
  printf("\n");}
  getch();
  return 0;

}