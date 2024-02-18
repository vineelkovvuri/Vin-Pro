/* solution to quadratic equation */
#include<stdio.h>
#include<math.h>
main()
{
float x,a,b,c,d,r,j;
printf("\nenter a,b,c");
scanf("%f%f%f",&a,&b,&c);
  if(a==0)
   {
     x=-c/b;
     printf("common root %f",x);
   }
  d=b*b-4*a*c;
  if(d>=0&&a!=0)
  {
    r=-b/(2*a);
    j=sqrt(d)/(2*a);
      printf("real roots are %f,%f",r+j,r-j);
  }
  else if(d<0&&a!=0)
  {
    r=-b/(2*a);
    j=sqrt(-d)/(2*a);
      if(j>0)
	printf("imaginary roots are %f+%fi,%f-%fi",r,j,r,j);
      else if(j<0){printf("imaginary roots are %f%fi,",r,j);
		   j=-1*j;printf("%f+%fi",r,j);}
}
getch();
}