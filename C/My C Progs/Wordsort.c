#include<stdio.h>
#include<string.h>
struct word{char a[6];}p[5];
main()
{int i,k;char x[6];
 printf("\nEnter the strings:");
 for(i=0;i<5;i++)
 scanf("%s",p[i].a);
 for(k=1;k<5;k++)
 for(i=k;i>0;i--)
  {if(strcmp(p[i].a,p[i-1].a)<0){strcpy(x,p[i].a);
                               strcpy(p[i].a,p[i-1].a);
                               strcpy(p[i-1].a,x);
                               }
   else i=0;
   }               
   for(i=0;i<5;i++)
   printf("%s",p[i]);
}
