#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;

template <typename T> int sign(T val) {
    return (T(0) < val) - (val < T(0));
}

void multiplication_arbitrary(int *a, int m, int *b, int n, int *res, int *len)
{
	int i = 0, j = 0;
	int carry = 0;
	int all_zeros = true;
	
	reverse(a, a + m);
	reverse(b, b + n);
	
	for (i = 0; i < m; i++) {
		carry = 0;
		for (j = 0; j < n; j++) {
			res[i + j] += abs(a[i]) * abs(b[j]) + carry;
			carry = res[i + j] / 10;
			res[i + j] %= 10;
		}
		if (carry != 0)
			res[i + j] = carry;
	}
	
	reverse(a, a + m);
	reverse(b, b + n);
	
	// both i and j got incremented so let j's increment counts for carry 
	// and i's increment counts for the actual size the number
	if (carry)
		*len = i + j; //maximum size of the result with multiplication is always i + j
	else
		*len = i + j - 1; //maximum size of the result with multiplication is always i + j - 1
	
	for (i = 0; i < *len; i++) {
		if (res[i] != 0) {
			all_zeros = false;
			break;
		}
	}
	if (all_zeros) {
		res[0] = 0;
		*len = 1;
		return;
	}
	
	// update the sign 
	res[*len - 1] *= sign(a[m - 1]) * sign(b[n - 1]); 
	
	reverse(res, res + *len);
}

int multiplication_arbitrary()
{
	int a[] = {1, 1, 2, 3, 4};
	int b[] = {2, 1, 2, 3, 4};
	int m = sizeof(a)/sizeof(int), n = sizeof(b)/sizeof(int);
	int res[100] = {0};
	int len = 0;
	
	multiplication_arbitrary(a, m, b, n, res, &len);

	printf("\n");
	for (int i = 0; i < len; i++)
		printf("%d", res[i]);
	
	return 0;
}
