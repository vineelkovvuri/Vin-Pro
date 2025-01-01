#include <stdio.h>


int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int n, count, i;
		scanf("%d", &n);
		for (count = n, i = 2; i*i <= n; i++) {
			if (n % i == 0) count -= count / i;
			while (n % i == 0) n /= i;
		}
		if (n > 1) count -= count / n; // This is needed if the given number is prime
		printf("%d\n", count);  //when n is 1 count is assinged to 1 in the beginning of the for loop
	}
	return 0;
}