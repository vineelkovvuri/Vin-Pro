

#include "searchthread.h"

SearchThread::SearchThread(QObject *parent = 0, const QString fileName = ""): QThread(parent){
    this->fileName = fileName;
    this->stop = false;
    this->count = 0;
}

void SearchThread::run(){
    //qDebug()  << " Run method executing"  << endl;

    QDir root("C:\\");
    Search(root);
    /* expensive or blocking operation  */

}

void SearchThread::Search(QDir &dir){

    //qDebug() << dir.absolutePath() << endl;
    QFileInfoList files = dir.entryInfoList(QDir::Dirs | QDir::Files | QDir::NoDotAndDotDot);
    for (int i = 0; i < files.size() && !this->stop; i++) {
        if (files.at(i).isDir()) {
            QDir temp(files.at(i).absoluteFilePath());
            Search(temp);
            //qDebug() << "D " <<files.at(i).absoluteFilePath();
            emit postStatusText(QString("%1").arg(count++, -10).append(files.at(i).absoluteFilePath()));
            if (files.at(i).fileName() == fileName) {
                emit postResults(files.at(i).absoluteFilePath());
            }
        } else if (files.at(i).isFile()) {
            //qDebug() << "F " <<files.at(i).absoluteFilePath();
            emit postStatusText(QString("%1").arg(count++, -10).append(files.at(i).absoluteFilePath()));
            if (files.at(i).fileName() == fileName)
                emit postResults(files.at(i).absoluteFilePath());
        }
    }
    //qDebug() << "End"<< endl;
}
void SearchThread::handleStopSearch(const bool stop){
    this->stop = stop;
}
