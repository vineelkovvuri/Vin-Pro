
#include <stdio.h>

int get_parity(int x, int n)
{
	while (n != 1) {
		n /= 2;
		x ^= x >> n;
	}
	return x & 0x1;
}

int finding_parity()
{
	int n = 32;
	int x = 0xff;
	printf("%d", get_parity(x, n));
    return 0;
}