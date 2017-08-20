#include <stdio.h>
#include <math.h>
int n;
double a[1000][1001];

void forwardSubstitution() {
	int i, j, k, max;
	float t;
	for (i = 0; i < n; ++i) {
		max = i;
		for (j = i + 1; j < n; ++j)
			if (a[j][i] > a[max][i])
				max = j;

		for (j = 0; j < n + 1; ++j) {
			t = a[max][j];
			a[max][j] = a[i][j];
			a[i][j] = t;
		}

		for (j = n; j >= i; --j)
			for (k = i + 1; k < n; ++k)
				a[k][j] -= a[k][i]/a[i][i] * a[i][j];

	}
}

void reverseElimination() {
	int i, j;
	for (i = n - 1; i >= 0; --i) {
		a[i][n] = a[i][n] / a[i][i];

		a[i][i] = 1;
		for (j = i - 1; j >= 0; --j) {
			a[j][n] -= a[j][i] * a[i][n];
			a[j][i] = 0;
		}
	}
}

void gauss() {
	int i,j,invalid=0;

	forwardSubstitution();
	reverseElimination();

	for (i = 0; i < n &&invalid==0; ++i) {
		for (j = 0; j < n+1 &&invalid==0; ++j) {
			if(a[i][j] == NAN ||a[i][j] ==  INFINITY){
				invalid = 1;
			}
		}
	}
	if(invalid == 1){
		for (i = 0; i < n; ++i) {
			for (j = 0; j < n+1; ++j) {
				a[i][j] = 0;
			}
		}
	}
	for (i = 0; i < n; ++i) 
		printf("%.0lf ", a[i][n]);
}

int main(int argc, char *argv[]) {
	int i, j;

	scanf("%d", &n);
	for (i = 0; i < n; ++i)
		for (j = 0; j < n + 1; ++j)
			scanf("%lf", &a[i][j]);

	gauss();

	return 0;
}

