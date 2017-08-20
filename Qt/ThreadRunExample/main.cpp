#include <QCoreApplication>
#include "workerthread.h"
#include <QDebug>

class MyMain : public QObject{

public:
    WorkerThread *workerThread ;
    void startWorkInAThread()
    {
        workerThread = new WorkerThread(this);
    //    connect(workerThread, &WorkerThread::resultReady, this, &MyObject::handleResults);
    //    connect(workerThread, &WorkerThread::finished, workerThread, &QObject::deleteLater);
        workerThread->start();
    }
};



int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    MyMain m;
    m.startWorkInAThread();

    for(int i = 0; i < 10; i++) {
        m.workerThread->lock.lock();
        qDebug() << "Main Thread " << i << "  " << QThread::currentThreadId() << endl;
        m.workerThread->lock.unlock();
    }

    return a.exec();
}
