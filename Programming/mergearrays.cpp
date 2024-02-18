// http://www.geeksforgeeks.org/merge-one-array-of-size-n-into-another-one-of-size-mn/

#include <iostream>

using namespace std;

void sqaush(int *arr, int m)
{
    int hole = 0;
    int i;
    
    for (i = 0; i < m; i++)
        if (arr[i] != -1)
            arr[hole++] = arr[i];
     
}

void merge(int *arr1, int m, int *arr2, int n)
{
    int i = m - n - 1;
    int j = n - 1;
    int k = m - 1;
    
    while (k >= 0) {
        if (j < 0 || (i > 0 && arr1[i] > arr2[j]))
            arr1[k--] = arr1[i--];
        else
            arr1[k--] = arr2[j--];
    }

}

void merge_arrays(int *arr1, int m, int *arr2, int n)
{
    sqaush(arr1, m);
    merge(arr1, m, arr2, n);
}

int mergearrays()
{
    int m, n;
    int arr1[100], arr2[100];
    int i;

    cout << "\nEnter m, n:";
    cin >> m >> n;
    
    cout << "\nEnter each element in first array:";
    for (i = 0; i < m; i++)
        cin >> arr1[i];

    cout << "\nEnter each element in second array:";
    for (i = 0; i < n; i++)
        cin >> arr2[i];

    merge_arrays(arr1, m, arr2, n);
    
    for (i = 0; i < m; i++)
        cout << arr1[i] << " ";
    return 0;
}
