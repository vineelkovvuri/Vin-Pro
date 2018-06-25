/*
	J(1) = 1; 
	J(2n) = 2 * J(n) - 1; //even
	J(2n + 1) = 2 * J(n) + 1; //odd

	Another idea is using bit count in number n
	let n = 100; i.e., (1100100) in binary
	J(n) = 64+32-16-8+4-2-1 = 73
	if bit is set then add or else substract
*/

#include <stdio.h>

int J(int n)
{
	if (n <= 1) return 1;
	if (n % 2 == 0) return 2 * J(n/2) - 1;
	else return 2 * J(n/2) + 1;
}


int main()
{
	while (1) {
		int n, k, i;
		scanf("%de%d", &n, &k);
		if (n == 0) break;
		for (i = 1; i <= k; i++)
			n = n*10;
		printf("%d\n", J(n));
	}
	return 0;
}