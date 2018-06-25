//spoj id: 902
#include<stdio.h>

/*
points to be noted
1. %lf should be used when reading doubles via scanf
2. any arthimetic operation which are expected to be double should have all expression in double format
	example: s + 1.0f/(++count); 
			 1.0f is required or else it becomes integer expression first
3. when comparing expression like if (x == 0.12) x should be double since 0.12 is promoted to double by default.
	if this is not possible then the above if should be modified as if (x == 0.12f) 0.12 with f specifier
*/



int main()
{
	int count = 0;
	double x = 0, s = 0;
	while (1) {
		scanf("%lf", &x);
		if (x == 0.00) break;
		s = 0;
		count = 1;
		while (s < x) {
			s += 1.0f/(++count);
//			printf("%f %d\n", s,count);
		}
		printf("%d card(s)\n", count - 1);
	}
	return 0;
}
