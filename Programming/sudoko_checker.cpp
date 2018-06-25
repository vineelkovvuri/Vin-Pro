#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <utility>

using namespace std;

int get_bit(int n, int k)
{
    if (k > 0)
        return (n >> k) & 1;
    return 0;
}

void set_bit(int& n, int k)
{
    if (k > 0)
        n |= (1 << k);
}    

bool checker(int board[9][9])
{
    // check rows
    for (int i = 0; i < 9; i++) {
        int check = 0;
        for (int j = 0; j < 9; j++) {
            if (get_bit(check, board[i][j]))
                return false;
            set_bit(check, board[i][j]);
        }
    }

    // check coloums
    for (int j = 0; j < 9; j++) {
        int check = 0;
        for (int i = 0; i < 9; i++) {
            if (get_bit(check, board[i][j]))
                return false;
            set_bit(check, board[i][j]);
        }
    }
    
    // check sub 3x3 boards
    int check[3][3] = {0};
    for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
            if (get_bit(check[i%3][j%3], board[i][j]))
                return false;
            set_bit(check[i%3][j%3], board[i][j]);
        }
    }
    
    return true;
}

int sudoko_checker()
{
	int board[9][9] = {0};
    
    printf("\nEnter the board configuration:");
    for (int i = 0; i < 9; i++)
        for (int j = 0; j < 9; j++)
            scanf("%d", &board[i][j]);
        
	printf("\nSudoko valid? %d", checker(board));
	return 0;
}