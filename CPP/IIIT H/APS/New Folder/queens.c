#include<stdio.h>

#define TRUE 1
#define FALSE 0

#define MSIZE   8

int matrix[MSIZE][MSIZE];


void printMatrix()
{
	int i,j;
	printf("\n-----------------------------\n");
	for(i = 0; i < MSIZE; i++){
		for(j = 0; j < MSIZE; j++){
			printf("%3d",matrix[i][j]);
		}
		printf("\n");
	}
}
int conflicted(int x, int y)
{
	int i,j;

	//column check
	for(i = 0; i < x; i++)  // sufficient to go till the depth of y
		if(matrix[i][y] == 1) return TRUE; // found conflit in column
	
	i = x - 1;
	j = y - 1;
	while(i >= 0 && j >= 0){
		if(matrix[i][j] == 1) return TRUE; // check in top left diagonal
		i--;
		j--;
	}
	
	i = x - 1;
	j = y + 1;
	while(i >= 0 && j < MSIZE){
		if(matrix[i][j] == 1) return TRUE; // check in top right diagonal
		i--;
		j++;
	}
	return FALSE;	// no conflicts
}
int count = 0;
void queens(int i)
{
	if(i == MSIZE ){
		printMatrix();
		count++;
		return;
	}
	else{
		int j;
		for(j = 0; j < MSIZE; j++){
			if(!conflicted(i,j)){
				matrix[i][j] = TRUE;
				queens(i+1);
				matrix[i][j] = FALSE;
			}
		}
	}
}


int main()
{
	queens(0);

	printf("\ncount = %d",count);
}

