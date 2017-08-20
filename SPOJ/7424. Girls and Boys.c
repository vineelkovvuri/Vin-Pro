#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

int main()
{
	int b, g;
	while (1) {
		scanf("%d%d", &b, &g);
		if (b == -1 && g == -1) break;
		printf("%.f\n", ceil(max2(b, g)/(double)(min2(b, g) + 1)));
	}
	return 0;
}

