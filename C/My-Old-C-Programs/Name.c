#include<stdio.h>
main()
{int i,j;
printf("\n");
for(i=1;i<1000;i++)
for(j=1;j<81;j++)
  {if(i==1&&(j>=40&&j<=60))printf("v");else break;}
getch();
return 0;
}