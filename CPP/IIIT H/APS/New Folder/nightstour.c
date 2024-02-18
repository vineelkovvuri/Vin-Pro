/*
  1  10  53  26  43  40  55  58
  8  27  24  39  54  57  44  41
 11   2   9  52  25  42  59  56
 16   7  28  23  38  61  50  45
  3  12  17  62  51  32  37  60
 18  15   6  29  22  35  46  49
 13   4  63  20  33  48  31  36
 64  19  14   5  30  21  34  47

*/


#include<stdio.h>
#include<stdlib.h>
#define TRUE 1
#define FALSE 0

#define MSIZE   5

int matrix[MSIZE][MSIZE];
int count = 0;
int cellcount = 1;

void printMatrix()
{
	int i,j;
	printf("\n-----------------------------\n");
	for(i = 0; i < MSIZE; i++){
		for(j = 0; j < MSIZE; j++){
			printf("%4d",matrix[i][j]);
		}
		printf("\n");
	}
}

int ValidMove(int x, int y)
{
	if(x >= 0 && y >= 0 && x < MSIZE && y < MSIZE && cellcount <= MSIZE*MSIZE  ) 
		if(matrix[x][y] == -1) return TRUE;
	return FALSE;
}

void nightstour(int x,int y)
{
	if(ValidMove(x,y)){ // if not conflicting
		matrix[x][y] = cellcount;
		if(cellcount >= MSIZE*MSIZE ){
			printMatrix();
			count++;
			return;
		}
		cellcount++;
		nightstour(x-2,y-1);
		nightstour(x-1,y-2);
		nightstour(x+1,y-2);
		nightstour(x+2,y-1);
		nightstour(x+2,y+1);
		nightstour(x+1,y+2);
		nightstour(x-1,y+2);
		nightstour(x-2,y+1);
		matrix[x][y] = -1;
		cellcount--;
	}
	return;
}
void clear()
{
	int i=0,j=0;
	for(i=0;i<MSIZE;i++)
		for(j=0;j<MSIZE;j++)
			matrix[i][j] = -1;
}

int main()
{
	int i=0,j=0;

	//nightstour(0,3);

	for(i=0;i<MSIZE;i++)
		for(j=0;j<MSIZE;j++){
			clear();
			cellcount = 1;
			nightstour(i,j);
		}

		printf("\ncount = %d",count);
}


