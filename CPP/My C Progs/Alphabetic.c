#include<stdio.h>
#include<string.h>
main()
{
int i,j,k=0;
char y[10],*p[]={"vineel","hari","vineel","sundeep","savi"};
for(i=0;i<4;i++)
if(strcmp(*p[k],*p[i+1])<=0)k=i+1;
strcpy(y,*p[k]);
for(j=0;j<5;j++)
 {k=0;
  for(i=0;i<4;i++)
   if(strcmp(*p[k],*p[i+1])>=0)k=i+1;
    printf("%s\n",p[k]);
 strcpy(*p[k],y);
 }
}

