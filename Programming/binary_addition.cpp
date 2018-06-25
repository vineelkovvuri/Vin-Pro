#define _SCL_SECURE_NO_WARNINGS

// Program to parition binary objects in to two sets
// but by honoring the order among objects of type true (1)
#include <iostream>
#include <utility>
#include <algorithm>

using namespace std;

void add_binary_numbers(int *a1, int m, int *a2, int n, int *res, int *len)
{
	int carry = 0;  // this acts as increment
	int i = 0;
	reverse(a1, a1 + m);
	reverse(a2, a2 + n);
	
	copy(a1, a1 + m, res);
	
	for (i = 0; i < n; i++) {
		res[i] += a2[i] + carry;
		carry = res[i] / 2;
		res[i] = res[i] % 2;
	}
	
	*len = i;
	
	if (carry != 0)
		res[(*len)++] = carry;
	
	reverse(a1, a1 + m);
	reverse(a2, a2 + n);
	
	reverse(res, res + *len);
	
}

int binary_addition()
{
	int a1[100] = {0};
	int a2[100] = {0};
	int res[100] = {0};
	int m, n, len;
	
	cout << "\nEnter number of elements in first array:";
	cin >> m;
	cout << "\nEnter elements in first array:";
	for (int i = 0; i < m; i++)
		cin >> a1[i];

	cout << "\nEnter number of elements in second array:";
	cin >> n;
	cout << "\nEnter elements in second array:";
	for (int i = 0; i < n; i++)
		cin >> a2[i];
	
	add_binary_numbers(a1, m, a2, n, res, &len);
	
	for (int i = 0; i < len; i++)
		cout << res[i] << " ";
	return 0;
}
