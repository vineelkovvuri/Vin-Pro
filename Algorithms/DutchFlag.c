
#include <stdio.h>

#define MAX_COL 10
#define MAX_ROW 10

extern int rndArr[MAX_ROW][MAX_COL];

int main() {
	int i,j,k;
	for(k = 0;k < MAX_ROW; k++){
		int *arr = rndArr[k];
		for(i = 0;i < MAX_COL; i++)
			printf("%3d",arr[i]);
		
		printf("\n");

		for(i = 0,j = MAX_COL-1;i<j;){
			if(arr[i] == 0)i++;
			if(arr[j] == 2)j--;
			if(arr[i] == 1 &&  arr[j] == 0){
				arr[j] = 1;
				arr[i] = 0;
			}

		}

		for(i = 0;i < MAX_COL; i++)
			printf("%3d",arr[i]);
		
		printf("\n========================\n");	
	}		
}

int rndArr[MAX_ROW][MAX_COL] = {{2,0,0,0,1,2,1,1,1,2},{1,1,1,0,2,1,1,0,1,2},{0,1,1,1,0,0,1,2,2,0},{0,1,0,1,1,2,0,1,2,0},{0,2,0,0,1,0,1,0,0,0},{1,1,2,1,1,0,0,2,2,0},{1,0,0,0,2,0,0,1,1,2},{0,0,1,0,0,0,0,1,0,0},{1,0,2,1,2,0,0,0,1,0},{1,0,0,1,0,2,1,1,1,2}};

