#include<stdio.h>
#include<stdlib.h>
#include<string.h>

/*
The only difference between this and the "3442 The last digit" problem is
Here the base can contain 1000 digits hence we need to capture the base as
string!!
*/

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

char *s;
void f()
{
	unsigned long long a,  b;
	scanf("%s%llu", s, &b);
	
	a = s[strlen(s)-1] - '0';
	if (a == 0) {
		printf("%d\n", 0);
	} else if (b == 0) {
		printf("%d\n", 1);
	} else {
		b = (b - 1) % rem[a];
		printf("%d\n", hash[a][b]);
	}
}

int main()
{
	int t;
	s = malloc(sizeof(char) * 1024);

	scanf("%d", &t);
	while(t--)
		f();
	free(s);
	return 0;
}

