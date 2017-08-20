#include<stdio.h>


int isprime(unsigned int n)
{
	unsigned int i = 1;

	if (n == 1) return 0;	
	if (n == 2 || n == 3) return 1;
	
	for (i = 2; i <= n/2; i++)
		if (n%i == 0) return 0;

	return 1;
}

int main()
{
	unsigned int n;
	unsigned int i, j;
	scanf("%d", &n);
	
	for (i = 0;i < n; i++) {
		int p, q;
		scanf("%d %d",&p, &q);
		for (j = p; j <= q; j++)
			if (isprime(j))
				printf("%u\n", j);
		printf("\n");
	}
		
	return 0;
}
