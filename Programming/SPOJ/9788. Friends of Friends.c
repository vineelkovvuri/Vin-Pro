#include <stdio.h>

char con[10000];
int main()
{
	int N, i, j, count = 0;
	scanf("%d", &N);
	for (i = 0; i < N; i++) {
		int f, nf;
		scanf("%d", &f);
		con[f] = 'F';
		scanf("%d", &nf);
		for (j = 0; j < nf; j++) {
			int mf;
			scanf("%d", &mf);
			if (con[mf] == 0)
				con[mf] = 'M';
		}
	}
	for (i = 0; i < 10000; i++)
		if (con[i] == 'M') count++;
	
	printf("%d\n", count);
	return 0;
}
