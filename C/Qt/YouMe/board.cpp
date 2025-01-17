#include "board.h"

Board::Board(int m, QWidget *parent) : QWidget(parent)
{
    //Create cell rows
    for (int i = 0; i < m; i++) {
        cells.push_back(QVector<Cell*>());
    }
    for (int i = 0; i < m; i++) {
        //Create cell columns
        for (int j = 0; j < m; j++) {
            cells[i].push_back(new Cell(i, j));
        }
    }
    //Create point rows
    for (int i = 0; i < m + 1; i++) {
        points.push_back(QVector<Point*>());
    }
    for (int i = 0; i < m + 1; i++) {
        //Create point columns
        for (int j = 0; j < m + 1; j++) {
            points[i].push_back(new Point(i, j));
        }
    }
}

void Board::updateCells(Point p1, Point p2)
{
    int i1, j1, i2, j2;

    i1 = p1.i;
    j1 = p1.j;
    i2 = p2.i;
    j2 = p2.j;

    if (i1 - 1 == i2 && j1 == j2) { // top
        // cells[i-1][j-1] && cells[i-1][j];
        //cell[i-1][j-1]
        if (i1 - 1 >= 0 && j1 - 1 >= 0) {
            cells[i1-1][j1-1]->edges[RIGHT] = true;
            //call updatecell();
        }
        //cell[i-1][j]
        if (i1 - 1 >= 0) {
            cells[i1-1][j1]->edges[LEFT] = true;
            //call updatecell();
        }
    }
    else if (i1 == i2 && j1 + 1 == j2) { // right
        // cells[i-1][j] && cells[i][j];
        //cell[i-1][j]
        if (i1 - 1 >= 0) {
            cells[i1-1][j1]->edges[DOWN] = true;
            //call updatecell();
        }
        //cell[i][j]
        if (i1 >= 0 && j1 >= 0) {
            cells[i1-1][j1-1]->edges[TOP] = true;
            //call updatecell();
        }
    }
    else if (i1 + 1 == i2 && j1 == j2) { // down
        // cells[i][j] && cells[i][j-1];
        //cell[i][j]
        if (i1 >= 0 && j1 >= 0) {
            cells[i1-1][j1-1]->edges[LEFT] = true;
            //call updatecell();
        }
        //cell[i][j - 1]
        if (j1 - 1 >= 0) {
            cells[i1][j1 - 1]->edges[RIGHT] = true;
            //call updatecell();
        }
    }
    else if (i1 == i2 && j1 - 1 == j2) { // left
        // cells[i][j-1] && cells[i-1][j-1];
        //cell[i][j - 1]
        if (j1 - 1 >= 0) {
            cells[i1][j1 - 1]->edges[TOP] = true;
            //call updatecell();
        }
        //cell[i - 1][j - 1]
        if (i1 - 1 >= 0 && j1 - 1 >= 0) {
            cells[i1-1][j1-1]->edges[DOWN] = true;
            //call updatecell();
        }
    }
}
void Board::paintEvent(QPaintEvent *event)
{
    QWidget::paintEvent(event);
    QPainter painter(this);
    QRect rect = contentsRect();

    QPen pen(Qt::black);
    pen.setStyle(Qt::SolidLine);
    pen.setWidth(5);
    painter.setPen(pen);
    //painter.fillRect(rect, Qt::red);
    painter.drawText(rect, Qt::AlignCenter, tr("Pause"));
    update();
    painter.drawRect(rect);
    return;
}
