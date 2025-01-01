
/*program to generate phythagaren triads */
#include<stdio.h>
#include<math.h>
main()
{
  int n,i,j;
  float k;
  printf("\nEnter n:");
  scanf("%d",&n);
for(i=1;i<=n;i++)
 for(j=1;j<=i;j++)
  {
   k=hypot(i,j);
   if(k-floor(k)==0)printf("%d,%d,%d\n",i,j,(int)k); 
  }
getch();
}
