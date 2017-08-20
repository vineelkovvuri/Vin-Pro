#include<stdio.h>
main()
{
 int b=0,i,j,k=1,x[6][6],a,m,n;
clrscr();
 printf("#press 0 and hit enter to quit the game#\n");
 for(i=0;i<5;i++)
 {printf("\t\t\t");
  for(j=0;j<5;j++)
   if(i==4&&j==4)printf("%d\t",x[i][j]=0);else printf("%d\t",x[i][j]=k++);
   printf("\n\n");
 }
m=--i;n=--j;
 while(1)
 {scanf("%d",&a);
   if(a==4&&n>0){x[m][n]=x[m][n-1];x[m][n-1]=0;n=n-1;}
   else if(a==6&&n<4){x[m][n]=x[m][n+1];x[m][n+1]=0;n=n+1;}
   else if(a==8&&m>0){x[m][n]=x[m-1][n];x[m-1][n]=0;m=m-1;}
   else if(a==2&&m<4){x[m][n]=x[m+1][n];x[m+1][n]=0;m=m+1;}
   else if(a==0)exit(0);
  clrscr();
  printf("#press 0 and hit enter to quit the game#\n");
   for(i=0;i<5;i++)
    {printf("\t\t\t");
     for(j=0;j<5;j++)
      printf("%d\t",x[i][j]);
      printf("\n\n");
   }
printf("The number of steps you performed till now is:%d\b",++b);
 }
}
