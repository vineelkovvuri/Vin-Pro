//spoj id : 24
#include<stdio.h>
#include<stdlib.h>

#define max2(x, y) ((x) > (y) ? (x) : (y))

int *f[110];

int l1[200];
int l2[200];

void precompute()
{
	int i, j, k, l = 0;
	int cc = 0;
	
	for (i = 0; i < 110; i++)
		f[i] = malloc(sizeof(int) * 210);
	
	f[1][0] = 1;
	f[1][200] = 1;
	
	for (i = 2; i <= 99; i++) {
			int n = i;
			//first digit
			int d = n % 10;
			cc = 0;
			for (j = 0; j < f[i - 1][200]; j++) {	
				int dd = d * f[i-1][j] + cc;
				cc = dd / 10;
				dd = dd % 10;
				l1[j] = dd;
			}
			if (cc)
				l1[j++] = cc;
			l1[j] = -1;
			l1[200] = j;
			//second digit
			d = n / 10;
			if (d != 0) {
				cc = 0;
				for (j = 0; j < f[i - 1][200]; j++) {	
					int dd = d * f[i-1][j] + cc;
					cc = dd / 10;
					dd = dd % 10;
					l2[j] = dd;
				}
				if (cc)
					l2[j++] = cc;
				l2[j] = -1;
				l2[200] = j;
			} else {
				l2[0] = -1;
			}
			//sum
			l = 0;
			cc = 0;
			f[i][l++] = l1[0];
			for (j = 1, k = 0; l1[j] != -1 || l2[k] != -1;) {
				int x = l1[j] != -1 ? l1[j++] : 0;
				int y = l2[k] != -1 ? l2[k++] : 0;
				int dd = x + y + cc;
				cc = dd / 10;
				dd = dd % 10;
				f[i][l++] = dd;
			}
			if (cc) 
				f[i][l++] = cc;
			f[i][200] = l;
	}
	f[100][0] = f[100][1] = 0;
	
	for (i = 2; i < f[99][200] + 2; i++)
		f[100][i] = f[99][i - 2];
	f[100][200] = f[99][200] + 2;
}

void fact()
{
	int n, i;
	scanf("%d", &n);
	for (i = f[n][200] - 1; i >= 0; i--)
		printf("%d", f[n][i]);
	printf("\n");	
}


int main()
{
	int t, i;
	precompute();
	scanf("%d", &t);
	for (i = 0; i < t; i++)
		fact();
	return 0;
}
