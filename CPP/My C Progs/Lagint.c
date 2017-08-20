/**************************************************
             LAGRANGES INTERPOLATION
**************************************************/
#include<stdio.h>
main()
{int i,j,n;float x[20],y[20],s=1,t=0,k;
 printf("\nHow many values would you like to enter:");
 scanf("%d",&n);
 for(i=0;i<n;i++)
 {printf("\nEnter x%d:",i+1);
  scanf("%f",&x[i]);
  printf("\nEnter y%d:",i+1);
  scanf("%f",&y[i]);
 }
 printf("\nEnter the value of k:");
 scanf("%f",&k);
 for(i=0;i<n;i++)
 {s=1;
  for(j=0;j<n;j++)
   if(j!=i)s*=(k-x[j])/(x[i]-x[j]);
  t+=s*y[i];
 }
 printf("%f",t);
}

   
 
