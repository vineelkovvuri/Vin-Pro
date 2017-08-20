/*
	Idea here is to, Use XOR, The beauty with XOR operation is it will nullify duplicates
	only leaving element which has appeared once
*/

#include<stdio.h>

int main()
{
	int t;
	unsigned long long ans = 0, n = 0;
	
	scanf("%d", &t);
	while(t--) {
		scanf("%llu", &n);
		ans ^= n;
	}
	printf("%llu\n", ans);
	return 0;
}
