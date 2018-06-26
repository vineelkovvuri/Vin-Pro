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
int SelectionSort(void) {

	int i,j,n=10;
	int temp;
	int arr[] = {1, 9, 2, 5, 0, 6, 8, 5, 2, 10};
	int arr2[] = {1,2,3,4,5,6,7,8,9,10};

	for(i = 0;i < n; i++){
		printf("%3d",arr[i]);
	}
	printf("\n");
	for(i = 0;i < n; i++){
		printf("%3d",arr2[i]);
	}
	printf("\n=====================================\n");
	for(i = 0;i < n; i++){
		int max = 0;
		for(j = 1;j < n-i; j++)
			if(arr[j] > arr[max]) max = j;


		temp = arr[max];
		arr[max] = arr[n-i-1];
		arr[n-i-1] = temp;
		//
		temp = arr2[max];
		arr2[max] = arr2[n-i-1];
		arr2[n-i-1] = temp;
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
