#include <stdio.h>

int remove_duplicate_elements(int *a, int m)
{
    int j = 0;
    for (int i = 1; i < m; i++)
        if (a[i] != a[j])
            a[++j] = a[i];
    return j + 1; // We are preincrementing j so the length will be j + 1
}

int delete_duplicates_sorted_array()
{
    int a[] = {1, 1, 2, 2, 2, 3, 4, 4, 5, 5};
    int m = sizeof(a)/sizeof(int);
    
    int len = remove_duplicate_elements(a, m);
    for (int  i = 0; i < len; i++) 
        printf("%d ", a[i]);

    return 0;
}
    
