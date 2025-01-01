#include <stdio.h>

int main()
{
	while (1) {
		int i, n, count = 0;
		scanf("%d", &n);
		if (n == 0) break;
		for (i = 15;n; i--) {
			 if ((n>>i)&1) {
				 count++;
				 n>>=1;
			 }
		}
		printf("%d\n", count-1);
	}
	return 0;
}
