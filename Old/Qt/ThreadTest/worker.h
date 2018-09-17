#ifndef WORKER_H
#define WORKER_H

#include <QDebug>

class Worker : public QObject
{
    Q_OBJECT

public slots:
    void doWork(const QString &parameter) {
        qDebug() << "Doing work" << endl;
        // ...
        emit resultReady(tr("Work done"));
    }

signals:
    void resultReady(const QString &result);
};
#endif // WORKER_H
