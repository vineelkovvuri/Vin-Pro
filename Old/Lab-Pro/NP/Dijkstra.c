#include<stdio.h>
#include<conio.h>

#define true 1
#define false 0

struct Node{						//structure representing a single Node in the Graph....		
	char id,						//Id of the node
		 prev;						//Id of its parent
	int cost,						//Current node cost
		nNeighs,					//Number of neighbours
		visited,					//true if node is already traversed false otherwise
		*edgeCost;					//edge cost b/w this node and its neighbours
	struct Node	**neighs;			//neighbours array
}
*Graph,								//Entire Graph		
**List;								//A List holding the reachable Nodes

int nNodes,							//Number of nodes in the Graph			
	rear=-1,						//rear acts as an index for List
	leastCost;								

//pop routine will remove an element from the List 
void pop();
//This routine is called by pop(). It will add the neighbours of recently popped node to List
void InsertNeighsList(struct Node * temp);

main()
{
	int i,j;
	char temp;
	printf("\nHow many nodes are there in the Graph: ");
	scanf("%d",&nNodes);
	//Creating the graph dynamically
	Graph = (struct Node *)malloc(nNodes*sizeof(struct Node));
	//Creating Array of pointer for constructing the List
	List = (struct Node **)malloc(nNodes*sizeof(struct Node *));

	for(i = 0;i<nNodes;i++){
		Graph[i].id = i + 'a';					//Id of the node 
		Graph[i].visited = false;				//Not yet visited
		Graph[i].cost = 0;						//All nodes have initial cost of Zero

		printf("\nHow many neighbours are directed from Node(%c):",Graph[i].id);
		scanf("%d",&Graph[i].nNeighs);
		//Creating an Array of pointers dynamically for holding the neighbours 
		Graph[i].neighs = (struct Node **)malloc(Graph[i].nNeighs*sizeof(struct Node*));
		//Creating an Array of pointers dynamically for holding the edge costs 
		Graph[i].edgeCost = (int *)malloc(Graph[i].nNeighs*sizeof(int ));

		if(Graph[i].nNeighs != 0){				//If neighbours are there
			for(j=0;j<Graph[i].nNeighs;j++){
				printf("\nEnter the ID and Edge cost of the Node#%d that is directed from Node(%c):",j+1,Graph[i].id);
				fflush(stdin);
				scanf("%c",&temp);
				if(temp>='a'&&temp<='z'){		//Validating whether user entered a valid ID or not
					Graph[i].neighs[j] = &Graph[temp - 'a'];
					scanf("%d",&Graph[i].edgeCost[j]);
				}
				else {
					printf("\nPlease enter the data correctly...");
					exit(1);
				}
			}
		}
	}
	//Inserting the first node into the List
	Graph[0].prev = ' ';
	List[++rear] = &Graph[0];
	while(rear!=-1)								//pop the List until it is empty....
		pop();

	printf("\nLeast Cost is %d",leastCost);
	//	Display();
	//	getch();
}

void pop()
{
	int i=0;
	struct Node *temp;
	temp = List[rear--];
	temp->visited = true;
	if(temp->prev != ' ')						//Calculate the least cost from all nodes except from the starting node
		leastCost += Graph[temp->id - 'a'].cost - Graph[temp->prev - 'a'].cost;
	printf("\n%c -> %c",temp->prev,temp->id);
	InsertNeighsList(temp);						//Load the neighbours of popped node in to the List	
}
void InsertNeighsList(struct Node * node)
{
	int i=0,j=0,eligible = true;
	struct Node *temp;

	for(i=0;i<node->nNeighs;i++)						//Enumerating the neighbouring nodes...
		if(!node->neighs[i]->visited ){					//Neighbour node should not be already visited
			eligible = true;
			for(j = 0;j<=rear;j++){						//Check whether the Neighbour node is in the list
				if(List[j] == node->neighs[i]){			//If the Neighbour node is already present in the list 
					if(node->cost + node->edgeCost[i] <	//If cost along new path is less than the
							List[j]->cost				//cost of the same node on the list 
							||List[j]->cost == 0){		//or Neighbour node is a new node
						List[j]->cost =	node->cost + node->edgeCost[i];	//Update the cost of Neighbour node in the List
						List[j]->prev = node->id;		//Update to new path	
					}
					eligible = false;
					break;
				}
			}
			if(eligible){								//If neighbour node is not already present on the List
				node->neighs[i]->cost = node->cost + node->edgeCost[i];
				node->neighs[i]->prev = node->id;		
				List[++rear] = node->neighs[i];			//Add the neighbour node to List
			}
		}
	//Swap the node with least cost to rear position in the List ....
	if(rear > 0){
		j = 0;
		for(i = 0 ; i <= rear ; i++)
			if(List[i]->cost < List[j]->cost) j = i;
		temp = List[j];
		List[j] = List[rear];
		List[rear] = temp;
	}
}

/*
Input:
How many nodes are there in the Graph: 5
How many neighbours are directed from Node(a):3
Enter the ID and Edge cost of the Node#1 that is directed from Node(a):b 1
Enter the ID and Edge cost of the Node#2 that is directed from Node(a):c 3
Enter the ID and Edge cost of the Node#3 that is directed from Node(a):d 2
How many neighbours are directed from Node(b):0
How many neighbours are directed from Node(c):1
Enter the ID and Edge cost of the Node#1 that is directed from Node(c):e 5
How many neighbours are directed from Node(d):1
Enter the ID and Edge cost of the Node#1 that is directed from Node(d):e 9
How many neighbours are directed from Node(e):0

Output:

-> a 
a -> b 
a -> d 
a -> c
c -> e
Least Cost is 11
*/ 
