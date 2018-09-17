#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <algorithm>
#include <utility>
#include <time.h>
#include <iostream>
using namespace std;

void random_subarray(int *array, int size, int k)
{
    srand(static_cast<unsigned int>(time(NULL)));
    for (int i = 0; i < k; i++) {
        // generate random number from [0, size-i)
        int r = rand() % (size - i);
        swap(array[i], array[i + r]);
    }
}

int random_subarray()
{
    int array[100] = {0};
    int size = 0;
    int k = 0;
    
    printf("\nEnter the size of the array:");
    cin >> size;
    printf("\nEnter elements of array:");
    for (int i = 0; i < size; i++)
        cin >> array[i];
    
    printf("\nEnter the size of the subarray:");
    cin >> k;

    random_subarray(array, size, k);
    for (int  i = 0; i < k; i++) 
        printf("%d ", array[i]);

    return 0;
}
    
