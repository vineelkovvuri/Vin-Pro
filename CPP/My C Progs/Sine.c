/* program to give out values for (sinx)/x */
#include<stdio.h>
#include<conio.h>
#include<math.h>
main()
{
int n,x;float s;
 printf("\nenter n");
 scanf("%d",&n);
 for(x=1;x<=n;x++)
  {
   s=(sin(x))/x;
   printf("%f\n",s);
  }
getch();
}

