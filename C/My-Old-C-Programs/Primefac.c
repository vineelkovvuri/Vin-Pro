#include<stdio.h>
main()
{
int n,t,i;
printf("\nEnter n");
scanf("%d",&n);
for(i=2;n!=0;i++)
 if(n%i==0){printf("%d ",i); n/=i;i=2;}
getch();
return 0;
}