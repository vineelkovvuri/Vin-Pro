#include <iostream>

using namespace std;

int max_sum(int *arr, int n)
{
    int max = 0;
    int i = 0;
    int j = 0;
    
    if (n <= 2)
        return -1;
    
    for (j = 0; j < n - 2; j++)
        for (i = j + 2; i < n; i++)
            if (max < arr[j] + arr[i])
                max = arr[j] + arr[i];
    
    return max;
}

int max_sum_not_adjacent()
{
    int n;
    int a[100];
    int i;
    int max;
    
    cout << "\nEnter n:";
    cin >> n;
    
    cout << "\nEnter elements:";
    for (i = 0; i < n; i++)
        cin >> a[i];
       
    max = max_sum(a, n);
    
    cout << max;
    return 0;
}