#include<stdio.h>

/*
	Idea is to update the corresponding seq element based on the characters
	encountered. T is considered as 0 and H is considered as 1. This makes
	indexing the array very easy(binary 0 to 7).
*/

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int tNum, i;
		char toss[42];
		int seq[8] = {0}; /* TTT, TTH, THT, THH, HTT, HTH, HHT and HHH */
		scanf("%d", &tNum);
		scanf("%s", toss);

		for (i = 0; i < 38; i++)
			seq[((toss[i+0] == 'H'? 1 : 0) << 2) |
				((toss[i+1] == 'H'? 1 : 0) << 1) |
				((toss[i+2] == 'H'? 1 : 0) << 0)]++;

		printf("%d ", tNum);
		for (i = 0; i < 8; i++)
			printf("%d ", seq[i]);
		printf("\n");

	}
	return 0;
}
