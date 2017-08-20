/*
	This problem can be solved only using BFS.
	At each level we populate prime numbers which are formed by changing one digit of its parent.
	DFS doesnot work because we donot know when to terminate the recursion tree.
*/

#include <iostream>
#include <utility>
#include <queue>
#include <cstdio>
#include <cstdlib>
#include <cstring>

using namespace std;
int primes[10000];
int visited[10000];
void precompute()
{
	int i, j = 2;
	for (i = 1; i < 10000; i++)
		primes[i] = 1;
	for (j = 2; j < 100; j++)
		if (primes[j] == 1)
			for (i = j*j; i < 10000; i += j)
				primes[i] = 0;
}

int start, end;
int f()
{
	char temp[5];
	queue<pair<int, int> > q;
	if (::start == ::end) return 0;
	q.push(make_pair(::start, 0));
	while (!q.empty()) {
		pair<int, int> e = q.front();
		q.pop();
		visited[e.first] = 1;
		if (e.first == ::end) return e.second + 1;
		for (int i = 0; i < 4; i++) {
			for (int j = (i == 0? 1: 0); j <= 9; j++) {
				sprintf(temp,"%d", e.first);
				temp[i] = j + '0';
				int newNum = atoi(temp);
				if (newNum == ::end)
					return e.second + 1;
				else if (newNum != e.first && !visited[newNum] && primes[newNum])
					q.push(make_pair(newNum, e.second + 1));
			}
		}
	}
	return -1;
}

int main()
{
	int i = 0, t;
	precompute();
	scanf("%d", &t);
	while (t--) {
		memset(visited, 0, sizeof(visited));
		scanf("%d%d", &::start, &::end);
		int k = f();
		if (k == -1)
			printf("Impossible\n");
		else
			printf("%d\n", k);
	}
	return 0;
}
