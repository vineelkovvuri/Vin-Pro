/*
 ============================================================================
 Name        : Sample.c
 Author      : 
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
int BubbleSort(void) {

	int i,j,n=10;
	int arr[] = {1, 3, 1, 0, 8, 6, 4, 2, 0, 10}; //{1,2,3,4,5,6,7,8,9,10};
	int arr2[] = {1,2,3,4,5,6,7,8,9,10};

	for(i = 0;i < n; i++){
			printf("%3d",arr[i]);
	}
	printf("\n");
	for(i = 0;i < n; i++){
		printf("%3d",arr2[i]);
	}
	printf("\n=====================================\n");
	for(i = 0;i < n-1; i++){
		for(j = 0;j < n-i-1; j++){
			if(arr[j] > arr[j+1]){
				int temp;
				temp = arr[j+1];
				arr[j+1] = arr[j];
				arr[j] = temp;
				//
				temp = arr2[j+1];
				arr2[j+1] = arr2[j];
				arr2[j] = temp;
			}
		}
	}
	for(i = 0;i < n; i++){
		printf("%3d",arr[i]);
	}
	printf("\n");
	for(i = 0;i < n; i++){
		printf("%3d",arr2[i]);
	}
	return EXIT_SUCCESS;
}
