#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

#define true 1
#define false 0

/*
	- do node traversal, if a node is visited twice during the recrusive traversal then the graph is not a tree
	- graph connectivity can be checked by maintaing the number of nodes traversed in the entire recursive traversal.
		- if nodes traversed doesnot equal total number of nodes then that graph is disconnected. Hence not a tree
*/

struct node {
	int visitied;
	int id;
	struct node *next;
};

struct node **nodelist;
int *visitedNodes;
int visitedNodeCount = 0;
int n, e;
int f(int id)
{
	struct node *p;
	if (visitedNodes[id] == 0) /* if node is already visited then we have a loop!!! */
		return false;
	
	visitedNodes[id] = 0;
	visitedNodeCount++;
	for (p = nodelist[id]; p; p = p->next)
		if (f(p->id) == false)
			return false;

	return true;
}

int main()
{
	int i, j;
	scanf("%d%d", &n, &e);
	
	visitedNodes = (int *)malloc(sizeof(int) * n);
	nodelist = (struct node **) malloc(sizeof(struct node *) * n);
	for (i = 0; i < n; i++) {
		nodelist[i] = NULL;
		visitedNodes[i] = -1;
	}
		
	for (i = 0; i < e; i++) {
		int t1, t2;
		struct node *temp;
		scanf("%d%d", &t1, &t2);
		t1--; t2--;
		temp = (struct node *)malloc(sizeof(struct node));
		temp->id = t2;
		temp->visitied  = -1;
		temp->next = NULL;
		if (nodelist[t1] != NULL) {
			int edgeExist = false;
			struct node * p;
			for (p = nodelist[t1]; ; p = p->next) {
				if (p->id == t2) { /* eliminate inputs with same edges */
					edgeExist = true;
					break;
				}
				if (p->next == NULL)
					break;
			}
			if (!edgeExist)
 				p->next = temp;
		} else {
			nodelist[t1] = temp;
		}
	}
	visitedNodeCount = 0;
	/* To prove a given graph as tree we have to check all nodes not just f(0),
		Since sometimes there may not be edges going out from node 0 */
	for (i = 0; i < n; i++) { 
		if (f(i) && visitedNodeCount == n) { /* visitedNodeCount == n checks for connectedness */
			printf("YES\n");	
			return 0;
		}
		visitedNodeCount = 0;
		for (j = 0; j < n; j++)
			visitedNodes[j] = -1;
	}
	printf("NO\n");
	
	return 0;
}

