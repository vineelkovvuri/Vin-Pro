/*program to generate graphs of some elementary functions*/
#include<stdio.h>
#include<math.h>
main()
{
float x,y;int k,j,i;
for(x=.1;x<5;x+=.3)
{y=tan(x)-(1/x);k=(int)((y-0)/.5);
if(y>0){if(k>100)printf("\ngraph is out of range increase the increment in y at x=%f\n",x);
        else{for(j=1;j<38;j++)         
         printf(" ");   
         printf("|");
         for(j=39;j<39+k;j++)
         printf(".");
         printf("\n");}            
       }
if(y<0){if(k<-38)printf("\ngraph is out of range increase the increment in y at x=%f\n",x);
       else{ for(j=1;j<38+k;j++)        
           printf(" ");            
        for(i=38+k;i<38;i++)         
           printf(".");
           printf("|");
           printf("\n");}
       }
}
}
