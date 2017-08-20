#ifndef BOARD_H
#define BOARD_H
#include <QObject>
#include <QWidget>
#include <QVector>
#include <QRect>
#include <QPainter>

#include "cell.h"
#include "point.h"

class Board : public QWidget
{
    Q_OBJECT

public:
    QVector<QVector<Cell*> > cells;
    QVector<QVector<Point*> > points;

    Board(int m, QWidget *parent = 0);
    //virtual ~Board(){}
    void updateCells(Point p1, Point p2);
    //void paintBoard();
protected:
    void paintEvent(QPaintEvent *event);
    //void keyPressEvent(QKeyEvent *event);

};

#endif // BOARD_H
