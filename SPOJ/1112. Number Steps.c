//spoj id : 1112
#include<stdio.h>

void fact()
{
	int x, y;
	scanf("%d %d", &x, &y);
	if (x == y || y == x - 2) {
		if (x % 2 == 0 && y % 2 == 0)
			printf("%d\n", x + y); 
		else if (x % 2 == 1 && y % 2 == 1)
			printf("%d\n", x + y - 1);
	} else {
		printf("No Number\n");
	}
}


int main()
{
	int t, i;
	scanf("%d", &t);
	for (i = 0; i < t; i++)
		fact();
	return 0;
}
