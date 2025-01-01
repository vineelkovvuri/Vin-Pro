#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define INF 0xFFFFFFF

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define min3(a, b, c) min2(a, min2(b, c))

int a[110][110];
int dp[110][110];
int main()
{
	int m, n, i, j;
	scanf("%d%d", &m, &n);
	for (i = 0; i < m; i++) {
		for (j = 0; j < n; j++) {
			scanf("%d", &a[i][j]);
		}
	}
	for (i = 0; i < m; i++) {
		for (j = 0; j < n; j++) {
			int x = i-1 >= 0 && j-1 >= 0 ? dp[i-1][j-1] : INF;
			int y = i-1 >= 0 && j   >= 0 ? dp[i-1][j  ] : INF;
			int z = i-1 >= 0 && j+1 <  n ? dp[i-1][j+1] : INF;
			dp[i][j] = a[i][j] + (min3(x, y, z) != INF? min3(x, y, z) : 0); 
		}
	}
	int min = INF;
	for (j = 0; j < n; j++)
		if(min > dp[m - 1][j]) min = dp[m - 1][j];
	printf("%d\n", min);
	return 0;
}

