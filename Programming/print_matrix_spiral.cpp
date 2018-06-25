
#include <stdio.h>
#include <iostream>
using namespace std;

int mat[100][100] = {0};

void spiral(int ii, int jj, int m, int n)
{
    // terminate if any of them crosses each other
    if (ii >= m || jj >= n)
        return;
    
    // Idea is to print the outer circle carefully
    // without violating ii, jj, m, n
    for (int j = jj; j < n; j++)
        printf("%2d ", mat[ii][j]);

    for (int i = ii + 1; i < m; i++)
        printf("%2d ", mat[i][n-1]);

    for (int j = n - 2; j >= jj; j--)
        printf("%2d ", mat[m-1][j]);

    for (int i = m - 2; i > ii; i--)
        printf("%2d ", mat[i][jj]);
    
    // Call the inner matrix formed from ii+1, jj+1, m-1, n-1
    // recursively
    spiral(ii + 1, jj + 1, m - 1, n - 1);
}

int print_matrix_spiral()
{
    int m, n;
    cout << "\nEnter size of matrix m n:";
    cin >> m >> n;
    
    cout << "\nEnter elements:";
    for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
        cin >> mat[i][j];
    
    spiral(0, 0, m, n);
	return 0;
}