//2157. Anti-Blot System
/*
	scans input as required by the program
	scanf("%s + %s = %s", op1, op2, op3);

*/
#include<stdio.h>
int check(const char * str)
{
	int i = 0;
	for (i = 0; str[i]; i++)
		if (str[i] == 'm') return 1;
	return 0;
}

int main()
{
	int t;
	char op1[40], op2[40], op3[40];
	scanf("%d", &t);	
	while (t--) {
		scanf("%s + %s = %s", op1, op2, op3);
		if (check(op1))
			printf("%d + %d = %d\n", atoi(op3) - atoi(op2), atoi(op2), atoi(op3));
		else if (check(op2))
			printf("%d + %d = %d\n", atoi(op1), atoi(op3) - atoi(op1), atoi(op3));
		else
			printf("%d + %d = %d\n", atoi(op1), atoi(op2), atoi(op1) + atoi(op2));
	}
	return 0;
}

