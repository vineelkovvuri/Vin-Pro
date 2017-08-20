/*

	Idea here is, what is the maximum stones that one can collect assuming
	the current tile to be in the final path?
	To solve this we take a dp matrix where each element denote the maximum
	stones that can be collected if that tile is on the path. This depends on
	the previous tile's maximum stones collected.

	dphall[i][j] = hall[i][j] + max3(dphall[i-1][j-1], dphall[i-1][j], dphall[i-1],[j+1])

*/

#include<stdio.h>

int hall[110][110];
int dphall[110][110];

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

#define min3(a, b, c) min2(a, min2(b, c)) 
#define max3(a, b, c) max2(a, max2(b, c))

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int M, N, i, j;
		int rowMax = -1;
		scanf("%d %d", &M, &N);
		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				scanf("%d", &hall[i][j]);
				dphall[i][j] = 0;
			}
		}

		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				int x = i-1 >= 0 && j-1 >= 0 ? dphall[i-1][j-1] : 0;
				int y = i-1 >= 0 && j-0 >= 0 ? dphall[i-1][j-0] : 0;
				int z = i-1 >= 0 && j+1 <  N ? dphall[i-1][j+1] : 0;
				dphall[i][j] = hall[i][j] + max3(x, y, z);
			}
		}

		for (j = 0; j < N; j++)
			if (rowMax < dphall[M-1][j])
				rowMax = dphall[M-1][j];
		printf("%d\n", rowMax);
	}
	return 0;
}

