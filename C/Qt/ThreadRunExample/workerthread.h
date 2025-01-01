#ifndef WORKERTHREAD_H
#define WORKERTHREAD_H
#include <QThread>
#include <QString>
#include <QMutex>

class WorkerThread : public QThread
{
    Q_OBJECT
    void run() Q_DECL_OVERRIDE;

public:
    WorkerThread(QObject *parent = 0): QThread(parent){}
    QMutex lock;
signals:
    void resultReady(const QString &s);
};
#endif // WORKERTHREAD_H
