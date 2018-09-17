//AvoidRoads
//http://community.topcoder.com/stat?c=problem_statement&pm=1889&rd=4709

#include<stdio.h>
#include<string.h>
//test1
char *bad[] = {"0 0 0 1", "5 6 6 6"}; 
int m = 6, n = 6;

//test2
//char *bad[] = {}; 
//int m = 1, n = 1;

//test3
//char *bad[] = {"0 0 1 0", "1 2 2 2", "1 1 2 1"}; 
//int m = 2, n = 2;

//test4 - Need Big number
//char *bad[] = {}; 
//int m = 31, n = 35;


unsigned long long int a[100][100] = {0};
int pathAllowed(int i_1, int j_1, int i, int j)
{
	char myBad[20] = {0};
	int k = 0;
	sprintf(myBad, "%d %d %d %d", i_1, j_1, i, j);

	for (k = 0; k < sizeof(bad)/sizeof(bad[0]); k++)
		if (strcmp(myBad, bad[k]) == 0)
			return 0;
	return 1;
}

int f(int i, int j)
{
	int left = 0, down = 0;
	if (i - 1 >= 0) {
		if (pathAllowed(i - 1, j, i, j))
			left = a[i-1][j];
	}
	if (j - 1 >= 0) {
		if (pathAllowed(i, j - 1, i, j))
			down = a[i][j-1];
	}
	return left + down;
}

int main()
{
	int i, j;
	a[0][0] = 1;
	for (i = 0; i <= m; i++) {
		for (j = 0; j <= n; j++) {
			if (i == 0 && j == 0) continue;
			a[i][j] = f(i, j);
		}	
	}

	printf("no of paths = %llu\n", a[m][n]);
	return 0;
}


