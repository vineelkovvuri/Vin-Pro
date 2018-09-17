/*
	Program to calculate Log2(x) for 1 <= x < 2
	Vineel Kumar Reddy
*/

#include<stdio.h>
#include<math.h>

int main()
{
	double an,bn,sn,x;
	printf("\nEnter value between [1,2) :");
	scanf("%lf",&x);
	if( x >= 1 && x < 2 ){   //Check for boundary conditions of input x
		an = x;				 //Initial Conditions
		bn = 1;
		sn = 0;
		while(bn != 0){
			bn = .5*bn;      
			sn = (an*an < 2) ? sn : sn + bn;
			an = (an*an < 2) ? an*an : .5*an*an;
		}
		printf("\nValue of Log2 %lf = %lf",x,sn);
	}
}

