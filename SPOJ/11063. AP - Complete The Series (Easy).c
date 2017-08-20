#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		unsigned long long t3, tn3, s, n = 0, a = 0, d = 0, i;
		scanf("%llu%llu%llu", &t3, &tn3, &s);
		n = 2*s/(t3 + tn3);
		d = (tn3 - t3)/(n - 5);
		a = t3 - 2 * d;
		printf("%llu\n", n);
		for (i = 1; i <= n; i++)
			printf("%llu ", a + (i - 1) * d);
		printf("\n");	
		
	}
	return 0;
}

