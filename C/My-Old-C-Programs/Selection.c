#include<stdio.h>
main()
{int a[20],i,t,j,k,m;
 printf("\nHow many numbers are you willing to sort.....:");
 scanf("%d",&m);
 printf("\nEnter the elements:");
 for(i=0;i<m;i++)
 scanf("%d",&a[i]);
 for(j=0;j<m-1;j++)
 { k=0;
  for(i=0;i<m-1-j;i++)
  if(a[k]<a[i+1])k=i+1;
   t=a[m-j-1];
   a[m-j-1]=a[k];
   a[k]=t;
 }
 for(i=0;i<m;i++)
 printf("%4d",a[i]);
}
Input:
How many numbers are you willing to sort.....:10
Enter the elements: 9 8 7 6 5 4 3 2 1 0
Output: 
 0   1   2   3   4   5   6   7   8   9
