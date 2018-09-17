#include <stdio.h>
char x[2000];
int main()
{
	long long a, b = -2, i = 0, n;
	scanf("%lld", &a);
		
	while (1) {
		if (a < 0) {
			x[i++] = abs(a) % abs(b) == 1? '1': '0';
			//printf("%d", abs(a)%abs(b));
			if (a == b * (abs(a)/abs(b)) + abs(a) % abs(b)) {
				a = abs(a)/abs(b);
			} else {
				a = abs(a)/abs(b) + 1;
			}
		} else {
			if (abs(a) < abs(b)) {
				x[i++] = a == 1? '1': '0';
				//printf("%d", a);
				break;
			} else {
				x[i++] = abs(a) % abs(b) == 1? '1': '0';
				//printf("%d", abs(a)%abs(b));
				a = -abs(a)/abs(b);
			}
		}
	}
	i--;
	for (; i >= 0; i--)
		printf("%c", x[i]);
	printf("\n");
	return 0;
}
