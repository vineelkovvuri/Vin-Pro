#include <iostream>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;
/*

min_steps[i] = for all k where x[k] + k >= i find min{min_steps[k]} + 1

*/
int can_reach_end(int *x, int m)
{

	int min_steps[100] = {0};

	for (int i = 1; i < m; i++) {
		
		min_steps[i] = min_steps[i-1] + 2;
		int k = min_steps[i-1] + 2;
		for (int j = i - 1; j >= 0 && min_steps[j] >= k - 3; j--)
			if (x[j] + j >= i && min_steps[i] > min_steps[j] + 1)
				min_steps[i] = min_steps[j] + 1;

		if (min_steps[i] == min_steps[i-1] + 2)
			break;
	}

	for (int i = 0; i < m; i++)
		cout << min_steps[i] << " ";
	
	return min_steps[m - 1];
}

int minimum_steps_advance_through_array()
{
	int a[] = {3, 4, 1, 1, 0, 2, 0, 1};
	int m = sizeof(a)/sizeof(int);

	cout << "Reachable " << can_reach_end(a, m);

	return 0;
}
	
