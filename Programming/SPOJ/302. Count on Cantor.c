//spoj id: 302
#include<stdio.h>




int main()
{
	int t;
	unsigned long long n, b;
	unsigned long long i = 0;
	scanf("%d", &t); 
	while (t--) {
		scanf("%lld", &n);
		b = n;
		i = 1;
		while ((i*(i+1)/2) < n)
			i++;
		n = n - (i-1)*(i)/2;
		if (i % 2 == 0) {
			printf("TERM %lld IS %lld/%lld\n", b, n, (i-n+1));
		} else {
			printf("TERM %lld IS %lld/%lld\n", b, (i-n+1), n);
		}
	}
	return 0;
}
