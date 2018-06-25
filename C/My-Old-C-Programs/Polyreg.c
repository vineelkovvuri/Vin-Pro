/**************************************************
              POLYNOMIAL REGRESSION
**************************************************/
#include<stdio.h>
float a[3][4];
gauss()
{int x=-1,i,j,k;float r;
 for(k=0;k<3;k++)
 {++x;
  for(i=0;i<3;i++)
  {if(i!=x){r=a[i][x]/a[x][x];
            for(j=0;j<3+1;j++)
            a[i][j]-=r*a[x][j];
           }
  }
 }
for(i=0;i<3;i++)
a[i][3]/=a[i][i];
}
main()
{float x=0,y=0,x2=0,x_=0,y_=0,xy=0,x3=0,x4=0,x2y=0;int n,i;
 printf("\nHow many values would you like to enter:");
 scanf("%d",&n);
 for(i=0;i<n;i++)
 {printf("\nEnter x%d:",i+1);
  scanf("%f",&x);
  printf("\nEnter y%d:",i+1);
  scanf("%f",&y);
  x_+=x;y_+=y;
  x2+=x*x;
  xy+=x*y;
  x2y+=x*x*y;
  x3+=x*x*x;
  x4+=x*x*x*x;
 }
 a[0][0]=x2;a[0][1]=x_;a[0][2]=n;a[0][3]=y_;
 a[1][0]=x3;a[1][1]=x2;a[1][2]=x_;a[1][3]=xy;
 a[2][0]=x4;a[2][1]=x3;a[2][2]=x2;a[2][3]=x2y;
gauss();
printf("\nY=%fX2+%fX+%f",a[0][3],a[1][3],a[2][3]);
}

