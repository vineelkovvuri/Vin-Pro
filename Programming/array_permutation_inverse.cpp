#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;
void array_permute_inverse(int *perm, int psize)
{
	for (int i = 0; i < psize; i++) {
		int prev = i;
		int curr = perm[prev];
		while (perm[curr] >= 0) {
			int temp = perm[curr];
			perm[curr] = -prev;
			prev = curr;
			curr = temp;
		}
	}

	for (int i = 0; i < psize; i++)
		perm[i] = (int)abs((double)perm[i]);
}

int array_permutation_inverse()
{

	int perm[] = {1, 2, 0, 4, 3, 5};// 201435
	int psize = sizeof(perm)/sizeof(int);

	array_permute_inverse(perm, psize);

	for (int i = 0; i < psize; i++)
		printf("%d ", perm[i]);

	return 0;
}

