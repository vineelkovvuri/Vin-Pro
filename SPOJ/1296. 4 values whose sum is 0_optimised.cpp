/*
	Idea is simple, calculate every possible sum for the two arrays 
	and sort each array and find the sum form both the arrays which equals zero
*/

#include <iostream>
#include <algorithm>
#include <vector>
#include <utility>
#include <cstdio>
using namespace std;

vector<int> a,b,c,d,e,f;
int main()
{
	int i, j, n = 0;
	scanf("%d", &n);
	for (i = 0; i < n; i++) {
		int ta, tb, tc, td;
		scanf("%d%d%d%d", &ta, &tb, &tc, &td);
		a.push_back(ta);
		b.push_back(tb);
		c.push_back(tc);
		d.push_back(td);
	}
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++)
			e.push_back(a[i] + b[j]);
	sort(e.begin(), e.end());

	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++)
			f.push_back(c[i] + d[j]);
	sort(f.begin(), f.end());


	int count = 0;
	for (i = 0; i < e.size(); i++) {
		pair<vector<int>::iterator, vector<int>::iterator> r = equal_range(f.begin(), f.end(), -e[i]);
		count += (r.second - r.first);
		while (i + 1 < e.size() && e[i] == e[i+1]) {count += (r.second - r.first); i++;}
	}
	printf("%d\n", count);
	return 0;
}


