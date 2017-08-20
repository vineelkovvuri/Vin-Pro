/*
	Idea is to copy the string as shown below and find the substring of length n which is lexiographically smallest

	helloworld
	helloworldhelloworl
	The above facilitate the easy comparision of round about the string
*/


#include <stdio.h>
#include <string.h>
#include <stdlib.h>


char s[10010*2];
int n;

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int i, imin = 0;
		scanf("%s", s);
		n = strlen(s);
		strncat(&s[n], &s[0], n-1);

		for (imin = 0, i = 1; i < n; i++)
			if (strncmp(&s[imin], &s[i], n) > 0) imin = i;

		printf("%d\n", imin + 1);
	}
	return 0;
}