#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;
void array_permute(int *string, int ssize, int *perm, int psize)
{
	for (int i = 0; i < ssize; i++) {
		int prev = string[i];
		int curr = perm[i];
		while (string[curr] >= 0) {
			int temp = string[curr];
			string[curr] = -prev;
			prev = temp;
			curr = perm[curr];
		}
	}

	for (int i = 0; i < ssize; i++)
		string[i] = abs((double)string[i]);
}

int array_permutation()
{

	int string[] = {'a', 'b', 'c', 'd', 'e', 'f'};
	int ssize = sizeof(string)/sizeof(int);
	int perm[] = {1, 2, 0, 4, 3, 5};
	int psize = sizeof(perm)/sizeof(int);

	array_permute(string, ssize, perm, psize);

	for (int i = 0; i < ssize; i++)
		printf("%c ", string[i]);

	return 0;
}
	
