/*********************************************************************************

	Program Name: 1744. Evaluate the polynomial
	Program Code: POLEVAL
	Author: Vineel Kumar Reddy Kovvuri
	Date: 
	Idea:
		Horner's Method
	References:

*********************************************************************************/

#include <iostream>
#include <cstdio>

using namespace std;

int c[1000];
int main()
{
	int t = 0;
	while (1) {
		int n;
		scanf("%d", &n);
		if (n == -1) break;
		n++;
		for (int i = 0; i < n; i++)
			scanf("%d", &c[i]);
		int np;
		scanf("%d", &np);
		printf("Case %d:\n", ++t);
		for (int i = 0; i < np; i++) {
			int x, sum = 0;
			scanf("%d", &x);
			for (int j = 0; j < n - 1; j++) {
				sum = sum + c[j];
			    sum = sum * x;
			}	
			printf("%d\n", sum + c[n-1]);
		}
	}
	return 0;
}
