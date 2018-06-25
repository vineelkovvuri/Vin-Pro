//spoj id:42
#include<stdio.h>

void f()
{
	char n1[100], n2[100];
	int i = 0, j = 0;
	int x, y, c = 0;
	int s = 0, d = 0;
	scanf("%s%s", n1, n2);
	while (n1[i] || n2[j]) {
		x = n1[i] ? n1[i++] - '0' : n1[i];
		y = n2[j] ? n2[j++] - '0' : n2[j];
		d = (x + y + c);
		c = d / 10;
		d = d % 10;
		s = 10 * s + d;
	}
	if (c) {
		s = 10 * s + c;
	}
	printf("%d\n", s);
}

int main()
{
	int t;
	int i;
	scanf("%d", &t);
	for (i = 0; i < t; i++)
		f();
	return 0;	
}