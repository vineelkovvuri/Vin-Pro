/*
	To find the distinct sub strings  we need to construct the suffix array and 
	least common prefix of the suffix array 
	distinct substring = n(n+1)/2 - lcs

	Not very much sure why this is working
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char * xp[1010];
//int xlcp[1010];
char x[1010];
int n;
int compareSA(const void *p1, const void *p2)
{
	char * cp1 = *(char **)p1;
	char * cp2 = *(char **)p2;
	return strcmp(cp1, cp2);
}

void constructSA(char *s)
{
	int i = 0;
	for (i = 0; x[i]; i++)
		xp[i] = &x[i];

	n = i;
	qsort(xp, n, sizeof(char *), compareSA);
#if 0
	for (i = 0; i < n; i++)
		printf("%s\n", xp[i]);
#endif
}

int constructLCP()
{
	//xlcp[0] = 0;
	int i = 0, sum = 0;
	for (i = 1; i < n; i++) {
		char *p1 = xp[i-1], *p2 = xp[i];
		int count = 0;
		while (*p1 || *p2) {
			if (*p1 == *p2) {
				count++; p1++; p2++;
			} else 
				break;
		}
		//xlcp[i] = count;
		sum += count;
	}
	return sum;
#if 0
	for (i = 0; i < n; i++)
		printf("%s %d\n", xp[i], xlcp[i]);
#endif

}
int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int lcp;
		scanf("%s", x);
		constructSA(x);
		lcp = constructLCP();
		printf("%d\n", n*(n+1)/2 - lcp);
	}
	return 0;
}