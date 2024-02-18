#include<stdio.h>

#include<math.h>

#define TRUE 1
#define FALSE 0

int n = 8;
int place(int k);
void queen(int k);
int x[5]={-1,-1,-1,-1,-1};   //index for column and value at that index is row number

// k == column 
int canPlaced(int row,int col) // row,col
{
	int i;
	for(i=0;i<=row;i++) // column 
		if((x[i]==col)||(row - i) == abs(x[i]-col))
			return 0;
	return 1;
}
void PrintMatrix()
{
	int i = 0;
	printf("\n-------------\n");
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
			printf("%d ",x[i]);
	printf("\n");
}
void queen(int i) //column number
{
	int j;
	for(j=0;j<n;j++){
		if(canPlaced(i,j)){
			x[i] = j;
			if(i==n-1){
				PrintMatrix();
			//	return;
			}
			else{
				
				queen(i+1);
				x[i] = -1;
			}
		}
	}
}


int main()
{
	int i =0;
	//for(i = 0 ;i<n;i++)
	queen(0);
}
