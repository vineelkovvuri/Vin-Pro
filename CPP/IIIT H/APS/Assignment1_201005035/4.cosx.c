/*
	Program to calculate Cos(x)
	Vineel Kumar Reddy
*/

#include<stdio.h>
#include<math.h>

int main()
{
	double term,sum,x,i;
	printf("\nEnter the value of x:");
	scanf("%lf",&x);
	sum = term = 1;
	for(i = 1; fabs(term) > 0.00001 ; i++){
		term = -term*x*x/(2*i*(2*i-1));
		sum += term;
	}
	printf("\nValue of Cos(%lf) = %lf",x,sum);
}

