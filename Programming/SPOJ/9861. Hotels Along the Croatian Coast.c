/*
The idea here is to maintain a window(of sum of elements). Make the window as close as possible 
to the required value. Expand and contract the window to the closer value needed 
*/

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

unsigned long long a[300010];

int main()
{
	unsigned long long N,M,i,j, close_max = 0, max = 0;
	scanf("%llu%llu", &N, &M);
	for (i = 0; i < N; i++)
		scanf("%llu", &a[i]);

	for (i = 0, j = 0; j < N;) {
		//expand window
		if (max + a[j] <= M) {
			max += a[j++];
			if (max > close_max) close_max = max;
			if (close_max == M) break;
		} else {
			//start new window
			if (i == j) {
				max = 0;
				i++; j++;
			} else { //contract window
				max -= a[i++];
			}
		}
	}
	printf("%llu\n", close_max);
	return 0;
}

