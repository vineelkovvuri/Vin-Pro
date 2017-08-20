#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define max2(a, b) ((a) > (b) ? (a) : (b))
#define max4(a, b, c, d) (max2(max2(a, b), max2(c,d)))


int main()
{
	while (1) {
		int a, b, c, d, a1, b1, c1, d1;
		scanf("%d%d%d%d", &a, &b, &c, &d);
		scanf("%d%d%d%d", &a1, &b1, &c1, &d1);
		if (a == -1 && b == -1 && c == -1 && d == -1 &&
			a1 == -1 && b1 == -1 && c1 == -1 && d1 == -1) break;
		int m = max4((int)ceil(a/(double)a1), (int)ceil(b/(double)b1), (int)ceil(c/(double)c1), (int)ceil(d/(double)d1));
		printf("%d %d %d %d\n", m*a1 - a, m*b1 - b, m*c1 - c, m*d1 - d);
	}	
	return 0;
}

