/**************************************************
           NEWTON FORWARD INTERPOLATION
**************************************************/
#include<stdio.h>
float x[20],y[20];
float dy(int i,int j)
{ if(i==1)return(y[j]-y[j-1]);
  else return (dy(i-1,j+1)-dy(i-1,j));
}
main()
{ float t,s=1,x0,p;int i,j,m;
 printf("\nHow many values would you like to enter:");
 scanf("%d",&m);
 for(i=0;i<m;i++)
 {printf("\nEnter x%d:",i+1);
  scanf("%f",&x[i]);
  printf("\nEnter y%d:",i+1);
  scanf("%f",&y[i]);
 }t=y[0];
 printf("\nEnter the x0:");
 scanf("%f",&x0);
 p=(x0-x[0])/(x[1]-x[0]);
 for(i=1;i<m;i++)
 {s=1;
  for(j=1;j<=i;j++)
  s*=(p-j+1)/j;
  t+=s*dy(i,1);
 }
printf("\n%f",t);
} 
