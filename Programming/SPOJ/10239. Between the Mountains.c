#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

int m1[1010], m2[1010];
#define INF 2000000
int compare(const void *p1, const void *p2)
{
	return *(int *)p1 - *(int *)p2;
}
int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int m1N, m2N, i, j;
		scanf("%d", &m1N);
		for (i = 0; i < m1N; i++)
			scanf("%d", &m1[i]);
		qsort(m1, m1N, sizeof(int), compare);
		scanf("%d", &m2N);
		for (i = 0; i < m2N; i++)
			scanf("%d", &m2[i]);
		qsort(m2, m2N, sizeof(int), compare);
#if 0		
		printf("\n");
		for (i = 0; i < m1N; i++)
			printf("%d ", m1[i]);
		printf("\n");
		for (i = 0; i < m2N; i++)
			printf("%d ", m2[i]);
#endif
#if 1
		int diff = INF;
		for (i = 0, j = 0;;) {
			if (i >= m1N || j >= m2N) break; 
			int x = m1[i];
			int y = m2[j];
			if (diff > abs(x - y))
				diff = abs(x - y);
			if (x < y) i++;
			else if (x > y) j++;
			else break;
		}
		printf("%d\n", diff);
#endif
	}
	return 0;
}
