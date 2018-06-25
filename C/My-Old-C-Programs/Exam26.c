#include<stdio.h>
main()
{
//int m;
struct comp{float real;float imag;}c[2];
//printf("\n1.addition\n2.subtraction\n3.multiplication\n4.division ");
//scanf("%d",&m);
printf("\nEnter the first complex number");
scanf("%f%f",&c[0].real,&c[0].imag);
printf("\nEnter the second complex number");
scanf("%f%f",&c[1].real,&c[1].imag);
//switch(m)
// {
// case 1:
 printf("\n%f",c[0].real+c[1].real);
 if(c[0].imag+c[1].imag>=0)printf("+%fi",c[0].imag+c[1].imag);
 else printf("%fi",c[0].imag+c[1].imag);//break;
// case 2:
 printf("\n%f",c[0].real-c[1].real);
 if(c[0].imag-c[1].imag>=0)printf("+%fi",c[0].imag-c[1].imag);
 else printf("%fi",c[0].imag-c[1].imag);//break;
// case 3:
 printf("\n%f",c[0].real*c[1].real-c[0].imag*c[1].imag);
 if(c[0].real*c[1].imag+c[0].imag*c[1].real>0)printf("+%fi",c[0].real*c[1].imag+c[0].imag*c[1].real);
 else printf("%fi",c[0].real*c[1].imag+c[0].imag*c[1].real);//break;
// case 4:
 printf("\n%f",(c[0].real*c[1].real+c[0].imag*c[1].imag)/(c[1].real*c[1].real+c[1].imag*c[1].imag));
 if(c[0].real*c[1].imag-c[0].imag*c[1].real>0)printf("+%fi",(c[0].real*c[1].imag-c[0].imag*c[1].real)/(c[1].real*c[1].real+c[1].imag*c[1].imag));
 else printf("%fi",(c[0].real*c[1].imag-c[0].imag*c[1].real)/(c[1].real*c[1].real+c[1].imag*c[1].imag));//break;
// }
getch();
return 0;