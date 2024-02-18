#include<stdio.h>

unsigned long long n;

unsigned long long mypow(unsigned long long x, unsigned long long exp)
{
	unsigned long long s = 1, i;
	for (i = 1;i <= exp; i++)
		s = s*x;
	return s;
}
unsigned long long cal(unsigned long long x, unsigned long long exp)
{
	unsigned long long s, t, i;
	
	if (x == 0) return exp;
	
	for (s = 1, i = 1; i <= exp; i++) {
		t = s;
		s = s * 2;
		if (s < t) return 0; //overflow
	}
	return cal(x - 1, s);
}

unsigned long long f(unsigned long long x)
{
	unsigned long long y,z;
	int i;
	unsigned long long t = cal(x, 2);
	if (t == 0 || t > n) {
		return 1;
	}
	printf("(2");
	t = f(x + 1);
	y = mypow(2, t);
	for (i = 7; i >= 0; i--) {
		z = cal(x, y + i);
		if (z == 0) continue;
		if (z <= n) {
			if (i&4) printf("+2(2)");
			if (i&2) printf("+2");
			if (i&1) printf("+2(0)");
			printf(")"); //closing
			return y + i;
		}
	}
}

int main()
{
	while (scanf("%llu", &n) != EOF) {
		unsigned long long z = 0, i = 0, t = 0;
		printf("%llu=",n);
		while (n > 0) {
			printf("2");
			z = f(1);
			t = mypow(2, z);
			if (n > t)
				printf("+");
			if (z == 1 && n < t) {
				printf("(0)");
				break;
			}
			n -= t;
		}
		printf("\n");

	}
	return 0;
}
