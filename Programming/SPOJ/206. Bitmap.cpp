#include<cstdio>
#include<cstdlib>
#include<cstring>
#include<iostream>
#include<ctime>
using namespace std;

int M, N;
int m[200][200];
int v[200][200]; //visited matrix to avoid infinite recursion
int F[200][200]; 
void f(int x, int y)
{
	int a, b, c, d;
	if (x >= M || y >= N || x < 0 || y < 0 || v[x][y] == 1) return;

	v[x][y] = 1;
	if (x-1 >= 0 && m[x-1][y] == 0 && F[x-1][y] > 1 + F[x][y]) {
		F[x-1][y] = 1 + F[x][y];
		f(x-1, y);
	}
	if (y-1 >= 0 && m[x][y-1] == 0 && F[x][y-1] > 1 + F[x][y]) {
		F[x][y-1] = 1 + F[x][y];
		f(x, y-1);
	}
	if (y+1 < N && m[x][y+1] == 0 && F[x][y+1] > 1 + F[x][y]) {
		F[x][y+1] = 1 + F[x][y];
		f(x, y+1);
	}
	if (x+1 < M && m[x+1][y] == 0 && F[x+1][y] > 1 + F[x][y]) {
		F[x+1][y] = 1 + F[x][y];
		f(x+1, y);
	}
	v[x][y] = 0;
}
int main()
{
	int t,i,j;
	//scanf("%d", &t);
//	srand(time(NULL));
	std::cin >> t;
	while (t--) {
	//	scanf("%d%d", &M, &N);
		std::cin >> M;
		std::cin >> N;

		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				std::cin >> m[i][j];
	//			m[i][j] = rand()&1;
				F[i][j] = 1000000000;
				v[i][j] = 0;
			}
		}
#if 0
		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++)
				printf("%d ", m[i][j]);
			printf("\n");
		}

		printf("--------------------------------\n");
#endif
		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				if (m[i][j] == 1){
					F[i][j] = 0;
					f(i, j);
				}
			}
		}
		for (i = 0; i < M; i++) {
			for (j = 0; j < N; j++) {
				printf("%d", F[i][j]);
				if (j + 1 != N) printf(" ");
			}
			printf("\n");
		}
	}
	return 0;
}


