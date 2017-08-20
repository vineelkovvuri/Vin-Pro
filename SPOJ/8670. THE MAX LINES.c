#include<stdio.h>

/*
First of all angle CAB is right(90 degrees). 

From there AB^2 + AC^2 = (2r)^2
=> AB^2 = 4r^2 - AC^2

s = AB^2 + AC
=> s = 4r^2 - AC^2 + AC
=> s = -AC^2 + AC + 4r^2

This is a quadratic function. We have to find its maximum. From school you 
know that it is when AC = -b / 2a(Where a and b are the coefficients of the quadratic equation). 

=> AC = -b / 2a = -1 / (-2) = 1/2

=> S = -(1/2)^2 + 1/2 + 4r^2 = -1/4 + 1/2 + 4r^2 = 1/4 + 4r^2 = 0.25 + 4r^2

*/

int main()
{
	int t, i;
	scanf("%d", &t);
	for (i = 1; i <= t; i++) {
		int r;
		scanf("%d", &r);
		printf("Case %d: %.2f\n", i, 0.25 + 4.0*r*r);
	}
	return 0;
}


