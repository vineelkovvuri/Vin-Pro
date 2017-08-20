/*
	Awesome Idea, to calculate the minimum smoke from the entire array one has to find the minimum of the below
		m(i, j) = min { m(i, k) + sum[i][k]*sum[k+1][j] + m(k + 1, j) } where k is running in [i, j)
		
		sum[i][j] contains the sum of ith element to jth element(including) in the array mod 100
		
		So effectively m(i,j) represents the minimum smoke for the range [i, j] this can be defined as
		for every k belonging to [i, j) m(i,j) is min { minimum smoke of i to k + smoke at k and k+1 + and minimum smoke of k to j }
		
		each of the value of m(i,j) is stored in mem[i][j] to cut the time
*/
	
#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

#define INF 9223372036854775LL
long long a[200];
long long sum[200][200];
long long mem[200][200];
long long n;

long long  M(long long  ii, long long  jj)
{
	if (ii == jj) return mem[ii][jj] = 0;
	if (ii + 1 == jj) return mem[ii][jj] = a[ii]*a[jj];
	if ((ii < 0) || (jj >= n)) return INF;
	if (mem[ii][jj] != 0) return mem[ii][jj];
	else {
		long long  min = INF;
		long long k = 0;
		//printf("%lld %lld n = %d line = %d\n",ii, jj,n, __LINE__);  
		for (k = ii; k < jj; k++) {
			long long s = M(ii, k) + sum[ii][k]*sum[k+1][jj] + M(k+1, jj);
			if (min > s) min = s;
		}
		return mem[ii][jj] = min;
	}
}
int  main()
{
	long long  i, j,s = 0;
	
	while (scanf("%lld", &n) != EOF) {
	
		for (i = 0; i < n; i++) {
			scanf("%lld", &a[i]);
			for (j = 0; j < n; j++)
				mem[i][j] = 0;
		}
		
		for (i = 0; i < n; i++) {
			s = 0;
			for (j = i; j < n; j++) {
				s += a[j];
				sum[i][j] = s % 100; 
			}
		}
			
		printf("%lld\n", M(0, n-1));
		
	#if 0
		for (i = 0; i < n; i++) {
			for (j = 0; j < n; j++) {
				printf("%4lld ", sum[i][j]); 
			}
			printf("\n");
		}
		printf("\n----------------------\n");
		for (i = 0; i < n; i++) {
			for (j = 0; j < n; j++) {
				printf("%4lld ", mem[i][j]); 
			}
			printf("\n");
		}
		printf("\n----------------------\n");
	#endif
	}
	return 0;
}

