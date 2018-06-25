	
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

int health[510];

int  main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int i, j, n, m, D;
		scanf("%d%d%d", &n, &m, &D);
		for (i = 0; i < n; i++)
			scanf("%d", &health[i]);
		int died = 1;		
		for (i = 0; i < m; i++) {
			died = 1;	
			for (j = 0; j < n; j++) {
				if (health[j] > D) {
					health[j] -= D;
					died = 0;
					break;
				}
			}
			if (died) break;
		}
		printf(died?"NO\n":"YES\n");
	}
	return 0;
}

