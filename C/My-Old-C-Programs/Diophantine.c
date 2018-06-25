#include<stdio.h>
main()
{
int i,j,k;
for(i=-1000;i<50;i++)
for(j=-1000;j<50;j++)
for(k=-1000;k<50;k++)
 if(i*i*i+j*j*j+k*k*k==3)printf("x=%d y=%d z=%d\n",i,j,k);

}
