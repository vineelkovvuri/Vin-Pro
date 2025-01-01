#include<stdio.h>
#include<stdlib.h>
#include<math.h>

int main()
{
	unsigned int n;
	int x;
	unsigned int i, j, k;
	unsigned int *arr;
	unsigned int _sqrt;
	unsigned int p, q;

	scanf("%d", &n);
	arr = malloc(sizeof(unsigned int) * (100020));

	for (i = 0; i < n; i++)	 
	{
		scanf("%u %u",&p, &q);

		if (p == 1) p = 2;
		for (j = p; j <= q; j++)
			arr[j - p] = j;
		
		_sqrt = sqrt(q);
		for (j = 2; j <= _sqrt; j++)	 {
			x = p-j*j;
			if ( x < 0) {
				k = j * j;
			}
			else {
				x /= j;
				k = j * j + x*j;
			}
			if (k < p) k += j;
			
			for (; k <= q; k += j) 
					arr[k - p] = 0; 
		
		}
		for (k = 0; k < q - p + 1; k++)	
			if (arr[k] != 0)
				printf("%u\n", arr[k]);

		printf("\n");
	}
	free(arr);
	return 0;
}
