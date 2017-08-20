#include<stdio.h>
#include<math.h>
int quad(float*);
main()
{float x[4],*p;
printf("\nEnter the coefficient:");
scanf("%f%f%f",x,x+1,x+2);
p=quad(x);
if(*p>=0)printf("%f\n%f",*(p+1)+*(p+2),*(p+1)-*(p+2));
else { if(*(p+2)>0){printf("%f+%fi\n%f-%fi",*(p+1),*(p+2),*(p+1),*(p+2));}
       else {printf("%f%fi\n%f+%fi",*(p+1),*(p+2),*(p+1),-*(p+2));}
     }
getch();
return 0;
}
int quad(float*p)
{ float d,x[3],y[3],*q;
d=(*(p+1))*(*(p+1))-4*(*p)*(*(p+2));
if(d>=0){x[2]=sqrt(d)/(2*(*p));x[1]=- *(p+1)/(2*(*p));x[0]=d;q=x;return(q);}
else {y[2]=sqrt(-d)/(2*(*p));y[1]=- *(p+1)/(2*(*p));x[0]=d;q=y;return(q);}
}
