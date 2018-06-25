
// Program to parition binary objects in to two sets
// but by honoring the order among objects of type true (1)
#include <stdio.h>
#include <utility>

using namespace std;

void increment_by_one(int *a, int n)
{
	int carry = 1;  // this acts as increment
	
	for (int i = n - 1; i >= 0 && carry != 0; i--) {
		a[i] = a[i] + carry;
		carry = a[i] / 10;
		a[i] = a[i] % 10;
		
	}
	
	if (carry != 0) {
		for (int i = n; i > 0;i--)
			a[i] = a[i-1];
		a[0] = carry;
	}
}

int increment_number()
{
	int i = 0;
	int arr[] = {9, 9, 9, 9, 0}; //last zero is a place holder
	int n = sizeof(arr)/sizeof(int) - 1;

	increment_by_one(arr, n);

	for (i = 0; i <= n; i++)
		printf("%d ", arr[i]);
	printf("\n");
	return 0;
}
