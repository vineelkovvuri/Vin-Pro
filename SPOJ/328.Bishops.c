#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

/*
	2(n-1) for all n > 1. first row is completely filled and last row is filled leaving first and last square( so n + n - 2)
	1 for n == 1
*/

int main()
{
	char n[110] = {0}, s[200] = {0};
	int j = 0, k = 0;
	while (scanf("%s", n) != EOF) {
		int len = strlen(n);
		int i;
		j = 0;
		k = 0;
		i = len - 1;

		if (len == 1 && n[0] == '1') {
			printf("1\n");
			continue;
		}
		if (len == 1 && n[0] == '0') {
			printf("0\n");
			continue;
		}

		int d = n[i] - '0';
		if (d == 0) {
			j = i - 1;
			while (n[j--] == '0');
			j++;
			n[j]--;
			while (++j <= i) {
				n[j] = '9';
			}
		} else {
			n[i] = (--d) + '0';
		}
//		printf("n = %s\n", n);
		//multiply by 2
		j = 0;
		int c = 0;
		//len = strlen(n);
		for (i = len - 1; i >= 0; i--) {
			int d = (n[i] - '0') * 2 + c;
			c = d / 10;
			d = d % 10;
			s[j++] = d + '0';
		}
		if (c) {
			s[j++] = c + '0';
		}
		s[j] = 0;
		for (i = j - 1; i >= 0; i--)
			printf("%c", s[i]);
		printf("\n");
		
		
		
		
	}
	return 0;
}

