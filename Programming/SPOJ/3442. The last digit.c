//spoj id: 3442
#include<stdio.h>
#include<stdlib.h>

int hash[10][10] = {{0},
{1},
{2, 4, 8, 6},
{3, 9, 7, 1},
{4, 6},
{5},
{6},
{7, 9, 3, 1},
{8, 4, 2, 6},
{9, 1},};
int rem[10] = {0, 1, 4, 4, 2, 1, 1, 4, 4, 2};

void f()
{
	unsigned long a, b;
	scanf("%lu%lu", &a, &b);
	a = a % 10;
	if (a == 0) {
		printf("%d\n", 0);
	} else if (b == 0) {
		printf("%d\n", 1);
	} else {
		printf("%d\n", hash[a][(b - 1) % rem[a]]);
	}
}

int main()
{
	int t;
	scanf("%d", &t);
	while(t--)
		f();
	
	return 0;
}

