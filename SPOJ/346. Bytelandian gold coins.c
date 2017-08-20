#include<stdio.h>
#define max2(a, b) ((a) > (b) ? (a) : (b))
unsigned long long ff[30][20] = {0};
unsigned long long n = 0;

/* returns value of n when divided by nthDiv2 and nthDiv3 */
unsigned long long current(int nthDiv2, int nthDiv3)
{
	int i = 0;
	unsigned long long nAfterDiv2 = n >> nthDiv2;
	unsigned long long nAfterDiv2Div3 = nAfterDiv2;
	for (i = 0; i < nthDiv3; i++)
		nAfterDiv2Div3 /= 3;
	return nAfterDiv2Div3;
}

unsigned long long F(int nthDiv2, int nthDiv3)
{
	/* if the value of n when divided by nthDiv2 and nthDiv3 is already calculated just return it from table */
	if (ff[nthDiv2][nthDiv3] != 0) 
		return ff[nthDiv2][nthDiv3];
	else {
		//calculate the current value of n when divided by nthDiv2 and nthDiv3 => F(nthDiv2, nthDiv3)
		unsigned long long k1 = current(nthDiv2, nthDiv3);
		if (k1 < 12) /* terminating condition */
			return k1;
		unsigned long long t = F(nthDiv2 + 1, nthDiv3) + F(nthDiv2, nthDiv3 + 1) + F(nthDiv2 + 2, nthDiv3); 
		/* Maximum of F(nthDiv2, nthDiv3) and F(nthDiv2 + 1, nthDiv3) + F(nthDiv2, nthDiv3 + 1) + F(nthDiv2 + 2, nthDiv3) */
		return ff[nthDiv2][nthDiv3] = max2(k1 , t); 
	}
}

int main()
{
	int i, j;
	while (scanf("%llu", &n) != EOF) {
		/* Every testcase need new Memoization table */
		for (i = 0; i < 30; i++)
			for (j = 0; j < 20; j++)
				ff[i][j] = 0;
		printf("%llu\n", F(0, 0));
	}
	return 0;
}
