/* program to arrange three numbrs in assending order*/
#include<stdio.h>
main()
{
int a,b,c;
printf("\n Enter three numbers");
scanf("%d%d%d",&a,&b,&c);
if(a>b){if(b>c)printf("%d,%d,%d",c,b,a);
         else if(a>c)printf("%d,%d,%d",b,c,a);
         else printf("%d,%d,%d",b,a,c);}
else{if(b<c)printf("%d,%d,%d",a,b,c);
     else if(a<c)printf("%d,%d,%d",a,c,b);
     else printf("%d,%d,%d",c,a,b);}
} 
