#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct account {
	int a, b, c, d, e, f;
	int count;
} acc[100010];


int compare(const void *p1, const void *p2)
{
	struct account *a1, *a2;
	a1 = (struct account *)p1;
	a2 = (struct account *)p2;
	if (a1->a != a2->a) return a1->a - a2->a;
	else if (a1->b != a2->b) return a1->b - a2->b;
	else if (a1->c != a2->c) return a1->c - a2->c;
	else if (a1->d != a2->d) return a1->d - a2->d;
	else if (a1->e != a2->e) return a1->e - a2->e;
	return a1->f - a2->f;
}

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int n, k, i;
	
		scanf("%d", &n);
		for (i = 0; i < n; i++) {
			scanf("%d%d%d%d%d%d", &acc[i].a, &acc[i].b, &acc[i].c, &acc[i].d, &acc[i].e, &acc[i].f);
			acc[i].count = 1;
		}
		qsort(acc, n, sizeof(struct account), compare);
		for (k = 0, i = 1; i < n; i++) {
			if (compare(&acc[k], &acc[i]) == 0)
				acc[k].count++;
			else
				acc[++k] = acc[i];
		}
		for (i = 0; i <= k; i++)
			printf("%02d %08d %04d %04d %04d %04d %d\n", acc[i].a, acc[i].b, acc[i].c, acc[i].d, acc[i].e, acc[i].f, acc[i].count);

	}
	return 0;
}