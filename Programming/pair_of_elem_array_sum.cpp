//http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/

#include <iostream>

using namespace std;

int comparer(const void *p1, const void *p2)
{
    return *(int *)p1 - *(int *)p2;
}

void array_sum_pointers(int *array, int n, int sum)
{
    int *p, *q;
    
    qsort(array, n, sizeof(int), comparer);
    p = &array[0];
    q = &array[n-1];
    while (*p < *q) {
        if (*p + *q < sum)
            p++;
        else if (*p + *q > sum)
            q--;
        else
            cout << *p++ << " " << *q-- << endl;
    }
}

void array_sum(int *array, int n, int sum)
{
    int i = 0, j = n - 1;
    
    qsort(array, n, sizeof(int), comparer);
    while (i < j) {
        int pair_sum = array[i] + array[j];
        if (pair_sum < sum)
            i++;
        else if (pair_sum > sum)
            j--;
        else
            cout << array[i++] << " " << array[j--] << endl;
    }
}

int pair_of_elem_array_sum()
{
    int n;
    int array[100];
    int sum;
    int i;
    
    cout << "\nEnter n:";
    cin >> n;
    cout << "\nEnter elements:";
    for (i = 0; i < n; i++)
        cin >> array[i];
    cout << "\nEnter sum:";
    cin >> sum;

    array_sum_pointers(array, n, sum);
    return 0;
}
