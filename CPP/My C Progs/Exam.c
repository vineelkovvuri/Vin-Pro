#include<stdio.h>
main()
{
int x[]={1,2,3,4,5,6,7,8,9,0},y[10],m,*p,i,j,k=0;
printf("\nEnter number of numbers");
scanf("%d",&m);
printf("\nEnter the numbers");
for(i=0;i<m;i++)
scanf("%d",&y[i]);
p=y;
for(i=0;i<10;i++)
{ if(k==m)break;
  else for(j=0;j<m;j++)
       if(*(p+j)==x[i])printf("%d ",x[i]);
  k++;
}
getch();
return 0;
}