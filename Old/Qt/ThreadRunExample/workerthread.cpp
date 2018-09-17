
#include <QThread>
#include <QString>
#include <QDebug>
#include "workerthread.h"

void WorkerThread::run(){
        QString result;
        for(int i = 0; i < 10; i++){
            lock.lock();
            qDebug() << "Worker Thread" << i << "  " << QThread::currentThreadId() << endl;
            lock.unlock();
        }

        /* expensive or blocking operation  */
        emit resultReady(result);
}
