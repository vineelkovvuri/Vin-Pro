/**************************************************
              LINEAR REGRESSION
**************************************************/
#include<stdio.h>
float a[2][3];
gauss()
{int x=-1,i,j,k;float r;
 for(k=0;k<2;k++)
 {++x;
  for(i=0;i<2;i++)
  {if(i!=x){r=a[i][x]/a[x][x];
            for(j=0;j<2+1;j++)
            a[i][j]-=r*a[x][j];
           }
  }
 }
for(i=0;i<2;i++)
a[i][2]/=a[i][i];
}
main()
{float x=0,y=0,x2=0,x_=0,y_=0,xy=0;int n,i;
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
 }
 a[0][0]=x_;a[0][1]=n;a[0][2]=y_;
 a[1][0]=x2;a[1][1]=x_;a[1][2]=xy;
gauss();
printf("\nY=%fX+%f",a[0][2],a[1][2]);
}
