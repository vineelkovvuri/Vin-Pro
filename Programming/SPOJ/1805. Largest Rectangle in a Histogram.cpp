/*********************************************************************************

	Program Name: 1805. Largest Rectangle in a Histogram
	Program Code: HISTOGRA
	Author: Vineel Kumar Reddy Kovvuri
	Date: Tue Sep 30 07:23:49 2014
	Idea:
	The idea is brilliant. Its not mine.
	Step 1: We iterate over the rectangles
		Step 2: While iterating we maintain a stack which will hold the largest
				rectangles(contiguous) possible until current rectangle
		Step 3: If we find the current rectangle smaller than the rectangle on top
	   			of the stack.  Then pop the rectangle and calculate the area as
				height of the popped rectangle * possible width of the rectangle as below.
				Step 4: If the popped rectangle is the only rectangle left over on the stack
						Then the possible width will be [0 to i) (current rectangle index)
						Else, the possible width will be from the index of [second largest
						rectangle on the stack to i) (current rectangle index)
		Step 5: Also on each iteration the maximum area found is updated

	References:
	1. http://homeofcox-cs.blogspot.in/2010/04/max-rectangle-in-histogram-problem.html
*********************************************************************************/
#include <iostream>
#include <vector>
#include <stack>
#include <cstdio>
#include <algorithm>

using namespace std;
long long get_max_area(vector<long long> &h)
{
	long long area = 0;
	stack<long long> s;
	int i = 0;
	if (h.size() == 0) return 0;

	h.push_back(0);
	while (i < h.size()) {
		if (s.empty() || h[s.top()] <= h[i]) { /* add a rectangle only if it is bigger than the one on the top of the stack */
			s.push(i++); /* holds the highest rectangle possible */
		} else { /* if new rectangle is smaller than the rectangle on the stack */
			int highest_idx = s.top(); /* pop the highest rectangle */
			s.pop();
			int strip_width = s.empty() ? i : /* 0 to i */
							i - s.top() - 1; /* s.top() to i i.e., second highest rectangle to i */
			area = max(area, h[highest_idx] * strip_width);
			/* NOTE: This else part is repeated until stack contain no rectangle strictly
			   larger than the rectangle at i (which is not added yet) */
		}
	}
	return area;
}

int main()
{
	while (1) {
		int n, i;
		vector <long long> h;
		scanf("%d", &n);
		if (n == 0) break;
		for (i = 0; i < n; i++) {
			long long temp;
			scanf("%lld", &temp);
			h.push_back(temp);
		}
		printf("%lld\n", get_max_area(h));
	}
	return 0;
}
