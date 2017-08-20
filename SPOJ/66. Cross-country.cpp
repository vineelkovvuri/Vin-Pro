#include <iostream>
#include <algorithm>
#include <vector>
#include <cstdio>

using namespace std;

int dp[2010][2010];

int lcs(vector<int> &v1, vector<int> &v2)
{
	int i, j;
	for (i = 1; i <= v1.size(); i++) {
		for (j = 1; j <= v2.size(); j++) {
			if (v1[i - 1] == v2[j - 1])
				dp[i][j] = dp[i-1][j-1] + 1;
			else
				dp[i][j] = max(dp[i-1][j], dp[i][j-1]);
		}
	}
	return dp[i-1][j-1];
}

int main()
{
	int t;
	vector<int> v1, v2;
	scanf("%d", &t);
	while (t--) {
		int _max = -1, c;
		v1.clear();
		while (1) {
			scanf("%d", &c);
			if (c == 0) break;
			v1.push_back(c);
		}
		while (1) {
			v2.clear();
			scanf("%d", &c);
			if (c == 0) break;
			v2.push_back(c);
			while (1) {
				scanf("%d", &c);
				if (c == 0) break;
				v2.push_back(c);
			}
			_max = max(_max, lcs(v1, v2));
		}
		printf("%d\n", _max);
	}
	return 0;
}
