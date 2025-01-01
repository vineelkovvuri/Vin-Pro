#define _CRT_SECURE_NO_WARNINGS
// www.geeksforgeeks.org/write-a-program-to-reverse-an-array-or-string/

#include <stdio.h>

void reverse(int *arr, int m)
{
    int i, j;
    
    for (i = 0, j = m - 1; i < j; i++, j--) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

int reverse_array()
{
    int n;
    int array[100];
    int i;

    printf("\nEnter n:");
    scanf("%d", &n);
    printf("\nEnter each element:");
    for (i = 0; i < n; i++)
        scanf("%d", &array[i]);

    reverse(array, n);
    for (i = 0; i < n; i++)
        printf("%d ", array[i]);
    return 0;
}
