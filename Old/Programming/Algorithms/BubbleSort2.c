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

int main(void) {
	int j;
	int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
	int sorted = 1;
	for(j = 0;j < sizeof(arr)/sizeof(int) - 1; j++)
		if(arr[j] > arr[j+1]){
			sorted = 0;
			break;
		}
	if(sorted) printf("Yes");
	else printf("No");
}

