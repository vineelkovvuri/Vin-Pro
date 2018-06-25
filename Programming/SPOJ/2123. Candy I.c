//spoj id: 2123
#include<stdio.h>
#include<stdlib.h>


int main()
{
	int n, s, count, i;
	int *k;
	k = malloc(11000 * sizeof(int));
	while(1) {
		scanf("%d", &n);
		if (n == -1) break;
		
		s = 0;
		count = 0;
		for (i = 0; i < n; i++) {
			scanf("%d", &k[i]);
			s += k[i];
		}
		if (s%n == 0) {
			int eq = s/n;
			for (i = 0; i < n; i++)
				count += k[i] > eq ? k[i] - eq : 0;
			printf("%d\n", count);
		} else {
			printf("-1\n");
		}
	}
	free(k);
	return 0;
}

