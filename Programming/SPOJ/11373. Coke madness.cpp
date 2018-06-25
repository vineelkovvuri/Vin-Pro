/*********************************************************************************

	Program Name: 11373. Coke madness
	Program Code: RPLC
	Author: Vineel Kumar Reddy Kovvuri
	Date: Wed Oct  1 07:42:04 2014
	Idea:
		Simple, Calculate the maximum -ve sum possible from the start of the array
		till the end of the array.

	References:

*********************************************************************************/
#include <iostream>
#include <cstdio>

using namespace std;
long long arr[1000010];
int main()
{
	long long t, i;
	scanf("%lld", &t);
	for (i = 1; i <= t; i++) {
		long long n, j, min_sum = 0, temp = 0;
		scanf("%lld", &n);
		for (j = 0; j < n; j++)
			scanf("%lld", &arr[j]);

		for (j = 0; j < n; j++) {
			temp += arr[j];
			if (min_sum > temp) min_sum = temp;
		}

		printf("Scenario #%lld: %lld\n",i, -min_sum + 1);

	}
	return 0;
}


