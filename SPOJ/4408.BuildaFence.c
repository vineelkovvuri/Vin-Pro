#include<stdio.h>
#include<stdlib.h>
#include<string.h>

#define pi  3.14159265359
#define pi1 0.31830988618

int main()
{
	int t;
	while (1) {
		double r = 0;
		scanf("%d", &t);
		if (t == 0) break;
		r = t * pi1;
		printf("%.2f\n", pi * r * r/2);
	}
	return 0;
}

