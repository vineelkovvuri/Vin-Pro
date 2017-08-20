/*
	The Idea: Try to find the candidate for major element of array using Moore's Voting Algorithm
	http://www.cs.utexas.edu/~moore/best-ideas/mjrty/index.html
	and check if that is the real major element(because above algo gives correct major element only if the element
	has occured more than n/2 times, called majority of the element)

*/

#include <stdio.h>

int e[1000010];
int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int n, k, c=0,i;
		scanf("%d", &n);
		for (i = 0; i < n; i++)
			scanf("%d", &e[i]);
		for (i = 0; i < n; i++) {
			if (c == 0) {
				k = e[i];
				c = 1;
			} else {
				if (k == e[i]) {
					c++;
				} else {
					c--;
				}
			}
		}
		for (i = 0, c = 0; i < n; i++)
			if (k == e[i]) c++;

		if (c > n/2)
			printf("YES %d\n", k);
		else
			printf("NO\n");
	}
	return 0;
}