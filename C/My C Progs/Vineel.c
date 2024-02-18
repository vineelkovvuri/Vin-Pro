#include<stdio.h>
main()
{int m,n,i,j,k=65,a=1,x[6][6];
system("clear");
printf("Enter 0 to quit the game:\n");
for(i=0;i<5;i++)
   {for(j=0;j<5;j++)
     {x[i][j]=k++;if(j==4&&i==4)x[i][j]=32;else printf("%c ",x[i][j]);}
    printf("\n");
   }--i;--j; 
while(1)
{
scanf("%d",&a);
    if(a==4){x[i][j]=x[i][j-1];x[i][j-1]=32;--j;}
    if(a==2){x[i][j]=x[i+1][j];x[i+1][j]=32;++i;}
    if(a==6){x[i][j]=x[i][j+1];x[i][j+1]=32;++j;}
    if(a==8){x[i][j]=x[i-1][j];x[i-1][j]=32;--i;}
    if(a==0)return;
system("clear");
 printf("Enter 0 to quit the game:\n");
 for(m=0;m<5;m++)
   {for(n=0;n<5;n++)
    printf("%c ",x[m][n]);
    printf("\n");
   }
}
}
