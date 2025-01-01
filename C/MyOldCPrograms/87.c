#include<stdio.h>
int fibb(int);
main()
{
int n;
printf("\nEnter the number");
scanf("%d",&n);
fibb(n);
getch();
}
int fibb(int n)
{static int y=0,z=1;
 if(n==0)return 0;
else {printf("%d\t",y+z);
       y=z;z=y+z;
      return fibb(--n);}
}
