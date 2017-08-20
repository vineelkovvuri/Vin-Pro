#include<stdio.h>
main()
{
int  x[10],*p;
int i,j,k,y=0,n;
printf("\nnum___" );
scanf("%d",&n);
printf("\nEnter numbers");
for(i=0;i<n;i++)
{ scanf("%d",&x[i]);
  y+=x[i];} p=x;
for(j=0;j<n;j++)
{  k=0;
  for(i=0;i<n-1;i++)
  if(*(p+k)>=*(p+i+1))k=i+1;
  printf("%d ",*(p+k));
  *(p+k)=y;
}
getch();
return 0;
}