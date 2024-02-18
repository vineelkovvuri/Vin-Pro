#include <algorithm>
#include <utility>
#include <cmath>
#include <vector>
#include <iostream>

using namespace std;

int can_reach_end(vector<int> a)
{
	auto max_reachable = a.begin();
	auto prev_position = a.begin();
    
	for (auto i = a.begin(); i <= max_reachable && max_reachable < a.end(); i++) {
		if (max_reachable < i + *i) {
			max_reachable = i + *i;

			cout << i - prev_position << endl;
			prev_position = i;
		}
	}

	return max_reachable >= a.end();
}

int advance_through_array()
{
	vector<int> a{3, 2, 0, 1, 2, 0, 1};
	cout << "Reachable " << can_reach_end(a);
	return 0;
}
