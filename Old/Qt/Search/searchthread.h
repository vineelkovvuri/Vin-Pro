#ifndef SEARCHTHREAD_H
#define SEARCHTHREAD_H
#include <QThread>
#include <QString>
#include <QMutex>
#include <QDir>
#include <QDebug>
#include <QMessageBox>

class SearchThread : public QThread
{
    Q_OBJECT
    void run() Q_DECL_OVERRIDE;
    void Search(QDir &dir);
    QString fileName;
    bool stop;
    int count;
public:
    SearchThread(QObject *parent, const QString fileName);

public slots:
    void handleStopSearch(const bool stop);
signals:
    void postStatusText(const QString& status);
    void postResults(const QString& filePath);
};

#endif // SEARCHTHREAD_H
