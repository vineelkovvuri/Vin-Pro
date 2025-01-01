/*
	The idea here is, Though many say it to be DP. I feel it more specifically Topdown recursion with memoization.

	f(0, n-1) denotes the maximum revenue after selling 0, n-1 treats each day one from either 0(start) or from n-1(end)
	This can be formualted using below recursive formula.

	f(i, j) = max{ f(i+1, j) + v[i]*(n-(j-i)) , f(i, j-1) + v[j]*(n-(j-i))}
	here n-(j-i) denotes the day. We are just finding the max {first treat on first day , last treat on first day}
	
	I believe this is not true dp because we are not finding the optimal substructure instead we are just enumerating 
	all possible ways and using memoization to speedup the process.

	Examples: 
		6 | 6 1 1 1 5 5  . Ans = 70 <- Greedy approach fails
	 	5 | 1 3 1 5 2    . Ans = 43 <- Greedy approach works
*/

#include <stdio.h>

#define max2(a, b) ((a) > (b) ? (a) : (b))
int v[2010];
int dp[2010][2010];
int n;

int f(int i, int j)
{
	if (i >= n || j < 0 || i > j) return 0;
//	printf("i = %d j = %d\n", i, j);
	if (dp[i][j] != 0) return dp[i][j];
	int x = f(i + 1, j) + v[i]*(n - (j - i));
	int y = f(i, j - 1) + v[j]*(n - (j - i));
	return dp[i][j] = max2(x, y);
}


int main()
{
	int i, j;
	scanf("%d", &n);
	for (i = 0; i < n; i++)
		scanf("%d", &v[i]);

	f(0, n-1);
	
	printf("%d", dp[0][n-1]);
	
#if 0
	for (i = 0; i < n; i++) {
		for (j = 0; j < n; j++)
			printf("%3d ", dp[i][j]);
		printf("\n");
	}
#endif	
	return 0;
}