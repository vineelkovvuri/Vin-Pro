#include <stdio.h>
#include <utility>

using namespace std;

void dutch_flag(int *arr, int n)
{
	int i;
	int small = 0;
	int large = n - 1;
	int pivot = 0;

	for (i = 0; i < n; i++)
		if (arr[i] < pivot)
			swap(arr[i], arr[small++]);

	large = n - 1;
	// arr[i] >= pivot is just an optimization for terminating
	// the loop once we saw a -1. Since we dont need to go below that
	for (i = n - 1; i >= 0 && arr[i] >= pivot; i--)
		if (arr[i] > pivot)
			swap(arr[i], arr[large--]);
}

int dutch()
{
	int i = 0;
	int arr[] = {0, -1, 0, 1, 1, -1, -1, 0, 1};
	int n = sizeof(arr)/sizeof(int);

	dutch_flag(arr, n);

	for (i = 0; i < n; i++)
		printf("%d ", arr[i]);

	printf("\n");
	return 0;
}
