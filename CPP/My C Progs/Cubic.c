#include<stdio.h>
#include<math.h>
#include"quad.h"
float f(float);
float a[4];
main()
{ float i,m=.5;
printf("\nEnter the coefficients");
for(i=0;i<4;i++)
scanf("%f",&a[(int)i]);
for(i=-100;i<100;i+=m)
 {if(f(i)*f(i+m)<=0)m/=10.;
  if(m<=1.e-5)break;}
printf("1st root=%f\n",i);
quad(a[0],a[0]*i+a[1],(a[0]*i+a[1])*i+a[2]);
}
float f(float i)
{ return(a[0]*i*i*i+a[1]*i*i+a[2]*i+a[3]);
}
