#include<stdio.h>
main()
{
int n,*p,f=1,t;
printf("\nEnter the number");
scanf("%d",&n);t=n;
p=&n;
for(;*p!=0;(*p)--)
      f*=*p;
printf("\nThe factorial of %d is %d",t,f);
getch();
return 0;
}
