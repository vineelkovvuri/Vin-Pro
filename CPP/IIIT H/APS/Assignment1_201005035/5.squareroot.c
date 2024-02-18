/*
	Program to calculate Sqrt(x) for 0 < x < 2
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
		an = x;				//Initial Conditions
		cn = 1-x;
		while(cn != 0){
			an = an*(1+.5*cn);
			cn = cn*cn*.25*(3+cn);
		}
		printf("\nValue of Sqrt(%lf) = %lf",x,an);
	}
}
