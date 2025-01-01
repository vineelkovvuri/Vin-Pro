/*********************************************************************************

	Program Name: 7718. Number of common divisors
	Program Code: COMDIV
	Author: Vineel Kumar Reddy Kovvuri
	Idea:
	   Idea here is to find the GCD of both the numbers and
	   find the number of divisors of that GCD

	   Algorithm to find number of divisors of n
	   -----------------------------------------
	   Let n = 12 then 1, 2, 3, 4, 6, 12 are divisors
	   but no divisor is composed of number greater than sqrt(12)
	   so in the above example 6 is 2 * 3 or 12 is 1 * 12
	   so if we run a loop till sqrt(12) and find the numbers which
	   can divide 12. If a number i is dividing 12 then we have
	   found two dividers of 12,  i and 12 / i
		The above observation holds for every number except perfect numbers
		like 16 for which when i = 4 the other number 16/i is also 4
		So effectively we need to count the i only once not twice

*********************************************************************************/

#include <iostream>
#include <cstdio>
#include <cmath>

using namespace std;

int gcd(int a, int b)
{
	return 	b == 0 ? a : gcd(b, a % b);
}

int ndivisors(int n)
{
	int i, res = 0;
	int _sqrt = sqrt(n);
	//find the number of divisors in n
	/* Let n = 12 then 1, 2, 3, 4, 6, 12 are divisors */
	for (i = 1; i <= _sqrt; i++) { /* sqrt(12) = 3 */
		if (n % i == 0) {
			res += 2;	/* i is one divisor and n/i is another divisor */
			/* But for perfect numbers like 16 where sqrt = 4;*/
			/* And when i = 4 above step will count one extra 4 */
			/* so we need to reduce the extra 4 */
			if (i * i == n) res--; /* needed only for perfect numbers */
		}
	}
	return res;
}

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int m, n;
		scanf("%d%d", &m, &n);
		printf("%d\n", ndivisors(gcd(m, n)));
	}
	return 0;
}


