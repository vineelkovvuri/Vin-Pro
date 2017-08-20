	
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

//unsigned long long s[10]

int  main()
{
	unsigned long long  i, j,n = 0;
	int t;
	scanf("%d", &t);
	while (t--) {
		scanf("%llu", &n);
		for (i = 0, j = sqrt(n); i <= j;) {
			if (i*i + j*j > n) j--;
			else if (i*i + j*j < n) i++;
			else if (i*i + j*j == n) {
				printf("Yes\n");
				break;
			} 
		}
		if (i > j) printf("No\n");
	}
	return 0;
}

