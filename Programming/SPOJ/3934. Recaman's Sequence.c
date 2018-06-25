/*
The limits clearly indicate that we should pre-compute the sequence, which is a very easy task once you can estimate 
what could be the maximum value upto which it can go. Here, i have taken it to go till seven times the number itself.
*/

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define MAX 500000
char h[7*MAX + 1] = {0};
int a[MAX + 10] = {0};

int main()
{
	int i;
	for (i = 1; i <= MAX; i++) {
		if (a[i-1] - i <= 0 || h[a[i-1]-i] == 1)
			a[i] = a[i-1] + i;
		else
			a[i] = a[i-1] - i;
		h[a[i]] = 1;
	}
	while (1) {
		int m;
		scanf("%d", &m);
		if (m == -1) break;
		printf("%d\n", a[m]);
	}
	return 0;
}

