

/* program to find the sum of elements in an array */
#include<stdio.h>
int add(int[],int);
main()
{
int a[20],i,n;
printf("\nenter the number of elements");
scanf("%d",&n);
printf("\nenter the elements of the array:");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
printf("\nthe sum of the elements of the array is %d",add(a,n));
getch();
}
int add(int a[],int n)
{if(n==0) return a[0];
else return a[n-1]+add(a,--n);
}