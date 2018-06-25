// http://www.geeksforgeeks.org/majority-element/

#include <iostream>
#include <stdlib.h>

using namespace std;

static int comparer(const void *p1, const void *p2)
{
    return *(int *)p1 - *(int *)p2;
}

void major(int *array, int n)
{
    int i;
    int major = -1, major_count = 0;

    for (i = 0; i < n; i++) {
        if (major_count == 0) {
            major_count = 1;
            major = array[i];
        }
        else {
            if (major == array[i])
                major_count++;
            else
                major_count--;
        }
    }

    major_count = 0;
    for (i = 0; i < n; i++)
        if (array[i] == major)
            major_count++;
    
    if (major_count > n / 2)
        cout << "Major: " << major <<"  Major count: " << major_count << endl;
    else
        cout << "NONE\n";
}

void major2(int *array, int n)
{
    int i;
    int major = -1, major_count = 0;
    int current = -1, current_count = 0;

    qsort(array, n, sizeof(int), comparer);
    for (i = 0; i < n; i++) {
        if (current != array[i]) {
            current_count = 1;
            current = array[i];
        }
        else {
            current_count++;
        }

        if (major_count < current_count) {
            major = current;
            major_count = current_count;
        }
    }

    cout << major_count << " \n";

    if (major_count > n / 2)
        cout << "\nMajor is: " << major;
    else
        cout << "\nNo major";
}

void major1(int *array, int n)
{
    int i;
    int major = -1, major_count = 0;
    int current = -1, current_count = 0;
    qsort(array, n, sizeof(int), comparer);
    for (i = 0; i < n; i++) {
        if (current != array[i]) {
            if (major_count < current_count) {
                major = current;
                major_count = current_count;
            }
            current_count = 1;
            current = array[i];
        }
        else {
            current_count++;
        }
    }

    if (major_count < current_count) {
        major = current;
        major_count = current_count;
    }

    cout << major_count << " \n";
    
    if (major_count > n / 2)
        cout << "\nMajor is: " << major;
    else
        cout << "\nNo major";
}

int majority()
{
    int n;
    int array[100];
    int i;
    
    cout << "\nEnter n:";
    cin >> n;
    cout << "\nEnter elements:";
    for (i = 0; i < n; i++)
        cin >> array[i];
    
    major(array, n);
	return 0;
}
