#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;

int remove_element(int *a, int m, int k)
{
	int i = 0, j = 0;
	for (i = 0; i < m; i++) {
		if (a[i] != k) {
			a[j] = a[i];
			j++;
		}
	}
	return j;
}

int delete_element_from_array()
{
	int a[] = {1, 1, 1, 1, 1, 1, 1, 1};
	int m = sizeof(a)/sizeof(int);
	int k = 1;
	
	int len = remove_element(a, m, k);
	for (int  i = 0; i < len; i++) 
		printf("%d ", a[i]);

	return 0;
}
	
