	
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))

int s1[27], s2[27];
char str1[1010], str2[1010];
int  main()
{
	while (scanf("%s%s", str1, str2) != EOF) {
		int i, j;
		for (i = 0; str1[i]; i++)
			s1[str1[i] - 'a']++;
		
		for (i = 0; str2[i]; i++)
			s2[str2[i] - 'a']++;
		
		for (i = 0; i < 26; i++)
			for (j = 0; j < min2(s1[i], s2[i]); j++)
				printf("%c", 'a' + i);

		printf("\n");

		for (i = 0; i < 26; i++)
			s1[i] = s2[i] = 0;
	}
	return 0;
}

