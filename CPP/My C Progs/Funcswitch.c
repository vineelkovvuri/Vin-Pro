/*program to use functions including switch statement*/
#include<stdio.h>
float add(float,float);
float sub(float,float);
float mul(float,float);
float div(float,float);
main()
{
   float x,y;int c;
   printf("1.ADDITION\n2.SUBTRACTION\n3.MULTIPLICATION\n4.DIVISION\nENTER THE APPROPRIATE CHOICE");
   scanf("%d",&c);
   printf("Enter x,y");
   scanf("%f%f",&x,&y);
   switch(c)
   {
     case 1:
          printf("The addition is %f",add(x,y));
          break;
     case 2:
          printf("The subtraction is %f",sub(x,y));
          break;
     case 3:
          printf("The multiplicaton is %f",mul(x,y));
          break;
     case 4:
          printf("The division is %f",div(x,y));
          break;
   }
}

float add(float a,float b)
{
  return(a+b);
}
float sub(float a,float b)
{
  return(a-b);
}
float mul(float a,float b)
{
  return(a*b);
}
float div(float a,float b)
{
  return(a/b);
}

