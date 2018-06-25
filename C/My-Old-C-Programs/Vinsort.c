#include<stdio.h>
main()
{int t,i,k,m,l,a[10]={9,8,7,6,5,4,3,2,1,0};
 for(k=0;k<=10;k++)
 {l=k;m=10-k-1;
  for(i=k;i<10;i++)
  {if(a[l]>a[i+1])l=i+1;
   if(a[m]<a[10-i-2])m=10-i-2;
  }
 t=a[k];a[k]=a[l];a[l]=t;
   t=a[10-k-1];a[10-k-1]=a[m];a[m]=t;
 }
 for(i=0;i<10;i++)
printf("%d  ",a[i]);
}
