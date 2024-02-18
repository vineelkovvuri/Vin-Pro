#include "cell.h"

Cell::Cell(int r, int c)
{
    row = r;
    col = c;

    edges[0] = edges[1] = edges[2] = edges[3] = false;

}
