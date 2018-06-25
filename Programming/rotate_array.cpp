#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void rotate(int *arr, int n, int shift)
{
    int temp;
    int  i;
    
    if (n <= 1)
        return;
    
    while (shift--) {
        temp = arr[0];
        for (i = 1; i < n; i++)
            arr[i - 1] = arr[i];
        arr[n - 1] = temp;
    }    
}

int rotate_array()
{
    int i;
    int n;
    int array[100];

    printf("\nEnter n:");
    scanf("%d", &n);
    printf("\nEnter each element:");
    for (i = 0; i < n; i++)
        scanf("%d", &array[i]);

    rotate(array, n, 4);

    for (i = 0; i < n; i++)
        printf("%d ", array[i]);
    return 0;
}
