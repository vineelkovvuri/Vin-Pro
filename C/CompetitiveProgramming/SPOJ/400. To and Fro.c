//spoj id: 400
#include<stdio.h>
#include<string.h>


int main()
{
	int t;
	int n;
	char s[210] = {0};
	while (1) {
		scanf("%d", &n);
		if (n == 0) break;
		scanf("%s", s);
		{
			int p, q, i;
			int len = strlen(s);
			for (i = 0; i < n; i++) {
				p = i;
				q = 2*n - p - 1;
				while (p < len || q < len) {
					if (p < len) {
						printf("%c", s[p]);
						p += 2*n;
					}
					if (q < len) {
						printf("%c", s[q]);
						q += 2*n;
					}
				}
			}
			printf("\n");
		}
	}
	return 0;
}
