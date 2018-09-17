/*
This task is solved with 2 BFSs. 
First of all we need to start a BFS from any arbitrary node and find the 
furthest node from this arbitrary node. The path we just found isn't the 
longest, But the furthest node we just found is the starting point for 
our real longest path. Now we need to find the furthest node from the node
we just found, that will be our answer.
*/
#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define false 0
#define true 1

struct node {
	int id;
	struct node *next;
};

struct nlist {
	int visited;
	struct node *head;
	struct node *end;
} n[10010] = {0};


int f(int id, int *lid)
{
	int max = 0;
	int noNodeToVisit = true;
	struct node *p;
	n[id].visited = true;
	for (p = n[id].head; p; p = p->next) {
		if (!n[p->id].visited) {
			noNodeToVisit = false;
			int _lid = 0;
			int val = 1 + f(p->id, &_lid);
			if (val > max) {
				max = val;
				*lid = _lid; /* propagate the furthest terminal node id */
			}
		}
	}
	if (noNodeToVisit) { /* propagate the terminal node id */
		*lid = id;
	}	
	n[id].visited = false;
	return max;
}

int main()
{
	int nNodes = 0;
	int gMax = -1;
	int n1, n2, i, j;
	struct node *p;

	scanf("%d", &nNodes);
	for (i = 0; i < nNodes - 1; i++) {
		scanf("%d %d", &n1, &n2);
		--n1; --n2;
		//First node
		struct node *new = malloc(sizeof(struct node));
		new->id = n2;
		new->next = NULL;
		if (n[n1].head == NULL) {
			n[n1].head = new;
			n[n1].end = new;
			n[n1].visited = false;
		} else {
			n[n1].end->next = new;
			n[n1].end = new;
		}
		//Second node
		new = malloc(sizeof(struct node));
		new->id = n1;
		new->next = NULL;
		if (n[n2].head == NULL) {
			n[n2].head = new;
			n[n2].end = new;
			n[n2].visited = false;
		} else {
			n[n2].end->next = new;
			n[n2].end = new;
		}
	}
	int lid = 0; //long length id
	f(0, &lid); // find further node from an arbitrary node
	printf("%d", f(lid, &i)); // find the actual longest length node
	return 0;
}
