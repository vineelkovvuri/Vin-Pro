#include "youmemainwindow.h"
#include "ui_youmemainwindow.h"
#include "board.h"

YouMeMainWindow::YouMeMainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::YouMeMainWindow)
{
    ui->setupUi(this);


    Board *b = new Board(8);
    ui->horizontalLayout->addWidget(b);




}

YouMeMainWindow::~YouMeMainWindow()
{
    delete ui;
}
