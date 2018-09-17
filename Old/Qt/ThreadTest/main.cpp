#include <QCoreApplication>
#include "controller.h"
#include <QDebug>
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    Controller c;
    emit c.operate("Start");
     emit c.operate("Start2");
    return a.exec();
}
