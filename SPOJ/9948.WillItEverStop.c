#include<stdio.h>
#include<stdlib.h>
#include<string.h>
/*
		'if (n & 1 == 0)' mean 'if (n & (1 == 0))'
		hence be careful when bit wise comparisions 
		correct way to check is 'if ((n & 1) == 0)'
*/
int main()
{
	unsigned long long n, n1;
	scanf("%llu", &n);
	while (n > 1) {
		if (n % 3 == 0) { /* when n becomes a multiple of 3 it will never stop */
			printf("NIE\n");
			return 0;
		}
		if ((n & 1) == 0)
			n >>= 1;
		else
			n = 3 * n + 3;
	}
	printf("TAK\n");
	return 0;
}

