/*
	Number of cards needed = n*(3*n+1)/2
	but this problems asks for modulo of number of cards needed with 1000007
*/

#include<stdio.h>

int main()
{
	int t;
	unsigned long long ans = 0, n = 0;
	
	scanf("%d", &t);
	while(t--) {
		scanf("%llu", &n);
		ans = ((n*(3*n + 1))/2) % 1000007;
		printf("%llu\n", ans);
	}

	return 0;
}
