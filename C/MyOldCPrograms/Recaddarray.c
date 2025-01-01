/* program to perform the sum of the array elements by recursion */
#include<stdio.h>
int sum(int[],int);
main()
{
    int a[20],n,i;
    printf("Enter the number of elements:");
    scanf("%d",&n);
    for(i=0;i<n;i++)
     scanf("%d",&a[i]);
     printf("%d",sum(a,n));
}
int sum(int a[],int n)
{
   if(n==1)return a[0];
   else return a[n-1]+sum(a,--n);
}

