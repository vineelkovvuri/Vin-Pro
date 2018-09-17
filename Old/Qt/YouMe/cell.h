#ifndef CELL_H
#define CELL_H
#include <QString>

using namespace std;
enum Directions{
    TOP,
    RIGHT,
    DOWN,
    LEFT
};
class Cell
{
    bool isFilled;
    QString filledBy;
public:
    int row, col;
    bool edges[4]; //top right down left
    Cell(int r, int c);
    void paintCell();
};

#endif // CELL_H
