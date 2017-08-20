
//http://www.graph-magics.com/articles/euler.php
//https://github.com/hbdhj/spoj-cpp/blob/master/41_WORDS1.cpp

/*
A directed graph has an eulerian path if and only if it is connected
and each vertex except 2 have the same in-degree as out-degree, and
one of those 2 vertices has out-degree with one greater than in-degree
(this is the start vertex), and the other vertex has in-degree with
one greater than out-degree (this is the end vertex).
*/


#include <iostream>
#include <cstdio>
#include <queue>
#include <cstring>
#include <vector>

using namespace std;

int graph[26][26] = {{0}};
int outdeg[26] = {0}, indeg[26] = {0};
int nodes[26];
int nNodes;

int BFS(int u)
{
	bool visited[26] = {0};
	int visitedCount = 0;
	queue <int> q;

	q.push(u);
	while (!q.empty()) {
		u = q.front();
		q.pop();
		if (!visited[u]) {
			visitedCount++;
			visited[u] = true;
			for (int i = 0; i < 26; i++)
				if (graph[u][i] || graph[i][u]) /*check connectivity as if given graph is undirected */
					q.push(i);
		}
	}
	return visitedCount; /* Number of nodes visited starting from u */
}
/* to know if a graph(undirected) is connected. Start from any node
and find out if we can visit all the nodes from it */
bool isConnected()
{
	int i = 0;
	for (i = 0; i < 26; i++)
		if (nodes[i]) /* find alteast one nodes which has degree > 0 */
			break;

	return i < 26 && BFS(i) == nNodes; /* Graph is connected if all nodes are visited */
}

bool isEulerPath()
{
	if (!isConnected()) return false;

	int start = 0, end = 0;
	for (int i = 0; i < 26; i++) {
		if (nodes[i]) {
			if (outdeg[i] - indeg[i] == 1) /* i will be the start node */
				start++;
			else if (indeg[i] - outdeg[i] == 1) /* i will be the end node */
				end++;
			else if (indeg[i] != outdeg[i]) /* indeg == outdeg else not eulerian */
				return false;
		}
	}
	if ((start == 1 && end == 1) || (start == 0 && end == 0))
		return true;
	return false;
}

int main()
{
	int t;
	cin >> t;
	while (t--) {
		int nWords;

		nNodes = 0;
		memset(graph,   0, sizeof(graph));
		memset(nodes,   0, sizeof(nodes));
		memset(indeg,   0, sizeof(indeg));
		memset(outdeg,  0, sizeof(outdeg));

		cin >> nWords;
		for (int i = 0; i < nWords; i++) {
			string temp;
			cin >> temp;
			int u = *temp.begin() - 'a';
			int v = *temp.rbegin() - 'a';
			graph[u][v] = nodes[u] = nodes[v] = 1;
			outdeg[u]++;
			indeg[v]++;
		}
		for (int i = 0; i < 26; i++)
			if (nodes[i]) nNodes++;

		cout << (isEulerPath() ? "Ordering is possible.\n" : "The door cannot be opened.\n");
	}
	return 0;
}
