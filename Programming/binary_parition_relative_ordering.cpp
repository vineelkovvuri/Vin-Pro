
// Program to parition binary objects in to two sets
// but by honoring the order among objects of type true (1)
#include <stdio.h>
#include <utility>

using namespace std;

void binary_partition_relative_ordering(int *a, int n)
{
	int l = n - 1;
	int h = n - 1;
	
	while (l >= 0) {
		if (a[l] == 1) // preserves the order of object of 1
			swap(a[l--], a[h--]);
		else if (a[l] == 0)
			l--;
	}
}

int binary_parition_relative_ordering()
{
	int i = 0;
	int arr[] = {0, 1, 0, 1, 1, 0, 0, 1, 0};
	int n = sizeof(arr)/sizeof(int);

	binary_partition_relative_ordering(arr, n);

	for (i = 0; i < n; i++)
		printf("%d ", arr[i]);
	printf("\n");
	return 0;
}