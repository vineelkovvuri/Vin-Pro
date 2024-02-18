
#include<stdio.h>

#define MAX_ROW 4
#define MAX_COL 4

int mat[MAX_ROW][MAX_COL] ={{1,3,1,2},{4,3,10,5},{9,5,1,8},{8,2,9,6}};//{{4,3,8,6},{5,7,2,4},{16,9,3,1},{2,5,3,7}};
int path[MAX_ROW] = {-1,-1,-1,-1};
int minpath[MAX_ROW] = {-1,-1,-1,-1};

int checkValid(int i, int j)
{
	int I;
	for(I=i; I >= 0;I--)
		if(path[I] == j) return 0;
	return 1;
}

int cost = 0;
int mincost = 1000000;
void JobAssignment(int row)
{
	if(row >= MAX_ROW){
		if(mincost > cost){
			int i;
		   	mincost = cost;
			for(i = 0;i < MAX_ROW; i++)  // need to save the min path becoz path array is overwritten once we go back to the recursive call 
				minpath[i] = path[i];
		}
	   	return;
	}
	else {
		int j;
		for(j = 0;j < MAX_COL;j++){
			if(checkValid(row,j)){
				path[row] = j;
				cost += mat[row][j];
				JobAssignment(row+1);
				cost -= mat[row][j];
				path[row] = -1;
			}
		}
	}
}

int main()
{
	int i = 0;
	JobAssignment(0);
	printf("\nmin cost:%d",mincost);
	for(i = 0;i < MAX_ROW; i++)
		printf("\n[%d,%d] = %d",i,minpath[i],mat[i][minpath[i]]);
}




