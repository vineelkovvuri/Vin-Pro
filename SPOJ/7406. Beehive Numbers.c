#include<stdio.h>
#include<string.h>
#include<stdlib.h>

/*
	f(0) = 1, f(1) = 6, f(2) = 12, f(3) = 18, f(4) = 24......
	where f(n) give the total number of cells surrounded in the nth round.
	no total number of cells in the bee heive is sum of f(0) to f(n) 
*/


int main()
{
	long long n;
	while (1) {
		long long s, i;
		scanf("%lld", &n);
		if (n == -1) break;
		for (s = 1, i = 0; s <= n; i++, s = s + 6 * i) {
			if (s == n) {
				printf("Y\n");
				break;
			}
		}
		if (s > n) {
			printf("N\n");
		}
	}
	return 0;
}
