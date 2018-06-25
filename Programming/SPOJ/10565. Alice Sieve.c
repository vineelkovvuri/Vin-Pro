/*
	With the problem description all number from N/2 to 2 will be nullified because...
	for each N the proper divisor always starts with N/2 and every number from N/2 to 2 will
	have a multiple in the range N to N/2 + 1. So the numbers that aren't nullified are
	the entire range [N, N/2 + 1]
*/


#include <stdio.h>

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int n;
		scanf("%d", &n);
		printf("%d\n", n - n/2);
	}
	return 0;
}