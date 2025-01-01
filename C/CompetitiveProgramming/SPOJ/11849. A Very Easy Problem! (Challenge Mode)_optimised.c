#include<stdio.h>
/*
	Idea here is to find the bits set in each given number and write that bit
	as 2^(?) and again that ? is recursively expressed in terms of powers of
	2. This continues until we go to number 2 or 1
	
	Note be accepted in SPOJ, We need to remove all identation and whitespaces
	in the program and replace unsigned long long and printf with #define's !!
*/
void f(unsigned long long n)
{
	unsigned long long i=63;
	for (;n;i--) {
		if ((n>>i)&1) {
			if (i < 2) printf(i==1?"2":"2(0)");
			else {
				printf("2(");
				f(i);
				printf(")");
			}
			n &= ~(1ULL << i);
			if (n) printf("+");
		}
	}
}
int main()
{
	unsigned long long n;
	while (scanf("%llu", &n) != EOF) {
		printf("%llu=", n);
		f(n);
		printf("\n");
	}
	return 0;
}

