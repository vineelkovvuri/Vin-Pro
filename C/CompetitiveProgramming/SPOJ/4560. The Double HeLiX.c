#include <stdio.h>

#define INF 20000
int x[10010], y[10010];

int main()
{
	while (1) {
		int i, j, nx, ny, sx = 0, sy = 0, smax = 0;
		scanf("%d", &nx);
		if (nx == 0) break;
		
		for (i = 0; i < nx; i++)
			scanf("%d", &x[i]);

		scanf("%d", &ny);
		for (i = 0; i < ny; i++)
			scanf("%d", &y[i]);
		
		i = j = 0;
		while (1) {
			int a = i < nx ? x[i] : INF;
			int b = j < ny ? y[j] : INF;
			if (i >= nx && j >= ny) break;
			
			if (a < b) {
				sx += a;
				i++;
			} else if (a > b) {
				sy += b;
				j++;
			} else if (a == b) {
				smax += (sx > sy) ? sx : sy;
				smax += a;
				sx = sy = 0;
				i++;
				j++;	
			}
		}
		smax += (sx > sy) ? sx : sy;
		printf("%d\n", smax);
		
	}
	return 0;
}