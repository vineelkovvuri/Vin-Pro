#include<stdio.h>
#include<string.h>
#include<stdlib.h>


int main()
{
	int t;
	unsigned long long *a;
	scanf("%d", &t);
	a = malloc(sizeof(unsigned long long) * 200010);
	while (t--) {
		int n;
		int i, j;
		unsigned long long count = 0;
		scanf("%d",	&n);
		for (i = 0; i < n; i++)
			scanf("%llu", &a[i]);

		for (i = 0; i < n; i++)
			for (j = i + 1; j < n; j++)
				if (a[i] > a[j]) count++;

		printf("%llu\n", count);
	}

	free(a);
	return 0;
}

