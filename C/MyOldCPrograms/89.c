#include<stdio.h>
#include"formula.h"
main()
{
float b,c;
printf("\nEnter b,c");
scanf("%f%f",&b,&c);
printf("\n%f",form(b,c));
getch();
}