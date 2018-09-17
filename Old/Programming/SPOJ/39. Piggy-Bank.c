#include<stdio.h>

/*
	The idea here is to use DP. To calculate the minimum cost for a needed 
	weight we have to come up with the optimum solution of finding minimum
	cost for weight - 1, this goes on until we have calculated the minimum
	cost for weight of 1 gram. So we start with minimum cost of weight 1
	and then try to build the minium cost of required weight in bottom up
	fashion. The key to establish the relation between each sub-problem
	is to add the c[0..nCoins] to the previously calculated subproblem

	cf[i] = min{ cf[i - w[j]] + c[j] }  0 <= j <= nCoins
*/

int c[500]; //cost of coins
int w[500]; //weight of coins
int cf[10010]; //minimum cost function for a given weight

#define INF 10000000

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int E, F, wf; //Final weight
		int nCoins, i, j;
		scanf("%d %d", &E, &F);
		scanf("%d", &nCoins);
		for (i = 0; i < nCoins; i++)
			scanf("%d %d", &c[i], &w[i]);
			
		wf = F - E;
		cf[0] = 0; //to handle exact weights case
		for (i = 1; i <= wf; i++) {
			cf[i] = INF;
			for (j = 0; j < nCoins; j++) {
				if (i - w[j] >= 0) {
					if (cf[i - w[j]] + c[j] < cf[i])
						cf[i] = cf[i - w[j]] + c[j];
				}
			}
		}
		if (cf[wf] == INF)
			printf("This is impossible.\n");
		else
			printf("The minimum amount of money in the piggy-bank is %d.\n", cf[wf]);
	}
	return 0;
}
