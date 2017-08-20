/*
	Program to calculate 1/x for 0 < x < 2
	Vineel Kumar Reddy
*/

#include<stdio.h>
#include<math.h>

int main()
{
	double an,cn,x;
	printf("\nEnter value between (0,2) :");
	scanf("%lf",&x);
	if( x > 0 && x < 2 ){	//Check for boundary conditions of input x
		an = 1;				//Initial Conditions
		cn = 1-x;
		while(fabs(cn) > 0.000001){
			an = an*(1+cn);
			cn = cn*cn;
		}
		printf("\nValue of 1/(%lf) = %lf",x,an);
	}
}
