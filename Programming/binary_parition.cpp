#include <stdio.h>
#include <utility>

using namespace std;

void binary_partition(int *a, int n)
{
	for (int i = 0, j = n - 1; i < j;) {		
		if (a[i] == 1 && a[j] == 0)
			swap(a[i], a[j]);
		
		if (a[i] == 0) i++;
		if (a[j] == 1) j--;
	}
}

int binary_parition()
{
	int i = 0;
	int arr[] = {1, 0, 1, 1, 0, 0};
	int n = sizeof(arr)/sizeof(int);

	binary_partition(arr, n);

	for (i = 0; i < n; i++)
		printf("%d ", arr[i]);
	printf("\n");
	return 0;
}