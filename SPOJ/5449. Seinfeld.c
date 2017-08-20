	
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

char st[2010];
char s[2010];	
int  main()
{
	int  t;
	for (t = 1; ;t++) {
		int top = -1, i, j;
		scanf("%s", s);
		if (s[0] == '-') break;
		for (i = 0; s[i]; i++) {
			char x = s[i];
			if (x == '}') {
				if (top > -1 && st[top] == '{')
					top--;
				else
					st[++top] = '}' ;
			} else {
				st[++top] = '{' ;
			}
		}
		int count = 0;
		for (i = 0; i < top; i += 2) {
			if (st[i] == '{' && st[i + 1] == '{') count++;
			else if (st[i] == '}' && st[i + 1] == '}') count++;
			else if (st[i] == '}' && st[i + 1] == '{') count += 2;
		}
		printf("%d. %d\n", t, count);
	}
	return 0;
}

