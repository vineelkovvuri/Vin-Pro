// http://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/

#include <iostream>
using namespace std;

int find_odd_number(int *array, int n)
{
    int i;
    int xor = 0;

    for (i = 0; i < n; i++)
        xor ^= array[i];

    return xor;
}

int oddnumber()
{
    int n;
    int array[100];
    int i;

    cout << "\nEnter n:";
    cin >> n;
    cout << "\nEnter each element:";
    for (i = 0; i < n; i++)
        cin >> array[i];

    cout << "\nNumber occuring odd number of times: " << find_odd_number(array, n);
    return 0;
}
