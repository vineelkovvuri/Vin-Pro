#include <iostream>

using namespace std;

static void reverse(int *arr, int n)
{
    int i, j;
    int temp;
    
    for (i = 0, j = n - 1; i < j; i++, j--) {
        temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

void reversal(int *arr, int n, int shifts)
{
    if (n <= shifts)
        return;
    
    reverse(arr, shifts);
    reverse(&arr[shifts], n - shifts);
    reverse(arr, n);
}

int block_reversal()
{
    int n;
    int a[100];
    int i;
    int shifts;
    
    cout << "\nEnter n:";
    cin >> n;
    
    cout << "\nEnter elements:";
    for (i = 0; i < n; i++)
        cin >> a[i];
    
    cout << "\nEnter number of shifts to make the rotation:";
    cin >> shifts;
    
    reversal(a, n, shifts);
    
    for (i = 0; i < n; i++)
        cout << a[i] << " ";
    
    return 0;
}