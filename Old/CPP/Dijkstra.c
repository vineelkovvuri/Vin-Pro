
#include<stdio.h>
#include<stdlib.h>
#include<math.h>

#define MaxNodes  100

struct Node
{
	int id;
	int nNeighs;
	int *neighsID;
	int *weights;
	int visited;
}Nodes[MaxNodes];

//swaping two structures.....
void swap(struct Node *p,struct Node *q)
{
	struct Node temp;

	temp.id = p->id;
	temp.nNeighs = p->nNeighs;
	temp.neighsID = p->neighsID;
	temp.weights = p->weights;
	temp.visited = p->visited;

	p->id = q->id;
	p->nNeighs = q->nNeighs;
	p->neighsID = q->neighsID;
	p->weights = q->weights;
	p->visited = q->visited;

	q->id = temp.id;
	q->nNeighs = temp.nNeighs;
	q->neighsID = temp.neighsID;
	q->weights = temp.weights;
	q->visited = temp.visited;

}

int index,nNodes,startNode;
main()
{
	int i,j,
		k=-1,						//Index for Queue
		count = 0;	
	static int queue[MaxNodes];

	printf("\nHow many nodes does the Graph contain ? ");
	scanf("%d",&nNodes);
	for(i=0;i<nNodes;i++)
	{
		Nodes[i].id = i; 
		printf("\nHow many neighbours does Node#%d has ? ",i);
		scanf("%d",&Nodes[i].nNeighs);
		if(Nodes[i].nNeighs!=0){
			Nodes[i].neighsID = (int*)malloc(Nodes[i].nNeighs*sizeof(int));
			Nodes[i].weights = (int*)malloc(Nodes[i].nNeighs*sizeof(int));
			for(j=0;j<Nodes[i].nNeighs;j++)
			{
				printf("\nEnter the Id and weight of neighbour%d :",j);
				scanf("%d%d",&Nodes[i].neighsID[j],&Nodes[i].weights[j]);
			}
		}
	}

	printf("\nEnter the start Node's Id :");
	scanf("%d",&startNode);
	i = startNode;
	do{
		if(i >= 0 && i < nNodes	//Check whether user enterted valid node ID.
				&&	Nodes[i].nNeighs != 0)		//Nodes Should have some neighbouring Nodes.
		{
			int min;
			//pushing the elements to queue
			for(k=0;k<Nodes[i].nNeighs;k++,count++)
			if(Node(	queue[k] = Nodes[i].neighsID[k];

			//find the 	
			temp = 0;
			for(j=0;j<Nodes[i].nNeighs;j++)
				if(Nodes[i].weights[min]>Nodes[i].weights[j])min = j;
			//swap min to starting of queue
			swap(Nodes[0],Nodes[min]);


		}
	}while(count!=0);									//If the Queue is not empty then continue.
	//Display
	for(i=0;i<nNodes;i++)
	{
		printf("\n%d : ",Nodes[i].id);
		for(j=0;j<Nodes[i].nNeighs;j++)
			printf("%d ",Nodes[i].neighsID[j]);
	}


}



