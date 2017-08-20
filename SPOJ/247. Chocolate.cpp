/*********************************************************************************

	Program Name: 247. Chocolate
	Program Code: CHOCOLA
	Author: Vineel Kumar Reddy Kovvuri
	Date: Sat Oct  4 08:31:15 2014
	Idea:
		Idea is simple Greedy technique:

		We sort the xcost (column cost) and ycost (vertical cost) and keep two
		variables hsplits, vsplits to count the number of horizontal and
		vertical splits

		Then we start with largest of xcost or ycost and multiply that with
		vsplits or hsplits respectively and update the hsplits or vsplits
		respectively

		If the chocolate is left unsplit either horizontally or vertically because the
		other dimension is already exhausted; We just loop through the left over
		chocolate and update the cost.

	References:

*********************************************************************************/

#include <iostream>
#include <algorithm>
#include <vector>
#include <cstdio>

using namespace std;

int main()
{
	int t;
	vector <int> xcost, ycost;
	scanf("%d", &t);
	while (t--) {
		int m, n;
		scanf("%d%d", &m, &n);
		--m; --n;
		xcost.resize(m); //resize() updates size() to m, reserve() do not update size()
		ycost.resize(n);

		for (int j = 0; j < m; j++)
			scanf("%d", &xcost[j]);
		for (int i = 0; i < n; i++)
			scanf("%d", &ycost[i]);
		sort(xcost.begin(), xcost.end());
		sort(ycost.begin(), ycost.end());

		int hsplits = 1, vsplits = 1, sum = 0;
		int i, j;
		for (i = n - 1, j = m - 1; i >= 0 && j >= 0;) {
			if (xcost[j] >= ycost[i]) {
				sum += xcost[j] * vsplits; //split horizontally
				hsplits++; //update number of new horizontal splits formed
				j--;
			} else {
				sum += ycost[i] * hsplits;
				vsplits++;
				i--;
			}
		}
		//left over in horizontal direction
		if (j >= 0)
			for (int jj = j; jj >= 0; jj--)
				sum += xcost[jj] * vsplits;

		//left over in vertical direction
		if (i >= 0)
			for (int ii = i; ii >= 0; ii--)
				sum += ycost[ii] * hsplits;

		printf("%d\n", sum);
	}
}

