
#include<stdio.h>

#define IMAX 100000 + 10

long long hall[IMAX][3];
long long dphall[IMAX][3];

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define min3(a, b, c) min2(a, min2(b, c)) 
#define min4(a, b, c, d) min2(min2(a, b), min2(c, d)) 
#define min5(a, b, c, d, e) min2(min4(a, b, c, d), e) 
#define INF 0x2fffffff
int main()
{
	long long t = 0;
	while (1) {
		long long M, N = 3, i, j, min = 0;
		scanf("%lld", &M);
		if (M == 0) break;
		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				scanf("%lld", &hall[i][j]);
				dphall[i][j] = 0;
			}
		}

		if (M > 2) {
			dphall[0][0] = hall[0][0];
			dphall[0][1] = hall[0][1];
			dphall[0][2] = hall[0][2];
			dphall[1][0] = hall[1][0] + hall[0][1];
			dphall[1][1] = hall[1][1] + min3(hall[0][1], hall[0][1] + hall[0][2], dphall[1][0]);
			dphall[1][2] = hall[1][2] + min3(dphall[1][1], hall[0][1], hall[0][1] + hall[0][2]);

			for (i = 2; i < M - 1; i++) {
				for (j = 0; j < N; j++) {
					long long a = i-1 >= 0 && j-1 >= 0 ? dphall[i-1][j-1] : INF;
					long long b = i-1 >= 0 && j-0 >= 0 ? dphall[i-1][j-0] : INF;
					long long c = i-1 >= 0 && j+1 <  N ? dphall[i-1][j+1] : INF;
					long long d = i-0 >= 0 && j-1 >= 0 ? dphall[i-0][j-1] : INF;
					long long _min = min4(a, b, c, d);
					dphall[i][j] = hall[i][j] + (_min == INF ? 0 : _min);
				}
			}
			min = hall[M-1][1] + min5(dphall[M-2][0] + hall[M-1][0],
					dphall[M-2][0],
					dphall[M-2][1] + hall[M-1][0],
					dphall[M-2][1],
					dphall[M-2][2]);
		} else {
			min = hall[M-1][1] + min3(hall[M-2][1] + hall[M-1][0],
					hall[M-2][1],
					hall[M-2][1] + hall[M-2][2]);
		}
#if 0
		printf("\n");
		for (i = 0; i < M - 1; i++) {
			for (j = 0; j < N; j++) {
				printf("%3lld ", dphall[i][j]);
			}
			printf("\n");
		}

		printf("\n");
#endif
		printf("%lld. %lld\n", ++t, min);
	}
	return 0;
}

