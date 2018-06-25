#include<stdio.h>
main()
{int a[20],i,j,m,k=-1,t;
 printf("\nHow many numbers are you willing to sort....:");
 scanf("%d",&m);
 printf("\nEnter the elements:");
 for(i=0;i<m;i++)
 scanf("%d",&a[i]);
 for(j=0;j<m&&k!=m-1;j++)
  { k=0;
    for(i=0;i<m-1-j;i++)
     { if(a[i]>a[i+1]){t=a[i+1];
                       a[i+1]=a[i];
                       a[i]=t;
                      }
       else k++;
     }
  }
 for(i=0;i<m;i++)
   printf("%4d",a[i]);
}
Input:
How many numbers are you willing to sort....:10
Enter the elements: 9 8 7 6 5 4 3 2 1 0
output:
 0   1   2   3   4   5   6   7   8   9
