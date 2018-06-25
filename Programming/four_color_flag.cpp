#include <stdio.h>
#include <utility>

using namespace std;

void four_color_flag(int *a, int n)
{
	int i = 0, j = n - 1;
	int l = 0, h = n - 1;
	int p1 = -1, p2 = 0;

	while (i <= j) {
		if (a[i] < p1)
			swap(a[i++], a[l++]);
		else if (a[i] == p1)
			i++;

		if (a[j] > p2)
			swap(a[j--], a[h--]);
		else if (a[j] == p2)
			j--;

		if (i <= j && a[i] > a[j])
			swap(a[i], a[j]);

	}
}

int four_color_flag()
{
	int i = 0;
	int arr[] = {1, 0, -1, -2};
	int n = sizeof(arr)/sizeof(int);

	four_color_flag(arr, n);

	for (i = 0; i < n; i++)
		printf("%d ", arr[i]);
	printf("\n");
	return 0;
}
