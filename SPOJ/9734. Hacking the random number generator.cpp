
/*********************************************************************************

	Program Name: 9734. Hacking the random number generator
	Program Code: HACKRNDM
	Author: Vineel Kumar Reddy Kovvuri
	Date: Thu Oct  2 16:30:03 2014
	Idea:
		The idea is simple map all integers and count the number of key + k elements
	References:

*********************************************************************************/
#include <iostream>
#include <cstdio>
#include <map>
#include <vector>
#include <utility>

using namespace std;

int main()
{
	int n, k, i;
	map<int, int> m;
	scanf("%d%d", &n, &k);
	for (i = 0; i < n; i++) {
		int t;
		scanf("%d", &t);
		m.insert(make_pair(t,t));
	}
	int count = 0;
	for (map<int,int>::iterator it=m.begin(); it!=m.end(); ++it)
		if (m.find(it->first + k) != m.end()) count++;
	printf("%d\n", count);
	return 0;
}

