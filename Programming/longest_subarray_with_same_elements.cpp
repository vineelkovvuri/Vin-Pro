#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;
int calculate_max_subarray(int *array, int size)
{
	int max = 1;
	int count = 1;
	for (int i = 1; i <= size; i++, count++) {
		if ((i < size && array[i] != array[i-1]) || i == size) {
			if (max < count)
				max = count;
			count = 0;
		}
	}

	return max;
}

int longest_subarray_with_same_elements()
{
	int stock_prices[] = {310, 310, 275, 275, 275, 275, 275, 290, 290, 255, 250};
	int size = sizeof(stock_prices)/sizeof(int);

	printf("max subarray length %d\n", calculate_max_subarray(stock_prices, size));

	return 0;
}
	
