/*********************************************************************************

	Program Name: 8132. Street Trees
	Program Code: STREETR
	Author: Vineel Kumar Reddy Kovvuri
	Date: Sat Oct  4 13:40:42 2014
	Idea:
	Nice problem. To find the total number of new trees to be planted,
	We need to find the maximum distance that we can have between each
	tree, This can be found by finding the gcd between the difference of
	all successive distances.

	Example :
	input :              1 3 7 13
	differences :         2 4 6
	gcd of differences:   gcd(gcd(2, 4), 6) = 2

	So 2 is the maximum distance that can be kept between each tree.
	so total number of trees that can be present in the range of [first, last]
	with difference 2 is (last - first)/g + 1 = (13 - 1)/2 + 1 = 7

	so new trees that are to be planted are 7 - original trees = 7 - 4 = 3

	References:
	To find the gcd under gnu libstdc++ we can use __gcd library function.
	https://gcc.gnu.org/onlinedocs/gcc-4.6.3/libstdc++/api/a01045_source.html#l01491

*********************************************************************************/
#include <iostream>
#include <cstdio>
#include <algorithm>

using namespace std;
#if 0
int gcd(int a, int b)
{
	return b == 0 ? a : gcd(b, a % b);
}
#endif

int main()
{
	int trees, first, last;
	int temp = 0, temp2;
	int g = 0;

	cin >> trees;
	cin >> temp;
	first = temp;
	for (int i = 1; i < trees; i++) {
		cin >> temp2;
		g = __gcd(g, temp2 - temp); //libstdc++ has __gcd
		temp = temp2;
	}
	last = temp;
	int total_trees = (last - first) / g + 1;
	printf("%d\n", total_trees - trees);

	return 0;
}

