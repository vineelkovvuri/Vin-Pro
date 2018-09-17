#include "youmemainwindow.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    YouMeMainWindow w;
    w.show();
    
    return a.exec();
}
