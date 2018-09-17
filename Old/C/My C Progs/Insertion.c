#include<stdio.h>
 main()
{ int i,k,a[20],m,t;
 printf("\nHow many numbers are you willing to sort....:");
 scanf("%d",&m);
 printf("\nEnter the elements:");
 for(i=0;i<m;i++)
 scanf("%d",&a[i]);
 for(k=1;k<m;k++)
  for(i=k;i>0;i--)
  {if(a[i]<a[i-1]){t=a[i];a[i]=a[i-1];a[i-1]=t;}
   else i=0;
  }
 for(i=0;i<m;i++)
 printf("%4d",a[i]);
}
Input:
How many numbers are you willing to sort....:10
Enter the elements:9 8 7 6 5 4 3 2 1 0
Output:
 0   1   2   3   4   5   6   7   8   9
