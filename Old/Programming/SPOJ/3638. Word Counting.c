#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>

#define MAX_SEN_LEN 1000*20*2
char s[MAX_SEN_LEN];
int words[1010];
int wordscnt[1010];
int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int word = 0, i, cnt = 0, k = 0;
		char c;
		while (!isalpha(c = getchar()));
		ungetc(c, stdin);
		scanf("%[^\n]", s);

		for (i = 0, word = 0, cnt = 0; ; i++) {
			c = s[i];
			if (!isalpha(c)) {
				if (cnt != 0)
					words[word++] = cnt;
				cnt = 0;
				if (c == 0) break;
			} else if (isalpha(c)) {
				cnt++;
			}
		}
		wordscnt[0] = 1;
		for (i = 1, k = 0; i < word; i++) {
			if (words[i] == words[i-1]) wordscnt[k]++;
			else wordscnt[++k] = 1;
		}
		int max = 0;
		for (i = 0; i <= k; i++)
			if (max < wordscnt[i]) max = wordscnt[i];
		printf("%d\n", max);

	}
	return 0;
}