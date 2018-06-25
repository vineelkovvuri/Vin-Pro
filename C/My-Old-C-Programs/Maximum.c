#include<stdio.h>
#include<math.h>
float f(float);
main()
{
float x,a,b,c=1,dy1,dy2,h=.00001;
printf("\nEnter lower and upper boundries:");
scanf("%f%f",&a,&b);
for(x=a;x<b;x+=c)
{dy1=(f(x+h)-f(x))/h;dy2=(f(x+c+h)-f(x+c))/h;
if(dy1*dy2<0&&f(x)>0){a=x;b=x+c;c/=10.;}if(dy1<=.00001)break;}
printf("\nTHE MAXIMUM VALUE OF THE GIVEN FUNCTION OCCURS AT X=%f",x);
}
float f(float x)
{
return (-(x-2)*(x-4));
}
