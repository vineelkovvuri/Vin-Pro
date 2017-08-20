#include<stdio.h>

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int M,N;
		scanf("%d%d", &M, &N);
		if (M <= N) {
			if (M % 2 == 1) printf("R\n");
			else printf("L\n");
		} else {
			if (N % 2 == 1) printf("D\n");
			else printf("U\n");
		}
	}
	return 0;
}
