#include <stdio.h>
#define max2(a, b) ((a) > (b) ? (a) : (b))
int n, a[110][110], t, i, j, m;
int  main()
{
	scanf("%d", &t);
	while (t--) {
		scanf("%d", &n);
		for (i = 1; i <= n; i++) {
            m = -1;
			for (j = 1; j <= i; j++) {
				scanf("%d", &a[i][j]);
				a[i][j] += max2(a[i-1][j],a[i-1][j-1]);
				m = max2(m,a[i][j]);
			}
		}
		printf("%d\n", m);
	}
	return 0;
}

