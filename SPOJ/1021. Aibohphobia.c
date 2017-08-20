/*
	The idea here is, Find the LCS of given string with reverse of the string.
	The answer will be n - LCS(str, R(str));
*/

#include <stdio.h>
#include <string.h>
#define max2(a, b) ((a) > (b) ? (a) : (b))

short dp[7000][7000];
char x[7000];
short n;
short lcs_itr()
{
	short i, j;
	for (i = 1; i <= n; i++) {
		for (j = 1; j <= n; j++) {
			if (x[i - 1] == x[n-1-(j - 1)])
				dp[i][j] = dp[i-1][j-1] + 1;
			else
				dp[i][j] = max2(dp[i-1][j], dp[i][j-1]);
		}
	}
	return dp[i-1][j-1];
}

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		scanf("%s", x);
		n = strlen(x);
		printf("%d\n", n - lcs_itr());
#if 0
		int i,j;
		for (i = 1; i <= n; i++) {
			for (j = 1; j <= n; j++)
				printf("%3d", dp[i][j]);
			printf("\n");
		}
#endif
	}
	return 0;

}
