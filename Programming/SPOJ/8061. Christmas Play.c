#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int h[20010];

int compare(const void *p1, const void *p2)
{
	return *(int*)p1 - *(int *)p2;
}

int main()
{
	int t;
	//srand(time(NULL));
	//t = 30;
	scanf("%d", &t);
	while (t--) {
		int n, k, i, min;
	//	n = 20000;
	//	k = rand()%n;
	
		scanf("%d%d", &n, &k);
		for (i = 0; i < n; i++) {
	//		h[i] = rand();
			scanf("%d", &h[i]);
		}
		qsort(h, n, sizeof(int), compare);
		
		min = 2000000000;
		for (i = 0; i < n - (k - 1); i++)
			if (min > h[i + k - 1] - h[i]) min = h[i + k - 1] - h[i];
		printf("%d\n", min);
	}
	return 0;
}