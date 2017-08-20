#include <stdio.h>

int main()
{
	int i = 0, x[11], s1 = 0, s2 = 0;
	for (i = 0; i < 10; i++)
		scanf("%d", &x[i]);
	for (i = 0; i < 10; i++) {
		s1 += x[i];
		if (s1 == 100) {
			printf("100\n");
			break;
		} else if (s1 > 100) {
			if (s2 == -1)
				printf("%d\n", s1);
			else if (s1 - 100 > 100 - s2)
				printf("%d\n",s2);
			else if (s1 - 100 == 100 - s2)
				printf("%d\n",s1);
			else if (s1 - 100 < 100 - s2)
				printf("%d\n",s1);
			break;
		}
		s2 = s1;
	}
	if (i == 10) printf("%d\n", s1);
	return 0;
}

