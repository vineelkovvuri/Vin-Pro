/*
The limits clearly indicate that we should pre-compute the sequence, which is a very easy task once you can estimate 
what could be the maximum value upto which it can go. Here, i have taken it to go till seven times the number itself.

Optimized for memory by packing true false value in h using bit manipulation
*/

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define MAX 500000
int a[MAX + 10] = {0};
char h[MAX] = {0};

void set(int m)
{
	int x = m/8;
	int r = m%8;
	h[x] |= (1 << r);
}
int get(int m)
{
	int x = m/8;
	int r = m%8;
	return (h[x]>>r) &1;
}


int main()
{
	int i;
	for (i = 1; i <= MAX; i++) {
		if (a[i-1] - i <= 0 || get(a[i-1]-i) == 1)
			a[i] = a[i-1] + i;
		else
			a[i] = a[i-1] - i;
		set(a[i]);
	}
	
	while (1) {
		int m;
		scanf("%d", &m);
		if (m == -1) break;
		printf("%d\n", a[m]);
	}
	return 0;
}

