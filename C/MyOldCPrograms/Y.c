/* program to display y=1 for x>0,y=0 forx=0,y=-1 forx<0 */
#include<stdio.h>
main()
{
int x,y;
printf("\nEnter x");
scanf("%d",&x);
if(x>0){y=1;printf("%d",y);}
else if(x=0){y=0;printf("%d",y);}
else {y=-1;printf("%d",y);}
}

