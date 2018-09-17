#include <iostream>
#include <cctype>
#include <algorithm>
#include <utility>

using namespace std;

// This function will find the index in the array
// from back of array where the elements change
// from increasing to decreasing
// example: 43192670
//               ^----this index is returned   
int find_inflection_point(int *perm, int size)
{
    int i = 0;
    for (i = size - 1; i > 0; i--)
        if (perm[i - 1] < perm[i])
            return i - 1;
    return -1;
}

// This function will return the next bigger
// number than the given number from the rest
// of the array.
// example: 43192 670
//                |^----this index is returned
int find_next_number(int *array, int size, int num)
{
    int i = 0;
    int idx = 0;
    int diff = array[0] - num;
    for (i = 1; i < size; i++) {
        if (array[i] > num && diff > array[i] - num) {
            idx = i;
            diff = array[i] - num;
        }
    }
    return idx;
}

int next_perm(int *perm, int size)
{
    int inflec = find_inflection_point(perm, size);

    if (inflec == -1)
        return false;

    int next_number_idx = find_next_number(perm + inflec + 1, 
                                           size - inflec - 1, 
                                           perm[inflec]);

    // make sure we convert back to actual index in main array
    next_number_idx += inflec + 1;
    swap(perm[inflec], perm[next_number_idx]);
    // sort the remaining elements in increasing order
    sort(perm + inflec + 1, perm + size);
    return true;
}

int next_permutation()
{
    int perm[100] = {0};
    int size = 0;
    
    cout << "\nEnter the size of the permutation:";
    cin >> size;
    cout << "\nEnter elements of permutation:";
    for (int i = 0; i < size; i++)
        cin >> perm[i];
    
    if (next_perm(perm, size))
        for (int  i = 0; i < size; i++) 
            cout << perm[i] << " ";
    else
        cout << "next permutation not possible!";

    return 0;
}
    
