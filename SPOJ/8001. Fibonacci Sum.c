/*
	The idea, sum of first n fibbonaci numbers is given by F(n+2) - 1;
	so the sum over a range F(M)..F(N) can be calculated using F(M+2) - F(N+1)
	calculating the nth Fibonnaci number can be done using matrix exponentiation
                                             
            _     _ n        _           _   
           | 1   1 |    =   | Fn+1   Fn   |  
           | 1   0 |        | Fn     Fn-1 |  
            -     -          -           -   
  
 	Since left side of the equation is calculating x^n, It can be done in O(lgn)
	if n is even x^n  =  x^(n/2) * x^(n/2)
	if n is odd  x^n  =  x^(n/2) * x^(n/2) * x

*/
 
#include <stdio.h>
#define MOD 1000000007ULL

unsigned long long f(unsigned long long n, unsigned long long ans[][2])
{
	unsigned long long a, b, c, d;

	if (n <= 1) {
		ans[0][0] = ans[0][1] = ans[1][0] = 1;
		ans[1][1] = 0;
		return n == 1 ? ans[0][1] : ans[1][1];
	}
	f(n/2, ans);
	a = ((ans[0][0]*ans[0][0]) + (ans[0][1]*ans[1][0]))%MOD;
	b = ((ans[0][0]*ans[0][1]) + (ans[0][1]*ans[1][1]))%MOD;
	c = ((ans[1][0]*ans[0][0]) + (ans[1][1]*ans[1][0]))%MOD;
	d = ((ans[1][0]*ans[0][1]) + (ans[1][1]*ans[1][1]))%MOD;
	ans[0][0] = a;
	ans[0][1] = b;
	ans[1][0] = c;
	ans[1][1] = d;
	
	if (n & 1) {
		unsigned long long x[2][2] = {{1,1},{1,0}};
		a = ((ans[0][0]*x[0][0]) + (ans[0][1]*x[1][0]))%MOD;
		b = ((ans[0][0]*x[0][1]) + (ans[0][1]*x[1][1]))%MOD;
		c = ((ans[1][0]*x[0][0]) + (ans[1][1]*x[1][0]))%MOD;
		d = ((ans[1][0]*x[0][1]) + (ans[1][1]*x[1][1]))%MOD;
		ans[0][0] = a;
		ans[0][1] = b;
		ans[1][0] = c;
		ans[1][1] = d;
	}
	return ans[1][0];
}

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		unsigned long long M, N, t[2][2]= {0};
		scanf("%llu%llu", &M, &N);
 		printf("%llu\n", (f(N+2, t) - f(M+1, t) + MOD)%MOD);
	}
	return 0;
}