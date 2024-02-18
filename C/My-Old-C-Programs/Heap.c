/*******************************************************
                      HEAP SORT
*******************************************************/
#include<stdio.h>
#include<math.h>
int a[10];
rec(int i)
{ if(i<=0||(a[(i-1)/2]>a[i]))return;
  else if(a[(i-1)/2]<a[i]){a[(i-1)/2]^=a[i];
                           a[i]^=a[(i-1)/2];
                           a[(i-1)/2]^=a[i];
                           rec((i-1)/2);
                          }
}
main()
{int i,n,j;
 printf("\nEnter the order:");
 scanf("%d",&n);
 printf("\nEnter the elements:");
 for(i=0;i<n;i++)
 scanf("%d",&a[i]);
 for(j=n-1;j>0;j--)
 { for(i=1;i<=j;i++)
   rec(i); 
  a[0]^=a[j];
  a[j]^=a[0];
  a[0]^=a[j];
 }
  for(i=0;i<n;i++)
  printf("%d ",a[i]);
  printf("\n");
} 
