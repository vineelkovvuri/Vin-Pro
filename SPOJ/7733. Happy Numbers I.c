#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

unsigned long h[1000];
int main()
{
	unsigned long n, i = 0, k = 0, s, count = 0, loop = 0;
	scanf("%lu", &n);
	s = n;
	while (s != 1) {
		n = s;
		s = 0;
		while (n) {
			s += (n%10) * (n%10);
			n /= 10;
		}
		for (i = 0; i < k; i++)
			if (h[i] == s) {
				loop = 1;
				break;
			}
		if (loop == 1) break;	
		h[k++] = s;
		count++;
	}
	if (loop == 0) printf("%lu", count);
	else printf("-1");
	
	return 0;
}

