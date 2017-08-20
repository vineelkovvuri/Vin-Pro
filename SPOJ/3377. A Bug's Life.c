/* 

   perform BFS or DFS on the graph. If the graph cannot be 2 colored(meaning not biparted)
   then professor is wrong!
 */



#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define true 1
#define false 0

struct neighbour {
	int idx;
	struct neighbour *next;
} buf[2*1000010];

struct node {
	int visited;
	int gender;
	int loop;
	struct neighbour *first;
	struct neighbour *last;
} nodes[2010];

int stack[100000];
int label(int x)
{
	struct neighbour * p;
	int top = -1;
	stack[++top] = x;

	while (top != -1) {

		int idx = stack[top--];
	//	printf("top = %d,", idx);
	  	
		nodes[idx].visited = true;
		if (nodes[idx].loop == true) return -1;
		for (p = nodes[idx].first; p != NULL; p = p->next) {
			if (nodes[p->idx].gender == 0) 
				nodes[p->idx].gender = (nodes[idx].gender == 'M' ? 'F' : 'M');
			else if (nodes[p->idx].gender != (nodes[idx].gender == 'M' ? 'F' : 'M')) 
				return -1;
			if (!nodes[p->idx].visited)
				stack[++top] = p->idx;
		}
	//	nodes[idx].visited = false;
	}
	return 0;	
}

int main()
{
	int t, j;
	scanf("%d", &t);
	for (j = 1; j <= t; j++) {
		int n, k, i, x, y, bufp = 0;
		scanf("%d%d", &n, &k);
		for (i = 1; i <= n; i++) {
			nodes[i].first = NULL;
			nodes[i].last = NULL;
			nodes[i].gender = 0;
			nodes[i].loop = 0;
			nodes[i].visited = 0;
		}
		for (i = 1; i <= k; i++) {
		    scanf("%d%d", &x, &y);
			if (x == y) {
				nodes[x].loop = 1;
				continue;
			}
			//push in to the list
			struct neighbour *p, *tmp;
			tmp = &buf[bufp++]; 
			tmp->idx = y;
			tmp->next = NULL;
			p = nodes[x].last;
			if (p == NULL) nodes[x].last = nodes[x].first = tmp;
			else {
				p->next = tmp;
				nodes[x].last = tmp;
			}

			tmp = &buf[bufp++]; 
			tmp->idx = x;
			tmp->next = NULL;
			p = nodes[y].last;
			if (p == NULL) nodes[y].last = nodes[y].first = tmp;
			else {
				p->next = tmp;
				nodes[y].last = tmp;
			}
		}
#if 1
		for (i = 1; i <= n; i++) {
			if (nodes[i].gender == 0 && nodes[i].first != NULL && nodes[i].visited == false){
				nodes[i].gender = 'M';
				if (label(i) != 0) {
					printf("Scenario #%d:\n", j);
					printf("Suspicious bugs found!\n");
					break;
				}
			}
		}
		if (i > n) {
			printf("Scenario #%d:\n", j);
			printf("No suspicious bugs found!\n");
		}
#endif
	}
	return 0;
}

