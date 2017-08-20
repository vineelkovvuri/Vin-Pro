#include<stdio.h>
main()
{
float a,b,d;int c;
printf("\n1.addition\n2.subtraction\n3.multiplication\n3.division\nEnter your choice");
scanf("%d",&c);
printf("Enter two numbers");
scanf("%f%f",&a,&b);
switch(c)
{
case 1:{d=a+b;printf("%f",d);break;}
case 2:{d=a-b;printf("%f",d);break;}
case 3:{d=a*b;printf("%f",d);break;}
case 4:{d=a/b;printf("%f",d);break;}
}
}
