#ifndef CONTROLLER_H
#define CONTROLLER_H
#include "worker.h"
#include <QThread>

class Controller : public QObject
{
    Q_OBJECT
    QThread workerThread;
public:
    Controller() {
        Worker *worker = new Worker;
        worker->moveToThread(&workerThread);
        //connect(workerThread, SIGNAL(QThread::finished()), worker, SLOT(QObject::deleteLater()));
        connect(this, &Controller::operate, worker, &Worker::doWork);
        //connect(worker, &Worker::resultReady, this, &Controller::handleResults);
        workerThread.start();
    }
    ~Controller() {
        workerThread.quit();
        workerThread.wait();
    }
//public slots:
 //   void handleResults(const QString &);
signals:
    void operate(const QString &);
};
#endif // CONTROLLER_H
